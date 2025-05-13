namespace generics.Interfaces
{
    interface IRepository<TEntity, TKey> where TEntity : class, new() where TKey    : struct
    { 
        void Add(TKey id, TEntity entity);
        TEntity Get(TKey id);
        IEnumerable<TEntity> GetAll();
        void Remove(TKey id); 
    }

    class InMemoryRepository<TEntity,TKey> : IRepository<TEntity,TKey>, IReadOnlyRepository<TEntity,TKey> where TEntity : class, new() where TKey    : struct {
        private Dictionary<TKey, TEntity> _entities = new Dictionary<TKey, TEntity>();

        public void Add(TKey id, TEntity entity)
        {
            _entities.Add(id, entity);
        }

        public TEntity Get(TKey id)
        {
            return _entities[id];
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities.Values;
        }

        public void Remove(TKey id)
        {
            _entities.Remove(id);
        }
    }

    interface IReadOnlyRepository<out TEntity, in TKey> {
        TEntity Get(TKey id);
        IEnumerable<TEntity> GetAll();
    }
}
