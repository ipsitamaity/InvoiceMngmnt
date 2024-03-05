using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using INVOICE_APP.Models;
using INVOICE_APP.Repository.Interfaces;

namespace INVOICE_APP.Controllers
{
    [Route("api/Invoices")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoices _invoicesRepository;
        public InvoicesController(IInvoices invoicesRepository)
        {
            _invoicesRepository = invoicesRepository;

        }
        [HttpGet]
        public IActionResult GetAllInvoices()
        {
          
            IEnumerable<Invoice> invoices= _invoicesRepository.GetAllInvoices();
            return Ok(invoices);
        }
        [HttpPost]
        public IActionResult Post( [FromBody] Invoices_view invoice)
        {
            Console.WriteLine("within controller");
            Console.WriteLine(invoice);

            if (invoice == null)
            {
                return BadRequest("Invoice data is missing.");
            }
         
            // Call the repository to add the invoice
            _invoicesRepository.AddInvoice(invoice);
            return Ok("Invoice added successfully.");
        }
        [HttpPut]
        public IActionResult UpdateInvoice([FromBody]Invoices_view invoice)
        {
            if (invoice == null)
            {
                return BadRequest("Invoice data is missing.");
            }
            // Call the repository to update the invoice
            _invoicesRepository.UpdateInvoice(invoice);
            return Ok("Invoice updated successfully.");
        }
    }
}

