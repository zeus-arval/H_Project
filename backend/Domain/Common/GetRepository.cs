using Backend.Aids.Methods;
namespace Backend.Domain.Common
{
    public static class GetRepository
    {
        internal static IServiceProvider services;
        public static void SetServiceProvider(IServiceProvider provider) => services = provider;
        public static T Instance<T>() => instance<T>(services);
        public static object Instance(Type t) => instance(services, t);
        internal static T instance<T>(IServiceProvider s)
            => Safe.Run(() => {
                if (s is null) return default;
                var i = s.GetRequiredService<T>();
                return i;
        }, null);
        internal static object instance(IServiceProvider s, Type t)
            => Safe.Run(() => 
            {
                var i = s?.GetRequiredService(t);
                return i;
            }, null);
    }
}