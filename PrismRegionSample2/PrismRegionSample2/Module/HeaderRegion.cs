using Prism.Modularity;
using Prism.Regions;
using PrismRegionSample2.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismRegionSample2.Module
{
public class HeaderRegion : IModule
{
    private readonly IRegionManager regionManager;

    public HeaderRegion(IRegionManager regionManager)
    {
        this.regionManager = regionManager;
    }

    public void Initialize()
    {
        regionManager.Regions["HeaderRegion"].Add(new HeaderView());
    }
}
}
