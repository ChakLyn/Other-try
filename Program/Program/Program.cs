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
             ///////////////////////////////////////////////////////////////////////////////
            int[] matr = new int[parts.Length - 1];
            // заполняем матрицу размерами слов
            for (int i = 0; i < matr.Length; i++)
            {
                matr[i] = parts[i + 1].Length;
                // если слово длиннее чем строка
                if (matr[i] > n)
                {
                    Console.WriteLine("Не корректные значения!");
                    return;
                }
            }
            ////////////////////////////////////////////////////////////////////////////////
            int[] CountInStr = new int[matr.Length];
            // заполняем матрицу 0
            for (int i = 0; i < CountInStr.Length; i++)
            {
                CountInStr[i] = 0;
            }
            int CountOfWords = matr.Length;
            int k = 0;
            // заполняем матрицу количсетвом слов в строке
            while (end != true)
            {
                int temp = n;
                for (int i = matr.Length - CountOfWords; i < matr.Length; i++)
                {
                    if (i == matr.Length - 1)
                    {
                        temp -= matr[i] + 1;    // сколько осталось свободного места
                        --CountOfWords;         // уменьшаем количетво доступных слов
                        CountInStr[k] += 1;     // увеличиваем количество для вмещения
                    }
                    else
                    {
                        if (temp - matr[i] >= matr[i + 1] + 1)// если есть место для слова + пробел
                        {
                            temp -= matr[i] + 1;
                            --CountOfWords;
                            CountInStr[k] += 1;
                        }
                        else // если только для слова
                        {
                            temp -= matr[i];
                            --CountOfWords;
                            CountInStr[k] += 1;
                            k += 1;
                            break;
                        }
                    }
                }// если слова кончились
                if (CountOfWords == 0)
                {
                    end = true;
                }

            }
            int CountOfNewStr = 0;// к-ство новый строк
            using (StreamWriter file = new StreamWriter(@"C:\Games\Repos\New\Program\Program\out.txt"))
            {
                foreach (int i in CountInStr)
                {
                    if (i == 0) // если в строке 0 слов 
                    {
                        continue;
                    }
                    file.WriteLine(i);
                    CountOfNewStr += 1;
                }
            }
           

        
        }
    }
}
