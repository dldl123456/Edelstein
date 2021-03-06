using System;
using System.Threading.Tasks;

namespace Edelstein.Provider.Parser
{
    public interface IDataProperty : IDataDirectory
    {
        IDataProperty Parent { get; }

        void Resolve(Action<IDataProperty> context);

        T? Resolve<T>(string path = null) where T : struct;
        T ResolveOrDefault<T>(string path = null) where T : class;

        Task<T?> ResolveAsync<T>(string path = null) where T : struct;
        Task<T> ResolveOrDefaultAsync<T>(string path = null) where T : class;
    }
}