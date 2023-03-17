using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemProject.DataApp;
using SystemProject.Models.UserAccount;
using SystemProject.Repository.ServicesClass;
using static SystemProject.Model.EnumService.EnumServices;

namespace SystemProject.Repository
{
    public interface IDepartment
    {
        public Task<int> AddDepartment(Department department);
        public Task<List<Department>> GetDepartmentListAsync(); 
        public Task<IEnumerable<Department>> GetDepartmentByIdAsync(string departID);
    }
    public class DepartmentRepo : IDepartment
    {
        private readonly DataContext _dataContext;
        private readonly ServicesGeneratePrimaryKey _generatePrimaryKey;
        public DepartmentRepo(DataContext dataContext, ServicesGeneratePrimaryKey servicesGeneratePrimary)
        {
            _dataContext = dataContext;
            _generatePrimaryKey = servicesGeneratePrimary;
        }
        public async Task<int> AddDepartment(Department department)
        {
            department.ComID = "1";
            department.ID = _generatePrimaryKey.GeneratePrimaryKey(TableName.DEPMENT);
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@ID", department.ID));
            parameter.Add(new SqlParameter("@Code", department.Code));
            parameter.Add(new SqlParameter("@Name", department.Name));
            parameter.Add(new SqlParameter("@ComID", department.ComID));
            parameter.Add(new SqlParameter("@Enable", department.Enable));
            var result = await Task.Run(() => _dataContext.Database
            .ExecuteSqlRawAsync(@"exec AddDepartment @ID,@Code,@Name,@ComID,@Enable", parameter.ToArray()));
            return result;
        }

        public async Task<IEnumerable<Department>> GetDepartmentByIdAsync(string departID)
        {
            var param = new SqlParameter("@DepartID", departID);
            var dapartDetails = await Task.Run(() => _dataContext.DEPMENT
            .FromSqlRaw(@"exec GetDepartmentByID @DepartID", param).ToListAsync());
            return dapartDetails;
        }

        public async Task<List<Department>> GetDepartmentListAsync()
        {
            return await _dataContext.DEPMENT.FromSqlRaw<Department>("GetDepartmentList").ToListAsync();
        }
    }
}
