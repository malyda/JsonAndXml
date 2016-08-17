using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Parser.Logic.Contracts.Providers;
using PCLStorage;
using System.IO;
using Newtonsoft.Json;

namespace Parser.Logic.FileReaders
{
    public class JsonFileProvider : IFileProvider
    {
        public async Task<bool> IsFileExist<T>()
        {
            var result = await FileSystem.Current.LocalStorage.CheckExistsAsync($"{typeof(T).Name}.json");
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
                var file = await FileSystem.Current.LocalStorage.GetFileAsync($"{typeof(T).Name}.json");
                using (var stream = await file.OpenAsync(FileAccess.ReadAndWrite))
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        using (var jsonReader = new JsonTextReader(streamReader))
                        {
                            var serializer = new JsonSerializer();
                            return serializer.Deserialize<T>(jsonReader);
                        }
                    }
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
                        FileSystem.Current.LocalStorage.CreateFileAsync($"{typeof(T).Name}.json", CreationCollisionOption.OpenIfExists);

                using (var stream = await file.OpenAsync(FileAccess.ReadAndWrite))
                {                   
                    using (var streamWriter = new StreamWriter(stream))
                    {
                        using (var jsonWriter = new JsonTextWriter(streamWriter))
                        {
                            var serializer = new JsonSerializer();
                            serializer.Serialize(jsonWriter, writeObject);
                        }

                    }

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
