﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6._1
{
    public class Input
    {
        public static string[] InputArray()
        {
            Console.WriteLine("\nEnter a string of words that you want to sort separated by a space, please\n");
            string str = Console.ReadLine();
            string[] array = str.Split(' ');
            return array;
        }
    }
}
