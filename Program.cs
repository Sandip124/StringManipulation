using System;
using System.Text;

namespace StringManipulation
{
    class Program
    {
        static void Main(string[] args)
        {

            string path =@"D:\Dotnet Projects\StringManipulation\cdn-list.txt";
            string prefix = "WWW";
            StringBuilder domains = DomainExtractor(path,prefix);
            Console.WriteLine(domains);
        }

        public static StringBuilder DomainExtractor(string Path,string prefix = "Prefix")
        {
            string[] lines = System.IO.File.ReadAllLines(@Path);
            StringBuilder sb = new StringBuilder();
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                string [] domain_parts = data[0].Trim().Split('"');
                string domain = domain_parts[1];
                if (domain.IndexOf('.') == 0)
                {
                    sb.Append(prefix + domain);
                }
                else
                {
                    sb.Append(prefix +'.'+ domain);
                }
                sb.Append("\n");
            }
            return sb;
        }
    }
}
