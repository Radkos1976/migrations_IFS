using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using static Common.Interfaces;

namespace conf_service_dot
{
    class Start : IDisposable
    {
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
        private CompositionContainer _container;
        private DirectoryCatalog _catalog;

        [ImportMany(AllowRecomposition = true)]
        public List<Lazy<IRunnable, IPluginInfo>> Plugins { get; set; }

        public Start(string pluginFolder)
        {
            _catalog = new DirectoryCatalog(pluginFolder);
            _container = new CompositionContainer(_catalog);
            LoadPlugins();
        }

        public void LoadPlugins()
        {
            try
            {
                _catalog.Refresh();
                _container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }
    }
}
