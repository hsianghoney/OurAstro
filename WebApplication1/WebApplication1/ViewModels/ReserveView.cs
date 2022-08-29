﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    public class ReserveView
    {
        public int rID { get; set; }
        public int MemberID { get; set; }
        public int ProID { get; set; }
        public string ProName { get; set; }
        public decimal ProCost { get; set; }
        public string ProSkill { get; set; }
        public string ProAddress { get; set; }
        public string ReserveDate { get; set; }
    }
}