using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace HomeWork13
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Item>));
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            var xmlString = client.DownloadString("https://habrahabr.ru/rss/interesting/");
            List<Item> itemList = new List<Item>();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);
            XmlNode title = null;
            XmlNode link = null;
            XmlNode description = null;
            XmlNode pubDate = null;

            foreach(XmlElement x in xmlDocument.GetElementsByTagName("item"))
            {
                foreach(XmlElement y in x)
                {
                    if (y.Name == "title")
                    {
                        title = y;
                    }
                    else if(y.Name == "link")
                    {
                        link = y;
                    }
                    else if(y.Name == "description")
                    {
                        description = y;
                    }
                    else if(y.Name == "pubDate")
                    {
                        pubDate = y;
                    }
                }
                Item item = new Item
                {
                    Title = title.InnerText,
                    Link = link.InnerText,
                    Description = description.InnerText,
                    PubDate = pubDate.InnerText
                };
                itemList.Add(item);
            }
            foreach (Item x in itemList)
            {
                Console.WriteLine($"{x.Title}\n{x.Link}\n{x.Description}\n{x.PubDate}");
            }

            Console.Read();
        }
    }
}
