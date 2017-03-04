using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace HKT.Employee.Entity
{
    public class Employee
    {

        public int EmpId { get; set; }

        public bool EmpStatus { get; set; }

        public string EmpName { get; set; }

        public int DepartmentId { get; set; }

        public string EmpEmail { get; set; }

        public byte[] Photo { get; set; }

        public int StartMonth { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }


    }
}
