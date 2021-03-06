﻿using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Day28
{

    static Dictionary<string, string> names = new Dictionary<string, string>();

    static void Main(string[] args)
    {
        int N = Convert.ToInt32(Console.ReadLine());

        for (int NItr = 0; NItr < N; NItr++)
        {
            string[] firstNameEmailID = Console.ReadLine().Split(' ');

            string firstName = firstNameEmailID[0];

            string emailID = firstNameEmailID[1];

            if (!names.ContainsKey(emailID))
            {
                names.Add(emailID, firstName);
            }
        }

        DisplayOrderedNames();
    }

    private static void DisplayOrderedNames()
    {
        var finalList = new List<string>();

        var regex = new Regex(@"^[\w-\.]+@gmail.com");

        foreach (var item in names)
        {
            if (regex.IsMatch(item.Key))
            {
                finalList.Add(item.Value);
            }
        }

        finalList.Sort();

        foreach (var name in finalList.OrderBy(n => n))
        {
            Console.WriteLine(name);
        }
    }
}