using System;

namespace Eksamensprojekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Encrypter encrypt = new Encrypter();
            Decrypter decrypt = new Decrypter();

            Console.WriteLine("Choose encryption (1) or decryption (2)");
            string user = Console.ReadLine();
            if (user == "1")
            {
                encrypt.EncryptMethod();
            }
            else if (user == "2")
            {
                decrypt.DecryptMethod();
            }
            else
            {
                Console.WriteLine("no...");
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("PRESS KEY TO CONTINUE");
                Console.ReadKey();
                return;
            }
        }
    }
}
