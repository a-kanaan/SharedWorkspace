using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using PrismRegionSample2.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrismRegionSample2
{
public class Bootstrapper : UnityBootstrapper
{
    protected override DependencyObject CreateShell()
    {
        return this.Container.TryResolve<Shell>();
    }

    protected override void InitializeShell()
    {
        base.InitializeShell();
        App.Current.MainWindow = (Window)this.Shell;
        App.Current.MainWindow.Show();
    }

    protected override void ConfigureModuleCatalog()
    {
        base.ConfigureModuleCatalog();

        var moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
        moduleCatalog.AddModule(typeof(MainRegion));
        moduleCatalog.AddModule(typeof(HeaderRegion));
    }

    protected override void InitializeModules()
    {
        base.InitializeModules();
    }

    protected override void ConfigureContainer()
    {
        base.ConfigureContainer();
    }
}
}
