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
                Name = "Spencer",
                CohortName = "Day Cohort 37"
                },

                new Student()
                {
                Name = "Heidi",
                CohortName = "Day Cohort 35"
                },

                new Student()
                {
                Name = "Namita",
                CohortName = "Day Cohort 37"
                },

                new Student()
                {
                Name = "Holden",
                CohortName = "Day Cohort 37"
                },

                new Student()
                {
                Name = "Aryn",
                CohortName = "Day Cohort 35"
                },

                new Student()
                {
                Name = "Aryn",
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
        }
        public class CohortReport
        {
            public string CohortName { get; set; }
            public int StudentCount { get; set; }
        }
    }
}