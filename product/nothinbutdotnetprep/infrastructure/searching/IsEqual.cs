namespace nothinbutdotnetprep.infrastructure.searching
{
    public class IsEqual<T> : Criteria<T>
    {
        T value;

        public IsEqual(T value)
        {
            this.value = value;
        }

        public bool is_satisfied_by(T item)
        {
            return item.Equals(value);
        }
    }
}