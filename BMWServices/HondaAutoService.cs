using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMWServices
{
    public class HondaAutoService : IAutoService
    {
        public void GetService()
        {
            Console.WriteLine("You chose Honda auto service");
        }
    }
}
