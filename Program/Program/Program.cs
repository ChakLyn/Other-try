using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader ReadFile = new StreamReader(@"C:\Games\Repos\New\Program\Program\in.txt", Encoding.Default);
            string Input = null;
            int n = 0;
            bool end = false;
            //Читаем из файла информацию
            Input = ReadFile.ReadToEnd();
            String[] parts = Input.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            n = Convert.ToInt32(parts[0]);
            using (StreamWriter WriteFile = new StreamWriter(@"C:\Games\Repos\New\Program\Program\out.txt"))
            {
                for (int i = 1; i < parts.Length; i++)
                {
                    WriteFile.WriteLine(parts[i]);
                    Console.WriteLine(parts[i]);
                }
            }
        }
    }
}
