﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model.Utils
{

    internal class IDGenerator
    {
        protected static int nextID = 0;
        public IDGenerator() 
        {

        }
        public static int generateID()
        {
            nextID++;
            return nextID;
        }
    }
}