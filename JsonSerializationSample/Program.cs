using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace JsonSerializationSample
{
    public class Student
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public override string ToString() =>
            $"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, Date of Birth: {DateOfBirth}";
    }

    class Program
    {
        static void Main(string[] args)
        {
            var s = new Student { Id = Guid.NewGuid(), FirstName = "Belal", LastName = "Rami", DateOfBirth = DateTime.Now };

            string json;

            using (var ms = new MemoryStream())
            using (var reader = new StreamReader(ms))
            {
                var serializer = new DataContractJsonSerializer(typeof(Student));
                serializer.WriteObject(ms, s);
                ms.Seek(0, SeekOrigin.Begin);
                json = reader.ReadToEnd();

                Console.WriteLine(json);
            }

            // عملية إعادة توليد كائن باستخدام تمثيل جيسن
            Console.WriteLine();
            Console.WriteLine("Deserialization....");

            using(var ms = new MemoryStream(Encoding.Default.GetBytes(json)))
            {
                var deserializer = new DataContractJsonSerializer(typeof(Student));
                var s2 = (Student)deserializer.ReadObject(ms);

                Console.WriteLine(s2);
            }
        }
    }
}
