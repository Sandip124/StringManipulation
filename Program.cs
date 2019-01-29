using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
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
            CreateFileFromList(domains, "domainLists.txt");

            string url = "https://stackexchange.com/sites?view=list#name";
            string urlData = CreateStringFromPostRequest(url);
            CreateFileFromString(urlData, "urldata.html");
        }

        public static List<string> DomainExtractor(string Path, string prefix = "Prefix")
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@Path);
                List<string> list = new List<string>();
                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    string[] domain_parts = data[0].Trim().Split('"');
                    string domain = domain_parts[1];
                    if (domain.IndexOf('.') == 0)
                    {
                        list.Add(prefix + domain);
                    }
                    else
                    {
                        list.Add(prefix + '.' + domain);
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Error occured:" + e);
            }
        }

        public static void CreateFileFromList(List<string> data, string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    using (var file = new StreamWriter(@path))
                    {
                        data.ForEach(v => file.WriteLine(v));
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error occured:" + e);
            }
        }
        public static void CreateFileFromString(string data, string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@path, true))
                    {
                        file.Write(data);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error occured:" + e);
            }

        }

        public static string CreateStringFromPostRequest(string url)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(@url);
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                return responseString;
            }
            catch (Exception e)
            {
                throw new Exception("Error occured:" + e);
            }

        }
    }
}
