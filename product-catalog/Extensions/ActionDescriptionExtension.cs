using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace product_catalog
{
    public static class ActionDescriptorExtensions
    {
        public static IEnumerable<T> GetCustomAttributes<T>(this ActionDescriptor actionDescriptor) where T : Attribute
        {
            var controllerActionDescriptor = actionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor != null)
            {
                return controllerActionDescriptor.MethodInfo.GetCustomAttributes<T>();
            }

            return Enumerable.Empty<T>();
        }
    }
}