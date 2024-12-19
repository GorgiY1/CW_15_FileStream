using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_15_FileStream
{
    class Program
    {
        private static void Write(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                Console.WriteLine("Input text: ");
                string text = Console.ReadLine();

                byte[] bytes = Encoding.UTF8.GetBytes(text);
                fs.Write(bytes, 0, bytes.Length);
                Console.WriteLine("Information OK!");
            }
        }
        private static string Read(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                byte[] vs = new byte[fs.Length];
                fs.Read(vs, 0, vs.Length);
                return Encoding.UTF8.GetString(vs);
            }
        }
        private static void WriteText(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {

                }
                Console.WriteLine("Input text: ");
                string text = Console.ReadLine();

                byte[] bytes = Encoding.UTF8.GetBytes(text);
                fs.Write(bytes, 0, bytes.Length);
                Console.WriteLine("Information OK!");
            }
        }

        private static string ReadText(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        private static void WriteBin(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs, Encoding.Unicode))
                {
                    Console.WriteLine("Input text: ");
                    string text = Console.ReadLine();

                    double salary = 456.123;
                    int number = 7896;
                    char symb = 't';

                    bw.Write(salary);
                    bw.Write(number);
                    bw.Write(symb);
                };
            }
        }

        private static string ReadBin(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (BinaryReader br = new BinaryReader(fs, Encoding.Unicode))
                {
                    return $"{br.ReadDouble()}\n{br.ReadInt32()}\n{br.ReadChar()}";
                };
            }
        }
        static void Main(string[] args)
        {
            //string path = "test.bd2";
            //string pathTxt = "test.txt";
            //string pathBin = "testBin.bd2";
            //try
            //{
            //    //Write(path);
            //    //Console.WriteLine(Read(path));

            //    //WriteBin(pathBin);
            //    //Console.WriteLine(ReadBin(pathBin));

            //    string directory = @"C:\Users\Михаил\source\Академия Шаг\C#\Class_Work\HW_15_FileStream\Dir";

            //    if (!Directory.Exists(directory))
            //    {
            //        Directory.CreateDirectory(directory);
            //    }

            //    foreach (string item in Directory.GetDirectories(@"C:\"))
            //    {
            //        Console.WriteLine(item);
            //    }

            //    using (StreamWriter writer = File.CreateText("Test1.txt"))
            //    {

            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}


            m();

            Exemple exemple = new Exemple();

            foreach (object item in typeof(Exemple).GetCustomAttributes(true))
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        [Obsolete]
        private static void m()
        {
            Console.WriteLine("m");
        }

    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    class CoderAttribute : Attribute
    {
        private string _name;
        private DateTime _date;

        public CoderAttribute()
        {
            _name = "Jack";
            _date = DateTime.Now;
        }
        public CoderAttribute(string name, string dateTime)
        {
            _name = name;
            _date = Convert.ToDateTime(dateTime);
        }
        public override string ToString()
        {
            return $"{_name}: {_date}";
        }
    }
    [Coder]
    class Exemple
    {
        [Coder("Jeena","")]
        public int Summ { get; set; }
    }
}
