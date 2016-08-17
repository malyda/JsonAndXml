using System;
using System.Threading.Tasks;
using Ninject;
using Parser.Logic.Contracts.Entities;
using Parser.Logic.Contracts.Providers;

namespace Parser
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Person person = null;

            // Init Dependency Injection
            var kernel = new StandardKernel(new ParserModule());
            var fileprovider = kernel.Get<IFileProvider>();

            // Default object
            var personInit = new Person
            {
                Name = "Vojtech Mádr",
                Email = "madrvojtech@outlook.com"
            };

            // WriteFile
            var createFile = fileprovider.Write(personInit);
            Task.WaitAll(createFile);
            var isFileCreated = createFile.Result;


            // ReadFile
            if (isFileCreated)
            {
                var readFile = fileprovider.Read<Person>();
                Task.WaitAll(readFile);
                person = readFile.Result;
            }

            // Condition
            if (person != null && personInit.Name == person?.Name && personInit.Email == person?.Email)
            {
                Console.WriteLine("Write and Read is OK");
            }
            else
            {
                Console.WriteLine("Write and Read Error");
            }
        }
    }
}