namespace CheapSkies.Interfaces
{
    public interface IRepository<T>
    {
        public List<T> _data { get; set; } 
        public void Add(T item);
        public void Fetch(T item);

    }
}