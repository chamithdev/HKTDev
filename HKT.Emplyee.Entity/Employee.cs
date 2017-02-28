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

        public int Id { get; set; }

        public string Name { get; set; }

        public int DepartmentId { get; set; }

        public string RatingContext { get; set; }

        public byte[] Photo { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }


    }
}
