using Ninject.Modules;
using Parser.Logic.Contracts.Providers;
using Parser.Logic.FileReaders;

namespace Parser
{
    public class ParserModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IFileProvider>().To<JsonFileProvider>().InSingletonScope();
            Bind<IFileProvider>().To<XmlFileProvider>().InSingletonScope();
        }
    }
}
