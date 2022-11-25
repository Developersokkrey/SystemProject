using KEDI.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using SystemProject.DataApp;
using SystemProject.Models.Branch;
using SystemProject.Models.BusinessPartner;
using SystemProject.Models.Company;
using SystemProject.Models.UserAccount;
using static SystemProject.Model.EnumService.EnumServices;

namespace SystemProject.Repository.ServicesClass
{
    public class ServicesInsertOrUpdate
    {
        private readonly DataContext _dataContext;
        private readonly ServicesGeneratePrimaryKey _servicesGeneratePrimaryKey;
        private readonly SecurityManager _securityManager;
        public ServicesInsertOrUpdate(DataContext dataContext, ServicesGeneratePrimaryKey servicesGeneratePrimaryKey, SecurityManager securityManager)
        {
            _dataContext = dataContext;
            _servicesGeneratePrimaryKey = servicesGeneratePrimaryKey;   
            _securityManager = securityManager;
        }
        #region OUSR
        public async Task InsertOrUpdateOCURE(UserAccount userAccount)
        {
            if(userAccount.ID == null)
            {
                _securityManager.TryComputeHash(userAccount.Password, out string _hash, out string _salt);
                var hash = $"{_hash}.{_salt}";
                userAccount.ID = _servicesGeneratePrimaryKey.GeneratePrimaryKey(TableName.OUSR);
                userAccount.PasswordHash = hash;
                userAccount.ComID = _dataContext.COMP.FirstOrDefault().ID;
                await _dataContext.OUSR.AddAsync(userAccount);
            }
            else
            {
                _securityManager.TryComputeHash(userAccount.Password, out string _hash, out string _salt);
                var hash = $"{_hash}.{_salt}";
                userAccount.PasswordHash = hash;
                _dataContext.OUSR.Update(userAccount);
            }
            await _dataContext.SaveChangesAsync();
        }
        #endregion         
        #region OCURE
        public async Task InsertOrUpdateOCURE(Currency currency)
        {
            currency.ID = _servicesGeneratePrimaryKey.GeneratePrimaryKey(TableName.OCURE);
            await _dataContext.AddAsync(currency);
            await _dataContext.SaveChangesAsync();
        }
        #endregion
        #region COMP
        public async Task InsertOrUpdateCOMP(Company company,bool New)
        {
            if (New)
            {
                company.ID = _servicesGeneratePrimaryKey.GeneratePrimaryKey(TableName.COMP);    
                await _dataContext.AddAsync(company);                
            }
            else
            {
                _dataContext.Update(company);                 
            }
            await _dataContext.SaveChangesAsync();
        }
        #endregion
        #region BRAN
        public async Task InsertOrUpdateBRAN(Branch branch)
        {
             if(branch.ID == "0" || branch.ID == null)
            {
                branch.ID = _servicesGeneratePrimaryKey.GeneratePrimaryKey(TableName.BRAN);
                await _dataContext.AddAsync(branch);
            }
            else
            {
                _dataContext.Update(branch);
            }
            await _dataContext.SaveChangesAsync();
        }
        #endregion
        #region BRINFO
        #endregion
        #region EXRATE
        public async Task InsertOrUpdateEXRATE(string currency,bool New)
        {             
            if (New)
            {
                ExchangeRate exchangeRate = new ExchangeRate();
                exchangeRate.ID = _servicesGeneratePrimaryKey.GeneratePrimaryKey(TableName.EXRATE);
                exchangeRate.CurrID = currency;
                exchangeRate.Rate1 = 0;
                exchangeRate.Rate2 = 0;
                await _dataContext.EXRATE.AddAsync(exchangeRate);
            }
            else
            {
                var exchangeRate = await _dataContext.EXRATE.FirstOrDefaultAsync(w=>w.CurrID == currency)?? new ExchangeRate();
                if (exchangeRate.Rate1 != 0)
                {
                    exchangeRate.Rate2 = 1 / exchangeRate.Rate1;
                }
                _dataContext.EXRATE.Update(exchangeRate);
            }             
            await _dataContext.SaveChangesAsync();
        }
        #endregion
        #region ROLES
        #endregion
        #region ROLEPRIVI
        #endregion
        #region FUNCTI
        #endregion
        #region USERPRIVI
        #endregion
        #region VENDOR
        public async Task InsertOrUpdateVENDOR(Vendor vendor)
        {
            if(vendor.ID == null)
            {
                vendor.ID = _servicesGeneratePrimaryKey.GeneratePrimaryKey(TableName.VENDOR);
                await _dataContext.AddAsync(vendor);
            }
            else
            {
                _dataContext.Update(vendor);
            }
            await _dataContext.SaveChangesAsync();
        }
        #endregion
        #region CUSMER
        public async Task InsertOrUpdateCUSMER(Customer customer)
        {
            if (customer.ID == null)
            {
                customer.ID = _servicesGeneratePrimaryKey.GeneratePrimaryKey(TableName.CUSMER);
                await _dataContext.AddAsync(customer);
            }
            else
            {
                _dataContext.Update(customer);
            }
            await _dataContext.SaveChangesAsync();
        }
        #endregion
    }
}
