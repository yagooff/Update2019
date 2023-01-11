using System;
using System.Collections.Generic;
using System.Linq;


namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Nema { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSaraly { get; set; }
        public Department Department { get; set; }
        public ICollection <SalesRecord> Sales { get; set; } = new List<SalesRecord>();
        
        public Seller()
        {

        }

        public Seller(int id, string nema, string email, DateTime birthDate, double baseSaraly, Department department)
        {
            Id = id;
            Nema = nema;
            Email = email;
            BirthDate = birthDate;
            BaseSaraly = baseSaraly;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);   
        }

        public double TotalSales (DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
