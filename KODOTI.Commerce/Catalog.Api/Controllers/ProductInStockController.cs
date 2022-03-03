using Catalog.Service.EventHandlers.Commands;
using Catalog.Service.Quieries;
using Catalog.Service.Quieries.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("stocks")]
    public class ProductInStockController : ControllerBase
    {
        private readonly ILogger<ProductInStockController> _logger;
        private readonly IMediator _mediator;

        public ProductInStockController(
            ILogger<ProductInStockController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }       

        [HttpPut]
        public async Task<IActionResult> UpateStock(ProductInStockUpdateCommand command)
        {
            await _mediator.Publish(command);
            return NoContent();
        }


    }
}
