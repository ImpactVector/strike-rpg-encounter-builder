using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using Xceed.Wpf.Toolkit;

namespace IVG.Strike.EncounterBuilderWPF
{
    public class StrikeBootstrapper: BootstrapperBase
    {
        public StrikeBootstrapper ()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            Dictionary<string, object> settings = new Dictionary<string, object>();
            settings.Add("Height", 600);
            settings.Add("Width", 1000);
            settings.Add("SizeToContent", System.Windows.SizeToContent.Manual);
            DisplayRootViewFor<ViewModels.MainViewModel>(settings);
        }
        protected override void Configure()
        {
            base.Configure();

            //setup the conventions
            var valueConvention = ConventionManager.AddElementConvention<FrameworkElement>(IntegerUpDown.ValueProperty, "Value", "ValueChanged");
            //var maximumConvention = ConventionManager.AddElementConvention<FrameworkElement>(IntegerUpDown.MaximumProperty, "Maximum", "ValueChanged");
            //var minimumConvention = ConventionManager.AddElementConvention<FrameworkElement>(IntegerUpDown.MinimumProperty, "Minimum", "ValueChanged");

            //bind the properties
            var baseBindProperties = ViewModelBinder.BindProperties;
            ViewModelBinder.BindProperties =
                (frameWorkElements, viewModels) => {

                    foreach (var frameworkElement in frameWorkElements)
                    {
                        var valuePropertyName = frameworkElement.Name;
                        var valueProperty = viewModels
                                .GetPropertyCaseInsensitive(valuePropertyName);

                        if (valueProperty != null)
                        {
                            ConventionManager.SetBindingWithoutBindingOverwrite(
                                    viewModels,
                                    valuePropertyName,
                                    valueProperty,
                                    frameworkElement,
                                    valueConvention,
                                    valueConvention.GetBindableProperty(frameworkElement));
                        }

                    //    var maxPropertyName = frameworkElement.Name + "Maximum";
                    //    var maxProperty = viewModels
                    //            .GetPropertyCaseInsensitive(maxPropertyName);

                    //    if (maxProperty != null)
                    //    {
                    //        ConventionManager.SetBindingWithoutBindingOverwrite(
                    //                viewModels,
                    //                maxPropertyName,
                    //                maxProperty,
                    //                frameworkElement,
                    //                maximumConvention,
                    //                maximumConvention.GetBindableProperty(frameworkElement));
                    //    }

                    //    var minPropertyName = frameworkElement.Name + "Minimum";
                    //    var minProperty = viewModels
                    //            .GetPropertyCaseInsensitive(minPropertyName);

                    //    if (minProperty != null)
                    //    {
                    //        ConventionManager.SetBindingWithoutBindingOverwrite(
                    //            viewModels,
                    //            minPropertyName,
                    //            minProperty,
                    //            frameworkElement,
                    //            minimumConvention,
                    //            minimumConvention.GetBindableProperty(frameworkElement));
                    //    }
                    }

                    return baseBindProperties(frameWorkElements, viewModels);
                };

        }
    }
}
