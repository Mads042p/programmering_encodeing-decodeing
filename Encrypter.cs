using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt
{
    public class Encrypter  //Enkrypterer tekst
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



        public void EncryptMethod()  //Giver brugeren mulighed for at vælge hvordan det skal krypteres
        {
            Console.WriteLine("\nChoose encryption method: \n Date encryption (1) \n Caesar encryption (2)");
            user = Console.ReadLine();
            user = user.ToUpper();
            if (user == "1")
            {
                EDate();
            }
            else if (user == "2")
            {
                ECaesar();
            }
            else if (user == "3")
            {
                EVigenere();
            }
        }

        public void EDate() //Kryptere alting med dato at gøre
        {
            Console.WriteLine("Choose encryption method");
            Console.WriteLine("Day (1) \n Day Month (2) \n Day Month Year (3)");
            string choose = Console.ReadLine(); //vælg hvordan du gerne vil Kryptere

            if (choose == "1")
            {

                int date = Convert.ToInt32(DateTime.UtcNow.ToString("dd"));
                Console.WriteLine(date); //Finder datoen for dagen 1-31

                user = Message();

                char[] charMessage = user.ToCharArray(); //laver input om til et array

                Console.WriteLine(charMessage);

                foreach (char i in charMessage) //loop som ændre hvert tegn i arrayet til et andet ved hjælp af den tidligere fundet dato
                {
                    int j = Array.IndexOf(Alphabet, i) + date;

                    while (j > 37) //hvis værdien går over vores listes max starter den forfra i vores liste
                    {
                        j = j - 37;
                    }
                    char q = Convert.ToChar(Alphabet[j]);

                    Console.Write(q); //skriver hver værdi i array
                }
            }
            else if (choose == "2") //gør præcis det samme som før men den her bruger også måned til at ændre værdien
            {
                int dateD = Convert.ToInt32(DateTime.UtcNow.ToString("dd"));
                int dateM = Convert.ToInt32(DateTime.UtcNow.ToString("MM"));
                Console.WriteLine(dateD + dateM);

                user = Message();

                char[] charMessage = user.ToCharArray();

                Console.WriteLine(charMessage);

                foreach (char i in charMessage)
                {
                    int j = Array.IndexOf(Alphabet, i) + dateD - dateM;

                    while (j > 37)
                    {
                        j = j - 37;
                    }
                    char q = Convert.ToChar(Alphabet[j]);

                    Console.Write(q);
                }
            }
            else if (choose == "3") //præcis det samme som før men den her bruger også år
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
                    int j = Array.IndexOf(Alphabet, i) + dateD - dateM + dateY;

                    while (j > 37)
                    {
                        j = j - 37;
                    }
                    char q = Convert.ToChar(Alphabet[j]);

                    Console.Write(q);
                }
            }
            else
            {
                Console.WriteLine("skriv 1, 2, eller 3");
            }

        }

        public void ECaesar() //Krypterer en besked ved at bruge Caesar metoden. Caesar går ud på at fx rykke et bogstav
                              //et antal pladser længere hen ad alfabetet Hvis der bliver rykket to gange vil A blive til C Vil B blive til D osv.
        {
            Console.WriteLine("Write displacement number");         //Bruger vælger "displacemnt number", hvor mange gange hvert bogstav og tegn skal ændres.
            int displacement = Convert.ToInt32(Console.ReadLine()); //Det bliver læst og sat ind i "displacement"

            user = Message();   //Kører Message metoden

            char[] charMessage = user.ToCharArray(); //Laver brugerens besked om til et char array

            Console.WriteLine(charMessage); //Skriver beskeden ud igen for at tjekke om det er omdannet til char array rigtigt

            foreach (char i in charMessage) //Virker overordnet på samme måde som dato kryptering
            {
                int j = Array.IndexOf(Alphabet, i) + displacement; //Rykker aray værdien displacemnt antal gange

                //Modsat dato kan caesar både ende med at være større end antal alphabet array værdier men også mindre end 0
                while (j > 37) //Mens det er større end 37 træk 37 fra.
                {
                    j = j - 37;
                }
                while (j < 0) //Mens det er mindre end 0 læg 37 til
                {
                    j = j + 37;
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
            string encodedText = EncodeText(message, keyword);

            Console.WriteLine(encodedText);
        }
        static string generateKey(string message, string keyword)
        {
            int x = message.Length;

            for (int i = 0; ; i ++)
            {
                if (x == i) { i = 0; }
                if (keyword.Length == message.Length) { break; }
                keyword += (keyword[i]);
            }
            return keyword;
        }
        string EncodeText(string message, string keyword)
        {
            string encodedText = "";

            for (int i = 0; i < message.Length; i++)
            {
                int x = (message[i] + keyword[i]) % 37;

                Console.WriteLine(x);

                string j = Convert.ToString(Alphabet[x]);

                encodedText += j;
            }

            Console.WriteLine(encodedText);
            return encodedText;
        }

        public string Message() //Bruger kan skrive sin besked
        {
            Console.WriteLine("Write a message");
            return Console.ReadLine().ToUpper(); //Besked bliver sat til kun at være store bogstaver og efter retuneret
        }
    }
}
