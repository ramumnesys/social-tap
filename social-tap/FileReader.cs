﻿using System.IO;

namespace social_tap
{
    public static class FileReader
    {
        public static void ReadBarInfo(ref BarInfo stats)
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
    }
}