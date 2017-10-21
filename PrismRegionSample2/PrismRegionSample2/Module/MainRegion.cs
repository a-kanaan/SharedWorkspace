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
public class MainRegion : IModule
{
    private readonly IRegionManager regionManager;

    public MainRegion(IRegionManager regionManager)
    {
        this.regionManager = regionManager ?? throw new ArgumentNullException(nameof(regionManager));
    }

    public void Initialize()
    {
        regionManager.Regions["MainRegion"].Add(new MainView());
    }
}
}
