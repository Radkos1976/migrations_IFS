using System;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;

namespace Event_plugin
{
    public class Event_Lst
    {


    }
    public class Event_History_LogNotify : IComparable<Event_History_LogNotify>,IEquatable<Event_History_LogNotify>
    {
        public double Log_id { get; set; }
        public string Module { get; set; }
        public string Lu_name { get; set; }
        public string Table_name { get; set; }
        public DateTime Time_stamp { get; set; }
        public string Keys { get; set; }
        public string History_type { get; set; }

        public int CompareTo([AllowNull] Event_History_LogNotify other)
        {
            if (other == null)
            {
                return 1;
            }
            else
            {
                return  Log_id.CompareTo(other.Log_id);              
            }
        }
        public bool Equals([AllowNull] Event_History_LogNotify other)
        {
            if (other == null) return false;
            return Log_id.Equals(other.Log_id);
        }
    }


}
