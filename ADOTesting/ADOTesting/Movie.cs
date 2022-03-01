using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOTesting
{
    public class Movie
    {
        //While you could do this, it is not typically done this way
        //public Movie(System.Data.IDataReader r)
        //{
        //    Id = r.GetInt32(0);
        //    //etc...
        //}
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Released { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int RatingID { get; set; }

        public override string ToString()
        {
            return $"{Id,3} {Title,-35} {Released,25} {Hours,3} {Minutes,4} {RatingID}";
        }
    }
}
