using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numbers_in_files
{
    internal class Program
    {

        class Numbers
        {
            List<int> numbers = new List<int>();

            List<int> positive_numbers = new List<int>();
            List<int> negative_numbers = new List<int>();
            List<int> two_symbols_numbers = new List<int>();
            List<int> fiwe_symbols_numbers = new List<int>();

            string path_numbers = "general";

            string Positive_path = "positive_numbers";
            string Negative_path = "negative_numbers";
            string Two_symbols_path = "two_symbols_numbers";
            string Fiwe_symbols_path = "fiwe_symbols_numbers";


            public void Fill()
            {

                FileStream fs = new FileStream(path_numbers, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);

                Random random = new Random();


                for (int i = 0; i < 10000; i++)
                {
                    numbers.Add(random.Next(-100000, 100000));

                }

                foreach (var item in numbers)
                {
                    sw.WriteLine(item);
                }

                sw.Close();
                fs.Close();
            }



            public void Read_General()
            {

                String line;
                try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader(path_numbers);
                    //Read the first line of text
                    line = sr.ReadLine();
                    //Continue to read until you reach end of file
                    while (line != null)
                    {
                        //write the line to console window
                        numbers.Add(Convert.ToInt32(line));
                        //Read the next line
                        line = sr.ReadLine();
                    }
                    //close the file
                    sr.Close();
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }

            }

            public void Find_Positive() {

                FileStream fs = new FileStream(Positive_path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);


                var query = numbers.Where(i => i > 0);
                positive_numbers = query.ToList();

                foreach (var item in positive_numbers) { sw.WriteLine(item); }

                sw.Close();
                fs.Close();

            }
            public void Find_Negative()
            {

                FileStream fs = new FileStream(Negative_path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);


                var query = numbers.Where(i => i < 0);
                negative_numbers = query.ToList();
                foreach (var item in negative_numbers) { sw.WriteLine(item); }

                sw.Close();
                fs.Close();

            }
            public void Find_2()
            {

                FileStream fs = new FileStream(Two_symbols_path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);

                var query = numbers.Where(i => (i.ToString().Length == 3 && i < 0) | (i.ToString().Length == 2 && i > 0));
                two_symbols_numbers = query.ToList();
                foreach (var item in two_symbols_numbers) { sw.WriteLine(item); }

                sw.Close();
                fs.Close();

            }
            public void Find_5()
            {

                FileStream fs = new FileStream(Fiwe_symbols_path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);

                var query = numbers.Where(i => (i.ToString().Length == 6 && i < 0) | (i.ToString().Length == 5 && i > 0));
                fiwe_symbols_numbers = query.ToList();

                foreach (var item in fiwe_symbols_numbers) { sw.WriteLine(item); }

                sw.Close();
                fs.Close();

            }

        }

        static void Main(string[] args)
        {
            Numbers numbers = new Numbers();

            numbers.Fill();
            numbers.Read_General();
            numbers.Find_Positive();
            numbers.Find_Negative();
            numbers.Find_2();
            numbers.Find_5();
            Console.ReadLine();


            

        }

    }
}
