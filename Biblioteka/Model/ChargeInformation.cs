using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    internal class ChargeInformation : Record
    {
        private decimal Charge { get; }
        private Reader Reader { get; }
        private DateTime DateOfCharge { get; }
        public ChargeInformation(decimal charge, Reader reader)
        {
            this.Charge = charge;
            this.Reader = reader;
            DateOfCharge = DateTime.Now;
        }
        public ChargeInformation(decimal charge, Reader reader, DateTime dateTime)
        {
            this.Charge = charge;
            this.Reader = reader;
            DateOfCharge = dateTime;
        }
            public decimal GetCharge()
        {
            return Charge;
        }
        public Reader GetReader()
        {
            return Reader;
        }
        public DateTime GetDateOfCharge()
        {
            return DateOfCharge;
        }
        public override string ToString()
        {
            return "Opłata: " + Charge + "zł, czytelnik: " + Reader.GetFullname() + ", data: " + DateOfCharge;
        }
        public override string ToCSV()
        {
            string newCharge = Charge.ToString().Replace(",", ".");
            return newCharge + "," + Reader.GetID() + "," + DateOfCharge;
        }
    }
}
