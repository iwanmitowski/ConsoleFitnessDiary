using FitnessDiary.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.Models
{
    public static class Table
    {
        //https://pastebin.com/H5K7yx9K

        private static StringBuilder sb = new StringBuilder();
        private static int TableWidth = 200;
        public static string ReturnTheReadyTable()
        {

            return sb.ToString().TrimEnd(); 

        }
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
            sb.AppendLine(new string('-', TableWidth));
        }

        public static void PrintRow(params string[] columns)
        {
            int width = (TableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AignCenter(column, width) + "|";
            }

            sb.AppendLine(row);
        }

        public static string AignCenter(string text, int width)
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
