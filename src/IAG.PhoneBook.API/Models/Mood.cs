using System;
using System.Collections.Generic;

namespace IAG.PhoneBook.API.Models
{
    public partial class Mood
    {
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string Mgrid { get; set; }
        public string Mgrname { get; set; }
        public string JobTitle { get; set; }
        public string TeamName { get; set; }
        public DateTime? MoodDate { get; set; }
        public int? Batch { get; set; }
        public int? Excellent { get; set; }
        public int? Good { get; set; }
        public int? Okay { get; set; }
        public int? Discouraged { get; set; }
        public int? Disencaged { get; set; }
        public int? Round { get; set; }
        public string EncodeId { get; set; }
        public string EmailId { get; set; }
        public int Id { get; set; }
    }
}
