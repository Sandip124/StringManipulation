using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace StringManipulation
{
    public class Program
    {
        static void Main(string[] args)
        {

            string path = @"D:\Dotnet Projects\StringManipulation\cdn-list.txt";
            string prefix = "www";
            List<string> domains = DomainExtractor(path, prefix);

            foreach (var domain in domains)
            {
                System.Console.WriteLine(domain);
            }
        }

        public static List<string> DomainExtractor(string Path, string prefix = "Prefix")
        {
            string[] lines = System.IO.File.ReadAllLines(@Path);
            List<string> sb = new List<string>();
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                string[] domain_parts = data[0].Trim().Split('"');
                string domain = domain_parts[1];
                if (domain.IndexOf('.') == 0)
                {
                    sb.Add(prefix + domain);
                }
                else
                {
                    sb.Add(prefix + '.' + domain);
                }
            }
            return sb;
        }
    }
}
