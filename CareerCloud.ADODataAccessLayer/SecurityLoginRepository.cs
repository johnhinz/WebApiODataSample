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
    public class SecurityLoginRepository : BaseADORepository<SecurityLoginPoco>, IDataRepository<SecurityLoginPoco>
    {
        public void Add(params SecurityLoginPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityLoginPoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Security_Logins]
                               ([Id],[Login],[Password], [Created_Date],[Password_Update_Date],[Agreement_Accepted_Date],[Is_Locked],[Is_Inactive],[Email_Address],[Phone_Number],[Full_Name],[Force_Change_Password],[Prefferred_Language])
                         VALUES
                               (@Id, @Login,@Password,@Created_Date,@Password_Update_Date,@Agreement_Accepted_Date,@Is_Locked,@Is_Inactive,@Email_Address,@Phone_Number,@Full_Name,@Force_Change_Password,@Prefferred_Language)";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Password", item.Password);
                    cmd.Parameters.AddWithValue("@Created_Date", item.Created);
                    cmd.Parameters.AddWithValue("@Password_Update_Date", item.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", item.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@Is_Locked", item.IsLocked);
                    cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@Email_Address", item.EmailAddress);
                    cmd.Parameters.AddWithValue("@Phone_Number", item.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Full_Name", item.FullName);
                    cmd.Parameters.AddWithValue("@Force_Change_Password", item.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@Prefferred_Language", item.PrefferredLanguage);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public override IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 120;
                cmd.Connection = conn;
                cmd.CommandText = "Select * from Security_Logins";
                SqlDataAdapter dadapter = new SqlDataAdapter();
                dadapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dadapter.Fill(ds);
                return ds.Tables[0].AsEnumerable().Select(dr => new SecurityLoginPoco()
                {
                    Id = dr.Field<Guid>("Id"),
                    Login = dr.Field<string>("Login"),
                    Password = dr.Field<string>("Password"),
                    Created = dr.Field<DateTime>("Created_Date"),
                    PasswordUpdate = dr.Field<DateTime?>("Password_Update_Date"),
                    AgreementAccepted = dr.Field<DateTime?>("Agreement_Accepted_Date"),
                    IsLocked = dr.Field<bool>("Is_Locked"),
                    IsInactive = dr.Field<bool>("Is_Inactive"),
                    EmailAddress = dr.Field<string>("Email_Address"),
                    PhoneNumber = dr.Field<string>("Phone_Number"),
                    FullName = dr.Field<string>("Full_Name"),
                    ForceChangePassword = dr.Field<bool>("Force_Change_Password"),
                    PrefferredLanguage = dr.Field<string>("Prefferred_Language"),
                    TimeStamp = dr.Field<byte[]>("Time_Stamp")
                }).ToList();
            }
        }

        public void Update(params SecurityLoginPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityLoginPoco item in items)
                {
                    cmd.CommandText = @"UPDATE Security_Logins
                         SET [Login] = @Login
                          ,[Password] = @Password
                          ,[Created_Date] = @Created_Date
                          ,[Password_Update_Date] = @Password_Update_Date
                          ,[Agreement_Accepted_Date] = @Agreement_Accepted_Date
                          ,[Is_Locked] = @Is_Locked
                          ,[Is_Inactive] = @Is_Inactive
                          ,[Email_Address] = @Email_Address
                          ,[Phone_Number] = @Phone_Number
                          ,[Full_Name] = @Full_Name
                          ,[Force_Change_Password] = @Force_Change_Password
                          ,[Prefferred_Language] = @Prefferred_Language
                            WHERE [Id] = @Id";

                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Password", item.Password);
                    cmd.Parameters.AddWithValue("@Created_Date", item.Created);
                    cmd.Parameters.AddWithValue("@Password_Update_Date", item.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", item.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@Is_Locked", item.IsLocked);
                    cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@Email_Address", item.EmailAddress);
                    cmd.Parameters.AddWithValue("@Phone_Number", item.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Full_Name", item.FullName);
                    cmd.Parameters.AddWithValue("@Force_Change_Password", item.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@Prefferred_Language", item.PrefferredLanguage);
                    cmd.Parameters.AddWithValue("@Id", item.Id);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
