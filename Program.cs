using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee()
            {
                Id = 22,
                FirstName = "Mohd",
                LastName = "Hassan",
                Salary = 27283
            };
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream file = new FileStream("C:\\Users\\HASSAN\\source\\repos\\Assignment 24\\Assignment 24\\employee.bin", FileMode.Create))
            {
               binaryFormatter.Serialize(file, emp);
            }
            Console.WriteLine("Binary File Serialized");
            
            Employee DeEmp;
            using (FileStream file = new FileStream("C:\\Users\\HASSAN\\source\\repos\\Assignment 24\\Assignment 24\\employee.bin", FileMode.Open))
            {
                DeEmp = (Employee)binaryFormatter.Deserialize(file);
            }
            Console.WriteLine("Binary File Deserialized\n");
            Console.WriteLine($"Id : {DeEmp.Id}\nFirst Name : {DeEmp.FirstName}\nLast Name : {DeEmp.LastName}\nSalary : {DeEmp.Salary}");
            Console.WriteLine("\n\n======================================================================================================================\n\n");
            Employee employee = new Employee()
            {
               Id = 01,
               FirstName = "Vishal",
                LastName = "Singh",
               Salary = 30000
            };
            XmlSerializer xml = new XmlSerializer(typeof(Employee));
            using (FileStream file = new FileStream("C:\\Users\\HASSAN\\source\\repos\\Assignment 24\\Assignment 24\\employee.xml", FileMode.Create))
            {
                xml.Serialize(file, employee);
            }
            Console.WriteLine("xml file serialized");
            Employee deemployee;
            using (FileStream file = new FileStream("c:\\users\\hassan\\source\\repos\\assignment 24\\assignment 24\\employee.xml", FileMode.Open))
            {
               deemployee = (Employee)xml.Deserialize(file);
            }
            Console.WriteLine("xml file deserialized");
            Console.WriteLine($"\nId : {deemployee.Id}\nFirst Name : {deemployee.FirstName}\nLast Name : {deemployee.LastName}\nSalary : {deemployee.Salary}\n");
            Console.ReadKey();
            
        }
    }
}