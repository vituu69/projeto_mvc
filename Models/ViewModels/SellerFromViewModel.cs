using System;
using System.Collections.Generic;
using System.Linq;


namespace WebProjct.Models.ViewModels
{
    public class SellerFromViewModel
    {
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }
    
    }
}