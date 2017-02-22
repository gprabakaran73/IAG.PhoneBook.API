using System;
using System.Collections.Generic;

namespace IAG.PhoneBook.API.Models
{
    public partial class Safetyroles
    {
        public int Id { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string SafetyRoleCode { get; set; }
        public string SafetyRoleText { get; set; }
        public string PersonnelNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string WorkPhoneFull { get; set; }
        public string WorkPhoneExt { get; set; }
        public string BusAddrStreet1 { get; set; }
        public string BusAddrStreet2 { get; set; }
        public string BusAddrCity { get; set; }
        public string BusAddrState { get; set; }
        public string BusAddrZipcode { get; set; }
        public string BusCountrycode { get; set; }
        public string PositionName { get; set; }
        public string FullName { get; set; }
        public string PreferredName { get; set; }
    }
}
