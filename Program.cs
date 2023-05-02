using Microsoft.EntityFrameworkCore;
namespace PersonDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var contextDb = ApplicationContext.GetApplicationContext();


            var employee1 = new Employee {OfficialDuties = "teacher" };
            var employee2 = new Employee {OfficialDuties = "director" };


            var address1 = new Address {City = "Minsk", Street = "Kirova", HomeNumber = 32 };
            var address2 = new Address {City = "Gomel", Street = "Veselaya", HomeNumber = 55};
            var address3 = new Address {City = "Grodno", Street = "Bodotrio", HomeNumber = 85 };
            var address4 = new Address {City = "Mogilev", Street = "Sovetskaya", HomeNumber = 12 };

            var person1 = new Person {FirstName = "Karina", LastName = "Vinogradova", Employee = employee1, Address = address3};
            var person2 = new Person {FirstName = "Ivan", LastName = "Botorkova", Employee = employee2, Address = address2};
            var person3 = new Person {FirstName = "Natalia", LastName = "Dobraya", Employee = employee1, Address = address1 };
            
            
            
            /*
            contextDb.Employees.Add(employee1);
            contextDb.Employees.Add(employee2);
            contextDb.Persons.AddRange(person1, person2, person3);
            contextDb.Addresses.AddRange(address1, address2, address3);
            contextDb.SaveChanges();
            */


            var person4 = new Person {FirstName = "Galina", LastName = "Ivanova", Address = address1};
            var employee4 = contextDb.Employees.SingleOrDefault(x => x.Id == 1);
            person4.Employee = employee4;
            contextDb.Add(person4);
            contextDb.SaveChanges();


            var personsWithEmployees = contextDb.Persons.Join(contextDb.Employees,
                p => p.EmployeeId,
                e => e.Id,
                (p, e) => new
                {
                    PersonOfFicialDuties = e.OfficialDuties,
                    PersonFirstName = p.FirstName,
                    PersonLastName = p.LastName,
                    AddressCity = p.Address.City,
                }).OrderBy(x => x.PersonLastName);

            foreach (var u in personsWithEmployees)
            {
                Console.WriteLine($"{u.PersonFirstName} {u.PersonLastName} {u.AddressCity} {u.PersonOfFicialDuties}");
            }


            var personsWithAddresses = contextDb.Persons.Join(contextDb.Addresses,
            p => p.AddressId,
            a => a.Id,
            (p, a) => new
            {
                PersonFirstName = p.FirstName,
                PersonLastName = p.LastName,
                AddressCity = a.City,
                AddressStreet = a.Street,
                AddressNumber = a.HomeNumber
            });
            foreach (var p in personsWithAddresses)
            {
                Console.WriteLine($"Name: {p.PersonFirstName}  {p.PersonLastName}, Address: {p.AddressCity} - {p.AddressStreet}, {p.AddressNumber}");
            }
        }
    }
}