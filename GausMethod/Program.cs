﻿using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace GausMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var reg = @"([\+-]?\d?)x(\d)";
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            if (n == 0)
            {
                Counter.Count(new double[,] {
                { 2, 1, 1, 1, 1 },
                { 2, 2, 2, 3, -1},
                { 4, 3, 3, 3, 1 },
                { 6, 4, 5, 2, 4 } });
                return;
            }

            var arr = new double[n, n + 1];
            for(var i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                foreach(Match t in Regex.Matches(line, reg, RegexOptions.IgnoreCase))
                {

                    var e = t.Groups[1].Value;
                    switch (e)
                    {
                        case "+":
                            arr[i, int.Parse(t.Groups[2].Value) - 1] = 1;
                            break;
                        case "-":
                            arr[i, int.Parse(t.Groups[2].Value) - 1] = -1;
                            break;
                        default:
                            arr[i, int.Parse(t.Groups[2].Value) - 1] = Double.Parse(e);
                            break;
                    }
                }
                arr[i, n] = Double.Parse(Regex.Match(line, @"=([\+-]?\d)").Groups[1].Value);
            }
            Counter.Count(arr);
            //5x1+2x2+3x3-7x2=9
            //@"[\+-]?(/d)x/d"
        }
    }
}
