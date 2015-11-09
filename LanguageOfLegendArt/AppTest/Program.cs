using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageOfLegendArt.Core.LanguageOfLegendArt;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.User;

namespace AppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var cntroler = new UserController();
            var lstData = cntroler.GetAll();
            Console.Write(lstData.Count);
            Console.ReadLine();
        }
    }
}
