﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class Calculator
    {
        public static double Add(double x, double y) 
        {
            return x + y;
        }

        public static double Subtract(int x, int y)
        {
            return x - y;
        }

        public static double Multiply(double x, double y)
        {
            return x * y;
        }

        public static double Divide(double x, double y)
        {
            if (y != 0) 
            {
                return x / y;
            }
            else
            {
                return 0;
            }
        }
    }
}
