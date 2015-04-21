using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string pattern = "abaababa";
            var m = pattern.Length;
            var border = ComputeBorder(pattern);
            var kmpNext = ComputeKmpNext(border, pattern);
            const int tableWidth = 77;
            var counterArray = new int[m + 1];
            for (var i = 0; i <= m; i++) counterArray[i] = i;

            Console.WriteLine("pattern: x={0}, |x|={1}", pattern, pattern.Length);
            Console.WriteLine();
            PrintLine(tableWidth);
            PrintRow(tableWidth, counterArray);
            PrintLine(tableWidth);
            PrintRow(tableWidth, pattern+" ");
            PrintLine(tableWidth);
            PrintRow(tableWidth, border);
            PrintLine(tableWidth);
            PrintRow(tableWidth, kmpNext);
            PrintLine(tableWidth);

            Console.ReadKey();

        }

        static int[] ComputeBorder(string pattern)
        {
            var m = pattern.Length;
            var border = new int[m + 1];
            border[0] = -1;
            var j = 0;
            for (var i = 0; i < m; i++)
            {
                j = border[i];
                while ((j > -1) && pattern[i] != pattern[j])
                {
                    j = border[j];
                }
                border[i + 1] = j + 1;
            }
            return border;
        }

        static int[] ComputeKmpNext(IList<int> border, string pattern)
        {
            var m = border.Count;
            var kmpNext = new int[m];
            kmpNext[0] = -1;
            for (var i = 1; i < m-1; i++)
            {
                if (pattern[i] == pattern[border[i]])
                {
                    kmpNext[i] = kmpNext[border[i]];
                }
                else
                {
                    kmpNext[i] = border[i];
                }
            }
            kmpNext[m-1] = border[m-1];
            return kmpNext;
        }

        static void PrintLine(int tableWidth)
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(int tableWidth, ICollection<int> columns)
        {
            var width = (tableWidth - columns.Count) / columns.Count;
            var row = columns.Aggregate("|",
                                        (current, column) => current + (AlignCentre(column.ToString(), width) + "|"));
            Console.WriteLine(row);
        }

        static void PrintRow(int tableWidth, string columns)
        {
            var width = (tableWidth - columns.Length) / columns.Length;
            var row = columns.Aggregate("|",
                                        (current, column) => current + (AlignCentre(column.ToString(), width) + "|"));
            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
            return string.IsNullOrEmpty(text)
                       ? new string(' ', width)
                       : text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }
    }
}
