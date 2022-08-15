using KEDI.Core.Repository;
using System.Linq;
using SystemProject.DataApp;
using SystemProject.Models.Branch;
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
        public void InsertOrUpdateOCURE(UserAccount userAccount)
        {
            if(userAccount.ID == null)
            {
                _securityManager.TryComputeHash(userAccount.Password, out string _hash, out string _salt);
                var hash = $"{_hash}.{_salt}";
                userAccount.ID = _servicesGeneratePrimaryKey.GeneratePrimaryKey(TableName.OUSR);
                userAccount.PasswordHash = hash;
                userAccount.ComID = _dataContext.COMP.FirstOrDefault().ID;
                _dataContext.OUSR.Add(userAccount);
            }
            else
            {
                _securityManager.TryComputeHash(userAccount.Password, out string _hash, out string _salt);
                var hash = $"{_hash}.{_salt}";
                userAccount.PasswordHash = hash;
                _dataContext.OUSR.Update(userAccount);
            }
            _dataContext.SaveChanges();
        }
        #endregion         
        #region OCURE
        public void InsertOrUpdateOCURE(Currency currency)
        {
            currency.ID = _servicesGeneratePrimaryKey.GeneratePrimaryKey(TableName.OCURE);
            _dataContext.Add(currency);
            _dataContext.SaveChanges();
        }
        #endregion
        #region COMP
        public void InsertOrUpdateCOMP(Company company,bool New)
        {
            if (New)
            {
                company.ID = _servicesGeneratePrimaryKey.GeneratePrimaryKey(TableName.COMP);    
                _dataContext.Add(company);                
            }
            else
            {
                _dataContext.Update(company);                 
            }
            _dataContext.SaveChanges();
        }
        #endregion
        #region BRAN
        public void InsertOrUpdateBRAN(Branch branch)
        {
             if(branch.ID == "0" || branch.ID == null)
            {
                branch.ID = _servicesGeneratePrimaryKey.GeneratePrimaryKey(TableName.BRAN);
                _dataContext.Add(branch);
            }
            else
            {
                _dataContext.Update(branch);
            }
            _dataContext.SaveChanges();
        }
        #endregion
        #region BRINFO
        #endregion
        #region EXRATE
        public void InsertOrUpdateEXRATE(string currency,bool New)
        {             
            if (New)
            {
                ExchangeRate exchangeRate = new ExchangeRate();
                exchangeRate.ID = _servicesGeneratePrimaryKey.GeneratePrimaryKey(TableName.EXRATE);
                exchangeRate.CurrID = currency;
                exchangeRate.Rate1 = 0;
                exchangeRate.Rate2 = 0;
                _dataContext.EXRATE.Add(exchangeRate);
            }
            else
            {
                var exchangeRate = _dataContext.EXRATE.FirstOrDefault(w=>w.CurrID == currency)?? new ExchangeRate();
                if (exchangeRate.Rate1 != 0)
                {
                    exchangeRate.Rate2 = 1 / exchangeRate.Rate1;
                }
                _dataContext.EXRATE.Update(exchangeRate);
            }             
            _dataContext.SaveChanges();
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

    }
}
