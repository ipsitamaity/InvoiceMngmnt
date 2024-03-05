using INVOICE_APP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using INVOICE_APP.Repository.Interfaces;

namespace INVOICE_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceItemController : ControllerBase
    {
        private readonly IInvoiceItems _invoiceItemsRepository;
        public InvoiceItemController(IInvoiceItems invoiceItemsRepository)
        {
            _invoiceItemsRepository = invoiceItemsRepository;
        }
        [HttpGet]
        public IActionResult GetInvoiceItems([FromQuery] int invoiceID)
        {
            IEnumerable<InvoiceItem> invoiceItems = _invoiceItemsRepository.GetAllInvoiceItems(invoiceID);
            return Ok(invoiceItems);
        }
    }
}
