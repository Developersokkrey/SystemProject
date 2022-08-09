using KSystemProject.References;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using SystemProject.DataApp;
using SystemProject.Models.Branch;
using SystemProject.Repository.ServicesClass;

namespace SystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]     
    public class BranchController : ControllerBase
    {
        private readonly DataContext _dataContect;
        private readonly ServicesInsertOrUpdate _servicesInsertOrUpdate;
        public BranchController(DataContext dataContext, ServicesInsertOrUpdate servicesInsertOrUpdate)
        {
            _dataContect = dataContext;
            _servicesInsertOrUpdate = servicesInsertOrUpdate;
        }
        [HttpPost("CreateBranch/branch")]
        public async Task<IActionResult> CreateBranch([FromBody] Branch branch)
        {
            ModelMessage msg = new();
            ValidateSummary(branch);
            using (var t = _dataContect.Database.BeginTransaction())
            {
                if (ModelState.IsValid)
                {
                    _servicesInsertOrUpdate.InsertOrUpdateBRAN(branch);
                    t.Commit();
                    ModelState.AddModelError("success", "Username save successfully./រក្សាទុកឈ្មោះអ្នកប្រើប្រាស់ដោយជោគជ័យ។");
                    msg.Approve();
                }
            }
             return Ok(await Task.FromResult(msg.Bind(ModelState)));
        }
        [HttpGet("GetBranch")]
        public IActionResult GetBranch()
        {
            var bran = from b in _dataContect.BRAN
                       select new
                       {
                           ID = b.ID,
                           title = b.Name,
                           Value = b.ID,
                           Name = b.Name,
                           Location = b.Location,
                           Address = b.Address,
                       };
            return Ok(bran);
        }
        [HttpGet("GetBranchEdit")]
        public IActionResult GetBranchEdit(string branid)
        {  
            if(branid == "0")
            {
               Branch branch = new Branch();
               return Ok(branch);
            }
            else
            {
                return Ok(_dataContect.BRAN.FirstOrDefault(w => w.ID == branid));
            }            
        }
        private void ValidateSummary(Branch branch)
        {
            if (string.IsNullOrWhiteSpace(branch.Name) || branch.Name.Length < 5)
            {
                ModelState.AddModelError("Name", "Name is required 5 charater !/ឈ្មោះអ្នកប្រើត្រូវបានទាមទារ 5 តួអក្សរ !");
            }              
        }
    }
}
