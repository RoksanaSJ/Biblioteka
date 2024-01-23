using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repository
{
    internal class ChargeInformationRepository
    {
        protected List<ChargeInformation> ChargeInformationList { get; }
        public ChargeInformationRepository() 
        {
            ChargeInformationList = new List<ChargeInformation>();
        }
        public List<ChargeInformation> GetChargeInformation()
        {
            return ChargeInformationList;
        }
        public void ListChargeIformation()
        {
            foreach (ChargeInformation chargeInformation in ChargeInformationList)
            {
                Console.WriteLine(chargeInformation);
            }
        }
        public void AddChargeInformation(ChargeInformation chargeInformation)
        {
            ChargeInformationList.Add(chargeInformation);
        }
        public bool ChargeInformationForSpecificReader(int readerID)
        {
            foreach (ChargeInformation chargeInformation in ChargeInformationList)
            {
                if (chargeInformation.GetReader().GetID() == readerID)
                {
                    Console.WriteLine(chargeInformation);
                    return true;
                }
            }
            return false;
        }
        public void PrintHistoryFromPeriod(DateTime startDate, DateTime finishDate)
        {
            if(CheckIfStartDateIsEarlierThanFinishDate(startDate,finishDate) == true) 
            { 
                foreach (ChargeInformation chargeInformation in ChargeInformationList)
                {
                    if (chargeInformation.GetDateOfCharge() >= startDate && chargeInformation.GetDateOfCharge() <= finishDate)
                    {
                        Console.WriteLine(chargeInformation.ToString());
                    }
                }
            }
        }
        public bool CheckIfStartDateIsEarlierThanFinishDate(DateTime startDate, DateTime finishDate)
        {
            if (finishDate >= startDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
