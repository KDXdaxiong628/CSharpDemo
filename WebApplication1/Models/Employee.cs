using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WebApplication1.ViewModels;

namespace WebApplication1.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId
        {
            get;
            set;
        }

        //[Required(ErrorMessage = "Enter First Name")] --> 没添加自定义验证之前
        [FirstNameValidation]// 自定义验证
        public string FirstName
        {
            get;
            set;
        }

        [StringLength(5, ErrorMessage = "Last Name length should not be greater than 5")]
        public string LastName
        {
            get;
            set;
        }
        
        public int? Salary// public int? Salary添加 问号  代表可空整数域
        {
            get;
            set;
        }

        
    }
}