using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IAG.PhoneBook.API.Models
{
    public partial class phonebookContext : DbContext
    {
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Mood> Mood { get; set; }
        public virtual DbSet<RollUp> RollUp { get; set; }
        public virtual DbSet<Safetyroles> Safetyroles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=SP2010;Database=phonebook;Trusted_Connection=True;");
        }

        public phonebookContext(DbContextOptions<phonebookContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Employee1)
                    .HasColumnName("Employee")
                    .HasColumnType("varchar(255)");
            });


            modelBuilder.Entity<Mood>(entity =>
            {
                entity.HasIndex(e => e.Mgrid)
                    .HasName("NC_NU_Emp_MgrID");

                entity.Property(e => e.EmailId)
                    .HasColumnName("EmailID")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.EmpId).HasColumnType("varchar(50)");

                entity.Property(e => e.EmpName).HasColumnType("varchar(100)");

                entity.Property(e => e.EncodeId).HasColumnType("varchar(25)");

                entity.Property(e => e.JobTitle).HasColumnType("varchar(100)");

                entity.Property(e => e.Mgrid)
                    .HasColumnName("MGRId")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Mgrname)
                    .HasColumnName("MGRName")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.MoodDate).HasColumnType("date");

                entity.Property(e => e.TeamName).HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Safetyroles>(entity =>
            {
                entity.ToTable("safetyroles");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BusAddrCity)
                    .HasColumnName("BUS_ADDR_CITY")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.BusAddrState)
                    .HasColumnName("BUS_ADDR_STATE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.BusAddrStreet1)
                    .HasColumnName("BUS_ADDR_STREET1")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.BusAddrStreet2)
                    .HasColumnName("BUS_ADDR_STREET2")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.BusAddrZipcode)
                    .HasColumnName("BUS_ADDR_ZIPCODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.BusCountrycode)
                    .HasColumnName("BUS_COUNTRYCODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("DATE_FROM")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.DateTo)
                    .HasColumnName("DATE_TO")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.EmailAddress)
                    .HasColumnName("EMAIL_ADDRESS")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.FirstName)
                    .HasColumnName("FIRST_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.FullName)
                    .HasColumnName("FULL_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.LastName)
                    .HasColumnName("LAST_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.MiddleName)
                    .HasColumnName("MIDDLE_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.PersonnelNo)
                    .HasColumnName("PERSONNEL_NO")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.PositionName)
                    .HasColumnName("POSITION_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.PreferredName)
                    .HasColumnName("PREFERRED_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.SafetyRoleCode)
                    .HasColumnName("SAFETY_ROLE_CODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.SafetyRoleText)
                    .HasColumnName("SAFETY_ROLE_TEXT")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.WorkPhoneExt)
                    .HasColumnName("WORK_PHONE_EXT")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.WorkPhoneFull)
                    .HasColumnName("WORK_PHONE_FULL")
                    .HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => new { e.Mandt, e.PersonnelNo, e.DateExtracted, e.LastName, e.FirstName, e.Initials, e.Title, e.GenderCode, e.GenderCodeText, e.WorkPhoneFull, e.EmailAddress, e.IsManagerFlag, e.OnLeaveFrom, e.OnLeaveTo, e.BusUnitCode, e.BusUnitName, e.BusAddrStreet1, e.BusAddrStreet2, e.BusAddrCity, e.BusAddrState, e.BusAddrZipcode, e.BusCountrycode, e.BusAddrIdCode, e.BusCompanyCode, e.BusCompanyName, e.ContractCode, e.ContractName, e.ContractExpiry, e.CostCentreCode, e.CostCentreName, e.EmpStartDate, e.SubareaCode, e.EmpgroupCode, e.EmpgroupName, e.SubgroupCode, e.SubgroupName, e.PayrollCountry, e.PayAreaCode, e.PositionCode, e.PositionName, e.PositionCommenced, e.JobkeyCode, e.MgrPersonnelNo, e.MgrFullname, e.MgrPosition, e.OrgDivisionCode, e.OrgDivisionName, e.OrgLdapCode, e.OrgSubdivCode, e.OrgSubdivName, e.OrgSubdivM1Code, e.OrgSubdivM1Name, e.OrgBusLine, e.FiUserFlag, e.HrUserFlag, e.CatsUserFlag, e.CatsStartDate, e.PortalUserFlag, e.EssUserFlag1, e.EssUserFlag2, e.EssStartDate, e.SiteAdminCode, e.SiteAdminName, e.DiSecFlags, e.Fte, e.WeeklyHrs, e.Headcnt, e.Username, e.FullName, e.MiddleName, e.PreferredName, e.WorkPhoneExt, e.WorkFax, e.MobilePhone, e.LeaveTypeCode, e.LeaveTypeName, e.MgrAssistPerno, e.EssGroupCode, e.Spacer, e.FullName1, e.FullName2, e.FullName3, e.Id })
                    .HasName("NonClusteredIndex-20170131-142726");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BusAddrCity)
                    .HasColumnName("BUS_ADDR_CITY")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.BusAddrIdCode)
                    .HasColumnName("BUS_ADDR_ID_CODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.BusAddrState)
                    .HasColumnName("BUS_ADDR_STATE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.BusAddrStreet1)
                    .HasColumnName("BUS_ADDR_STREET1")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.BusAddrStreet2)
                    .HasColumnName("BUS_ADDR_STREET2")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.BusAddrZipcode)
                    .HasColumnName("BUS_ADDR_ZIPCODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.BusCompanyCode)
                    .HasColumnName("BUS_COMPANY_CODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.BusCompanyName)
                    .HasColumnName("BUS_COMPANY_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.BusCountrycode)
                    .HasColumnName("BUS_COUNTRYCODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.BusUnitCode)
                    .HasColumnName("BUS_UNIT_CODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.BusUnitName)
                    .HasColumnName("BUS_UNIT_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.CatsStartDate)
                    .HasColumnName("CATS_START_DATE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.CatsUserFlag)
                    .HasColumnName("CATS_USER_FLAG")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.ContractCode)
                    .HasColumnName("CONTRACT_CODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.ContractExpiry)
                    .HasColumnName("CONTRACT_EXPIRY")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.ContractName)
                    .HasColumnName("CONTRACT_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.CostCentreCode)
                    .HasColumnName("COST_CENTRE_CODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.CostCentreName)
                    .HasColumnName("COST_CENTRE_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.DateExtracted)
                    .HasColumnName("DATE_EXTRACTED")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.DiSecFlags)
                    .HasColumnName("DI_SEC_FLAGS")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.EmailAddress)
                    .HasColumnName("EMAIL_ADDRESS")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.EmpStartDate)
                    .HasColumnName("EMP_START_DATE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.EmpgroupCode)
                    .HasColumnName("EMPGROUP_CODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.EmpgroupName)
                    .HasColumnName("EMPGROUP_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.EssGroupCode)
                    .HasColumnName("ESS_GROUP_CODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.EssStartDate)
                    .HasColumnName("ESS_START_DATE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.EssUserFlag1)
                    .HasColumnName("ESS_USER_FLAG_1")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.EssUserFlag2)
                    .HasColumnName("ESS_USER_FLAG_2")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.FiUserFlag)
                    .HasColumnName("FI_USER_FLAG")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.FirstName)
                    .HasColumnName("FIRST_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Fte)
                    .HasColumnName("FTE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.FullName)
                    .HasColumnName("FULL_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.FullName1)
                    .HasColumnName("FULL_NAME_1")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.FullName2)
                    .HasColumnName("FULL_NAME_2")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.FullName3)
                    .HasColumnName("FULL_NAME_3")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.GenderCode)
                    .HasColumnName("GENDER_CODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.GenderCodeText)
                    .HasColumnName("GENDER_CODE_TEXT")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Headcnt)
                    .HasColumnName("HEADCNT")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.HrUserFlag)
                    .HasColumnName("HR_USER_FLAG")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Initials)
                    .HasColumnName("INITIALS")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.IsManagerFlag)
                    .HasColumnName("IS_MANAGER_FLAG")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.JobkeyCode)
                    .HasColumnName("JOBKEY_CODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.LastName)
                    .HasColumnName("LAST_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.LeaveTypeCode)
                    .HasColumnName("LEAVE_TYPE_CODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.LeaveTypeName)
                    .HasColumnName("LEAVE_TYPE_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Mandt)
                    .HasColumnName("MANDT")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.MgrAssistPerno)
                    .HasColumnName("MGR_ASSIST_PERNO")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.MgrFullname)
                    .HasColumnName("MGR_FULLNAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.MgrPersonnelNo)
                    .HasColumnName("MGR_PERSONNEL_NO")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.MgrPosition)
                    .HasColumnName("MGR_POSITION")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.MiddleName)
                    .HasColumnName("MIDDLE_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.MobilePhone)
                    .HasColumnName("MOBILE_PHONE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.OnLeaveFrom)
                    .HasColumnName("ON_LEAVE_FROM")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.OnLeaveTo)
                    .HasColumnName("ON_LEAVE_TO")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.OrgBusLine)
                    .HasColumnName("ORG_BUS_LINE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.OrgDivisionCode)
                    .HasColumnName("ORG_DIVISION_CODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.OrgDivisionName)
                    .HasColumnName("ORG_DIVISION_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.OrgLdapCode)
                    .HasColumnName("ORG_LDAP_CODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.OrgSubdivCode)
                    .HasColumnName("ORG_SUBDIV_CODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.OrgSubdivM1Code)
                    .HasColumnName("ORG_SUBDIV_M1_CODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.OrgSubdivM1Name)
                    .HasColumnName("ORG_SUBDIV_M1_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.OrgSubdivName)
                    .HasColumnName("ORG_SUBDIV_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.PayAreaCode)
                    .HasColumnName("PAY_AREA_CODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.PayrollCountry)
                    .HasColumnName("PAYROLL_COUNTRY")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.PersonnelNo)
                    .HasColumnName("PERSONNEL_NO")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.PortalUserFlag)
                    .HasColumnName("PORTAL_USER_FLAG")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.PositionCode)
                    .HasColumnName("POSITION_CODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.PositionCommenced)
                    .HasColumnName("POSITION_COMMENCED")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.PositionName)
                    .HasColumnName("POSITION_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.PreferredName)
                    .HasColumnName("PREFERRED_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.SiteAdminCode)
                    .HasColumnName("SITE_ADMIN_CODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.SiteAdminName)
                    .HasColumnName("SITE_ADMIN_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Spacer)
                    .HasColumnName("spacer")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.SubareaCode)
                    .HasColumnName("SUBAREA_CODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.SubgroupCode)
                    .HasColumnName("SUBGROUP_CODE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.SubgroupName)
                    .HasColumnName("SUBGROUP_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Username)
                    .HasColumnName("USERNAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.WeeklyHrs)
                    .HasColumnName("WEEKLY_HRS")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.WorkFax)
                    .HasColumnName("WORK_FAX")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.WorkPhoneExt)
                    .HasColumnName("WORK_PHONE_EXT")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.WorkPhoneFull)
                    .HasColumnName("WORK_PHONE_FULL")
                    .HasColumnType("varchar(200)");
            });
        }
    }
}