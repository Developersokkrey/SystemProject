using KEDI.Core.Premise.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using SystemProject.DataApp;
using static SystemProject.Model.EnumService.EnumServices;

namespace SystemProject.Repository.ServicesClass
{
    public class ServicesGeneratePrimaryKey
    {
        private readonly DataContext _dataContect;
        public ServicesGeneratePrimaryKey(IScopeFactory<DataContext> dataContext)
        {
            _dataContect = dataContext.GetService();
        }

        public string GeneratePrimaryKey(TableName tableName)
        {
            var keyTable = _dataContect.PRIMARYKEYS.FirstOrDefault(x => x.TableName == tableName) ?? new Models.Other.PrimaryKey();
            long keyNumber = long.Parse(keyTable.KeyNumber) + 1;
            keyTable.KeyNumber = Convert.ToString(keyNumber);
            //OCURE
            if (tableName == TableName.OCURE)
            {
                bool isValid = _dataContect.OCURE.Any(n => n.ID == keyTable.KeyNumber);
                if (isValid)
                {
                    keyNumber = long.Parse(_dataContect.OCURE.Max().ID) + 1;
                    keyTable.KeyNumber = Convert.ToString(keyNumber);
                }
            }
            //OUSR
            else if (tableName == TableName.OUSR)
            {
                bool isValid = _dataContect.OUSR.Any(n => n.ID == keyTable.KeyNumber);
                if (isValid)
                {
                    keyNumber = long.Parse(_dataContect.OUSR.Max().ID) + 1;
                    keyTable.KeyNumber = Convert.ToString(keyNumber);
                }
            }
            //COMP
            else if (tableName == TableName.COMP)
            {
                bool isValid = _dataContect.COMP.Any(n => n.ID == keyTable.KeyNumber);
                if (isValid)
                {
                    keyNumber = long.Parse(_dataContect.COMP.Max().ID) + 1;
                    keyTable.KeyNumber = Convert.ToString(keyNumber);
                }
            }
            //BRAN
            else if (tableName == TableName.BRAN)
            {
                bool isValid = _dataContect.BRAN.Any(n => n.ID == keyTable.KeyNumber);
                if (isValid)
                {
                    keyNumber = long.Parse(_dataContect.BRAN.Max().ID) + 1;
                    keyTable.KeyNumber = Convert.ToString(keyNumber);
                }
            }
            //BRINFO
            else if (tableName == TableName.BRINFO)
            {
                bool isValid = _dataContect.BRINFO.Any(n => n.ID == keyTable.KeyNumber);
                if (isValid)
                {
                    keyNumber = long.Parse(_dataContect.BRINFO.Max().ID) + 1;
                    keyTable.KeyNumber = Convert.ToString(keyNumber);
                }
            }
            //EXRATE
            else if (tableName == TableName.EXRATE)
            {
                bool isValid = _dataContect.EXRATE.Any(n => n.ID == keyTable.KeyNumber);
                if (isValid)
                {
                    keyNumber = long.Parse(_dataContect.EXRATE.Max().ID) + 1;
                    keyTable.KeyNumber = Convert.ToString(keyNumber);
                }
            }
            //ROLES
            else if (tableName == TableName.ROLES)
            {
                bool isValid = _dataContect.ROLES.Any(n => n.ID == keyTable.KeyNumber);
                if (isValid)
                {
                    keyNumber = long.Parse(_dataContect.EXRATE.Max().ID) + 1;
                    keyTable.KeyNumber = Convert.ToString(keyNumber);
                }
            }
            _dataContect.PRIMARYKEYS.Update(keyTable);
            _dataContect.SaveChanges();
            return keyTable.KeyNumber.ToString();
        }
        public async Task<bool> Test()
        {
           return await Task.FromResult(true);
        }
    }
}
