using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using WebProjct.Data;
using WebProjct.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebProjct.Service.Exception;

namespace WebProjct.Service
{
    public class SellerService
    {
        private readonly WebProjctContext _context;

        public SellerService(WebProjctContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
        public List<Department> FindAllDepartments()
        {
            return _context.Department.ToList();
        }

        public List<Department> FindAllDepartments2(int value)
        {
            return _context.Department.ToList();
        }

        public void Inserts(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _context.Seller.FirstOrDefault(obj => obj.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            if (obj != null)
            {
                _context.Seller.Remove(obj);
            }
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFuondExceptions("ID NOT FOUND");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}