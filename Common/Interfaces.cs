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
        /// Metods for main start of plugins
        /// </summary>
        public interface IRunnable
        {
            void Run();
        }
        /// <summary>
        /// List of diferences beetwen two same types of List T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public interface IChanges_list <T> where T :class,new()
        {
            public List<T> Insert { get; set; }
            public List<T> Update { get; set; }
            public List<T> Delete { get; set; }
        }
        /// <summary>
        /// Simple get dataset for Oracle database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public interface ISimpDBORAoperations <T> where T :class,new()
        {
            Task<List<T>> Get_Ora(string Sql_ora, string Task_name);
        }
        /// <summary>
        /// Compare two List T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public interface ICopmapreLST <T> where T : class, new()
        {
            IChanges_list<T> Changes(List<T> Old_list,
                                            List<T> New_list,
                                            string[] ID_column,
                                            string IntSorted_by,
                                            string guid_col);
            Task<int> PSTRG_Changes_to_dataTable(IChanges_list<T> _list,
                                                          string name_table,
                                                          string guid_col,
                                                          string[] query_before,
                                                          string[] query_after);
        }
        /// <summary>
        /// Simple get dataset for Posteggresql database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public interface ISimpPOSTGRoperations <T> where T : class, new()
        {
            Task<List<T>> Get_PSTGR(string Sql_ora,
                                    string Task_name);
        }
        /// <summary>
        /// Container for all impelementations of Idbmetods
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public interface IDBoperations<T> : ISimpDBORAoperations<T>, ISimpPOSTGRoperations<T>, ICopmapreLST<T> where T : class, new()
        {          
            

        }
    }
}
