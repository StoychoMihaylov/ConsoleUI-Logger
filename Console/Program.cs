namespace ConsoleUI
{
    using System;
    using System.Net;
    using System.IO;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    class Program
    {
        
        static void Main(string[] args)
        {
            TakveValuesAsync();
        }

        private static void TakveValuesAsync()
        {
            string url = @"https://localhost:44323/api/values";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var content = reader.ReadToEnd();

                var result = JsonConvert.DeserializeObject<IList<dynamic>>(content);

                foreach(var item in result)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
