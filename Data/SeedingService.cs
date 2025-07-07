using WebProjct.Models;
using Microsoft.EntityFrameworkCore;
using WebProjct.Models.enums;
namespace WebProjct.Data
{
    public class SeedingService
    {
        private readonly WebProjctContext _context;

        public SeedingService(WebProjctContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecords.Any())
            {
                return; //caso ja aja dados em algumas das tabelas acima
                        // siguinifica que o banco ja foi populado 
            }
            Department d1 = new Department(1, "Computadores");
            Department d2 = new Department(2, "Eletronicos");
            Department d3 = new Department(3, "Book");
            _context.Department.AddRange(d1, d2, d3);
            _context.SaveChanges();
            
            Seller s1 = new Seller(1, "victor lucas", "victor.lucas@gmail.com", new DateTime(2001, 4, 21), 2000.0, d1);
            Seller s2 = new Seller(2, "Ingrid", "Ingrid.ingrid@gmail.com", new DateTime(2005, 7, 15), 2000.0, d2);
            Seller s3 = new Seller(3, "tonho", "tonho.toni@gmail.com", new DateTime(2001, 4, 21), 2000.0, d3);

            _context.Seller.AddRange(s1, s2, s3);
            _context.SaveChanges();

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 25), 110000.0, SalerStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2020, 09, 15), 110000.0, SalerStatus.Billed, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2025, 09, 25), 110000.0, SalerStatus.Billed, s3);



            _context.SalesRecords.AddRange(r1, r2, r3);

            _context.SaveChanges();
        }
    }

}