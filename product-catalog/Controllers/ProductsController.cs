using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace product_catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public ProductsController(IMapper mapper, IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        // GET api/products
        [HttpGet]
        public ActionResult<ProductDTO[]> Get()
        {
            var products = productRepository
                .GetAll()
                .ToArray();

            return Ok(mapper.Map<ProductDTO[]>(products));
        }

        // POST api/products
        [HttpPost]
        [Transaction]
        public ActionResult<ProductDTO> Post([FromBody]ProductDTO product)
        {
            var newProduct = Product
                .Create(product.Name, product.Description, product.Image);

            productRepository.Add(newProduct);

            return Ok(mapper.Map<ProductDTO>(newProduct));
        }
    }
}
