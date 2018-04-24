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
    public class SecurityRoleRepository : BaseADORepository<SecurityRolePoco>, IDataRepository<SecurityRolePoco>
    {
        public void Add(params SecurityRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityRolePoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Security_Roles]
                               ([Id],[Role],[Is_Inactive])
                         VALUES
                               (@Id, @Role, @Is_Inactive)";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Role", item.Role);
                    cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public override IList<SecurityRolePoco> GetAll(params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 120;
                cmd.Connection = conn;
                cmd.CommandText = "Select * from Security_Roles";
                SqlDataAdapter dadapter = new SqlDataAdapter();
                dadapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dadapter.Fill(ds);
                return ds.Tables[0].AsEnumerable().Select(dr => new SecurityRolePoco()
                {
                    Id = dr.Field<Guid>("Id"),
                    Role = dr.Field<String>("Role"),
                    IsInactive = dr.Field<bool>("Is_Inactive")
                }).ToList();
            }
        }

        public void Update(params SecurityRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityRolePoco item in items)
                {
                    cmd.CommandText = @"UPDATE Security_Roles
                         SET [Role] = @Role, [Is_Inactive] = @Is_Inactive
                            WHERE [Id] = @Id";

                    cmd.Parameters.AddWithValue("@Role", item.Role);
                    cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
