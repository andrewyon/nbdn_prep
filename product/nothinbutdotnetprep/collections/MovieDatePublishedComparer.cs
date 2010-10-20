using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class MovieDatePublishedComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            //0 - x and y sort the same
            //>0 - x sorts greater than y
            //<0 - x sorts less than y
            return x.date_published.CompareTo(y.date_published);
        }
    }
}