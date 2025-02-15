using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBFirstDemo.Infrastructure.Data.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Departments = new HashSet<Department>();
            InverseManager = new HashSet<Employee>();
            Projects = new HashSet<Project>();
        }

        [Key]
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string LastName { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string? MiddleName { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string JobTitle { get; set; } = null!;
        [Column("DepartmentID")]
        public int DepartmentId { get; set; }
        [Column("ManagerID")]
        public int? ManagerId { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime HireDate { get; set; }
        [Column(TypeName = "money")]
        public decimal Salary { get; set; }
        [Column("AddressID")]
        public int? AddressId { get; set; }

        [ForeignKey("AddressId")]
        [InverseProperty("Employees")]
        public virtual Address? Address { get; set; }
        [ForeignKey("DepartmentId")]
        [InverseProperty("Employees")]
        public virtual Department Department { get; set; } = null!;
        [ForeignKey("ManagerId")]
        [InverseProperty("InverseManager")]
        public virtual Employee? Manager { get; set; }
        [InverseProperty("Manager")]
        public virtual ICollection<Department> Departments { get; set; }
        [InverseProperty("Manager")]
        public virtual ICollection<Employee> InverseManager { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("Employees")]
        public virtual ICollection<Project> Projects { get; set; }
    }
}
