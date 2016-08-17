using System;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Parser.Logic.Contracts.Providers;
using PCLStorage;

namespace Parser.Logic.FileReaders
{
    public class XmlFileProvider : IFileProvider
    {
        public async Task<bool> IsFileExist<T>()
        {
            var result = await FileSystem.Current.LocalStorage.CheckExistsAsync($"{typeof(T).Name}.xml");
            switch (result)
            {
                case ExistenceCheckResult.FileExists:

                    return true;

                case ExistenceCheckResult.FolderExists:

                    return false;

                case ExistenceCheckResult.NotFound:
                    return false;

                default:
                    return false;
            }
        }

        public async Task<T> Read<T>()
        {
            try
            {
                var file = await FileSystem.Current.LocalStorage.GetFileAsync($"{typeof(T).Name}.xml");
                using (var stream = await file.OpenAsync(FileAccess.ReadAndWrite))
                {
                    var writer = new XmlSerializer(typeof(T));
                    return (T) writer.Deserialize(stream);
                }
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public async Task<bool> Write<T>(T writeObject) where T : new()
        {
            try
            {
                var file =
                    await
                        FileSystem.Current.LocalStorage.CreateFileAsync($"{typeof(T).Name}.xml", CreationCollisionOption.OpenIfExists);

                using (var stream = await file.OpenAsync(FileAccess.ReadAndWrite))
                {
                    var writer = new XmlSerializer(typeof(T));
                    writer.Serialize(stream, writeObject);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}