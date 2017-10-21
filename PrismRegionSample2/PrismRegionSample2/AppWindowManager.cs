using Prism.Regions;
using PrismRegionSample2.UserControls;
using PrismRegionSample2.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismRegionSample2
{
    public class AppWindowManager
    {
        private static IRegionManager regionManager;

        public static void Init(IRegionManager regionManager)
        {
            AppWindowManager.regionManager = regionManager;
            Navigate();
        }

        public static void Navigate()
        {
            var mainRegion = regionManager.Regions["MainRegion"];
            var v = new SecondaryView();
            mainRegion.Add(v);
            //mainRegion.Activate(v);
            mainRegion.RequestNavigate("SecondaryView");
        }
    }
}
