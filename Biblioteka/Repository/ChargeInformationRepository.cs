using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repository
{
    internal class ChargeInformationRepository : Repository<ChargeInformation>
    {
        public ChargeInformationRepository() 
        {
            
        }
        public bool ChargeInformationForSpecificReader(int readerID)
        {
            foreach (ChargeInformation chargeInformation in ElementList)
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
            if(CheckIfStartDateIsEarlierThanFinishDate(startDate,finishDate)) 
            { 
                foreach (ChargeInformation chargeInformation in ElementList)
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
            return finishDate >= startDate;
        }
    }
}
