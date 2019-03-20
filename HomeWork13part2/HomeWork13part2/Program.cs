using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HomeWork13part2
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student
            {
                FullName = "Касым-Жомарт Токаев",
                Age = 65,
                Country = "Kazakhstan",
                University = "MGIMO USSR"
            };

            XmlDocument xml = new XmlDocument();
            XmlElement root = xml.CreateElement("student");
            XmlElement fullname = xml.CreateElement("fullname");
            XmlElement age = xml.CreateElement("age");
            XmlElement country = xml.CreateElement("country");
            XmlElement university = xml.CreateElement("university");
            fullname.InnerText = student.FullName;
            age.InnerText = student.Age.ToString();
            country.InnerText = student.Country;
            university.InnerText = student.University;

            root.AppendChild(fullname);
            root.AppendChild(age);
            root.AppendChild(country);
            root.AppendChild(university);

            xml.AppendChild(root);
            xml.Save("student.xml");
            
        }
    }
}
