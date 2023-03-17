using KSystemProject.References;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using SystemProject.DataApp;
using SystemProject.Models.Branch;
using SystemProject.Models.UserAccount;

namespace SystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public DepartmentController(DataContext dataContext) { _dataContext = dataContext; }
        [HttpGet("GetDepartmentEdit")]
        public IActionResult GetDepartmentEdit(string depmentid)
        {
            if (depmentid == "0")
            {
                Department department = new Department();
                return Ok(department);
            }
            else
            {
                var department = _dataContext.DEPMENT.Where(w=>w.ID == depmentid);
                return Ok(department);
            }
        }
        [HttpGet("GetAllDepartment")]
        public IActionResult GetAllDepartment()
        {
            return Ok(_dataContext.DEPMENT);
        }
        [HttpPost("CreateDepartment/department")]
        public async Task<IActionResult> CreateDepartment([FromBody] Department department)
        {
            ModelMessage msg = new ModelMessage();
            ValidateSummary(department);
            using (var t = await _dataContext.Database.BeginTransactionAsync())
            {
                if (ModelState.IsValid)
                {
                    t.Commit();
                    ModelState.AddModelError("success", "Department save successfully./រក្សាទុកឈ្មោះអ្នកប្រើប្រាស់ដោយជោគជ័យ។");
                    msg.Approve();
                }
                return Ok(await Task.FromResult(msg.Bind(ModelState)));
            }
        }
        private void ValidateSummary(Department department)
        {
            if (string.IsNullOrWhiteSpace(department.Name) || department.Name.Length < 5)
            {
                ModelState.AddModelError("Name", "Name is required 5 charater !/ឈ្មោះអ្នកប្រើត្រូវបានទាមទារ 5 តួអក្សរ !");
            }
        }
    }
}
