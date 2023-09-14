using InvoiceAutomation.EF;
using InvoiceAutomation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using System.Collections.ObjectModel;

namespace InvoiceAutomation.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ApplicationDbContext _db;

        protected readonly DbSet<Invoice> _dbSet;

        public List<Invoice> ListOfProducts = new List<Invoice>();

        public InvoiceController(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
            _dbSet = _db.Set<Invoice>();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _dbSet.FindAsync(new object[] { id });

            return View("GetByIdAsync",result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _dbSet.AsNoTracking().ToListAsync();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAsync(int id)
        {
            var model = await _dbSet.FindAsync(new object[] { id });

            return View("UpdateAsync",model);
        }

        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var invoice = await _dbSet.FindAsync(new object[] { id });

            _dbSet.Remove(invoice);

            return RedirectToAction("Index");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Invoice invoice)
        {
            _dbSet.Update(invoice);

            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] List<Invoice> invoiceList)
        {
            try
            {
                foreach (var invoice in invoiceList)
                {
                    await _dbSet.AddAsync(invoice);
                }
                
                await _db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
