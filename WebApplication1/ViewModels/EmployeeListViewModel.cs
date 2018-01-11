﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.ViewModels;

namespace WebApplication1.ViewModels
{
    public class EmployeeListViewModel
    {
        public List<EmployeeViewModel> Employees
        {
            get;
            set;
        }
        public string UserName { get; set; }
        //public string UserName
        //{
        //    get;
        //    set;
        //}
    }
}