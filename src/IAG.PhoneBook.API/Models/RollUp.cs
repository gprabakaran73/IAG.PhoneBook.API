using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAG.PhoneBook.API.Models
{
    public class RollUp
    {
        public int Id { get; set; }
        public string teamleavel0 { get; set; }
        public string teamleavel1 { get; set; }
        public string teamleavel2 { get; set; }
        public string teamleavel3 { get; set; }
        public string Empname { get; set; }
        public string Level1Mgr { get; set; }
        public string managername { get; set; }
        public string Level2Mgr { get; set; }
        public string Level3Mgr { get; set; }
        //public string Level4Mgr { get; set; }
        //public string Teamname1 { get; set; }
        //public string Teamname2 { get; set; }
        //public string Teamname3 { get; set; }
        //public string Teamname4 { get; set; }
        public int? level { get; set; }
        public int? Excellent { get; set; }
        public int? Good { get; set; }
        public int? Okay { get; set; }
        public int? Discouraged { get; set; }
        public int? Disencaged { get; set; }
        public string CreatedDate { get; set; }
        public int? Round { get; set; }
        public int? Rating { get; set; }

    }
}
