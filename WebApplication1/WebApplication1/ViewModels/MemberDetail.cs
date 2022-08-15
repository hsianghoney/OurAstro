using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    public class MemberDetail
    {
        public int aID { get; set; }
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public DateTime MemberBirth { get; set; }
        public DateTime MemberBirthTime { get; set; }
        public string MemberBirthPlace { get; set; }
        public string MemberAstro { get; set; }
        public string MemberAstronut { get; set; }
    }
}