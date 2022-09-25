using Backend.Aids.Methods;

namespace Backend.Domain.Common
{
    public sealed class GetFrom<TRepository, TObject>
        where TRepository : IRepository<TObject>
        where TObject : class
    {
        internal TRepository repository => GetRepository.Instance<TRepository>();
        
        public TObject ById(Guid id)
            => Safe.Run(() => repository?.Get(id)?.GetAwaiter().GetResult(), default(TObject)); 
        public IReadOnlyList<TObject> ListBy(string field, string value){
            var r = repository;
            return list(r, field, value);
        }

        private static IReadOnlyList<TObject> list(TRepository r, string field, string value) {
            if (r is null) return new List<TObject>().AsReadOnly();
            
            return r.Get().GetAwaiter().GetResult();
        }
    }
}