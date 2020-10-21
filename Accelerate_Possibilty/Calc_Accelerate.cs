using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text;

namespace Accelerate_Possibilty
{
  
    class Calc_Accelerate 
    {

    }
    /// <summary>
    /// Records for calculations of possibilty acceleration orders by scheduled materials streams
    /// </summary>
    internal class Acc_material_ord : IEquatable<Acc_material_ord>, IComparable<Acc_material_ord>
    {
        public string Cust_ord { get; set; }
        public DateTime Prom_date { get; set; }
        public DateTime Date_entered { get; set; }
        public string OrdId { get; set; }
        public int Dop { get; set; }
        public int Dop_lin { get; set; }
        public string Part_no { get; set; }
        public DateTime Work_day { get; set; }
        public DateTime Date_required { get; set; }
        public BigInteger Qty_ord { get; set; }
        public double Balance { get; set; }
        public string Ord_state { get; set; }
        public DateTime Data_dop {get;set;}
        /// <summary>
        /// Default sort by work_day,part_no,prom_date,ordid,dop,dop_lin all not null
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo([AllowNull] Acc_material_ord other)
        {
            if (other == null)
            {
                return 1;
            }
            else
            {
                int result = Work_day.Date.CompareTo(other.Date_entered.Date);
                if (result == 0)
                { result = Part_no.CompareTo(other.Part_no);
                    if (result == 0)
                    {
                        result = Prom_date.Date.CompareTo(other.Prom_date.Date);
                        if (result==0)
                        {
                            result = OrdId.CompareTo(other.OrdId);
                            if (result==0)
                            {
                                result = Dop.CompareTo(other.Dop);
                                if (result==0)
                                {
                                    result = Dop_lin.CompareTo(other.Dop_lin);
                                }
                            }
                        }
                    }
                }
                return result;
            }
        }
        /// <summary>
        /// Equatable by Work_day,Part_no,OrdId,Dop,Dop_lin
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals([AllowNull] Acc_material_ord other)
        {
            if (other == null) return false;
            return Work_day.Date.Equals(other.Work_day.Date) && Part_no.Equals(other.Part_no)&&OrdId.Equals(other.OrdId)&&Dop.Equals(other.Dop)&&Dop_lin.Equals(other.Dop_lin) ;
        }        
    }
    /// <summary>
    /// Helpers records for calculations of balances materials.
    /// </summary>
    internal class Acc_balance :IEquatable<Acc_balance>,IComparable<Acc_balance>
    {
        public  string Part_no { get; set; }
        public string Balance { get; set; }
        public DateTime Work_day { get; set; }
        /// <summary>
        /// Default sort work_day,part_no
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo([AllowNull] Acc_balance other)
        {
            int result = Work_day.CompareTo(other.Work_day);
            if (result == 0) result = Part_no.CompareTo(other.Part_no);
            return result;
        }
        /// <summary>
        /// Equtable by Work_day,part_no
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals([AllowNull] Acc_balance other)
        {
            return Work_day.Equals(other.Work_day) && Part_no.Equals(other.Part_no);
        }
    }

}
