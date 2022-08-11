using System;
using System.Text.RegularExpressions;

namespace Homework02_Extra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = " Предложение один Теперь предложение два Предложение три ";
            Console.WriteLine(str);
            Regex regex = new(@" (\p{Lu})");
            string res = regex.Replace(str.Trim(), ". $1") + '.';
            Console.WriteLine(res);
        }
    }
}
