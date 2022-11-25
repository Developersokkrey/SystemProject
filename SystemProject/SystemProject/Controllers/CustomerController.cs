using KSystemProject.References;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SystemProject.DataApp;
using SystemProject.Models.BusinessPartner;
using SystemProject.Repository.ServicesClass;

namespace SystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly ServicesInsertOrUpdate _servicesInsertOrUpdate;
        public CustomerController(DataContext dataContext, ServicesInsertOrUpdate servicesInsertOrUpdate)
        {
            _dataContext = dataContext;
            _servicesInsertOrUpdate = servicesInsertOrUpdate;
        }
        [HttpGet("GetCustomer")]
        public async Task<IActionResult> GetCustomer()
        {
            return Ok(await _dataContext.CUSMER.ToListAsync());
        }
        [HttpGet("GetCustomerEdit")]
        public async Task<IActionResult> GetCustomerEdit(string customerID)
        {
            if (customerID == "0")
            {
                Customer customerBlank = new Customer();
                return Ok(customerBlank);
            }
            else
            {
                return Ok(await _dataContext.CUSMER.FirstOrDefaultAsync(w => w.ID == customerID));
            }
        }
        [HttpPost("CreateCustomer/customer")]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            ModelMessage msg = new();
            ValidateSummary(customer);
            using (var t = _dataContext.Database.BeginTransaction())
            {
                if (ModelState.IsValid)
                {
                    await _servicesInsertOrUpdate.InsertOrUpdateCUSMER(customer);
                    t.Commit();
                    ModelState.AddModelError("success", "Vendor save successfully./រក្សាទុកឈ្មោះអ្នកប្រើប្រាស់ដោយជោគជ័យ។");
                    msg.Approve();
                }
            }
            return Ok(await Task.FromResult(msg.Bind(ModelState)));
        }
        private void ValidateSummary(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.Code) || customer.Name1.Length < 4)
            {
                ModelState.AddModelError("Code", "Code is required 4 charater !/ឈ្មោះអ្នកប្រើត្រូវបានទាមទារ 4 តួអក្សរ !");
            }
        }
    }
}
