using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var nssStudents = new List<Student>()
            {
                new Student()
                {
                Name = "Onterio",
                CohortName = "Day Cohort 37"
                },

                new Student()
                {
                Name = "Luis",
                CohortName = "Day Cohort 37"
                },

                new Student()
                {
                Name = "Tyler",
                CohortName = "Day Cohort 35"
                },

                new Student()
                {
                Name = "Spenser",
                CohortName = "Day Cohort 37"
                },

                new Student()
                {
                Name = "Phillip",
                CohortName = "Day Cohort 37"
                },

                new Student()
                {
                Name = "Aja",
                CohortName = "Day Cohort 35"
                },

                new Student()
                {
                Name = "Rebecca",
                CohortName = "Day Cohort 35"
                },

                new Student()
                {
                Name = "Jansen",
                CohortName = "Day Cohort 37"
                }

            };

            var names = nssStudents.Select(student => student.Name);

            var studentDescription = nssStudents.Select(student =>
            {
                return $"{student.Name} is a student in {student.CohortName}";
            });

            var StudentsIn37 = nssStudents.Where(student => student.CohortName == "Day Cohort 37");
            var spencer = nssStudents.FirstOrDefault(student =>
            {
                return student.Name.Contains("pen");
            });

            var hasStudentsIn37 = nssStudents.Any(student =>
            {
                return student.CohortName == "Day Cohort 37";
            });

            // GroupBy is always followed by Select
            var cohortBreakDown = nssStudents
                .GroupBy(student => student.CohortName)
                .Select(group =>
                {
                    return new CohortReport
                    {
                    StudentCount = group.Count(),
                    CohortName = group.Key

                    };
                });

            List<Product> shoppingCart = new List<Product>()
            {
                new Product("Bike", 109.99),
                new Product("Mittens", 6.49),
                new Product("Lollipop", 0.50),
                new Product("Pocket Watch", 584.00)
            };

            IEnumerable<Product> inexpensive = from product in shoppingCart
            where product.Price < 100.00
            orderby product.Price descending
            select product;

            Console.WriteLine("Inexpensive");
            Console.WriteLine();
            foreach (Product product in inexpensive)
            {
                Console.WriteLine($"{ product.Title} ${ product.Price:f2}");
            }

            Console.WriteLine();

            var expensive = from product in shoppingCart
            where product.Price >= 100.00
            orderby product.Price descending
            select product;

            Console.WriteLine("Expensive");
            Console.WriteLine();
            foreach (Product product in expensive)
            {
                Console.WriteLine($"{ product.Title} ${ product.Price:f2}");
            }

            List<int> numbers = new List<int>() { 9, -59, 23, 71, -74, 13, 52, 44, 2 };
            var smallPositiveNumbers = numbers.Where(n => n < 40 && n > 0).OrderBy(n => n);
            var allBetweenSmall = numbers.All(n => n > -5 && n < 39); // false
            var allBetweenLarge = numbers.All(n => n > -100 && n < 400); // true

            Console.WriteLine(allBetweenSmall);
            Console.WriteLine(allBetweenLarge);

            List<int> sampleNumbers = new List<int> { 18, 9, 5, 6, 84, 2, 5, 13 };
            bool areAllEven = sampleNumbers.All(number => number % 2 == 0);
            Console.WriteLine(areAllEven);

            IEnumerable<int> onlyEvens = sampleNumbers.Where(number => number % 2 == 0);
            onlyEvens.ToList().ForEach(evenValue => Console.WriteLine(evenValue + " is an even value"));

            IEnumerable<int> sampleNumbersSquared = sampleNumbers.Select(number => number * number);
            int small = sampleNumbers.Single(n => n < 5);
            Console.WriteLine(small);
        }
        public class CohortReport
        {
            public string CohortName { get; set; }
            public int StudentCount { get; set; }
        }

        public class Product
        {
            /*
            Properties
            */
            public string Title { get; set; }
            public double Price { get; set; }

            // Constructor method
            public Product(string title, double price)
            {
                this.Title = title;
                this.Price = price;
            }
        }

    }
}