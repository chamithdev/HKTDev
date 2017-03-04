using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HKT.Rating.Entity
{
    public class Rating
    {

        public int EmpId { get; set; }

        public int ReportYear { get; set; }

        public int RateBlock { get; set; }

        public DateTime RatedOn { get; set; }

        public int RatedBy { get; set; }

        public int CatId { get; set; }

        public int Rate { get; set; }


    }
}
