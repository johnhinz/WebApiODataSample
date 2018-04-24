using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityLoginsRoleRepository : BaseADORepository<SecurityLoginsRolePoco>, IDataRepository<SecurityLoginsRolePoco>
    {
        public void Add(params SecurityLoginsRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityLoginsRolePoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Security_Logins_Roles]
                               ([Id],[Login],[Role])
                         VALUES
                               (@Id,@Login,@Role)";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Role", item.Role);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public override IList<SecurityLoginsRolePoco> GetAll(params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 120;
                cmd.Connection = conn;
                cmd.CommandText = "Select * from Security_Logins_Roles";
                SqlDataAdapter dadapter = new SqlDataAdapter();
                dadapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dadapter.Fill(ds);
                return ds.Tables[0].AsEnumerable().Select(dr => new SecurityLoginsRolePoco()
                {
                    Id = dr.Field<Guid>("Id"),
                    Login = dr.Field<Guid>("Login"),
                    Role = dr.Field<Guid>("Role"),
                    TimeStamp = dr.Field<byte[]>("Time_Stamp")
                }).ToList();
            }
        }

        public void Update(params SecurityLoginsRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityLoginsRolePoco item in items)
                {
                    cmd.CommandText = @"UPDATE Security_Logins_Roles
                         SET [Login] = @Login
                          ,[Role] = @Password
                            WHERE [Id] = @Id";

                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Role", item.Role);
                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }
    }
}
