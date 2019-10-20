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
                Console.WriteLine("x{0} = {1}",i + 1, array[i, array.GetLength(1) - 1] / array[i, i]);

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
