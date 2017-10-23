﻿using System;
using System.IO;

namespace social_tap
{
    public static class FileReader
    {
        public static void ReadBarInfo(ref BarInfo stats)
        {
            try
            {
                StreamReader dataStream = new StreamReader("rez1.txt"); //Failo location'as:  ...Source\Repos\social-tap\social-tap\bin\Debug
                string datasample;
                int number = 0;
                while ((datasample = dataStream.ReadLine()) != null)
                {
                    stats.amount++;
                    int.TryParse(datasample, out number);
                    stats.sum += number;
                }
                dataStream.Close();
            }
            catch (FileNotFoundException e)
            {
                StreamWriter file = new StreamWriter("rez1.txt"); // jei nėra failo tai sukurs jį 
                file.Close();
                ReadBarInfo(ref stats);
                Console.WriteLine("File does not exist");
            }
          
        }
    }
}
