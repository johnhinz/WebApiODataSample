using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobRepository : BaseADORepository<CompanyJobPoco>, IDataRepository<CompanyJobPoco>
    {
        public void Add(params CompanyJobPoco[] items)
        {

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyJobPoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Company_Jobs]
                               ([Id],[Company],[Profile_Created],[Is_Inactive],[Is_Company_Hidden])
                        VALUES
                               (@Id,@Company,@Profile_Created,@Is_Inactive,@Is_Company_Hidden)";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Company", item.Company);
                    cmd.Parameters.AddWithValue("@Profile_Created", item.ProfileCreated);
                    cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@Is_Company_Hidden", item.IsCompanyHidden);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public override IList<CompanyJobPoco> GetAll(params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 120;
                cmd.Connection = conn;
                cmd.CommandText = "Select * from Company_Jobs";
                SqlDataAdapter dadapter = new SqlDataAdapter();
                dadapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dadapter.Fill(ds);
                return ds.Tables[0].AsEnumerable().Select(dr => new CompanyJobPoco()
                {
                    Id = dr.Field<Guid>("Id"),
                    Company = dr.Field<Guid>("Company"),
                    ProfileCreated = dr.Field<DateTime>("Profile_Created"),
                    IsInactive = dr.Field<bool>("Is_Inactive"),
                    IsCompanyHidden = dr.Field<bool>("Is_Company_Hidden"),
                    TimeStamp = dr.Field<byte[]>("Time_Stamp")
                }).ToList();
            }
        }

        public void Update(params CompanyJobPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyJobPoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Company_Jobs]
                       SET [Company] = @Company
                          ,[Profile_Created] = @Profile_Created
                          ,[Is_Inactive] = @Is_Inactive
                          ,[Is_Company_Hidden] = @Is_Company_Hidden
                       WHERE [Id] = @Id";

                    cmd.Parameters.AddWithValue("@Company", item.Company);
                    cmd.Parameters.AddWithValue("@Profile_Created", item.ProfileCreated);
                    cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@Is_Company_Hidden", item.IsCompanyHidden);
                    cmd.Parameters.AddWithValue("@Id", item.Id);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
