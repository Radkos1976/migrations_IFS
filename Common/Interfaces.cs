using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common
{
    public class Interfaces
    {
        /// <summary>
        /// Interface For info of subprogram
        /// </summary>
        public interface IPluginInfo
        {
            string DisplayName { get; }
            string Description { get; }
            string Version { get; }
        }
        /// <summary>
        /// Interface of Loger with metods
        /// </summary>
        public interface IDB_Loger
        {
            void Log(string txt);
            void Srv_start();
            void Srv_stop();
            DateTime Serw_run { get; }
        }
        /// <summary>
        /// Metods for main of plugins
        /// </summary>
        public interface IRunnable
        {
            void Run();
        }
        public interface ISimpDBORAoperations <T> where T :class,new()
        {
            Task<List<T>> Get_Ora(string Sql_ora, string Task_name);
        }
        public interface ISimpPOSTGRoperations <T> where T : class, new()
        {
            Task<List<T>> Get_PSTGR(string Sql_ora, string Task_name);

        }        
        public interface IDBoperations<T> : ISimpDBORAoperations <T>, ISimpPOSTGRoperations<T> where T : class, new()
        {          
            

        }
    }
}
