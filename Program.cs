/*Завдання 2:
Реалізуйте запити з першого завдання з використанням
синтаксису методів розширень. */
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_With_Method_Syntax

{
    class Company
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string Profile { get; set; }
        public string CEO { get; set; }
        public int NumberOfWorkers { get; set; }
        public string Address { get; set; }

        public Company(string name,
                       DateTime foundationDate,
                       string profile,
                       string ceo,
                       int numberOfWorkers,
                       string address)
        {
            Name = name;
            FoundationDate = foundationDate;
            Profile = profile;
            CEO = ceo;
            NumberOfWorkers = numberOfWorkers;
            Address = address;
        }



        class Program
        {
            static void Main()
            {
                List<Company> companies = new List<Company>
                {
                    new Company("Food For You", DateTime.Now.AddYears(-3), "Продукты питания", "John Tomas", 150, "New York"),
                    new Company("IT Thought", DateTime.Now.AddYears(-2), "IT", "Jane Doe", 200, "San Francisco"),
                    new Company("Mark For U", DateTime.Now.AddYears(-1), "Маркетинг", "Michael Duglas", 80, "London"),
                    new Company("White Nights", DateTime.Now.AddYears(-4), "IT", "Terry White", 300, "London"),
                    new Company("Black Doors", DateTime.Now.AddYears(-5), "Маркетинг", "Bob Black", 120, "Paris")
                };

                var allCompanies = companies.Select(c => c);
                var foodCompanies = companies.Where(c => c.Name.Contains("Продукты питания"));
                var marketingCompanies = companies.Where(c => c.Profile == "Маркетинг");
                var markOrIT = companies.Where(c => c.Profile == "Маркетинг" || c.Profile == "IT");
                var Over100Workers = companies.Where(c => c.NumberOfWorkers > 100);
                var between100And300Workers = companies.Where(c => c.NumberOfWorkers >= 100 && c.NumberOfWorkers <= 300);
                var fromLondon = companies.Where(c => c.Address == "London");
                var whiteDirectors = companies.Where(c => c.CEO.Split(' ').Last() == "White");
                var MoreThan2YearsAgo = companies.Where(c => c.FoundationDate < DateTime.Now.AddYears(-2));
                var founded123DaysAgo = companies.Where(c => (DateTime.Now - c.FoundationDate).TotalDays > 123);
                var blackDirectorsOrWhiteCompanies = companies.Where(c => c.CEO.Split(' ').Last() == "Black" || c.Name.Contains("White"));

                Console.WriteLine("Все компании:");
                DisplayCompanies(allCompanies);

                Console.WriteLine("\nКомпании продуктов питания:");
                DisplayCompanies(foodCompanies);

                Console.WriteLine("\nМаркетинговые компании :");
                DisplayCompanies(marketingCompanies);

                Console.WriteLine("\nМаркетинг и сфера IT:");
                DisplayCompanies(markOrIT);

                Console.WriteLine("\nВ этих компаниях работает более 100 человек:");
                DisplayCompanies(Over100Workers);

                Console.WriteLine("\nВ этих компаниях работает от 100 до 300 человек:");
                DisplayCompanies(between100And300Workers);

                Console.WriteLine("\nКомпании с пропиской в Лондоне:");
                DisplayCompanies(fromLondon);

                Console.WriteLine("\nКомпания, владельцем которой является мистер White:");
                DisplayCompanies(whiteDirectors);

                Console.WriteLine("\nЭтим компаниям более 2 лет:");
                DisplayCompanies(MoreThan2YearsAgo);

                Console.WriteLine("\nЭтим компаниям больше 123 дней:");
                DisplayCompanies(founded123DaysAgo);

                Console.WriteLine("\nДиректор: Black, Компания: White:");
                DisplayCompanies(blackDirectorsOrWhiteCompanies);

                Console.ReadKey();
            }

            static void DisplayCompanies(IEnumerable<Company> companies)
            {
                foreach (var company in companies)
                {
                    Console.WriteLine($"{company.Name}, \t" +
                        $"{company.Profile}, " +
                        $"{company.CEO}, " +
                        $"{company.NumberOfWorkers} работников, " +
                        $"Основана в {company.FoundationDate}, " +
                        $"Располагается в {company.Address}");
                }
            }
        }
    }
}
