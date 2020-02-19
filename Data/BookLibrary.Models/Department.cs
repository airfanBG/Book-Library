using BookLibrary.Data.Common.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookLibrary.Models
{
    public class Department: IAuditInfo<string>
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
            this.Id = Guid.NewGuid().ToString();
        }
        [Column("Department_Name")]
        [MinLength(3)]
        [MaxLength(20)]
        public string DepartmentName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
