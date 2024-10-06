//1
using Microsoft.VisualBasic;
using Practice_8_Dedok;
List<int> numbers = new List<int> { 2, 7, 14, 21, 28, 32, 45, 56, 63, 70, 81, 88, 96 };
Console.WriteLine("Task_1: ");
Console.WriteLine("Весь масив цілих чисел:");
numbers.ForEach(n => Console.Write(n + " "));
Console.WriteLine();

var evenNumbers = from n in numbers
                  where n % 2 == 0
                  select n;

Console.WriteLine("\nПарні числа:");
foreach (var num in evenNumbers)
{
    Console.Write(num + " ");
}
Console.WriteLine();

var oddNumbers = from n in numbers
                 where n % 2 != 0
                 select n;

Console.WriteLine("\nНепарні числа:");
foreach (var num in oddNumbers)
{
    Console.Write(num + " ");
}
Console.WriteLine();

int rangeStart = 10;
int rangeEnd = 60;
var numbersInRange = from n in numbers
                     where n >= rangeStart && n <= rangeEnd
                     select n;

Console.WriteLine($"\nЧисла в діапазоні від {rangeStart} до {rangeEnd}:");
foreach (var num in numbersInRange)
{
    Console.Write(num + " ");
}
Console.WriteLine();

var multiplesOfSeven = from n in numbers
                       where n % 7 == 0
                       orderby n
                       select n;
Console.WriteLine("\nЧисла, кратні семи, відсортовані:");
foreach (var num in multiplesOfSeven)
{
    Console.Write(num + " ");
}
Console.WriteLine();

var multiplesOfEight = from n in numbers
                       where n % 8 == 0
                       orderby n descending
                       select n;
Console.WriteLine("\nЧисла, кратні восьми, відсортовані за спаданням:");
foreach (var num in multiplesOfEight)
{
    Console.Write(num + " ");
}
Console.WriteLine();
//2
Console.WriteLine("Task_2: ");
string[] cities = { "New York", "Amsterdam", "Berlin", "Helsinki", "Kyiv", "London", "Naples", "Stockholm", "Tokyo" };
Console.WriteLine("Весь масив міст: ");
foreach (var city in cities)
{
    Console.WriteLine(city);
}
int nameLength = 6;
var citiesWithSpecificLength = from city in cities
                               where city.Length == nameLength
                               select city;
Console.WriteLine($"\nМіста з довжиною назви {nameLength}");
foreach (var city in citiesWithSpecificLength)
{
    Console.WriteLine(city);
}
var citiesStartingWithA = from city in cities
                          where city.StartsWith("A", StringComparison.OrdinalIgnoreCase)
                          select city;
Console.WriteLine("\nМіста, назви яких починаються з літери 'A':");
foreach (var city in citiesStartingWithA)
{
    Console.WriteLine(city);
}
var citiesEndingWithM = from city in cities
                        where city.EndsWith("m", StringComparison.OrdinalIgnoreCase)
                        select city;
Console.WriteLine("\nМіста, назви яких закінчуються літерою 'M':");
foreach (var city in citiesEndingWithM)
{
    Console.WriteLine(city);
}
var citiesStartingWithNEndingWithK = from city in cities
                                     where city.StartsWith("N", StringComparison.OrdinalIgnoreCase) &&
                                           city.EndsWith("k", StringComparison.OrdinalIgnoreCase)
                                     select city;
Console.WriteLine("\nМіста, назви яких починаються з літери 'N' і закінчуються літерою 'K':");
foreach (var city in citiesStartingWithNEndingWithK)
{
    Console.WriteLine(city);
}
Console.WriteLine();
//3 - 7 
Console.WriteLine("Task_3-7: ");
Student[] students = {
            new Student("John", "Brown", 20, "Oxford"),
            new Student("Emma", "Brooks", 22, "Cambridge"),
            new Student("David", "Johnson", 19, "Oxford"),
            new Student("Linda", "Browne", 23, "Oxford")
        };

