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
    public class CompanyDescriptionRepository : BaseADORepository<CompanyDescriptionPoco>, IDataRepository<CompanyDescriptionPoco>
    {
        public void Add(params CompanyDescriptionPoco[] items)
        {
             using (SqlConnection conn = new SqlConnection(_connStr))
             {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyDescriptionPoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Company_Descriptions]
                               ([Id],[Company],[LanguageID],[Company_Name],[Company_Description])
                        VALUES
                               (@Id,@Company,@LanguageID,@Company_Name,@Company_Description)";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Company", item.Company);
                    cmd.Parameters.AddWithValue("@LanguageID", item.LanguageId);
                    cmd.Parameters.AddWithValue("@Company_Name", item.CompanyName);
                    cmd.Parameters.AddWithValue("@Company_Description", item.CompanyDescription);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public override IList<CompanyDescriptionPoco> GetAll(params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {

             using (SqlConnection conn = new SqlConnection(_connStr))
             {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 120;
                cmd.Connection = conn;
                cmd.CommandText = "Select * from Company_Descriptions";
                SqlDataAdapter dadapter = new SqlDataAdapter();
                dadapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dadapter.Fill(ds);
                return ds.Tables[0].AsEnumerable().Select(dr => new CompanyDescriptionPoco()
                {
                    Id = dr.Field<Guid>("Id"),
                    Company = dr.Field<Guid>("Company"),
                    LanguageId = dr.Field<string>("LanguageID"),
                    CompanyName = dr.Field<string>("Company_Name"),
                    CompanyDescription = dr.Field<string>("Company_Description"),
                    TimeStamp = dr.Field<byte[]>("Time_Stamp")
                }).ToList();
            }
        }

        public void Update(params CompanyDescriptionPoco[] items)
        {
             using (SqlConnection conn = new SqlConnection(_connStr))
             {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyDescriptionPoco item in items)
                {
                    cmd.CommandText = @"UPDATE Company_Descriptions
                         SET [Company] = @Company
                          ,[LanguageID] = @LanguageID
                          ,[Company_Name] = @Company_Name
                          ,[Company_Description] = @Company_Description
                        WHERE [Id] = @Id";

                    cmd.Parameters.AddWithValue("@Company", item.Company);
                    cmd.Parameters.AddWithValue("@LanguageID", item.LanguageId);
                    cmd.Parameters.AddWithValue("@Company_Name", item.CompanyName);
                    cmd.Parameters.AddWithValue("@Company_Description", item.CompanyDescription);
                    cmd.Parameters.AddWithValue("@Id", item.Id);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
           
        }
    }
}
