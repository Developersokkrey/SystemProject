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
        private readonly DataContext _dataContext;
        public ServicesGeneratePrimaryKey(IScopeFactory<DataContext> dataContext)
        {
            _dataContext = dataContext.GetService();
        }

        public string GeneratePrimaryKey(TableName tableName)
        {
            var keyTable = _dataContext.PRIMARYKEYS.FirstOrDefault(x => x.TableName == tableName) ?? new Models.Other.PrimaryKey();
            long keyNumber = long.Parse(keyTable.KeyNumber) + 1;
            keyTable.KeyNumber = Convert.ToString(keyNumber);
            //OCURE
            if (tableName == TableName.OCURE)
            {
                bool isValid = _dataContext.OCURE.Any(n => n.ID == keyTable.KeyNumber);
                if (isValid)
                {
                    keyNumber = long.Parse(_dataContext.OCURE.Max().ID) + 1;
                    keyTable.KeyNumber = Convert.ToString(keyNumber);
                }
            }
            //OUSR
            else if (tableName == TableName.OUSR)
            {
                bool isValid = _dataContext.OUSR.Any(n => n.ID == keyTable.KeyNumber);
                if (isValid)
                {
                    keyNumber = long.Parse(_dataContext.OUSR.Max().ID) + 1;
                    keyTable.KeyNumber = Convert.ToString(keyNumber);
                }
            }
            //COMP
            else if (tableName == TableName.COMP)
            {
                bool isValid = _dataContext.COMP.Any(n => n.ID == keyTable.KeyNumber);
                if (isValid)
                {
                    keyNumber = long.Parse(_dataContext.COMP.Max().ID) + 1;
                    keyTable.KeyNumber = Convert.ToString(keyNumber);
                }
            }
            //BRAN
            else if (tableName == TableName.BRAN)
            {
                bool isValid = _dataContext.BRAN.Any(n => n.ID == keyTable.KeyNumber);
                if (isValid)
                {
                    keyNumber = long.Parse(_dataContext.BRAN.Max().ID) + 1;
                    keyTable.KeyNumber = Convert.ToString(keyNumber);
                }
            }
            //BRINFO
            else if (tableName == TableName.BRINFO)
            {
                bool isValid = _dataContext.BRINFO.Any(n => n.ID == keyTable.KeyNumber);
                if (isValid)
                {
                    keyNumber = long.Parse(_dataContext.BRINFO.Max().ID) + 1;
                    keyTable.KeyNumber = Convert.ToString(keyNumber);
                }
            }
            //EXRATE
            else if (tableName == TableName.EXRATE)
            {
                bool isValid = _dataContext.EXRATE.Any(n => n.ID == keyTable.KeyNumber);
                if (isValid)
                {
                    keyNumber = long.Parse(_dataContext.EXRATE.Max().ID) + 1;
                    keyTable.KeyNumber = Convert.ToString(keyNumber);
                }
            }
            //ROLES
            else if (tableName == TableName.ROLES)
            {
                bool isValid = _dataContext.ROLES.Any(n => n.ID == keyTable.KeyNumber);
                if (isValid)
                {
                    keyNumber = long.Parse(_dataContext.ROLES.Max().ID) + 1;
                    keyTable.KeyNumber = Convert.ToString(keyNumber);
                }
            }
            //VENDOR
            else if (tableName == TableName.VENDOR)
            {
                bool isValid = _dataContext.VENDOR.Any(n => n.ID == keyTable.KeyNumber);
                if (isValid)
                {
                    keyNumber = long.Parse(_dataContext.VENDOR.Max().ID) + 1;
                    keyTable.KeyNumber = Convert.ToString(keyNumber);
                }
            }
            //CUSMER
            else if (tableName == TableName.CUSMER)
            {
                bool isValid = _dataContext.CUSMER.Any(n => n.ID == keyTable.KeyNumber);
                if (isValid)
                {
                    keyNumber = long.Parse(_dataContext.CUSMER.Max().ID) + 1;
                    keyTable.KeyNumber = Convert.ToString(keyNumber);
                }
            }
            //DEPMENT
            else if(tableName == TableName.DEPMENT)
            {
                bool isValid = _dataContext.DEPMENT.Any(n => n.ID == keyTable.KeyNumber);
                if (isValid)
                {
                    keyNumber = long.Parse(_dataContext.DEPMENT.Max().ID) + 1;
                    keyTable.KeyNumber = Convert.ToString(keyNumber);
                }
            }
            _dataContext.PRIMARYKEYS.Update(keyTable);
            _dataContext.SaveChanges();
            return keyTable.KeyNumber.ToString();
        }
        public async Task<bool> Test()
        {
           return await Task.FromResult(true);
        }
    }
}
