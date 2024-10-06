using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_8_Dedok
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string University { get; set; }

        public Student(string firstName, string lastName, int age, string university)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            University = university;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}, {Age}, {University}";
        }
    }
    public class Employee
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }

        public Employee(string fullName, string position, string phoneNumber, string email, decimal salary)
        {
            FullName = fullName;
            Position = position;
            PhoneNumber = phoneNumber;
            Email = email;
            Salary = salary;
        }
        public override string ToString()
        {
            return $"{FullName}, {Position}, {PhoneNumber}, {Email}, {Salary:C}";
        }
    }
    public class Company
    {
        public string Name { get; set; }
        public Employee[] Employees { get; set; }

        public Company(string name, Employee[] employees)
        {
            Name = name;
            Employees = employees;
        }
    }
}
