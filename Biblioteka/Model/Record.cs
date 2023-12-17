using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public abstract class Record
    {
        public Record() 
        { 
        
        }

        public abstract string toCSV();
    }
}
