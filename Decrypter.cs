using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt
{
    class Decrypter //Dekrypterer tekst
    {

        string user;

        char[] Alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',   //
                            'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',   // array over alfabet, tal
                            'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3',   //
                            '4', '5', '6', '7', '8', '9', ' '};

        int[] AlphabetRef = {  0,  1,  2,  3,  4,  5,  6,  7,  8,  9,
                              10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
                              20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
                              30, 31, 32, 33, 34, 35, 36};

        public void DecryptMethod() //Giver brugeren mulighed for at vælge hvordan det skal dekrypteres
        {
            Console.WriteLine("\nChoose decryption method: \n Date decryption (1) \n Caesar decryption (2)");
            user = Console.ReadLine();
            user = user.ToUpper();
            if (user == "1")
            {
                DDate();
            }
            else if (user == "2")
            {
                DCaesar();
            }
            else if (user == "3")
            {
                EVigenere();
            }
        }



        public void DDate() //alting i den her gør præcis det omvendte som i EDate for at dekryptere
        {
            Console.WriteLine("Choose decryption method");
            Console.WriteLine("Day (1) \n Day Month (2) \n Day Month Year (3)");
            string choose = Console.ReadLine();

            if (choose == "1")
            {
                int date = Convert.ToInt32(DateTime.UtcNow.ToString("dd"));
                Console.WriteLine(date);

                user = Message();

                char[] charMessage = user.ToCharArray();
                Console.WriteLine(charMessage);

                foreach (char i in charMessage)
                {
                    int j = Array.IndexOf(Alphabet, i) - date;

                    while (j < 0)
                    {
                        j = j + 37;
                    }
                    char q = Convert.ToChar(Alphabet[j]);

                    Console.Write(q);
                }
            }
            else if (choose == "2")
            {
                int dateD = Convert.ToInt32(DateTime.UtcNow.ToString("dd"));
                int dateM = Convert.ToInt32(DateTime.UtcNow.ToString("MM"));
                Console.WriteLine(dateD + dateM);

                user = Message();

                char[] charMessage = user.ToCharArray();

                Console.WriteLine(charMessage);

                foreach (char i in charMessage)
                {
                    int j = Array.IndexOf(Alphabet, i) - dateD + dateM;

                    while (j < 0)
                    {
                        j = j + 37;
                    }
                    char q = Convert.ToChar(Alphabet[j]);

                    Console.Write(q);
                }
            }
            else if (choose == "3")
            {
                int dateD = Convert.ToInt32(DateTime.UtcNow.ToString("dd"));
                int dateM = Convert.ToInt32(DateTime.UtcNow.ToString("MM"));
                int dateY = Convert.ToInt32(DateTime.UtcNow.ToString("yy"));
                Console.WriteLine(dateD + dateM + dateY);

                user = Message();

                char[] charMessage = user.ToCharArray();

                Console.WriteLine(charMessage);

                foreach (char i in charMessage)
                {
                    int j = Array.IndexOf(Alphabet, i) - dateD + dateM - dateY;

                    while (j < 0)
                    {
                        j = j + 37;
                    }
                    char q = Convert.ToChar(Alphabet[j]);

                    Console.Write(q);
                }
            }
        }

        public void DCaesar()//Dekrypterer en besked ved at bruge Caesar metoden. Caesar går ud på at fx rykke et bogstav
        {                    //et antal pladser længere hen ad alfabetet Hvis der bliver rykket to gange vil A blive til C Vil B blive til D osv.
            Console.WriteLine("Write displacement number");         //Bruger vælger "displacemnt number", hvor mange gange hvert bogstav og tegn skal ændres.
            int displacement = Convert.ToInt32(Console.ReadLine()); //Det bliver læst og sat ind i "displacement"

            user = Message();  //Kører message metoden

            char[] charMessage = user.ToCharArray(); //Laver brugerens besked om til et char array

            Console.WriteLine(charMessage); //Skriver beskeden ud igen for at tjekke om det er omdannet til char array rigtigt

            foreach (char i in charMessage) //Virker overordnet på samme måde som dato dekryptering
            {
                int j = Array.IndexOf(Alphabet, i) - displacement;

                //Modsat dato kan caesar både ende med at være større end antal alphabet array værdier men også mindre end 0
                while (j < 0) //Mens det er mindre end 0 læg 37 til
                {
                    j = j + 37;
                }
                while (j > 37) //Mens det er større end 37 træk 37 fra.
                {
                    j = j - 37;
                }
                char q = Convert.ToChar(Alphabet[j]);

                Console.Write(q);
            }
        }

        public void EVigenere()
        {
            string message = Message();
            Console.WriteLine("Write Keyword");
            string keyword = Console.ReadLine();

            string key = generateKey(message, keyword);
            string decodedText = DecodeText(message, keyword);

            Console.WriteLine(decodedText);
        }

        static string generateKey(string message, string keyword)
        {
            int x = message.Length;

            for (int i = 0; ; i++)
            {
                if (x == i) { i = 0; }
                if (keyword.Length == message.Length) { break; }
                keyword += (keyword[i]);
            }
            return keyword;
        }

        string DecodeText(string message, string keyword)
        {
            string decodedText = "";

            for (int i = 0; i < message.Length && i < keyword.Length; i++)
            {
                int x = (message[i] - keyword[i] + 37) % 37;

                string j = Convert.ToString(Alphabet[x]);

                decodedText += j;
            }
            return decodedText;
        }



        public string Message() //Bruger kan skrive sin besked
        {
            Console.WriteLine("Write a message");
            return Console.ReadLine().ToUpper(); //Besked bliver sat til kun at være store bogstaver og efter retuneret
        }
    }
}
