using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Member
    {
        public int mID { get; set; }
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public bool MemberSex { get; set; }
        public DateTime MemberBirth { get; set; }
        public DateTime MemberBirthTime { get; set; }
        public string MemberBirthPlace { get; set; }
        public string MemberPhone { get; set; }
        public string MemberEmail { get; set; }
        public string MemberPWD { get; set; }
        public string MemberAccount { get; set; }
    }
}