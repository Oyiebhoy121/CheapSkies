namespace CheapSkies.Interfaces
{
    public interface IRepository<T>
    {
        public List<T> _data { get; set; } 
        public void AddData(T item);
        public List<T> GetData(T item);

    }
}