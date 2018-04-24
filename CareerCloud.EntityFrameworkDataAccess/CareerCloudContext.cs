using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext : DbContext
    {
        public CareerCloudContext(bool createProxy = true) : base(ConfigurationManager.ConnectionStrings["HumberRocks"].ConnectionString)
        {
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            Configuration.ProxyCreationEnabled = createProxy;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /* things to discuss
             * - Timestamp (see below)
             * 
             * 
             * */

            modelBuilder.Entity<CompanyDescriptionPoco>().Ignore(c => c.SystemLanguageCodes);

            modelBuilder.Entity<ApplicantWorkHistoryPoco>().Property(a => a.TimeStamp).IsRowVersion();

            #region Security Logins
            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(e => e.ApplicantProfiles)
                .WithRequired(e => e.SecurityLogin)
                .HasForeignKey(e => e.Login)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(e => e.SecurityLoginsLog)
                .WithRequired(e => e.SecurityLogins)
                .HasForeignKey(e => e.Login)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(e => e.SecurityLoginsRoles)
                .WithRequired(e => e.SecurityLogins)
                .HasForeignKey(e => e.Login)
                .WillCascadeOnDelete(false);
            #endregion
            #region Security Roles
            modelBuilder.Entity<SecurityRolePoco>()
            .HasMany(e => e.SecurityLoginsRoles)
            .WithRequired(e => e.SecurityRoles)
            .HasForeignKey(e => e.Role)
            .WillCascadeOnDelete(false);
            #endregion
            #region System Country Codes
            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(e => e.ApplicantProfiles)
                .WithOptional(e => e.SystemCountryCodes)
                .HasForeignKey(e => e.Country);

            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(e => e.ApplicantWorkHistory)
                .WithRequired(e => e.SystemCountryCodes)
                .HasForeignKey(e => e.CountryCode)
                .WillCascadeOnDelete(false);
            #endregion
            #region Company Jobs
            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(e => e.ApplicantJobApplications)
                .WithRequired(e => e.CompanyJob)
                .HasForeignKey(e => e.Job)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(e => e.CompanyJobEducations)
                .WithRequired(e => e.CompanyJob)
                .HasForeignKey(e => e.Job)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(e => e.CompanyJobsDescriptions)
                .WithRequired(e => e.CompanyJobs)
                .HasForeignKey(e => e.Job)
                .WillCascadeOnDelete(false);

            #endregion
            #region Application Profile
            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(e => e.Applications)
                .WithRequired(e => e.ApplicantProfiles)
                .HasForeignKey(e => e.Applicant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(e => e.ApplicantEducation)
                .WithRequired(e => e.ApplicantProfile)
                .HasForeignKey(e => e.Applicant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(e => e.ApplicantResumes)
                .WithRequired(e => e.ApplicantProfile)
                .HasForeignKey(e => e.Applicant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(e => e.ApplicantSkills)
                .WithRequired(e => e.ApplicantProfiles)
                .HasForeignKey(e => e.Applicant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(e => e.ApplicantWorkHistory)
                .WithRequired(e => e.ApplicantProfiles)
                .HasForeignKey(e => e.Applicant)
                .WillCascadeOnDelete(false);
            #endregion
            #region Company Profile

            modelBuilder.Entity<CompanyProfilePoco>()
            .Property(e => e.CompanyWebsite)
            .IsUnicode(false);

            modelBuilder.Entity<CompanyProfilePoco>()
                .Property(e => e.ContactPhone)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyProfilePoco>()
                .Property(e => e.ContactName)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyProfilePoco>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<CompanyProfilePoco>()
            .HasMany(e => e.CompanyJobs)
            .WithRequired(e => e.CompanyProfiles)
            .HasForeignKey(e => e.Company)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyProfilePoco>()
            .HasMany(e => e.CompanyDescriptions)
            .WithRequired(e => e.CompanyProfiles)
            .HasForeignKey(e => e.Company)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyProfilePoco>()
               .HasMany(e => e.CompanyLocations)
               .WithRequired(e => e.CompanyProfiles)
               .HasForeignKey(e => e.Company)
               .WillCascadeOnDelete(false);

            #endregion
            #region System Lanaguage Codes
            modelBuilder.Entity<SystemLanguageCodePoco>()
                .HasMany(e => e.CompanyDescriptions)
                .WithOptional(e => e.SystemLanguageCodes)
                .HasForeignKey(e => e.LanguageId);
            #endregion

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ApplicantEducationPoco> ApplicantEducation { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplication { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfile { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResume { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkill { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistory { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescription { get; set; }
        //public DbSet<Company_Job_Educations> Company_Job_Educations { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducation { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkill { get; set; }
        public DbSet<CompanyJobPoco> CompanyJob { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescription { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocation { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfile { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogin { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLog { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRole { get; set; }
        public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        public DbSet<SystemLanguageCodePoco> System_Language_Codes { get; set; }

    }
}
