using System;
using System.Collections.Generic;
using System.Text;

namespace GausMethod
{
    public class Counter
    {
        public static double[] Count(double[,] array)
        {
            for(var i = 0; i < array.GetLength(0); i++)
            {
                for(var j = i + 1; j < array.GetLength(0); j++)
                {
                    if(array[i,i]== 0)
                    {
                        for(int t = i+1; t < array.GetLength(0); t++)
                        {
                            if (array[t, i] != 0)
                            {
                                ChengeLines(array, i, t);
                                break;
                            }
                        }
                        if (array[i, i] == 0) throw new ArgumentException();
                    }
                    var k = array[j, i] / array[i, i];
                    for (var t = i; t < array.GetLength(1); t++)
                    {
                        
                        array[j, t] -= array[i, t] * k;
                    }
                }
                //Print(array);
            }
            //Print(array);
            //Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

            for(var i = array.GetLength(0) - 1; i >= 0; i--)
            {
                for (var j = 0; j < i; j++)
                {
                    var k = array[j, i] / array[i, i];
                    for(var t = i; t < array.GetLength(1); t++)
                    {
                        array[j, t] -= k * array[i, t];
                    }
                    //Print(array);
                }
            }
            //Print(array);

            var res = new double[array.GetLength(0)];

            for (var i = 0; i < array.GetLength(0); i++)
                Console.WriteLine("x{0} = {1:N5}",i + 1, array[i, array.GetLength(1) - 1] / array[i, i]);

            //foreach (var i in res) Console.Write(i + " ");
            return res;
        }

        static void ChengeLines(double[,] array, int a, int b)
        {
            double k;
            for(int i= 0; i < array.GetLength(1); i++)
            {
                k = array[a, i];
                array[a, i] = array[b, i];
                array[b, i] = k;
            }

        }

        public static void ThomasMethod(double[,] array)
        {
            int n = array.GetLength(0);
            var e = new Dictionary<char, double>[n];
            for(var i = 0; i < n; i++)
            {
                e[i] = new Dictionary<char, double>();
                e[i]['a'] = i - 1 >= 0 ? array[i, i - 1] : 0;
                e[i]['b'] = array[i, i];
                e[i]['c'] = i + 1 < n ? array[i, i + 1] : 0;
                e[i]['d'] = array[i, n];
                e[i]['u'] = 0;
                e[i]['v'] = 0;
                e[i]['x'] = 0;
            }

            e[0]['u'] = -e[0]['c'] / e[0]['b'];
            e[0]['v'] = e[0]['d'] / e[0]['b'];
            //e[i]['']

            for (var i = 1; i < n - 1; i++)
            {
                e[i]['u'] = -e[i]['c'] /(e[i]['a']* e[i-1]['u'] + e[i]['b']);
                e[i]['v'] = (e[i]['d'] - e[i]['a']* e[i-1]['v']) / (e[i]['a'] * e[i - 1]['u'] + e[i]['b']);
            }

            e[n-1]['x'] = (e[n-1]['d'] - e[n-1]['a'] * e[n - 2]['v']) / (e[n-1]['a'] * e[n - 2]['u'] + e[n-1]['b']);

            for (var i = 1; i < n; i++)
            {
                e[n - 1 - i]['x'] = e[n - i]['x'] * e[n - 1 - i]['u'] + e[n - 1 - i]['v'];
            }
            DrawTable(e);

            for (var i = 0; i < n; i++)
                Console.WriteLine("x{0} = {1:N5}", i + 1, e[i]['x']);

        }

        public static void DrawTable(Dictionary<char,double>[] table)
        {
            Console.WriteLine("i  a        b        c         d         u         v       x");
            for(var i = 0; i < table.Length; i++)
            {
                Console.WriteLine("{0}  {1:N5}  {2:N5}  {3:N5}  {4:N5}  {5:N5}  {6:N5}  {7:N5}",i, table[i]['a'], table[i]['b'], table[i]['c'], table[i]['d'], table[i]['u'], table[i]['v'], table[i]['x']);
            }
            Console.WriteLine();
        }

        public static void Print(double[,] array)
        {
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
