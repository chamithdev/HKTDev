using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HKT.Common
{
    public class RatingResult<T> 
    {

        public IList<T> Items { get; set; }

        public int Count { get; set; }

        public int Page { get; set; }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}
