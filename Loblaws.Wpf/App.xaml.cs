using Loblaws.Biz;
using Loblaws.Biz.Interfaces;
using Loblaws.Wpf.Views;
using Prism.Ioc;
using Prism.Unity;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;

namespace Loblaws.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        /// <summary>
        /// Fenêtre de départ.
        /// </summary>
        /// <returns>Window.</returns>
        protected override Window CreateShell() =>
            Container.Resolve<MainWindow>();

        /// <summary>
        /// Injection de dépendances.
        /// </summary>
        /// <param name="containerRegistry">Régistre.</param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Injection.
            containerRegistry.Register<ICalculSousTotal, CalculSousTotal>();
            containerRegistry.Register<ICalculTaxes, CalculTaxes>();
            containerRegistry.Register<ICalculTotal, CalculTotal>();
        }

        /// <summary>
        /// Sur démarrage, s'assurer de la culture courante.
        /// </summary>
        /// <param name="e">Arguments.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // Établir la culture courante.
            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement), 
                new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            base.OnStartup(e);
        }
    }
}
