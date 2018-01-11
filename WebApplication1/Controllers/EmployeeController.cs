using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;
//实验 17 添加授权认证

namespace WebApplication1.Controllers
{
    public class Customer
    {
        public string CustomerName
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }

        // 重写ToString方法
        public override string ToString()
        {
            return this.CustomerName + "|" + this.Address;
        }
    }


    public class EmployeeController : Controller
    {
        // GET: Test
        public string GetString()
        {
            return "Hello World is old now. It’s time for wassup bro ;";
        }

        public Customer GetCustomer()
        {
            Customer c = new Customer();
            c.CustomerName = "Customer 1";
            c.Address = "Address1";
            return c;
        }

        [NonAction]
        public string SimpleMethod()
        {
            return "Hi, I am not action method";
        }

        //认证属性 [Authorize] 对于Index action的请求会自动重链接到 login action
        [Authorize]
        public ActionResult Index()
        {
            //Employee emp = new Employee();
            //emp.FirstName = "Sukesh";
            //emp.LastName = "Marla";
            //emp.Salary = 20000;

            //ViewData["Employee"] = emp;

            //ViewBag.Employee = emp;
            //return View("MyView", emp);

            // 使用EmployeeViewModel 
            //EmployeeViewModel vmEmp = new EmployeeViewModel();
            //vmEmp.EmployeeName = emp.FirstName + " " + emp.LastName;
            //vmEmp.Salary = emp.Salary.ToString("C");
            //if (emp.Salary > 15000)
            //{
            //    vmEmp.SalaryColor = "yellow";
            //}
            //else
            //{
            //    vmEmp.SalaryColor = "green";
            //}
            //vmEmp.UserName = "KDX";

            //return View("MyView", vmEmp);

            // 集合，多个数据源

            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
            employeeListViewModel.UserName = User.Identity.Name; //New Line

            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();

            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary?.ToString("C");
                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                empViewModels.Add(empViewModel);
            }
            employeeListViewModel.Employees = empViewModels;
            //employeeListViewModel.UserName = "Admin";  -->Remove this line -->Change1
            return View("Index", employeeListViewModel);//-->Change View Name -->Change 2
        }

        public ActionResult AddNew()
        {
            /*
             View中，试着将Model中的数据重新显示在文本框中。
            如：
            <input id="TxtSalary" name="Salary" type="text" value="@Model.Salary" />
            如上所示，可以访问当前Model的“First Name”属性，如果Model 为空，会抛出类无法实例化的异常“Object reference not set to an instance of the class”。
            当点击”Add New“超链接时，请求会通过Add New方法处理，在该Action 方法中，可以不传递任何数据。即就是，View中的Model属性为空。因此会抛出“Object reference not set to an instance of the class”异常。为了解决此问题，所以会在初始化请求时，传”new CreateEmployeeViewModel()“。
             */
            return View("CreateEmployee", new CreateEmployeeViewModel());
        }

        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                /*
                UpdateModel 和 TryUpdateModel 方法之间的区别是什么？

                TryUpdateModel 与UpdateModel 几乎是相同的，有点略微差别。

                如果Model调整失败，UpdateModel会抛出异常。就不会使用UpdateModel的 ModelState.IsValid属性。

                TryUpdateModel是将函数参数与Employee对象保持相同，如果更新失败，ModelState.IsValid会设置为False值。
                 */
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                        empBal.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
                        vm.FirstName = e.FirstName;
                        vm.LastName = e.LastName;
                        if (e.Salary.HasValue)
                        {
                            vm.Salary = e.Salary.ToString();
                        }
                        else
                        {
                            vm.Salary = ModelState["Salary"].Value.AttemptedValue;
                        }
                        return View("CreateEmployee", vm);
                    }
                case "Cancel":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
        }
    }



}