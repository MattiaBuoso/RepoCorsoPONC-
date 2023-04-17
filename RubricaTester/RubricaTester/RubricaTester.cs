using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RubricaTester
{
    class RubricaTester
    {
        static void Main(string[] args)
        {

            string text, filePath, parola="";
            string[] tmp;

            Rubrica r1 = new Rubrica();
            Rubrica r2 = new Rubrica();

            Console.WriteLine("inserisci nome del file : ");
            filePath= Console.ReadLine();

            using(FileStream stream = File.OpenRead(filePath)) 
            {
                int totalBytes = (int)stream.Length;
                byte[] data = new byte[totalBytes];
                int bytesRead = 0;

                while (bytesRead < totalBytes)
                {
                    int len = stream.Read(data, bytesRead, totalBytes - bytesRead);
                    bytesRead += len;
                }
                text = Encoding.UTF8.GetString(data);
            }

            for(int i = 0; i<text.Length; i++)
            {
                if (text[i] == '\n') 
                {
                    tmp = parola.Split(':');
                    Console.WriteLine(tmp[])
                }
            }
            
        }
    }
}
