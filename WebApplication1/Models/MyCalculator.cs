using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MyCalculator
    {
        public int GetAvg(int sumScore, int sumObject)
        {
            return sumScore / sumObject;
        }
    }
}