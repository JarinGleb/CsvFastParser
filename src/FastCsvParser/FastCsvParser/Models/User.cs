using System;
using System.Collections.Generic;
using System.Text;

namespace FastCsvParser.Models
{
    public class User
    {
        public long Index;
        public string Id;
        public string FirstName;
        public string LastName;
        public string Sex;
        public string Email;
        public string Phone;
        public DateTime DateOfBirth;
        public string JobTitle;
    

        public void PrintUserCard()
        {
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("USER");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine();

            Console.WriteLine($"Index          : {Index}");
            Console.WriteLine($"ID             : {Id}");
            Console.WriteLine($"FirstName      : {FirstName}");
            Console.WriteLine($"Last Name      : {LastName}");
            Console.WriteLine($"Email          : {Email}");
            Console.WriteLine($"Phone number   : {Phone}");
            Console.WriteLine($"Date of Birth  : {DateOfBirth:dd.MM.yyyy}");
            Console.WriteLine($"Sex            : {Sex}");
            Console.WriteLine($"Job Title      : {JobTitle}");
            Console.WriteLine($"Age            : {CalculateAge(DateOfBirth)} years");

            Console.WriteLine();
            Console.WriteLine(new string('=', 50));
        }

        static int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
