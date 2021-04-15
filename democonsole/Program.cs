using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Computas_Cipher {
    class Program {
        public static char cipher(char letter, int number_shift) {
            if (!char.IsLetter(letter)) {

                return letter;
            }

            char d = char.IsUpper(letter) ? 'A' : 'a';
            return (char)((((letter + number_shift) - d) % 26) + d);


        }
        public static string encrypt_message(string input, int number_shift) {
            string output = string.Empty;


            foreach(char letter in input) {
                output += cipher(letter, number_shift);
            }

            return output;
        }

        public static string decrypt_message(string input, int number_shift) {
            Console.WriteLine(input);
            return encrypt_message(input, 26 - number_shift);
        }

        public static void howtorun() {
            Console.WriteLine("Compile program by:\n1. csc Program.cs\n2. mono Program.exe <file>.txt <number shift> <flag>. -d for decryption -e for encryption");

        }


        static void Main(string[] args) {
            /*
            1.mono Program.exe tekst.txt 1 -e
            2. deKryptere:  mono Program.exe encrypted_tekst.txt 1 -d
            */


            if (args.Length != 3) {

                howtorun();
                System.Environment.Exit(0);


            }
            string text_file = args[0];
            int number_shift = Convert.ToInt32(args[1]);


            string flag = args[2];

            string text = System.IO.File.ReadAllText(text_file);
            Console.WriteLine(text);


            if(flag == "-d")
            {
               string decrypted =  decrypt_message(text,number_shift);

                if(text_file.Contains("encrypted")) {
                    Console.WriteLine("Hallo");

                    string newfile =text_file.Replace("encrypted","decrypted");

                    Console.WriteLine(newfile);
                    File.WriteAllText(newfile, decrypted);
                }

            }
            else if (flag == "-e"){

                string encrypted = encrypt_message(text,number_shift);
                Console.WriteLine("Encrypted: " + encrypted);
                File.WriteAllText("encrypted_" + text_file, encrypted);

            }


        }
    }
}