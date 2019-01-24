using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IOrderRepository orderRepository;

        public OrdersController(IMapper mapper, IOrderRepository orderRepository)
        {
            this.mapper = mapper;
            this.orderRepository = orderRepository;
        }

        // GET api/orders
        [HttpGet]
        public ActionResult<OrderDTO[]> Get()
        {
            var orders = orderRepository
                .GetAll()
                .ToArray();

            return Ok(mapper.Map<OrderDTO[]>(orders));
        }

        // POST api/orders
        [HttpPost]
        public ActionResult<OrderDTO> Post([FromBody]OrderDTO order)
        {
            var newOrder = Order
                .Create(Product.Create(order.ProductId, order.ProductName), order.Amount);

            orderRepository.Add(newOrder);

            return Ok(mapper.Map<OrderDTO>(newOrder));
        }
    }
}
