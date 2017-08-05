//==============================================================
//=		請勿手動修改此檔案，此為T4範本自動產生。			   =
//=								By Edward Huang(2017/8/5)	   =
//==============================================================

using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using TokikuNew.Frame;

namespace TokikuNew 
{	
	public partial class ViewsLocator
	{
		public ViewsLocator()
		{
			if (!ServiceLocator.IsLocationProviderSet)
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			if (!SimpleIoc.Default.IsRegistered<OptionWindow>())
				SimpleIoc.Default.Register<OptionWindow>(() => new OptionWindow(),"OptionWindow");

			if (!SimpleIoc.Default.IsRegistered<StartUpWindow>())
				SimpleIoc.Default.Register<StartUpWindow>(() => new StartUpWindow(),"StartUpWindow");

			if (!SimpleIoc.Default.IsRegistered<MainWindow>())
				SimpleIoc.Default.Register<MainWindow>(() => new MainWindow(),"MainWindow");
										
		}

		public OptionWindow OptionWindow
		{
			get => SimpleIoc.Default.GetInstance<OptionWindow>("OptionWindow");
		}
		public StartUpWindow StartUpWindow
		{
			get => SimpleIoc.Default.GetInstance<StartUpWindow>("StartUpWindow");
		}
		public MainWindow MainWindow
		{
			get => SimpleIoc.Default.GetInstance<MainWindow>("MainWindow");
		}
	}
}
