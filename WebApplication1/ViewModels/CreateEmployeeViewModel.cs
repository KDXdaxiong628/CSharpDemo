using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*
    如何在验证失败时，填充值 
*/
namespace WebApplication1.ViewModels
{
    public class CreateEmployeeViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Salary { get; set; }
    }
}