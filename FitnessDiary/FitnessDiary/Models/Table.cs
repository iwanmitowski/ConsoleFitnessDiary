using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.Models
{
    public static class Table
    {

        static int TableWidth = 200;
        
        public static void SetTableWidth(int width)
        {
            TableWidth = width;
        }
        public static void SetWindowSize()
        {
            Console.SetWindowSize(TableWidth+1, 30);
        }
        public static void ShowTheBeginningOfTheTable()
        {
            Console.SetWindowPosition(0, 0);
        }
        public static void PrintLine()
        {
            Console.WriteLine(new string('-', TableWidth));
        }

        public static void PrintRow(params string[] columns)
        {
            int width = (TableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        public static string AlignCentre(string text, int width)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
