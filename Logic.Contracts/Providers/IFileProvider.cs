using System.Threading.Tasks;

namespace Parser.Logic.Contracts.Providers
{
    public interface IFileProvider
    {
        Task<bool> IsFileExist<T>();
        Task<T> Read<T>();
        Task<bool> Write<T>(T writeObject) where T : new();
    }
}