Console.WriteLine("Всі студенти:");
foreach (var student in students)
{
    Console.WriteLine(student);
}

Console.WriteLine("\nСтуденти з прізвищем, яке починається з 'Bro':");
var studentsWithBro = students.Where(s => s.LastName.StartsWith("Bro")).ToList();
studentsWithBro.ForEach(s => Console.WriteLine(s));

Console.WriteLine("\nСтуденти, старші 19 років:");
var studentsOlderThan19 = students.Where(s => s.Age > 19).ToList();
studentsOlderThan19.ForEach(s => Console.WriteLine(s));

Console.WriteLine("\nСтуденти, старші 20 років і молодші 23 років:");
var studentsBetween20And23 = students.Where(s => s.Age > 20 && s.Age < 23).ToList();
studentsBetween20And23.ForEach(s => Console.WriteLine(s));

Console.WriteLine("\nСтуденти, які навчаються в Oxford і старші 18 років, за спаданням віку:");
var oxfordStudentsOlderThan18 = students
    .Where(s => s.University == "Oxford" && s.Age > 18)
    .OrderByDescending(s => s.Age)
    .ToList();
oxfordStudentsOlderThan18.ForEach(s => Console.WriteLine(s));

Company[] companies = {
            new Company("TechCorp", new Employee[] {
                new Employee("Alice Johnson", "Manager", "2345678901", "alice@techcorp.com", 70000),
                new Employee("Bob Brown", "Developer", "2312345678", "bob@techcorp.com", 65000)
            }),
            new Company("BizInc", new Employee[] {
                new Employee("Charlie Davis", "Manager", "2311234567", "charlie@bizinc.com", 80000),
                new Employee("David Smith", "Analyst", "2387654321", "david@bizinc.com", 55000),
                new Employee("Lionel Messi", "Consultant", "2398765432", "lionel@bizinc.com", 120000)
            })
        };

Console.WriteLine("\nПрацівники фірми TechCorp:");
var employeesOfCompany = companies.FirstOrDefault(c => c.Name == "TechCorp")?.Employees;
if (employeesOfCompany != null)
{
    foreach (var employee in employeesOfCompany)
    {
        Console.WriteLine(employee);
    }
}

Console.WriteLine("\nПрацівники фірми BizInc з заробітною платою більше 60000:");
var employeesWithHighSalary = companies
    .FirstOrDefault(c => c.Name == "BizInc")?.Employees
    .Where(e => e.Salary > 60000)
    .ToList();
employeesWithHighSalary?.ForEach(e => Console.WriteLine(e));

Console.WriteLine("\nМенеджери усіх фірм:");
var managers = companies
    .SelectMany(c => c.Employees)
    .Where(e => e.Position == "Manager")
    .ToList();
managers.ForEach(e => Console.WriteLine(e));

Console.WriteLine("\nПрацівники з телефоном, що починається з '23':");
var employeesWithPhoneStarting23 = companies
    .SelectMany(c => c.Employees)
    .Where(e => e.PhoneNumber.StartsWith("23"))
    .ToList();
employeesWithPhoneStarting23.ForEach(e => Console.WriteLine(e));

Console.WriteLine("\nПрацівники з Email, що починається з 'di':");
var employeesWithEmailStartingDi = companies
    .SelectMany(c => c.Employees)
    .Where(e => e.Email.StartsWith("di"))
    .ToList();
employeesWithEmailStartingDi.ForEach(e => Console.WriteLine(e));

Console.WriteLine("\nПрацівники з ім'ям Lionel:");
var employeesNamedLionel = companies
    .SelectMany(c => c.Employees)
    .Where(e => e.FullName.StartsWith("Lionel"))
    .ToList();
