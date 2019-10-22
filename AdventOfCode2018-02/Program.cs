using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018_02
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = LoadData();
            var checksum = GetChecksum(data);
            Console.WriteLine(checksum);

            var x = CompareSimilar(data);
            Console.WriteLine(x);
        }

        static string[] LoadData()
        {
            var text = System.IO.File.ReadAllText("data.txt");
            return text.Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
        }

        static int GetChecksum(string[] data)
        {
            int rowsWith2Chars = 0;
            int rowsWith3Chars = 0;

            foreach (var row in data)
            {
                var counts = new Dictionary<char, int>();
                foreach (var c in row)
                {
                    if (counts.ContainsKey(c))
                    {
                        counts[c]++;
                    }
                    else
                    {
                        counts.Add(c, 1);
                    }
                }

                bool contains2Chars = counts.Values.Any(x => x == 2);
                bool contains3Chars = counts.Values.Any(x => x == 3);

                if (contains2Chars)
                {
                    rowsWith2Chars++;
                }
                if (contains3Chars)
                {
                    rowsWith3Chars++;
                }
            }

            return rowsWith2Chars * rowsWith3Chars;
        }

        static string CompareSimilar(string[] data)
        {
            foreach (var row in data)
            {
                foreach (var nextRow in data)
                {
                    if (nextRow == row)
                    {
                        continue;
                    }

                    if (row.Length != nextRow.Length)
                    {
                        continue;
                    }

                    int differentChars = 0;
                    string textWithoutDifferentChars = "";
                    for (int i = 0; i < row.Length; i++)
                    {
                        if (row[i] != nextRow[i])
                        {
                            differentChars++;
                            if(differentChars > 1)
                            {
                                break;
                            }
                        }
                        else
                        {
                            textWithoutDifferentChars += row[i];
                        }
                    }

                    if(differentChars == 1)
                    {
                        return textWithoutDifferentChars;
                    }
                }
            }

            return "";
        }
    }
}
