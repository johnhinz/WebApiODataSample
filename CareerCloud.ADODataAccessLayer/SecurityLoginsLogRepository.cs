using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System.Data;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityLoginsLogRepository : BaseADORepository<SecurityLoginsLogPoco>, IDataRepository<SecurityLoginsLogPoco>
    {
        public void Add(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityLoginsLogPoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Security_Logins_Log]
                               ([Id],[Is_Succesful],[Login], [Logon_Date],[Source_IP])
                         VALUES
                               (@Id,@Is_Succesful,@Login,@Logon_Date,@Source_IP)";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Is_Succesful", item.IsSuccesful);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Logon_Date", item.LogonDate);
                    cmd.Parameters.AddWithValue("@Source_IP", item.SourceIP);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public override IList<SecurityLoginsLogPoco> GetAll(params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 120;
                cmd.Connection = conn;
                cmd.CommandText = "Select * from Security_Logins_Log";
                SqlDataAdapter dadapter = new SqlDataAdapter();
                dadapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dadapter.Fill(ds);
                return ds.Tables[0].AsEnumerable().Select(dr => new SecurityLoginsLogPoco()
                {
                    Id = dr.Field<Guid>("Id"),
                    IsSuccesful = dr.Field<bool>("Is_Succesful"),
                    Login = dr.Field<Guid>("Login"),
                    LogonDate = dr.Field<DateTime>("Logon_Date"),
                    SourceIP = dr.Field<string>("Source_IP"),
                }).ToList();
            }
        }

        public void Update(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityLoginsLogPoco item in items)
                {
                    cmd.CommandText = @"UPDATE Security_Logins_Log
                         SET Is_Succesful = @Is_Succesful, Login = @Login, Logon_Date = @Logon_Date, Source_IP = @Source_IP WHERE [Id] = @Id";

                    cmd.Parameters.AddWithValue("@Is_Succesful", item.IsSuccesful);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Logon_Date", item.LogonDate);
                    cmd.Parameters.AddWithValue("@Source_IP", item.SourceIP);
                    cmd.Parameters.AddWithValue("@Id", item.Id);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