employeesNamedLionel.ForEach(e => Console.WriteLine(e));
Console.WriteLine();
//4
Console.WriteLine("Task_4: ");
var companies_1 = new[]
        {
            new Company_1 { Name = "FoodTech", FoundationDate = new DateTime(2021, 5, 10), BusinessProfile = "IT", DirectorFullName = "John White", NumberOfEmployees = 150, Address = "London" },
            new Company_1 { Name = "WhiteFood Solutions", FoundationDate = new DateTime(2020, 1, 15), BusinessProfile = "Marketing", DirectorFullName = "Sarah Black", NumberOfEmployees = 250, Address = "London" },
            new Company_1 { Name = "Tech Innovators", FoundationDate = new DateTime(2019, 11, 20), BusinessProfile = "IT", DirectorFullName = "Michael Green", NumberOfEmployees = 50, Address = "New York" },
            new Company_1 { Name = "Marketing Pros", FoundationDate = new DateTime(2022, 2, 1), BusinessProfile = "Marketing", DirectorFullName = "Emma White", NumberOfEmployees = 400, Address = "Paris" },
        };

var allCompanies = companies_1.Select(c => c);

var foodCompanies = companies_1.Where(c => c.Name.Contains("Food"));

var marketingCompanies = companies_1.Where(c => c.BusinessProfile == "Marketing");

var marketingOrItCompanies = companies_1.Where(c => c.BusinessProfile == "Marketing" || c.BusinessProfile == "IT");

var companiesWithMoreThan100Employees = companies_1.Where(c => c.NumberOfEmployees > 100);

var companiesWith100To300Employees = companies_1.Where(c => c.NumberOfEmployees >= 100 && c.NumberOfEmployees <= 300);

var londonCompanies = companies_1.Where(c => c.Address == "London");

var companiesWithDirectorWhite = companies_1.Where(c => c.DirectorFullName.Split(' ').Last() == "White");

var companiesFoundedMoreThanTwoYearsAgo = companies_1.Where(c => (DateTime.Now - c.FoundationDate).TotalDays > 365 * 2);

var companiesFounded123DaysAgo = companies_1.Where(c => (DateTime.Now - c.FoundationDate).TotalDays == 123);

var companiesWithDirectorBlackAndWhiteInName = companies_1.Where(c => c.DirectorFullName.Split(' ').Last() == "Black" && c.Name.Contains("White"));

Console.WriteLine("All Companies:");
foreach (var company in allCompanies) Console.WriteLine(company.Name);

Console.WriteLine("\nCompanies with 'Food' in the name:");
foreach (var company in foodCompanies) Console.WriteLine(company.Name);
Console.WriteLine();
//5
Console.WriteLine("Task_5: ");
int[] numbers_1 = { 121, 75, 81 };

var sortedAscending = numbers_1.OrderBy(n => n.ToString().Sum(c => c - '0')).ToArray();

var sortedDescending = numbers_1.OrderByDescending(n => n.ToString().Sum(c => c - '0')).ToArray();

Console.WriteLine("Сортування за зростанням суми цифр:");
foreach (var number in sortedAscending) Console.WriteLine(number);

Console.WriteLine("\nСортування за зменшенням суми цифр:");
foreach (var number in sortedDescending) Console.WriteLine(number);
Console.WriteLine();
//6
Console.WriteLine("Task_6: ");
int[] array1 = { 1, 2, 3, 4, 5, 5 };
int[] array2 = { 3, 4, 5, 6, 7 };

var difference = array1.Except(array2).ToArray();

var intersection = array1.Intersect(array2).ToArray();

var union = array1.Union(array2).ToArray();

var distinctArray1 = array1.Distinct().ToArray();

Console.WriteLine("Різниця масивів (array1 - array2):");
foreach (var item in difference) Console.WriteLine(item);

Console.WriteLine("\nПеретин масивів:");
foreach (var item in intersection) Console.WriteLine(item);

Console.WriteLine("\nОб'єднання масивів:");
foreach (var item in union) Console.WriteLine(item);

Console.WriteLine("\nПерший масив без повторень:");
foreach (var item in distinctArray1) Console.WriteLine(item);