using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOTesting
{
    public class MovieMapper
    {
        //private ordinals
        int _IDOffset;          // Expected to be 0
        int _TitleOffset;       // Expected to be 1
        int _ReleasedOffset;    // Expected to be 2
        int _HoursOffset;       // Expected to be 3
        int _MinutesOffset;     // Expected to be 4
        int _RatingIDOffset;    // Expected to be 5

        public MovieMapper(System.Data.IDataReader r)
        {
            _IDOffset = r.GetOrdinal("ID");
            if(_IDOffset != 0)
            {
                throw new Exception($"The ID 'column is not valid. I expected it to be 0, and it is {_IDOffset}");
            }
            _TitleOffset = r.GetOrdinal("Title");
            if (_TitleOffset != 1)
            {
                throw new Exception($"The Title 'column is not valid. I expected it to be 1, and it is {_TitleOffset}");
            }
            _ReleasedOffset = r.GetOrdinal("Released");
            _HoursOffset = r.GetOrdinal("Hours");
            _MinutesOffset = r.GetOrdinal("Minutes");
            _RatingIDOffset = r.GetOrdinal("RatingID");


        }

        public Movie MapMovie(System.Data.IDataReader r)
        {
            Movie m = new Movie();
            m.Id = r.GetInt32(_IDOffset);
            m.Title = r.GetString(_TitleOffset);
            m.Hours = r.GetInt32 (_HoursOffset);
            m.Minutes = r.GetInt32 (_MinutesOffset);
            if (r.IsDBNull(_ReleasedOffset))
            {
                m.Released = GetString(_ReleasedOffset);
            }
            
            m.RatingID = r.GetInt32(_RatingIDOffset);

            return m;
        }
    }
}
