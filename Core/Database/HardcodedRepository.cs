namespace Core.Database
{
    internal class HardcodedRepository<T> : IRepository<T> where T : class
    {
        private readonly List<T> source;

        public HardcodedRepository(IEnumerable<T> source)
        {
            this.source = new List<T>(source);
        }

        public async Task<T> CreateAsync(T entity)
        {
            source.Add(entity);
            return await Task.FromResult(entity);
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.FromResult(source);
        }
    }
}
