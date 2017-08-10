//==============================================================
//=		請勿手動修改此檔案，此為T4範本自動產生。			   =
//=								By Edward Huang(2017/8/5)	   =
//==============================================================

using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Tokiku.DataServices 
{	
	public partial class DefaultLocator
	{
		public DefaultLocator()
		{
			if (!ServiceLocator.IsLocationProviderSet)
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			if (!SimpleIoc.Default.IsRegistered<ICoreDataService>())
				SimpleIoc.Default.Register<ICoreDataService,CoreDataService>();			

			if (!SimpleIoc.Default.IsRegistered<ICustomerRelationshipManagementDataService>())
				SimpleIoc.Default.Register<ICustomerRelationshipManagementDataService,CustomerRelationshipManagementDataService>();			

			if (!SimpleIoc.Default.IsRegistered<IFinancialManagementDataService>())
				SimpleIoc.Default.Register<IFinancialManagementDataService,FinancialManagementDataService>();			

			if (!SimpleIoc.Default.IsRegistered<IManufacturingExecutionDataService>())
				SimpleIoc.Default.Register<IManufacturingExecutionDataService,ManufacturingExecutionDataService>();			
										
            if (_Current == null)
                _Current = this;
		}

		private static DefaultLocator _Current=null;
		
		/// <summary>
        /// 取得預設的容器解析物件。
        /// </summary>
        public static DefaultLocator Current
        {
            get
            {
                if (_Current == null)
                    _Current = new DefaultLocator();
                return _Current;
            }
        }

		/// <summary>
        /// 取得IoC容器中的實作 ICoreDataService 介面的物件執行個體。
        /// </summary>
		public ICoreDataService CoreDataService
		{
			get => SimpleIoc.Default.GetInstance<ICoreDataService>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 ICustomerRelationshipManagementDataService 介面的物件執行個體。
        /// </summary>
		public ICustomerRelationshipManagementDataService CustomerRelationshipManagementDataService
		{
			get => SimpleIoc.Default.GetInstance<ICustomerRelationshipManagementDataService>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IFinancialManagementDataService 介面的物件執行個體。
        /// </summary>
		public IFinancialManagementDataService FinancialManagementDataService
		{
			get => SimpleIoc.Default.GetInstance<IFinancialManagementDataService>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IManufacturingExecutionDataService 介面的物件執行個體。
        /// </summary>
		public IManufacturingExecutionDataService ManufacturingExecutionDataService
		{
			get => SimpleIoc.Default.GetInstance<IManufacturingExecutionDataService>();
		}
	}
}
