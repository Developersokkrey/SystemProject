using KSystemProject.References;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemProject.DataApp;
using SystemProject.Models.Branch;
using SystemProject.Models.UserAccount;
using SystemProject.Repository;

namespace SystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly DepartmentRepo _departmentRepo;
        public DepartmentController(DataContext dataContext, DepartmentRepo departmentRepo) 
        { 
            _dataContext = dataContext;
            _departmentRepo = departmentRepo;
         }
        [HttpGet("GetDepartmentEdit")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDepartmentEdit(string depmentid)
        {
            Department department = new Department();
            if (depmentid == "0")
            {
                return Ok(department);
            }
            else
            {
                var depart = await _dataContext.DEPMENT.FirstOrDefaultAsync(w => w.ID == depmentid)?? new Department();
                department.ID = depart.ID;
                department.Code = depart.Code;
                department.Name = depart.Name;
                department.Enable= depart.Enable;                
            }
            return Ok(department);
        }
        [HttpGet("GetDepartmentList")]
        public async Task<IActionResult> GetDepartmentList()
        {
            try
            {
                return Ok(await _departmentRepo.GetDepartmentListAsync());
            }
            catch
            {
                throw;
            }            
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
                    await _departmentRepo.AddDepartment(department);
                    t.Commit();
                    ModelState.AddModelError("success", "Department save successfully./នាយកដ្ឋានរក្សាទុកដោយជោគជ័យ !");
                    msg.Approve();
                }
                return Ok(await Task.FromResult(msg.Bind(ModelState)));
            }
        }
        private void ValidateSummary(Department department)
        {
            if (string.IsNullOrWhiteSpace(department.Code))
            {
                ModelState.AddModelError("Code", "Code is required Code required​​ !/លេខកូដត្រូវបានទាមទារ !");
            }
            else if(department.Code == _dataContext.DEPMENT.FirstOrDefault(w => w.ID != department.ID).Code)
            {
                ModelState.AddModelError("Code", "Code is already exists !/កូដមានរួចហើយ !");
            }
            if (string.IsNullOrWhiteSpace(department.Name))
            {
                ModelState.AddModelError("Name", "Name is required !/ឈ្មោះត្រូវបានទាមទារ !");
            }
        }
        [HttpGet("getdepartmentbyid")]
        public async Task<IEnumerable<Department>> GetDepartmentByIdAsync(string departID)
        {
            try
            {
                var response = await _departmentRepo.GetDepartmentByIdAsync(departID);
                if(response == null) { return null; }
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
