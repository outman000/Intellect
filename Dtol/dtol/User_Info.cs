using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
     public partial class User_Info
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string UserPwd { get; set; }
        public string RoleNames { get; set; }
        public string RoleIds { get; set; }
        public string Dept { get; set; }
        public string DeptId { get; set; }
        public string Number { get; set; }
        public string AddInfoDate { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string Birthdate { get; set; }
        public string Nation { get; set; }
        public string MaritalStatus { get; set; }
        public string Idcard { get; set; }
        public string NativePlace { get; set; }
        public string PoliticalBackground { get; set; }
        public string JoinPartyDate { get; set; }
        public string BloodType { get; set; }
        public string HomeAddress { get; set; }
        public string ZipCode { get; set; }
        public string PhoneCall { get; set; }
        public string MobileCall { get; set; }
        public string Address { get; set; }
        public string Interest { get; set; }
        public string InitialEducation { get; set; }
        public string InitialGraduated { get; set; }
        public string InitialSpecialty { get; set; }
        public string FinalEducation { get; set; }
        public string FinalGraduated { get; set; }
        public string FinalSpecialty { get; set; }
        public string Degree { get; set; }
        public string Title { get; set; }
        public string ForeignLanguageLevel { get; set; }
        public string ComputerLevel { get; set; }
        public string DriveLevel { get; set; }
        public string EntryDate { get; set; }
        public string EmployNature { get; set; }
        public string Post { get; set; }
        public string ContractSignDate { get; set; }
        public string ContractMaturityDate { get; set; }
        public string WorkExperience { get; set; }
        public string TrainSituation { get; set; }
        public string FamilyMembers { get; set; }
        public string JobPerformance { get; set; }
        public string AwardAndPunish { get; set; }
        public DateTime? AddDate { get; set; }
        public int MasterId { get; set; }
        public string Remark { get; set; }
        public string Email { get; set; }
        public string DeptLeaderId { get; set; }
        public string DeptLeaderName { get; set; }
        public string Levels { get; set; }
        public string Files { get; set; }
        public string ServiceExperience { get; set; }
        public string RoleNameNiwen { get; set; }
        public string RoleIdNiwen { get; set; }
        public string DzbId { get; set; }
        public int? OrderId { get; set; }
        public virtual ICollection<User_Role> SMUserRoles { get; set; }
    }
}
