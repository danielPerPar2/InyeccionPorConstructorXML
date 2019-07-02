using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMWServices
{
    public class AutoServiceCallerImp : IAutoServiceCaller
    {
        private BMWAutoService bmwAutoService;
        private FordAutoService fordAutoService;
        private HondaAutoService hondaAutoService;

        public AutoServiceCallerImp(BMWAutoService bmwAutoService, 
            FordAutoService fordAutoService, 
            HondaAutoService hondaAutoService)
        {
            this.bmwAutoService = bmwAutoService;
            this.fordAutoService = fordAutoService;
            this.hondaAutoService = hondaAutoService;
        }
        public void CallAutoService()
        {
            bmwAutoService.GetService();
            fordAutoService.GetService();
            hondaAutoService.GetService();
        }
    }
}
