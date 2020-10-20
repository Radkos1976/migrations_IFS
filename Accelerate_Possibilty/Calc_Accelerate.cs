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
    internal class Acc_material_ord : IEquatable<Acc_material_ord>, IComparable<Acc_material_ord>
    {
        public string Cust_ord { get; set; }
        public DateTime Prom_date { get; set; }
        public DateTime Date_entered { get; set; }
        public string OrdId { get; set; }
        public int Dop { get; set; }
        public string Part_no { get; set; }
        public DateTime Work_day { get; set; }
        public DateTime Date_required { get; set; }
        public BigInteger Qty_ord { get; set; }
        public double Balance { get; set; }
        public string Ord_state { get; set; }
        public DateTime Data_dop {get;set;}

        public int CompareTo([AllowNull] Acc_material_ord other)
        {
            throw new NotImplementedException();
        }

        public bool Equals([AllowNull] Acc_material_ord other)
        {
            throw new NotImplementedException();
        }
    }
    internal class Acc_balance
    {
        public  string Part_no { get; set; }
        public string Balance { get; set; }
        public DateTime Work_day { get; set; }
    }

}
