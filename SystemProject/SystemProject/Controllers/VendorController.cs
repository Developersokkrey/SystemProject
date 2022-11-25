using KSystemProject.References;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using SystemProject.DataApp;
using SystemProject.Models.Branch;
using SystemProject.Models.BusinessPartner;
using SystemProject.Repository.ServicesClass;

namespace SystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly ServicesInsertOrUpdate _servicesInsertOrUpdate;
        public VendorController(DataContext dataContext, ServicesInsertOrUpdate servicesInsertOrUpdate)
        {
            _dataContext = dataContext;
            _servicesInsertOrUpdate = servicesInsertOrUpdate;
        }
        [HttpGet("GetVendor")]
        public async Task<IActionResult> GetVendor()
        {
            return Ok(await _dataContext.VENDOR.ToListAsync());
        }
        [HttpGet("GetVendorEdit")]
        public async Task<IActionResult> GetVendorEdit(string vendorID)
        {
            if (vendorID == "0")
            {
                Vendor vendorBlank = new Vendor();
                return Ok(vendorBlank);
            }
            else
            {                           
                return Ok(await _dataContext.VENDOR.FirstOrDefaultAsync(w => w.ID == vendorID));
            }
        }
        [HttpPost("CreateVendor/vendor")]
        public async Task<IActionResult> CreateVendor([FromBody] Vendor vendor)
        {
            ModelMessage msg = new();
            ValidateSummary(vendor);
            using (var t = _dataContext.Database.BeginTransaction())
            {
                if (ModelState.IsValid)
                {
                    await _servicesInsertOrUpdate.InsertOrUpdateVENDOR(vendor);
                    t.Commit();
                    ModelState.AddModelError("success", "Vendor save successfully./រក្សាទុកឈ្មោះអ្នកប្រើប្រាស់ដោយជោគជ័យ។");
                    msg.Approve();
                }
            }
            return Ok(await Task.FromResult(msg.Bind(ModelState)));
        }
        private void ValidateSummary(Vendor vendor)
        {
            if (string.IsNullOrWhiteSpace(vendor.Code) || vendor.Name1.Length < 4)
            {
                ModelState.AddModelError("Code", "Code is required 4 charater !/ឈ្មោះអ្នកប្រើត្រូវបានទាមទារ 4 តួអក្សរ !");
            }
        }
    }
}
