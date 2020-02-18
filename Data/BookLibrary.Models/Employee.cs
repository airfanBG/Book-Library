using BookLibrary.Data.Common.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookLibrary.Models
{
    public class Employee: BaseDeletableModel<string>
    {
        public Employee()
        {
            EmployeeNumber = Guid.NewGuid().ToString().Substring(0, 5);
            this.Id = Guid.NewGuid().ToString();
        }
        public string EmployeeNumber { get; set; }
        public Department Department { get; set; }
       
        public User User { get; set; }
    }
}
