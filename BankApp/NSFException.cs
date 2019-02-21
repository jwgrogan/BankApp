using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public class NSFException : Exception
    {
        public NSFException(string message) : base(message)
        {
            
        }
    }
}
