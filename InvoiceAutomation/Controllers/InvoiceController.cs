using InvoiceAutomation.EF;
using InvoiceAutomation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xceed.Document.NET;
using Xceed.Words.NET;
using Table = Xceed.Document.NET.Table;

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

        public async Task<IActionResult> DownloadInvoice([FromBody] List<Invoice> invoiceList)
        {
            string[] columnHeaders1 = { "№ Документа", "Дата", "Шифр отправителя", "Шифр получателя" };
            string[] columnHeaders2 = { "№", "Шифр затрат", "Наименование", "Номенклатурный номер", "Ед. изм", "Кол-во", "Цена", "Сумма" };
            string[] columnHeaders3 = { "Разрешил", "Контролёр", "Сдал", "Принял" };

            float[] columnWidths1 = { 88.3881f, 138.5f, 138.5f, 191.233499f };
            float[] columnWidths2 = { 22.6636f, 65.7245328f, 138.5f, 138.5f, 33.995448f, 32.578971f, 62.32954f, 62.32954f };
            float[] columnWidths3 = { 88.3881f, 138.5f, 138.5f, 191.233499f };

            var doc = DocX.Create("Documents/Invoice.docx");

            Table table1 = doc.AddTable(1, 4);
            table1.Alignment = Alignment.center;

            table1.Design = TableDesign.TableGrid;


            for (int i = 0; i < columnHeaders1.Length; i++)
            {
                table1.Rows[0].Cells[i].Paragraphs.First().Append(columnHeaders1[i]).Bold();
                table1.SetColumnWidth(i, columnWidths1[i]);
            }
            Row row1 = table1.InsertRow();

            // Заполнение ячеек данными из объекта InvoiceItem
            row1.Cells[0].Paragraphs.First().Append(invoiceList[0].Document_Number.ToString());
            row1.Cells[1].Paragraphs.First().Append(invoiceList[0].Data_Of_Creation.Date.ToString("dd.MM.yyyy"));
            row1.Cells[2].Paragraphs.First().Append(invoiceList[0].Sender_Code);
            row1.Cells[3].Paragraphs.First().Append(invoiceList[0].Recipient_Code);

            doc.InsertTable(table1);

            doc.InsertParagraph();
            //Вторая таблица


            Table table2 = doc.AddTable(1, 8);

            table2.Alignment = Alignment.center;

            table2.Design = TableDesign.TableGrid;

            for (int i = 0; i < columnHeaders2.Length; i++)
            {
                table2.Rows[0].Cells[i].Paragraphs.First().Append(columnHeaders2[i]).Bold();
                table2.SetColumnWidth(i, columnWidths2[i]);
            }

            var serialNumber = 0;
            // Добавление данных из базы данных в таблицу
            foreach (var item in invoiceList)
            {
                // Создание новой строки в таблице
                Row row2 = table2.InsertRow();

                serialNumber++;

                var sum = item.Quantity * item.Price;
                // Заполнение ячеек данными из объекта InvoiceItem
                row2.Cells[0].Paragraphs.First().Append(serialNumber.ToString());
                row2.Cells[1].Paragraphs.First().Append(item.Cost_Code.ToString());
                row2.Cells[2].Paragraphs.First().Append(item.Name);
                row2.Cells[3].Paragraphs.First().Append(item.Item_Number);
                row2.Cells[4].Paragraphs.First().Append(item.Unit);
                row2.Cells[5].Paragraphs.First().Append(item.Quantity.ToString());
                row2.Cells[6].Paragraphs.First().Append(item.Price.ToString());
                row2.Cells[7].Paragraphs.First().Append(sum.ToString());
            }

            doc.InsertTable(table2);

            doc.InsertParagraph();

            //Третья таблица
            Table table3 = doc.AddTable(1, 4);
            table3.Alignment = Alignment.center;

            table3.Design = TableDesign.TableGrid;


            for (int i = 0; i < columnHeaders3.Length; i++)
            {
                table3.Rows[0].Cells[i].Paragraphs.First().Append(columnHeaders3[i]).Bold();
                table3.SetColumnWidth(i, columnWidths3[i]);
            }
            Row row3 = table3.InsertRow();

            // Заполнение ячеек данными из объекта InvoiceItem
            row3.Cells[0].Paragraphs.First().Append(invoiceList[0].Allowed.ToString());
            row3.Cells[1].Paragraphs.First().Append(invoiceList[0].Controller.ToString());
            row3.Cells[2].Paragraphs.First().Append(invoiceList[0].Passed.ToString());
            row3.Cells[3].Paragraphs.First().Append(invoiceList[0].Accepted.ToString());

            doc.InsertTable(table3);

            using (MemoryStream ms = new MemoryStream())
            {
                // Сохраняем документ в поток
                doc.SaveAs(ms);

                // Отправляем файл для скачивания
                byte[] fileBytes = ms.ToArray();
                return File(fileBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Invoice.docx");
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAllAsync()
        //{
        //    var result = await _dbSet.AsNoTracking().ToListAsync();

        //    return View(result);
        //}

        //[HttpGet]
        //public async Task<IActionResult> UpdateAsync(int id)
        //{
        //    var model = await _dbSet.FindAsync(new object[] { id });

        //    return View("UpdateAsync", model);
        //}

        //public async Task<IActionResult> DeleteByIdAsync(int id)
        //{
        //    var invoice = await _dbSet.FindAsync(new object[] { id });

        //    _dbSet.Remove(invoice);

        //    return RedirectToAction("Index");
        //}

        //[HttpPut]
        //public async Task<IActionResult> UpdateAsync(Invoice invoice)
        //{
        //    _dbSet.Update(invoice);

        //    await _db.SaveChangesAsync();

        //    return RedirectToAction("Index");
        //}

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
