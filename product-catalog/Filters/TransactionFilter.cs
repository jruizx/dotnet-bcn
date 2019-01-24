

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace product_catalog
{
    public class TransactionFilter : IAsyncActionFilter
    {
        private readonly ProductCatalogContext context;

        public TransactionFilter(ProductCatalogContext context)
        {
            this.context = context;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext executingContext, ActionExecutionDelegate next)
        {
            var executionStrategy = context.Database.CreateExecutionStrategy();

            await executionStrategy.ExecuteAsync(async () =>
            {
                var transactionAttribute = executingContext
                    .ActionDescriptor
                    .GetCustomAttributes<TransactionAttribute>()
                    .SingleOrDefault();

                if (transactionAttribute != null)
                {
                    context.Database.BeginTransaction();
                }

                var executedContext = await next();

                if (transactionAttribute != null)
                {
                    try
                    {

                        if (context.Database.CurrentTransaction != null)
                        {
                            if (executedContext.Exception == null)
                            {
                                context.SaveChanges();
                                context.Database.CurrentTransaction.Commit();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (context.Database.CurrentTransaction != null)
                            context.Database.CurrentTransaction.Rollback();
                        throw ex;
                    }
                    finally
                    {
                        context.Database.CurrentTransaction?.Dispose();
                    }
                }
            });
        }
    }
}