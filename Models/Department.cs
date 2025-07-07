using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace WebProjct.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSaller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSaler(DateTime initial, DateTime final) => Sellers.Sum(seller => seller.TotalSals(initial, final));
    }
}