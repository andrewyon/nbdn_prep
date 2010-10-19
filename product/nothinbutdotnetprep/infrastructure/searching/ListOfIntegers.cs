using System;
using System.Collections;
using System.Data.SqlClient;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class ListOfIntegers
    {
        IList items = new ArrayList();

        public void add(int number)
        {
            items.Add(number);
        }
    }

    public class ListOfDates
    {
        IList items = new ArrayList();

        public void add(DateTime date_time)
        {

        }
    }

    public class MyDisposableComparable : IDisposable,
        IComparable<MyDisposableComparable>
    {
        public MyDisposableComparable(int number)
        {
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(MyDisposableComparable other)
        {
            throw new NotImplementedException();
        }
    }

    public class ListOf<T> where T : IDisposable,IComparable<T>,new()
    {
        IList items = new ArrayList();

        public void add(T t)
        {
            items.Add(t);

            var t1 = new T();
        }
    }
}