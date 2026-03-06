using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern
{
    public class FlavourService
    {
        public string GetFlavour()
        {
            Console.WriteLine("Checking available flavours...");
            return "Vanilla Ice Creame";
        }
    }
}