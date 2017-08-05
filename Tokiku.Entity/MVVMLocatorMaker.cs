//==============================================================
//=		請勿手動修改此檔案，此為T4範本自動產生。			   =
//=								By Edward Huang(2017/8/5)	   =
//==============================================================

using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Tokiku.Entity 
{	
	public partial class EntityLocator
	{
		public EntityLocator()
		{
			if (!ServiceLocator.IsLocationProviderSet)
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			if (!SimpleIoc.Default.IsRegistered<IAbnormalQualityDetailsRepository>())
				SimpleIoc.Default.Register<IAbnormalQualityDetailsRepository,AbnormalQualityDetailsRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IAbnormalQualityRepository>())
				SimpleIoc.Default.Register<IAbnormalQualityRepository,AbnormalQualityRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IAccessLogRepository>())
				SimpleIoc.Default.Register<IAccessLogRepository,AccessLogRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IBOMRepository>())
				SimpleIoc.Default.Register<IBOMRepository,BOMRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IConstructionAtlasRepository>())
				SimpleIoc.Default.Register<IConstructionAtlasRepository,ConstructionAtlasRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IContactsRepository>())
				SimpleIoc.Default.Register<IContactsRepository,ContactsRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IControlTableDetailsRepository>())
				SimpleIoc.Default.Register<IControlTableDetailsRepository,ControlTableDetailsRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IControlTablesRepository>())
				SimpleIoc.Default.Register<IControlTablesRepository,ControlTablesRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IEncodingRecordsRepository>())
				SimpleIoc.Default.Register<IEncodingRecordsRepository,EncodingRecordsRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IEngineeringRepository>())
				SimpleIoc.Default.Register<IEngineeringRepository,EngineeringRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IInventoryRepository>())
				SimpleIoc.Default.Register<IInventoryRepository,InventoryRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IInvoiceDetails_MaterialRepository>())
				SimpleIoc.Default.Register<IInvoiceDetails_MaterialRepository,InvoiceDetails_MaterialRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IInvoiceDetails_MiscellaneousRepository>())
				SimpleIoc.Default.Register<IInvoiceDetails_MiscellaneousRepository,InvoiceDetails_MiscellaneousRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IInvoiceDetailsRepository>())
				SimpleIoc.Default.Register<IInvoiceDetailsRepository,InvoiceDetailsRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IInvoicesRepository>())
				SimpleIoc.Default.Register<IInvoicesRepository,InvoicesRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IManufacturersBussinessItemsRepository>())
				SimpleIoc.Default.Register<IManufacturersBussinessItemsRepository,ManufacturersBussinessItemsRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IManufacturersFactoriesRepository>())
				SimpleIoc.Default.Register<IManufacturersFactoriesRepository,ManufacturersFactoriesRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IManufacturersRepository>())
				SimpleIoc.Default.Register<IManufacturersRepository,ManufacturersRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IMaterialCategoriesRepository>())
				SimpleIoc.Default.Register<IMaterialCategoriesRepository,MaterialCategoriesRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IMaterialEstimationRepository>())
				SimpleIoc.Default.Register<IMaterialEstimationRepository,MaterialEstimationRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IMaterialsRepository>())
				SimpleIoc.Default.Register<IMaterialsRepository,MaterialsRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IMembershipRepository>())
				SimpleIoc.Default.Register<IMembershipRepository,MembershipRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IMoldsInProjectsRepository>())
				SimpleIoc.Default.Register<IMoldsInProjectsRepository,MoldsInProjectsRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IMoldsRepository>())
				SimpleIoc.Default.Register<IMoldsRepository,MoldsRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IMoldUseStatusRepository>())
				SimpleIoc.Default.Register<IMoldUseStatusRepository,MoldUseStatusRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IOrderControlTableDetailsRepository>())
				SimpleIoc.Default.Register<IOrderControlTableDetailsRepository,OrderControlTableDetailsRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IOrderDetailsRepository>())
				SimpleIoc.Default.Register<IOrderDetailsRepository,OrderDetailsRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IOrderMaterialValuationRepository>())
				SimpleIoc.Default.Register<IOrderMaterialValuationRepository,OrderMaterialValuationRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IOrderMiscellaneousRepository>())
				SimpleIoc.Default.Register<IOrderMiscellaneousRepository,OrderMiscellaneousRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IOrdersRepository>())
				SimpleIoc.Default.Register<IOrdersRepository,OrdersRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IOrderTypesRepository>())
				SimpleIoc.Default.Register<IOrderTypesRepository,OrderTypesRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IPaymentTypesRepository>())
				SimpleIoc.Default.Register<IPaymentTypesRepository,PaymentTypesRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IPickListDetailsRepository>())
				SimpleIoc.Default.Register<IPickListDetailsRepository,PickListDetailsRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IPickListRepository>())
				SimpleIoc.Default.Register<IPickListRepository,PickListRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IProcessingAtlasRepository>())
				SimpleIoc.Default.Register<IProcessingAtlasRepository,ProcessingAtlasRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IProfileRepository>())
				SimpleIoc.Default.Register<IProfileRepository,ProfileRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IProjectContractRepository>())
				SimpleIoc.Default.Register<IProjectContractRepository,ProjectContractRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IProjectItemCostRepository>())
				SimpleIoc.Default.Register<IProjectItemCostRepository,ProjectItemCostRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IProjectsRepository>())
				SimpleIoc.Default.Register<IProjectsRepository,ProjectsRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IPromissoryNoteManagementRepository>())
				SimpleIoc.Default.Register<IPromissoryNoteManagementRepository,PromissoryNoteManagementRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IReceiveDetailsRepository>())
				SimpleIoc.Default.Register<IReceiveDetailsRepository,ReceiveDetailsRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IReceiveRepository>())
				SimpleIoc.Default.Register<IReceiveRepository,ReceiveRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IRequiredDetailsRepository>())
				SimpleIoc.Default.Register<IRequiredDetailsRepository,RequiredDetailsRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IRequiredRepository>())
				SimpleIoc.Default.Register<IRequiredRepository,RequiredRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IReturnDetailsRepository>())
				SimpleIoc.Default.Register<IReturnDetailsRepository,ReturnDetailsRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IReturnsRepository>())
				SimpleIoc.Default.Register<IReturnsRepository,ReturnsRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IRolesRepository>())
				SimpleIoc.Default.Register<IRolesRepository,RolesRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IShopFlowDetailRepository>())
				SimpleIoc.Default.Register<IShopFlowDetailRepository,ShopFlowDetailRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IShopFlowHistoryRepository>())
				SimpleIoc.Default.Register<IShopFlowHistoryRepository,ShopFlowHistoryRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IShopFlowRepository>())
				SimpleIoc.Default.Register<IShopFlowRepository,ShopFlowRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IStatesRepository>())
				SimpleIoc.Default.Register<IStatesRepository,StatesRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IStocksRepository>())
				SimpleIoc.Default.Register<IStocksRepository,StocksRepository>();			

			if (!SimpleIoc.Default.IsRegistered<ISupplierTranscationItemRepository>())
				SimpleIoc.Default.Register<ISupplierTranscationItemRepository,SupplierTranscationItemRepository>();			

			if (!SimpleIoc.Default.IsRegistered<ITicketPeriodRepository>())
				SimpleIoc.Default.Register<ITicketPeriodRepository,TicketPeriodRepository>();			

			if (!SimpleIoc.Default.IsRegistered<ITicketTypesRepository>())
				SimpleIoc.Default.Register<ITicketTypesRepository,TicketTypesRepository>();			

			if (!SimpleIoc.Default.IsRegistered<ITranscationCategoriesRepository>())
				SimpleIoc.Default.Register<ITranscationCategoriesRepository,TranscationCategoriesRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IUsersRepository>())
				SimpleIoc.Default.Register<IUsersRepository,UsersRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IView_BussinessItemsListRepository>())
				SimpleIoc.Default.Register<IView_BussinessItemsListRepository,View_BussinessItemsListRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IView_ManufacturersBussinessTranscationsRepository>())
				SimpleIoc.Default.Register<IView_ManufacturersBussinessTranscationsRepository,View_ManufacturersBussinessTranscationsRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IView_OrderControlTableRepository>())
				SimpleIoc.Default.Register<IView_OrderControlTableRepository,View_OrderControlTableRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IView_OrderMaterialValuationRepository>())
				SimpleIoc.Default.Register<IView_OrderMaterialValuationRepository,View_OrderMaterialValuationRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IView_OrdersRepository>())
				SimpleIoc.Default.Register<IView_OrdersRepository,View_OrdersRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IView_PickListRepository>())
				SimpleIoc.Default.Register<IView_PickListRepository,View_PickListRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IView_RequiredControlTableRepository>())
				SimpleIoc.Default.Register<IView_RequiredControlTableRepository,View_RequiredControlTableRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IView_RequiredFormsRepository>())
				SimpleIoc.Default.Register<IView_RequiredFormsRepository,View_RequiredFormsRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IView_ShippingListRepository>())
				SimpleIoc.Default.Register<IView_ShippingListRepository,View_ShippingListRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IView_ShippingRepository>())
				SimpleIoc.Default.Register<IView_ShippingRepository,View_ShippingRepository>();			

			if (!SimpleIoc.Default.IsRegistered<IWorkShopsRepository>())
				SimpleIoc.Default.Register<IWorkShopsRepository,WorkShopsRepository>();			
										
		}

		public IAbnormalQualityDetailsRepository AbnormalQualityDetailsRepository
		{
			get => SimpleIoc.Default.GetInstance<IAbnormalQualityDetailsRepository>();
		}
		public IAbnormalQualityRepository AbnormalQualityRepository
		{
			get => SimpleIoc.Default.GetInstance<IAbnormalQualityRepository>();
		}
		public IAccessLogRepository AccessLogRepository
		{
			get => SimpleIoc.Default.GetInstance<IAccessLogRepository>();
		}
		public IBOMRepository BOMRepository
		{
			get => SimpleIoc.Default.GetInstance<IBOMRepository>();
		}
		public IConstructionAtlasRepository ConstructionAtlasRepository
		{
			get => SimpleIoc.Default.GetInstance<IConstructionAtlasRepository>();
		}
		public IContactsRepository ContactsRepository
		{
			get => SimpleIoc.Default.GetInstance<IContactsRepository>();
		}
		public IControlTableDetailsRepository ControlTableDetailsRepository
		{
			get => SimpleIoc.Default.GetInstance<IControlTableDetailsRepository>();
		}
		public IControlTablesRepository ControlTablesRepository
		{
			get => SimpleIoc.Default.GetInstance<IControlTablesRepository>();
		}
		public IEncodingRecordsRepository EncodingRecordsRepository
		{
			get => SimpleIoc.Default.GetInstance<IEncodingRecordsRepository>();
		}
		public IEngineeringRepository EngineeringRepository
		{
			get => SimpleIoc.Default.GetInstance<IEngineeringRepository>();
		}
		public IInventoryRepository InventoryRepository
		{
			get => SimpleIoc.Default.GetInstance<IInventoryRepository>();
		}
		public IInvoiceDetails_MaterialRepository InvoiceDetails_MaterialRepository
		{
			get => SimpleIoc.Default.GetInstance<IInvoiceDetails_MaterialRepository>();
		}
		public IInvoiceDetails_MiscellaneousRepository InvoiceDetails_MiscellaneousRepository
		{
			get => SimpleIoc.Default.GetInstance<IInvoiceDetails_MiscellaneousRepository>();
		}
		public IInvoiceDetailsRepository InvoiceDetailsRepository
		{
			get => SimpleIoc.Default.GetInstance<IInvoiceDetailsRepository>();
		}
		public IInvoicesRepository InvoicesRepository
		{
			get => SimpleIoc.Default.GetInstance<IInvoicesRepository>();
		}
		public IManufacturersBussinessItemsRepository ManufacturersBussinessItemsRepository
		{
			get => SimpleIoc.Default.GetInstance<IManufacturersBussinessItemsRepository>();
		}
		public IManufacturersFactoriesRepository ManufacturersFactoriesRepository
		{
			get => SimpleIoc.Default.GetInstance<IManufacturersFactoriesRepository>();
		}
		public IManufacturersRepository ManufacturersRepository
		{
			get => SimpleIoc.Default.GetInstance<IManufacturersRepository>();
		}
		public IMaterialCategoriesRepository MaterialCategoriesRepository
		{
			get => SimpleIoc.Default.GetInstance<IMaterialCategoriesRepository>();
		}
		public IMaterialEstimationRepository MaterialEstimationRepository
		{
			get => SimpleIoc.Default.GetInstance<IMaterialEstimationRepository>();
		}
		public IMaterialsRepository MaterialsRepository
		{
			get => SimpleIoc.Default.GetInstance<IMaterialsRepository>();
		}
		public IMembershipRepository MembershipRepository
		{
			get => SimpleIoc.Default.GetInstance<IMembershipRepository>();
		}
		public IMoldsInProjectsRepository MoldsInProjectsRepository
		{
			get => SimpleIoc.Default.GetInstance<IMoldsInProjectsRepository>();
		}
		public IMoldsRepository MoldsRepository
		{
			get => SimpleIoc.Default.GetInstance<IMoldsRepository>();
		}
		public IMoldUseStatusRepository MoldUseStatusRepository
		{
			get => SimpleIoc.Default.GetInstance<IMoldUseStatusRepository>();
		}
		public IOrderControlTableDetailsRepository OrderControlTableDetailsRepository
		{
			get => SimpleIoc.Default.GetInstance<IOrderControlTableDetailsRepository>();
		}
		public IOrderDetailsRepository OrderDetailsRepository
		{
			get => SimpleIoc.Default.GetInstance<IOrderDetailsRepository>();
		}
		public IOrderMaterialValuationRepository OrderMaterialValuationRepository
		{
			get => SimpleIoc.Default.GetInstance<IOrderMaterialValuationRepository>();
		}
		public IOrderMiscellaneousRepository OrderMiscellaneousRepository
		{
			get => SimpleIoc.Default.GetInstance<IOrderMiscellaneousRepository>();
		}
		public IOrdersRepository OrdersRepository
		{
			get => SimpleIoc.Default.GetInstance<IOrdersRepository>();
		}
		public IOrderTypesRepository OrderTypesRepository
		{
			get => SimpleIoc.Default.GetInstance<IOrderTypesRepository>();
		}
		public IPaymentTypesRepository PaymentTypesRepository
		{
			get => SimpleIoc.Default.GetInstance<IPaymentTypesRepository>();
		}
		public IPickListDetailsRepository PickListDetailsRepository
		{
			get => SimpleIoc.Default.GetInstance<IPickListDetailsRepository>();
		}
		public IPickListRepository PickListRepository
		{
			get => SimpleIoc.Default.GetInstance<IPickListRepository>();
		}
		public IProcessingAtlasRepository ProcessingAtlasRepository
		{
			get => SimpleIoc.Default.GetInstance<IProcessingAtlasRepository>();
		}
		public IProfileRepository ProfileRepository
		{
			get => SimpleIoc.Default.GetInstance<IProfileRepository>();
		}
		public IProjectContractRepository ProjectContractRepository
		{
			get => SimpleIoc.Default.GetInstance<IProjectContractRepository>();
		}
		public IProjectItemCostRepository ProjectItemCostRepository
		{
			get => SimpleIoc.Default.GetInstance<IProjectItemCostRepository>();
		}
		public IProjectsRepository ProjectsRepository
		{
			get => SimpleIoc.Default.GetInstance<IProjectsRepository>();
		}
		public IPromissoryNoteManagementRepository PromissoryNoteManagementRepository
		{
			get => SimpleIoc.Default.GetInstance<IPromissoryNoteManagementRepository>();
		}
		public IReceiveDetailsRepository ReceiveDetailsRepository
		{
			get => SimpleIoc.Default.GetInstance<IReceiveDetailsRepository>();
		}
		public IReceiveRepository ReceiveRepository
		{
			get => SimpleIoc.Default.GetInstance<IReceiveRepository>();
		}
		public IRequiredDetailsRepository RequiredDetailsRepository
		{
			get => SimpleIoc.Default.GetInstance<IRequiredDetailsRepository>();
		}
		public IRequiredRepository RequiredRepository
		{
			get => SimpleIoc.Default.GetInstance<IRequiredRepository>();
		}
		public IReturnDetailsRepository ReturnDetailsRepository
		{
			get => SimpleIoc.Default.GetInstance<IReturnDetailsRepository>();
		}
		public IReturnsRepository ReturnsRepository
		{
			get => SimpleIoc.Default.GetInstance<IReturnsRepository>();
		}
		public IRolesRepository RolesRepository
		{
			get => SimpleIoc.Default.GetInstance<IRolesRepository>();
		}
		public IShopFlowDetailRepository ShopFlowDetailRepository
		{
			get => SimpleIoc.Default.GetInstance<IShopFlowDetailRepository>();
		}
		public IShopFlowHistoryRepository ShopFlowHistoryRepository
		{
			get => SimpleIoc.Default.GetInstance<IShopFlowHistoryRepository>();
		}
		public IShopFlowRepository ShopFlowRepository
		{
			get => SimpleIoc.Default.GetInstance<IShopFlowRepository>();
		}
		public IStatesRepository StatesRepository
		{
			get => SimpleIoc.Default.GetInstance<IStatesRepository>();
		}
		public IStocksRepository StocksRepository
		{
			get => SimpleIoc.Default.GetInstance<IStocksRepository>();
		}
		public ISupplierTranscationItemRepository SupplierTranscationItemRepository
		{
			get => SimpleIoc.Default.GetInstance<ISupplierTranscationItemRepository>();
		}
		public ITicketPeriodRepository TicketPeriodRepository
		{
			get => SimpleIoc.Default.GetInstance<ITicketPeriodRepository>();
		}
		public ITicketTypesRepository TicketTypesRepository
		{
			get => SimpleIoc.Default.GetInstance<ITicketTypesRepository>();
		}
		public ITranscationCategoriesRepository TranscationCategoriesRepository
		{
			get => SimpleIoc.Default.GetInstance<ITranscationCategoriesRepository>();
		}
		public IUsersRepository UsersRepository
		{
			get => SimpleIoc.Default.GetInstance<IUsersRepository>();
		}
		public IView_BussinessItemsListRepository View_BussinessItemsListRepository
		{
			get => SimpleIoc.Default.GetInstance<IView_BussinessItemsListRepository>();
		}
		public IView_ManufacturersBussinessTranscationsRepository View_ManufacturersBussinessTranscationsRepository
		{
			get => SimpleIoc.Default.GetInstance<IView_ManufacturersBussinessTranscationsRepository>();
		}
		public IView_OrderControlTableRepository View_OrderControlTableRepository
		{
			get => SimpleIoc.Default.GetInstance<IView_OrderControlTableRepository>();
		}
		public IView_OrderMaterialValuationRepository View_OrderMaterialValuationRepository
		{
			get => SimpleIoc.Default.GetInstance<IView_OrderMaterialValuationRepository>();
		}
		public IView_OrdersRepository View_OrdersRepository
		{
			get => SimpleIoc.Default.GetInstance<IView_OrdersRepository>();
		}
		public IView_PickListRepository View_PickListRepository
		{
			get => SimpleIoc.Default.GetInstance<IView_PickListRepository>();
		}
		public IView_RequiredControlTableRepository View_RequiredControlTableRepository
		{
			get => SimpleIoc.Default.GetInstance<IView_RequiredControlTableRepository>();
		}
		public IView_RequiredFormsRepository View_RequiredFormsRepository
		{
			get => SimpleIoc.Default.GetInstance<IView_RequiredFormsRepository>();
		}
		public IView_ShippingListRepository View_ShippingListRepository
		{
			get => SimpleIoc.Default.GetInstance<IView_ShippingListRepository>();
		}
		public IView_ShippingRepository View_ShippingRepository
		{
			get => SimpleIoc.Default.GetInstance<IView_ShippingRepository>();
		}
		public IWorkShopsRepository WorkShopsRepository
		{
			get => SimpleIoc.Default.GetInstance<IWorkShopsRepository>();
		}
	}
}
