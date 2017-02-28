using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HKT.Rating.Entity
{
    public class Rating
    {

        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int RatingCategoryId { get; set; }

        public int Rate { get; set; }


    }
}
