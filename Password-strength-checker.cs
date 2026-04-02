using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace password_strength_checker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            int score = 0;
            bool hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;

            for (int i = 0; i < password.Length; i++)
            {
                char ch = password[i];

                if (char.IsUpper(ch))
                    hasUpper = true;
                else if (char.IsLower(ch))
                    hasLower = true;
                else if (char.IsDigit(ch))
                    hasDigit = true;
                else
                    hasSpecial = true;
            }

            if (password.Length >= 8) score++;
            if (hasUpper) score++;
            if (hasLower) score++;
            if (hasDigit) score++;
            if (hasSpecial) score++;

            Console.WriteLine();

            if (score <= 2)
            {
                Console.WriteLine("Password Strength: WEAK :-( ");
                Console.WriteLine("Suggestions:");
                if (!hasUpper) Console.WriteLine("- Add uppercase letters");
                if (!hasLower) Console.WriteLine("- Add lowercase letters");
                if (!hasDigit) Console.WriteLine("- Add digits");
                if (!hasSpecial) Console.WriteLine("- Add special characters");
                if (password.Length < 8) Console.WriteLine("- Use at least 8 characters");
            }
            else if (score == 3 || score == 4)
            {
                Console.WriteLine("Password Strength: MODERATE :-| ");
                Console.WriteLine("Suggestions:");
                if (!hasUpper) Console.WriteLine("- Add uppercase letters");
                if (!hasLower) Console.WriteLine("- Add lowercase letters");
                if (!hasDigit) Console.WriteLine("- Add digits");
                if (!hasSpecial) Console.WriteLine("- Add special characters");
                if (password.Length < 8) Console.WriteLine("- Use at least 8 characters");
            }
            else
            {
                Console.WriteLine("Password Strength: STRONG :-)");
                File.AppendAllText("strong_passwords.txt", password + Environment.NewLine);
                Console.WriteLine("Saved to file ✅");
            }
        }
    }
}
