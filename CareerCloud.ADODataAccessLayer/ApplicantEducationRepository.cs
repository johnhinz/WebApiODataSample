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
    public class ApplicantEducationRepository : BaseADORepository<ApplicantEducationPoco>, IDataRepository<ApplicantEducationPoco>
    {
        public void Add(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantEducationPoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Educations]
                               ([Id],[Applicant],[Major],[Certificate_Diploma],[Start_Date],[Completion_Date],[Completion_Percent])
                        VALUES
                               (@Id,@Applicant,@Major,@Certificate_Diploma,@Start_Date,@Completion_Date,@Completion_Percent)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Major", item.Major);
                    cmd.Parameters.AddWithValue("@Certificate_Diploma", item.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@Start_Date", item.StartDate);
                    cmd.Parameters.AddWithValue("@Completion_Date", item.CompletionDate);
                    cmd.Parameters.AddWithValue("@Completion_Percent", item.CompletionPercent);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public override IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"Select [Id]
                                  ,[Applicant]
                                  ,[Major]
                                  ,[Certificate_Diploma]
                                  ,[Start_Date]
                                  ,[Completion_Date]
                                  ,[Completion_Percent]
                                  ,[Time_Stamp]
                                    FROM[JOB_PORTAL_DB].[dbo].[Applicant_Educations]";
                conn.Open();

                int x = 0;
                SqlDataReader rdr = cmd.ExecuteReader();
                ApplicantEducationPoco[] appPocos = new ApplicantEducationPoco[1000];
                while (rdr.Read())
                {
                    ApplicantEducationPoco poco = new ApplicantEducationPoco();
                    poco.Id = rdr.GetGuid(0);
                    poco.Applicant = rdr.GetGuid(1);
                    poco.Major = rdr.GetString(2);
                    poco.CertificateDiploma = rdr.GetString(3);
                    poco.StartDate = rdr.GetDateTime(4);
                    poco.CompletionDate = rdr.GetDateTime(5);
                    poco.CompletionPercent = (byte?)rdr[6];
                    poco.TimeStamp = (byte[])rdr[7];

                    appPocos[x] = poco;
                    x++;
                }

                return appPocos.Where(a => a != null).ToList();
            }
        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantEducationPoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Applicant_Educations]
                       SET [Applicant] = @Applicant
                          ,[Major] = @Major
                          ,[Certificate_Diploma] = @Certificate_Diploma
                          ,[Start_Date] = @Start_Date
                          ,[Completion_Date] = @Completion_Date
                          ,[Completion_Percent] = @Completion_Percent
                       WHERE [Id] = @Id";

                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Major", item.Major);
                    cmd.Parameters.AddWithValue("@Certificate_Diploma", item.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@Start_Date", item.StartDate);
                    cmd.Parameters.AddWithValue("@Completion_Date", item.CompletionDate);
                    cmd.Parameters.AddWithValue("@Completion_Percent", item.CompletionPercent);
                    cmd.Parameters.AddWithValue("@Id", item.Id);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
