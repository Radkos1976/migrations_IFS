using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using static Common.Interfaces;

namespace Accelerate_Possibilty
{
    public class Main
    {

        [Export(typeof(IRunnable))]
        [ExportMetadata("DisplayName", "Accelerate of orders")]
        [ExportMetadata("Description", "Calculate posibility of speedup orders")]
        [ExportMetadata("Version", "0.1")]
        public class Run_migrations : IRunnable
        {

            public void Run()
            {
                using Acceler_serv _Serv = new Acceler_serv();
                _Serv.Run();
            }
        }
        public class Acceler_serv : IDisposable
        {
            private static readonly string _pluginFolder = @"..\..\..\Plugins\";
            private CompositionContainer _container;
            private readonly DirectoryCatalog _catalog;
            public Acceler_serv()
            {
                _catalog = new DirectoryCatalog(_pluginFolder);
                _container = new CompositionContainer(_catalog);
                _container.ComposeParts(this);
            }
            private bool isDisposed = false;
            protected virtual void Dispose(bool disposing)
            {
                if (!isDisposed)
                {
                    if (disposing)
                    {
                        _catalog.Dispose();
                        _container.Dispose();
                    }
                }
                isDisposed = true;
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            public void Run()
            {
                throw new NotImplementedException();
            }

            private DateTime Start;
            public string serv_state = "Ready";



        }
    }
}
