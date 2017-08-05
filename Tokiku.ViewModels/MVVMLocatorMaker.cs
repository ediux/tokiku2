//==============================================================
//=		請勿手動修改此檔案，此為T4範本自動產生。			   =
//=								By Edward Huang(2017/8/5)	   =
//==============================================================

using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Tokiku.ViewModels 
{	
	public partial class ViewModelLocator
	{
		public ViewModelLocator()
		{
			if (!ServiceLocator.IsLocationProviderSet)
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			if (!SimpleIoc.Default.IsRegistered<IBaseViewModelWithLoginedUser>())
				SimpleIoc.Default.Register<IBaseViewModelWithLoginedUser,MainViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IUserViewModel>())
				SimpleIoc.Default.Register<IUserViewModel,UserViewModel>();			
										
		}

		public IBaseViewModelWithLoginedUser MainViewModel
		{
			get => SimpleIoc.Default.GetInstance<IBaseViewModelWithLoginedUser>();
		}
		public IUserViewModel UserViewModel
		{
			get => SimpleIoc.Default.GetInstance<IUserViewModel>();
		}
	}
}
