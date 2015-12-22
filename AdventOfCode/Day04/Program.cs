using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Day04
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        private static void Part1()
        {
            var input = File.ReadAllText("input.txt");
            var startingWithStr = string.Empty.PadRight(5,'0');
            var result = FindIntPostfix(input, startingWithStr);

            Console.WriteLine(result);
        }
        private static void Part2()
        {
            var input = File.ReadAllText("input.txt");
            var startingWithStr = string.Empty.PadRight(6, '0');
            var result = FindIntPostfix(input, startingWithStr);

            Console.WriteLine(result);
        }

        private static int FindIntPostfix(string input, string startingWithStr)
        {
            var result = 0;
            using (var md5 = MD5.Create())
            {
                do
                {
                    var str = input + result;
                    var md5Hash = GetMd5Hash(md5, str);
                    if (md5Hash.StartsWith(startingWithStr))
                    {
                        break;
                    }
                    result++;
                } while (true);
            }
            return result;
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sb = new StringBuilder();
            for (var i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}