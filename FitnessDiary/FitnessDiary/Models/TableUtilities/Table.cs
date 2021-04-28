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
        private static StringBuilder sb = new StringBuilder();
        private static int TableWidth = 200;
        public static string ReturnTheReadyTable()
        {

            return sb.ToString().TrimEnd(); 

        }
        public static void ClearTableBuilder()
        {
            sb.Clear();
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
            string line = '├' + new string('─', TableWidth - 2) + '┤';
            sb.AppendLine(line);
        }
        public static void PrintTop()
        {
            string top = '┌' + new string('─', TableWidth - 2) + '┐';
            sb.AppendLine(top);
        }
        public static void PrintBot()
        {
            string bot = '└' + new string('─', TableWidth - 2) + '┘';
            sb.AppendLine(bot);
        }
        public static void PrintRow(params string[] columns)
        {
            int width = (TableWidth - columns.Length) / columns.Length;
            string row = "│";

            foreach (string column in columns)
            {
                row += AignCenter(column, width) + "│";
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
