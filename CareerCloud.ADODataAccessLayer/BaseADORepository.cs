using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public abstract class BaseADORepository<T> where T : IPoco
    {
        protected readonly string _connStr ;

        public abstract IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);

        public BaseADORepository()
        {
            _connStr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        }

        public IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> pocos = GetAll().AsQueryable();
            return pocos.Where(where).ToList();
        }

        public T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public virtual void Remove(params T[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn
                };
                foreach (T item in items)
                {

                    TableAttribute attribute =
                        (TableAttribute)Attribute.GetCustomAttribute(item.GetType(), typeof(TableAttribute));
                    string tblName = attribute.Name;

                    cmd.CommandText = $"DELETE {tblName} WHERE ID = @ID";
                    cmd.Parameters.AddWithValue("@ID", item.Id);
                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        public virtual void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

    }
}
