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
    public class ApplicantSkillRepository : BaseADORepository<ApplicantSkillPoco>, IDataRepository<ApplicantSkillPoco>
    {
        public void Add(params ApplicantSkillPoco[] items)
        {

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantSkillPoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO Applicant_Skills
                               (Id,Applicant,Skill,Skill_Level,Start_Month,Start_Year, End_Month, End_Year)
                        VALUES
                               (@Id,@Applicant,@Skill,@Skill_Level,@Start_Month,@Start_Year,@End_Month,@End_Year)";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Skill", item.Skill);
                    cmd.Parameters.AddWithValue("@Skill_Level", item.SkillLevel);
                    cmd.Parameters.AddWithValue("@Start_Month", item.StartMonth);
                    cmd.Parameters.AddWithValue("@Start_Year", item.StartYear);
                    cmd.Parameters.AddWithValue("@End_Month", item.EndMonth);
                    cmd.Parameters.AddWithValue("@End_Year", item.EndYear);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public override IList<ApplicantSkillPoco> GetAll(params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 120;
                cmd.Connection = conn;
                cmd.CommandText = "Select * from Applicant_Skills";
                SqlDataAdapter dadapter = new SqlDataAdapter();
                dadapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dadapter.Fill(ds);
                return ds.Tables[0].AsEnumerable().Select(dr => new ApplicantSkillPoco()
                {
                    Id = dr.Field<Guid>("Id"),
                    Applicant = dr.Field<Guid>("Applicant"),
                    Skill = dr.Field<string>("Skill"),
                    SkillLevel = dr.Field<string>("Skill_Level"),
                    StartMonth = dr.Field<byte>("Start_Month"),
                    StartYear = dr.Field<int>("Start_Year"),
                    EndMonth = dr.Field<byte>("End_Month"),
                    EndYear = dr.Field<int>("End_Year"),
                    TimeStamp = dr.Field<byte[]>("Time_Stamp"),
                }).ToList();
            }
        }

        public void Update(params ApplicantSkillPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantSkillPoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Applicant_Skills]
                           SET [Applicant] = @Applicant
                              ,[Skill] = @Skill
                              ,[Skill_Level] = @Skill_Level
                              ,[Start_Month] = @Start_Month
                              ,[Start_Year] = @Start_Year
                              ,[End_Month] = @End_Month
                              ,[End_Year] = @End_Year
                            WHERE [Id] = @Id";

                    cmd.Parameters.AddWithValue("Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("Skill", item.Skill);
                    cmd.Parameters.AddWithValue("Skill_Level", item.SkillLevel);
                    cmd.Parameters.AddWithValue("Start_Month", item.StartMonth);
                    cmd.Parameters.AddWithValue("Start_Year", item.StartYear);
                    cmd.Parameters.AddWithValue("End_Month", item.EndMonth);
                    cmd.Parameters.AddWithValue("End_Year", item.EndYear);
                    cmd.Parameters.AddWithValue("Id", item.Id);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
