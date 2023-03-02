using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql.Replication.PgOutput.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SystemProject.DataApp;
using SystemProject.Models.UserAccount;

namespace SystemProject.Repository.ServicesClass
{
    public interface IUserAccount{
        IEnumerable<Dictionary<string, object>> ToDictionaries();
    }
    public class UserAccountRepo : IUserAccount
    {
        private readonly DataContext _dataContext;
        private readonly SqlConnection _sqlConn;
        public UserAccountRepo(DataContext dataContext, IConfiguration config){
            _dataContext = dataContext;
            _sqlConn = new SqlConnection(config["UsersConnection:ConnectionString"]);
        }

        public IEnumerable<Dictionary<string, object>> ToDictionaries()
        {
            var command = new SqlCommand("GetAllUserAccount", _sqlConn);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var dict = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dict.TryAdd(reader.GetName(i), reader.GetValue(i));
                }

                yield return dict;
            }
        }

        public IEnumerable<T> ToList<T>(string procedure) where T : class, new()
        {
            var command = new SqlCommand(procedure, _sqlConn);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var obj = new T();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    PropertyInfo propInfo = typeof(T).GetProperty(reader.GetName(i));
                    if(propInfo == null) { continue; }
                    propInfo.SetValue(obj, reader.GetValue(i), null);                   
                }
                yield return obj;
            }
        }
    }
}