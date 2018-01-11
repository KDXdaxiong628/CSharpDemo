using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication1.Models;


namespace WebApplication1.Data_Access_Layer
{
    
    public class SalesERPDAL : DbContext
    {
        /*
             DbSet数据集是数据库方面的概念 ，指数据库中可以查询的实体的集合。当执行Linq 查询时，Dbset对象能够将查询内部转换，并触发数据库。
在本实例中，数据集是Employees，是所有Employee的实体的集合。当每次需要访问Employees时，会获取“TblEmployee”的所有记录，并转换为Employee对象，返回Employee对象集
        */
        public DbSet<Employee> Employees  //DbSet表示数据库中能够被查询的所有Employee
        {
            get;
            set;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("TblEmployee");
            base.OnModelCreating(modelBuilder);
        }
    }
}