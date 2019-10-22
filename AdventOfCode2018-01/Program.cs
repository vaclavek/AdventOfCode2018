using System;
using System.Collections.Generic;

namespace AdventOfCode2018_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = LoadData();
            var sum = Sum(data);
            var duplicate = GetDuplicte(data);
            Console.WriteLine(sum);
            Console.WriteLine(duplicate);
        }

        static string[] LoadData()
        {
            var text = System.IO.File.ReadAllText("data.txt");
            return text.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        }

        static int Sum(string[] data)
        {
            int sum = 0;
            foreach (var item in data)
            {
                bool plus = item[0] == '+';
                int number = Convert.ToInt32(item.Substring(1));
                if (plus)
                {
                    sum += number;
                }
                else
                {
                    sum -= number;
                }
            }
            return sum;
        }

        static int GetDuplicte(string[] data)
        {
            int sum = 0;
            var signs = new HashSet<int>();
            while (true)
            {
                foreach (var item in data)
                {
                    bool plus = item[0] == '+';
                    int number = Convert.ToInt32(item.Substring(1));
                    if (plus)
                    {
                        sum += number;
                    }
                    else
                    {
                        sum -= number;
                    }

                    if (signs.Contains(sum))
                    {
                        return sum;
                    }
                    else
                    {
                        signs.Add(sum);
                    }
                }
            }
        }
    }
}
