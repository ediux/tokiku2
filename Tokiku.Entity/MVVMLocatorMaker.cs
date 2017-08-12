//==============================================================
//=		請勿手動修改此檔案，此為T4範本自動產生。			   =
//=								By Edward Huang(2017/8/5)	   =
//==============================================================

using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Tokiku.Entity.ViewTables;

namespace Tokiku.Entity 
{	
	public partial class EntityLocator
	{
		public EntityLocator()
		{
			if (!ServiceLocator.IsLocationProviderSet)
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			if (!SimpleIoc.Default.IsRegistered<IAbnormalQualityDetailsRepository>())
				SimpleIoc.Default.Register<IAbnormalQualityDetailsRepository,AbnormalQualityDetailsRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IAbnormalQualityRepository>())
				SimpleIoc.Default.Register<IAbnormalQualityRepository,AbnormalQualityRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IAccessLogRepository>())
				SimpleIoc.Default.Register<IAccessLogRepository,AccessLogRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IBOMRepository>())
				SimpleIoc.Default.Register<IBOMRepository,BOMRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IConstructionAtlasRepository>())
				SimpleIoc.Default.Register<IConstructionAtlasRepository,ConstructionAtlasRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IContactsRepository>())
				SimpleIoc.Default.Register<IContactsRepository,ContactsRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IControlTableDetailsRepository>())
				SimpleIoc.Default.Register<IControlTableDetailsRepository,ControlTableDetailsRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IControlTablesRepository>())
				SimpleIoc.Default.Register<IControlTablesRepository,ControlTablesRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IUnitOfWork>())
				SimpleIoc.Default.Register<IUnitOfWork,EFUnitOfWork>(true);

			if (!SimpleIoc.Default.IsRegistered<IEncodingRecordsRepository>())
				SimpleIoc.Default.Register<IEncodingRecordsRepository,EncodingRecordsRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IEngineeringRepository>())
				SimpleIoc.Default.Register<IEngineeringRepository,EngineeringRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IInventoryRepository>())
				SimpleIoc.Default.Register<IInventoryRepository,InventoryRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IInvoiceDetails_MaterialRepository>())
				SimpleIoc.Default.Register<IInvoiceDetails_MaterialRepository,InvoiceDetails_MaterialRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IInvoiceDetails_MiscellaneousRepository>())
				SimpleIoc.Default.Register<IInvoiceDetails_MiscellaneousRepository,InvoiceDetails_MiscellaneousRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IInvoiceDetailsRepository>())
				SimpleIoc.Default.Register<IInvoiceDetailsRepository,InvoiceDetailsRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IInvoicesRepository>())
				SimpleIoc.Default.Register<IInvoicesRepository,InvoicesRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IManufacturersBussinessItemsRepository>())
				SimpleIoc.Default.Register<IManufacturersBussinessItemsRepository,ManufacturersBussinessItemsRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IManufacturersFactoriesRepository>())
				SimpleIoc.Default.Register<IManufacturersFactoriesRepository,ManufacturersFactoriesRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IManufacturersRepository>())
				SimpleIoc.Default.Register<IManufacturersRepository,ManufacturersRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IMaterialCategoriesRepository>())
				SimpleIoc.Default.Register<IMaterialCategoriesRepository,MaterialCategoriesRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IMaterialEstimationRepository>())
				SimpleIoc.Default.Register<IMaterialEstimationRepository,MaterialEstimationRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IMaterialsRepository>())
				SimpleIoc.Default.Register<IMaterialsRepository,MaterialsRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IMembershipRepository>())
				SimpleIoc.Default.Register<IMembershipRepository,MembershipRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IMoldsInProjectsRepository>())
				SimpleIoc.Default.Register<IMoldsInProjectsRepository,MoldsInProjectsRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IMoldsRepository>())
				SimpleIoc.Default.Register<IMoldsRepository,MoldsRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IMoldUseStatusRepository>())
				SimpleIoc.Default.Register<IMoldUseStatusRepository,MoldUseStatusRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IOrderControlTableDetailsRepository>())
				SimpleIoc.Default.Register<IOrderControlTableDetailsRepository,OrderControlTableDetailsRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IOrderDetailsRepository>())
				SimpleIoc.Default.Register<IOrderDetailsRepository,OrderDetailsRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IOrderMaterialValuationRepository>())
				SimpleIoc.Default.Register<IOrderMaterialValuationRepository,OrderMaterialValuationRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IOrderMiscellaneousRepository>())
				SimpleIoc.Default.Register<IOrderMiscellaneousRepository,OrderMiscellaneousRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IOrdersRepository>())
				SimpleIoc.Default.Register<IOrdersRepository,OrdersRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IOrderTypesRepository>())
				SimpleIoc.Default.Register<IOrderTypesRepository,OrderTypesRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IPaymentTypesRepository>())
				SimpleIoc.Default.Register<IPaymentTypesRepository,PaymentTypesRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IPickListDetailsRepository>())
				SimpleIoc.Default.Register<IPickListDetailsRepository,PickListDetailsRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IPickListRepository>())
				SimpleIoc.Default.Register<IPickListRepository,PickListRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IProcessingAtlasRepository>())
				SimpleIoc.Default.Register<IProcessingAtlasRepository,ProcessingAtlasRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IProfileRepository>())
				SimpleIoc.Default.Register<IProfileRepository,ProfileRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IProjectContractRepository>())
				SimpleIoc.Default.Register<IProjectContractRepository,ProjectContractRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IProjectItemCostRepository>())
				SimpleIoc.Default.Register<IProjectItemCostRepository,ProjectItemCostRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IProjectsRepository>())
				SimpleIoc.Default.Register<IProjectsRepository,ProjectsRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IPromissoryNoteManagementRepository>())
				SimpleIoc.Default.Register<IPromissoryNoteManagementRepository,PromissoryNoteManagementRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IReceiveDetailsRepository>())
				SimpleIoc.Default.Register<IReceiveDetailsRepository,ReceiveDetailsRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IReceiveRepository>())
				SimpleIoc.Default.Register<IReceiveRepository,ReceiveRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IRequiredDetailsRepository>())
				SimpleIoc.Default.Register<IRequiredDetailsRepository,RequiredDetailsRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IRequiredRepository>())
				SimpleIoc.Default.Register<IRequiredRepository,RequiredRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IReturnDetailsRepository>())
				SimpleIoc.Default.Register<IReturnDetailsRepository,ReturnDetailsRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IReturnsRepository>())
				SimpleIoc.Default.Register<IReturnsRepository,ReturnsRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IRolesRepository>())
				SimpleIoc.Default.Register<IRolesRepository,RolesRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IShopFlowDetailRepository>())
				SimpleIoc.Default.Register<IShopFlowDetailRepository,ShopFlowDetailRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IShopFlowHistoryRepository>())
				SimpleIoc.Default.Register<IShopFlowHistoryRepository,ShopFlowHistoryRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IShopFlowRepository>())
				SimpleIoc.Default.Register<IShopFlowRepository,ShopFlowRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IStatesRepository>())
				SimpleIoc.Default.Register<IStatesRepository,StatesRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IStocksRepository>())
				SimpleIoc.Default.Register<IStocksRepository,StocksRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<ISupplierTranscationItemRepository>())
				SimpleIoc.Default.Register<ISupplierTranscationItemRepository,SupplierTranscationItemRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<ITicketPeriodRepository>())
				SimpleIoc.Default.Register<ITicketPeriodRepository,TicketPeriodRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<ITicketTypesRepository>())
				SimpleIoc.Default.Register<ITicketTypesRepository,TicketTypesRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<ITranscationCategoriesRepository>())
				SimpleIoc.Default.Register<ITranscationCategoriesRepository,TranscationCategoriesRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IUsersRepository>())
				SimpleIoc.Default.Register<IUsersRepository,UsersRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IView_BussinessItemsListRepository>())
				SimpleIoc.Default.Register<IView_BussinessItemsListRepository,View_BussinessItemsListRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IView_ManufacturersBussinessTranscationsRepository>())
				SimpleIoc.Default.Register<IView_ManufacturersBussinessTranscationsRepository,View_ManufacturersBussinessTranscationsRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IView_OrderControlTableRepository>())
				SimpleIoc.Default.Register<IView_OrderControlTableRepository,View_OrderControlTableRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IView_OrderMaterialValuationRepository>())
				SimpleIoc.Default.Register<IView_OrderMaterialValuationRepository,View_OrderMaterialValuationRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IView_OrdersRepository>())
				SimpleIoc.Default.Register<IView_OrdersRepository,View_OrdersRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IView_PickListRepository>())
				SimpleIoc.Default.Register<IView_PickListRepository,View_PickListRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IView_RequiredControlTableRepository>())
				SimpleIoc.Default.Register<IView_RequiredControlTableRepository,View_RequiredControlTableRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IView_RequiredFormsRepository>())
				SimpleIoc.Default.Register<IView_RequiredFormsRepository,View_RequiredFormsRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IView_ShippingListRepository>())
				SimpleIoc.Default.Register<IView_ShippingListRepository,View_ShippingListRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IView_ShippingRepository>())
				SimpleIoc.Default.Register<IView_ShippingRepository,View_ShippingRepository>(true);

			if (!SimpleIoc.Default.IsRegistered<IWorkShopsRepository>())
				SimpleIoc.Default.Register<IWorkShopsRepository,WorkShopsRepository>(true);
			
			if (!SimpleIoc.Default.IsRegistered<AbnormalQuality>())
				SimpleIoc.Default.Register<AbnormalQuality>();
			
			if (!SimpleIoc.Default.IsRegistered<AbnormalQualityMetaData>())
				SimpleIoc.Default.Register<AbnormalQualityMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<AbnormalQualityDetails>())
				SimpleIoc.Default.Register<AbnormalQualityDetails>();
			
			if (!SimpleIoc.Default.IsRegistered<AbnormalQualityDetailsMetaData>())
				SimpleIoc.Default.Register<AbnormalQualityDetailsMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<AccessLog>())
				SimpleIoc.Default.Register<AccessLog>();
			
			if (!SimpleIoc.Default.IsRegistered<AccessLogMetaData>())
				SimpleIoc.Default.Register<AccessLogMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<BOM>())
				SimpleIoc.Default.Register<BOM>();
			
			if (!SimpleIoc.Default.IsRegistered<BOMMetaData>())
				SimpleIoc.Default.Register<BOMMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<ConstructionAtlas>())
				SimpleIoc.Default.Register<ConstructionAtlas>();
			
			if (!SimpleIoc.Default.IsRegistered<ConstructionAtlasMetaData>())
				SimpleIoc.Default.Register<ConstructionAtlasMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<Contacts>())
				SimpleIoc.Default.Register<Contacts>();
			
			if (!SimpleIoc.Default.IsRegistered<ContactsMetaData>())
				SimpleIoc.Default.Register<ContactsMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<ControlTableDetails>())
				SimpleIoc.Default.Register<ControlTableDetails>();
			
			if (!SimpleIoc.Default.IsRegistered<ControlTableDetailsMetaData>())
				SimpleIoc.Default.Register<ControlTableDetailsMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<ControlTables>())
				SimpleIoc.Default.Register<ControlTables>();
			
			if (!SimpleIoc.Default.IsRegistered<ControlTablesMetaData>())
				SimpleIoc.Default.Register<ControlTablesMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<EncodingRecords>())
				SimpleIoc.Default.Register<EncodingRecords>();
			
			if (!SimpleIoc.Default.IsRegistered<EncodingRecordsMetaData>())
				SimpleIoc.Default.Register<EncodingRecordsMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<Engineering>())
				SimpleIoc.Default.Register<Engineering>();
			
			if (!SimpleIoc.Default.IsRegistered<EngineeringMetaData>())
				SimpleIoc.Default.Register<EngineeringMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<Inventory>())
				SimpleIoc.Default.Register<Inventory>();
			
			if (!SimpleIoc.Default.IsRegistered<InventoryMetaData>())
				SimpleIoc.Default.Register<InventoryMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<InvoiceDetails>())
				SimpleIoc.Default.Register<InvoiceDetails>();
			
			if (!SimpleIoc.Default.IsRegistered<InvoiceDetailsMetaData>())
				SimpleIoc.Default.Register<InvoiceDetailsMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<InvoiceDetails_Material>())
				SimpleIoc.Default.Register<InvoiceDetails_Material>();
			
			if (!SimpleIoc.Default.IsRegistered<InvoiceDetails_MaterialMetaData>())
				SimpleIoc.Default.Register<InvoiceDetails_MaterialMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<InvoiceDetails_Miscellaneous>())
				SimpleIoc.Default.Register<InvoiceDetails_Miscellaneous>();
			
			if (!SimpleIoc.Default.IsRegistered<InvoiceDetails_MiscellaneousMetaData>())
				SimpleIoc.Default.Register<InvoiceDetails_MiscellaneousMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<Invoices>())
				SimpleIoc.Default.Register<Invoices>();
			
			if (!SimpleIoc.Default.IsRegistered<InvoicesMetaData>())
				SimpleIoc.Default.Register<InvoicesMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<Manufacturers>())
				SimpleIoc.Default.Register<Manufacturers>();
			
			if (!SimpleIoc.Default.IsRegistered<ManufacturersMetaData>())
				SimpleIoc.Default.Register<ManufacturersMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<ManufacturersBussinessItems>())
				SimpleIoc.Default.Register<ManufacturersBussinessItems>();
			
			if (!SimpleIoc.Default.IsRegistered<ManufacturersBussinessItemsMetaData>())
				SimpleIoc.Default.Register<ManufacturersBussinessItemsMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<ManufacturersFactories>())
				SimpleIoc.Default.Register<ManufacturersFactories>();
			
			if (!SimpleIoc.Default.IsRegistered<ManufacturersFactoriesMetaData>())
				SimpleIoc.Default.Register<ManufacturersFactoriesMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<MaterialCategories>())
				SimpleIoc.Default.Register<MaterialCategories>();
			
			if (!SimpleIoc.Default.IsRegistered<MaterialCategoriesMetaData>())
				SimpleIoc.Default.Register<MaterialCategoriesMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<MaterialEstimation>())
				SimpleIoc.Default.Register<MaterialEstimation>();
			
			if (!SimpleIoc.Default.IsRegistered<MaterialEstimationMetaData>())
				SimpleIoc.Default.Register<MaterialEstimationMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<Materials>())
				SimpleIoc.Default.Register<Materials>();
			
			if (!SimpleIoc.Default.IsRegistered<MaterialsMetaData>())
				SimpleIoc.Default.Register<MaterialsMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<Membership>())
				SimpleIoc.Default.Register<Membership>();
			
			if (!SimpleIoc.Default.IsRegistered<MembershipMetaData>())
				SimpleIoc.Default.Register<MembershipMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<Molds>())
				SimpleIoc.Default.Register<Molds>();
			
			if (!SimpleIoc.Default.IsRegistered<MoldsMetaData>())
				SimpleIoc.Default.Register<MoldsMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<MoldsInProjects>())
				SimpleIoc.Default.Register<MoldsInProjects>();
			
			if (!SimpleIoc.Default.IsRegistered<MoldsInProjectsMetaData>())
				SimpleIoc.Default.Register<MoldsInProjectsMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<MoldUseStatus>())
				SimpleIoc.Default.Register<MoldUseStatus>();
			
			if (!SimpleIoc.Default.IsRegistered<MoldUseStatusMetaData>())
				SimpleIoc.Default.Register<MoldUseStatusMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<OrderControlTableDetails>())
				SimpleIoc.Default.Register<OrderControlTableDetails>();
			
			if (!SimpleIoc.Default.IsRegistered<OrderControlTableDetailsMetaData>())
				SimpleIoc.Default.Register<OrderControlTableDetailsMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<OrderDetails>())
				SimpleIoc.Default.Register<OrderDetails>();
			
			if (!SimpleIoc.Default.IsRegistered<OrderDetailsMetaData>())
				SimpleIoc.Default.Register<OrderDetailsMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<OrderMaterialValuation>())
				SimpleIoc.Default.Register<OrderMaterialValuation>();
			
			if (!SimpleIoc.Default.IsRegistered<OrderMaterialValuationMetaData>())
				SimpleIoc.Default.Register<OrderMaterialValuationMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<OrderMiscellaneous>())
				SimpleIoc.Default.Register<OrderMiscellaneous>();
			
			if (!SimpleIoc.Default.IsRegistered<OrderMiscellaneousMetaData>())
				SimpleIoc.Default.Register<OrderMiscellaneousMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<Orders>())
				SimpleIoc.Default.Register<Orders>();
			
			if (!SimpleIoc.Default.IsRegistered<OrdersMetaData>())
				SimpleIoc.Default.Register<OrdersMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<OrderTypes>())
				SimpleIoc.Default.Register<OrderTypes>();
			
			if (!SimpleIoc.Default.IsRegistered<OrderTypesMetaData>())
				SimpleIoc.Default.Register<OrderTypesMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<PaymentTypes>())
				SimpleIoc.Default.Register<PaymentTypes>();
			
			if (!SimpleIoc.Default.IsRegistered<PaymentTypesMetaData>())
				SimpleIoc.Default.Register<PaymentTypesMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<PickList>())
				SimpleIoc.Default.Register<PickList>();
			
			if (!SimpleIoc.Default.IsRegistered<PickListMetaData>())
				SimpleIoc.Default.Register<PickListMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<PickListDetails>())
				SimpleIoc.Default.Register<PickListDetails>();
			
			if (!SimpleIoc.Default.IsRegistered<PickListDetailsMetaData>())
				SimpleIoc.Default.Register<PickListDetailsMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<ProcessingAtlas>())
				SimpleIoc.Default.Register<ProcessingAtlas>();
			
			if (!SimpleIoc.Default.IsRegistered<ProcessingAtlasMetaData>())
				SimpleIoc.Default.Register<ProcessingAtlasMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<Profile>())
				SimpleIoc.Default.Register<Profile>();
			
			if (!SimpleIoc.Default.IsRegistered<ProfileMetaData>())
				SimpleIoc.Default.Register<ProfileMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<ProjectContract>())
				SimpleIoc.Default.Register<ProjectContract>();
			
			if (!SimpleIoc.Default.IsRegistered<ProjectContractMetaData>())
				SimpleIoc.Default.Register<ProjectContractMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<ProjectItemCost>())
				SimpleIoc.Default.Register<ProjectItemCost>();
			
			if (!SimpleIoc.Default.IsRegistered<ProjectItemCostMetaData>())
				SimpleIoc.Default.Register<ProjectItemCostMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<Projects>())
				SimpleIoc.Default.Register<Projects>();
			
			if (!SimpleIoc.Default.IsRegistered<ProjectsMetaData>())
				SimpleIoc.Default.Register<ProjectsMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<PromissoryNoteManagement>())
				SimpleIoc.Default.Register<PromissoryNoteManagement>();
			
			if (!SimpleIoc.Default.IsRegistered<PromissoryNoteManagementMetaData>())
				SimpleIoc.Default.Register<PromissoryNoteManagementMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<Receive>())
				SimpleIoc.Default.Register<Receive>();
			
			if (!SimpleIoc.Default.IsRegistered<ReceiveMetaData>())
				SimpleIoc.Default.Register<ReceiveMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<ReceiveDetails>())
				SimpleIoc.Default.Register<ReceiveDetails>();
			
			if (!SimpleIoc.Default.IsRegistered<ReceiveDetailsMetaData>())
				SimpleIoc.Default.Register<ReceiveDetailsMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<Required>())
				SimpleIoc.Default.Register<Required>();
			
			if (!SimpleIoc.Default.IsRegistered<RequiredMetaData>())
				SimpleIoc.Default.Register<RequiredMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<RequiredDetails>())
				SimpleIoc.Default.Register<RequiredDetails>();
			
			if (!SimpleIoc.Default.IsRegistered<RequiredDetailsMetaData>())
				SimpleIoc.Default.Register<RequiredDetailsMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<ReturnDetails>())
				SimpleIoc.Default.Register<ReturnDetails>();
			
			if (!SimpleIoc.Default.IsRegistered<ReturnDetailsMetaData>())
				SimpleIoc.Default.Register<ReturnDetailsMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<Returns>())
				SimpleIoc.Default.Register<Returns>();
			
			if (!SimpleIoc.Default.IsRegistered<ReturnsMetaData>())
				SimpleIoc.Default.Register<ReturnsMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<Roles>())
				SimpleIoc.Default.Register<Roles>();
			
			if (!SimpleIoc.Default.IsRegistered<RolesMetaData>())
				SimpleIoc.Default.Register<RolesMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<ShopFlow>())
				SimpleIoc.Default.Register<ShopFlow>();
			
			if (!SimpleIoc.Default.IsRegistered<ShopFlowMetaData>())
				SimpleIoc.Default.Register<ShopFlowMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<ShopFlowDetail>())
				SimpleIoc.Default.Register<ShopFlowDetail>();
			
			if (!SimpleIoc.Default.IsRegistered<ShopFlowDetailMetaData>())
				SimpleIoc.Default.Register<ShopFlowDetailMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<ShopFlowHistory>())
				SimpleIoc.Default.Register<ShopFlowHistory>();
			
			if (!SimpleIoc.Default.IsRegistered<ShopFlowHistoryMetaData>())
				SimpleIoc.Default.Register<ShopFlowHistoryMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<SplitString_Result>())
				SimpleIoc.Default.Register<SplitString_Result>();
			
			if (!SimpleIoc.Default.IsRegistered<SplitString_ResultMetaData>())
				SimpleIoc.Default.Register<SplitString_ResultMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<States>())
				SimpleIoc.Default.Register<States>();
			
			if (!SimpleIoc.Default.IsRegistered<StatesMetaData>())
				SimpleIoc.Default.Register<StatesMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<Stocks>())
				SimpleIoc.Default.Register<Stocks>();
			
			if (!SimpleIoc.Default.IsRegistered<StocksMetaData>())
				SimpleIoc.Default.Register<StocksMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<SupplierTranscationItem>())
				SimpleIoc.Default.Register<SupplierTranscationItem>();
			
			if (!SimpleIoc.Default.IsRegistered<SupplierTranscationItemMetaData>())
				SimpleIoc.Default.Register<SupplierTranscationItemMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<TicketPeriod>())
				SimpleIoc.Default.Register<TicketPeriod>();
			
			if (!SimpleIoc.Default.IsRegistered<TicketPeriodMetaData>())
				SimpleIoc.Default.Register<TicketPeriodMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<TicketTypes>())
				SimpleIoc.Default.Register<TicketTypes>();
			
			if (!SimpleIoc.Default.IsRegistered<TicketTypesMetaData>())
				SimpleIoc.Default.Register<TicketTypesMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<TradingItems>())
				SimpleIoc.Default.Register<TradingItems>();
			
			if (!SimpleIoc.Default.IsRegistered<TradingItemsMetaData>())
				SimpleIoc.Default.Register<TradingItemsMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<TranscationCategories>())
				SimpleIoc.Default.Register<TranscationCategories>();
			
			if (!SimpleIoc.Default.IsRegistered<TranscationCategoriesMetaData>())
				SimpleIoc.Default.Register<TranscationCategoriesMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<Users>())
				SimpleIoc.Default.Register<Users>();
			
			if (!SimpleIoc.Default.IsRegistered<UsersMetaData>())
				SimpleIoc.Default.Register<UsersMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<View_BussinessItemsList>())
				SimpleIoc.Default.Register<View_BussinessItemsList>();
			
			if (!SimpleIoc.Default.IsRegistered<View_BussinessItemsListMetaData>())
				SimpleIoc.Default.Register<View_BussinessItemsListMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<View_ManufacturersBussinessTranscations>())
				SimpleIoc.Default.Register<View_ManufacturersBussinessTranscations>();
			
			if (!SimpleIoc.Default.IsRegistered<View_ManufacturersBussinessTranscationsMetaData>())
				SimpleIoc.Default.Register<View_ManufacturersBussinessTranscationsMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<View_ObtainMaterial>())
				SimpleIoc.Default.Register<View_ObtainMaterial>();
			
			if (!SimpleIoc.Default.IsRegistered<View_ObtainMaterialMetaData>())
				SimpleIoc.Default.Register<View_ObtainMaterialMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<View_OrderControlTable>())
				SimpleIoc.Default.Register<View_OrderControlTable>();
			
			if (!SimpleIoc.Default.IsRegistered<View_OrderControlTableMetaData>())
				SimpleIoc.Default.Register<View_OrderControlTableMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<View_OrderMaterialValuation>())
				SimpleIoc.Default.Register<View_OrderMaterialValuation>();
			
			if (!SimpleIoc.Default.IsRegistered<View_OrderMaterialValuationMetaData>())
				SimpleIoc.Default.Register<View_OrderMaterialValuationMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<View_Orders>())
				SimpleIoc.Default.Register<View_Orders>();
			
			if (!SimpleIoc.Default.IsRegistered<View_OrdersMetaData>())
				SimpleIoc.Default.Register<View_OrdersMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<View_PickList>())
				SimpleIoc.Default.Register<View_PickList>();
			
			if (!SimpleIoc.Default.IsRegistered<View_PickListMetaData>())
				SimpleIoc.Default.Register<View_PickListMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<View_RequiredControlTable>())
				SimpleIoc.Default.Register<View_RequiredControlTable>();
			
			if (!SimpleIoc.Default.IsRegistered<View_RequiredControlTableMetaData>())
				SimpleIoc.Default.Register<View_RequiredControlTableMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<View_RequiredForms>())
				SimpleIoc.Default.Register<View_RequiredForms>();
			
			if (!SimpleIoc.Default.IsRegistered<View_RequiredFormsMetaData>())
				SimpleIoc.Default.Register<View_RequiredFormsMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<View_Shipping>())
				SimpleIoc.Default.Register<View_Shipping>();
			
			if (!SimpleIoc.Default.IsRegistered<View_ShippingMetaData>())
				SimpleIoc.Default.Register<View_ShippingMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<View_ShippingList>())
				SimpleIoc.Default.Register<View_ShippingList>();
			
			if (!SimpleIoc.Default.IsRegistered<View_ShippingListMetaData>())
				SimpleIoc.Default.Register<View_ShippingListMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<WorkShops>())
				SimpleIoc.Default.Register<WorkShops>();
			
			if (!SimpleIoc.Default.IsRegistered<WorkShopsMetaData>())
				SimpleIoc.Default.Register<WorkShopsMetaData>();
			
			if (!SimpleIoc.Default.IsRegistered<TokikuEntities>())
				SimpleIoc.Default.Register<TokikuEntities>();
			
			if (!SimpleIoc.Default.IsRegistered<AluminumExtrusionOrderEntity>())
				SimpleIoc.Default.Register<AluminumExtrusionOrderEntity>();
			
			if (!SimpleIoc.Default.IsRegistered<AluminumExtrusionOrderListEntity>())
				SimpleIoc.Default.Register<AluminumExtrusionOrderListEntity>();
			
			if (!SimpleIoc.Default.IsRegistered<AluminumExtrusionOrderMaterialValuationEntity>())
				SimpleIoc.Default.Register<AluminumExtrusionOrderMaterialValuationEntity>();
			
			if (!SimpleIoc.Default.IsRegistered<AluminumExtrusionOrderMiscellaneousEntity>())
				SimpleIoc.Default.Register<AluminumExtrusionOrderMiscellaneousEntity>();
			
			if (!SimpleIoc.Default.IsRegistered<ContractManagementEntity>())
				SimpleIoc.Default.Register<ContractManagementEntity>();
			
			if (!SimpleIoc.Default.IsRegistered<InventoryListEntity>())
				SimpleIoc.Default.Register<InventoryListEntity>();
			
			if (!SimpleIoc.Default.IsRegistered<MainWindowEntity>())
				SimpleIoc.Default.Register<MainWindowEntity>();
			
			if (!SimpleIoc.Default.IsRegistered<ManufacturersEnter>())
				SimpleIoc.Default.Register<ManufacturersEnter>();
			
			if (!SimpleIoc.Default.IsRegistered<MoldsEnter>())
				SimpleIoc.Default.Register<MoldsEnter>();
			
			if (!SimpleIoc.Default.IsRegistered<ProcessingAtlasDetailEntity>())
				SimpleIoc.Default.Register<ProcessingAtlasDetailEntity>();
			
			if (!SimpleIoc.Default.IsRegistered<ProjectListEntity>())
				SimpleIoc.Default.Register<ProjectListEntity>();
			
			if (!SimpleIoc.Default.IsRegistered<PromissoryNoteManagementEntity>())
				SimpleIoc.Default.Register<PromissoryNoteManagementEntity>();
			
			if (!SimpleIoc.Default.IsRegistered<RecvMaterialListEntity>())
				SimpleIoc.Default.Register<RecvMaterialListEntity>();
			
			if (!SimpleIoc.Default.IsRegistered<SystemMembersEntity>())
				SimpleIoc.Default.Register<SystemMembersEntity>();
			
			if (!SimpleIoc.Default.IsRegistered<SystemRolesEntity>())
				SimpleIoc.Default.Register<SystemRolesEntity>();
										
            if (_Current == null)
                _Current = this;
		}

		private static EntityLocator _Current=null;
		
		/// <summary>
        /// 取得預設的容器解析物件。
        /// </summary>
        public static EntityLocator Current
        {
            get
            {
                if (_Current == null)
                    _Current = new EntityLocator();
                return _Current;
            }
        }

		/// <summary>
        /// 取得IoC容器中的實作 IAbnormalQualityDetailsRepository 介面的物件執行個體。
        /// </summary>
		public IAbnormalQualityDetailsRepository AbnormalQualityDetailsRepository
		{
			get => SimpleIoc.Default.GetInstance<IAbnormalQualityDetailsRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IAbnormalQualityRepository 介面的物件執行個體。
        /// </summary>
		public IAbnormalQualityRepository AbnormalQualityRepository
		{
			get => SimpleIoc.Default.GetInstance<IAbnormalQualityRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IAccessLogRepository 介面的物件執行個體。
        /// </summary>
		public IAccessLogRepository AccessLogRepository
		{
			get => SimpleIoc.Default.GetInstance<IAccessLogRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IBOMRepository 介面的物件執行個體。
        /// </summary>
		public IBOMRepository BOMRepository
		{
			get => SimpleIoc.Default.GetInstance<IBOMRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IConstructionAtlasRepository 介面的物件執行個體。
        /// </summary>
		public IConstructionAtlasRepository ConstructionAtlasRepository
		{
			get => SimpleIoc.Default.GetInstance<IConstructionAtlasRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IContactsRepository 介面的物件執行個體。
        /// </summary>
		public IContactsRepository ContactsRepository
		{
			get => SimpleIoc.Default.GetInstance<IContactsRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IControlTableDetailsRepository 介面的物件執行個體。
        /// </summary>
		public IControlTableDetailsRepository ControlTableDetailsRepository
		{
			get => SimpleIoc.Default.GetInstance<IControlTableDetailsRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IControlTablesRepository 介面的物件執行個體。
        /// </summary>
		public IControlTablesRepository ControlTablesRepository
		{
			get => SimpleIoc.Default.GetInstance<IControlTablesRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IUnitOfWork 介面的物件執行個體。
        /// </summary>
		public IUnitOfWork EFUnitOfWork
		{
			get => SimpleIoc.Default.GetInstance<IUnitOfWork>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IEncodingRecordsRepository 介面的物件執行個體。
        /// </summary>
		public IEncodingRecordsRepository EncodingRecordsRepository
		{
			get => SimpleIoc.Default.GetInstance<IEncodingRecordsRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IEngineeringRepository 介面的物件執行個體。
        /// </summary>
		public IEngineeringRepository EngineeringRepository
		{
			get => SimpleIoc.Default.GetInstance<IEngineeringRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IInventoryRepository 介面的物件執行個體。
        /// </summary>
		public IInventoryRepository InventoryRepository
		{
			get => SimpleIoc.Default.GetInstance<IInventoryRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IInvoiceDetails_MaterialRepository 介面的物件執行個體。
        /// </summary>
		public IInvoiceDetails_MaterialRepository InvoiceDetails_MaterialRepository
		{
			get => SimpleIoc.Default.GetInstance<IInvoiceDetails_MaterialRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IInvoiceDetails_MiscellaneousRepository 介面的物件執行個體。
        /// </summary>
		public IInvoiceDetails_MiscellaneousRepository InvoiceDetails_MiscellaneousRepository
		{
			get => SimpleIoc.Default.GetInstance<IInvoiceDetails_MiscellaneousRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IInvoiceDetailsRepository 介面的物件執行個體。
        /// </summary>
		public IInvoiceDetailsRepository InvoiceDetailsRepository
		{
			get => SimpleIoc.Default.GetInstance<IInvoiceDetailsRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IInvoicesRepository 介面的物件執行個體。
        /// </summary>
		public IInvoicesRepository InvoicesRepository
		{
			get => SimpleIoc.Default.GetInstance<IInvoicesRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IManufacturersBussinessItemsRepository 介面的物件執行個體。
        /// </summary>
		public IManufacturersBussinessItemsRepository ManufacturersBussinessItemsRepository
		{
			get => SimpleIoc.Default.GetInstance<IManufacturersBussinessItemsRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IManufacturersFactoriesRepository 介面的物件執行個體。
        /// </summary>
		public IManufacturersFactoriesRepository ManufacturersFactoriesRepository
		{
			get => SimpleIoc.Default.GetInstance<IManufacturersFactoriesRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IManufacturersRepository 介面的物件執行個體。
        /// </summary>
		public IManufacturersRepository ManufacturersRepository
		{
			get => SimpleIoc.Default.GetInstance<IManufacturersRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IMaterialCategoriesRepository 介面的物件執行個體。
        /// </summary>
		public IMaterialCategoriesRepository MaterialCategoriesRepository
		{
			get => SimpleIoc.Default.GetInstance<IMaterialCategoriesRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IMaterialEstimationRepository 介面的物件執行個體。
        /// </summary>
		public IMaterialEstimationRepository MaterialEstimationRepository
		{
			get => SimpleIoc.Default.GetInstance<IMaterialEstimationRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IMaterialsRepository 介面的物件執行個體。
        /// </summary>
		public IMaterialsRepository MaterialsRepository
		{
			get => SimpleIoc.Default.GetInstance<IMaterialsRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IMembershipRepository 介面的物件執行個體。
        /// </summary>
		public IMembershipRepository MembershipRepository
		{
			get => SimpleIoc.Default.GetInstance<IMembershipRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IMoldsInProjectsRepository 介面的物件執行個體。
        /// </summary>
		public IMoldsInProjectsRepository MoldsInProjectsRepository
		{
			get => SimpleIoc.Default.GetInstance<IMoldsInProjectsRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IMoldsRepository 介面的物件執行個體。
        /// </summary>
		public IMoldsRepository MoldsRepository
		{
			get => SimpleIoc.Default.GetInstance<IMoldsRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IMoldUseStatusRepository 介面的物件執行個體。
        /// </summary>
		public IMoldUseStatusRepository MoldUseStatusRepository
		{
			get => SimpleIoc.Default.GetInstance<IMoldUseStatusRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IOrderControlTableDetailsRepository 介面的物件執行個體。
        /// </summary>
		public IOrderControlTableDetailsRepository OrderControlTableDetailsRepository
		{
			get => SimpleIoc.Default.GetInstance<IOrderControlTableDetailsRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IOrderDetailsRepository 介面的物件執行個體。
        /// </summary>
		public IOrderDetailsRepository OrderDetailsRepository
		{
			get => SimpleIoc.Default.GetInstance<IOrderDetailsRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IOrderMaterialValuationRepository 介面的物件執行個體。
        /// </summary>
		public IOrderMaterialValuationRepository OrderMaterialValuationRepository
		{
			get => SimpleIoc.Default.GetInstance<IOrderMaterialValuationRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IOrderMiscellaneousRepository 介面的物件執行個體。
        /// </summary>
		public IOrderMiscellaneousRepository OrderMiscellaneousRepository
		{
			get => SimpleIoc.Default.GetInstance<IOrderMiscellaneousRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IOrdersRepository 介面的物件執行個體。
        /// </summary>
		public IOrdersRepository OrdersRepository
		{
			get => SimpleIoc.Default.GetInstance<IOrdersRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IOrderTypesRepository 介面的物件執行個體。
        /// </summary>
		public IOrderTypesRepository OrderTypesRepository
		{
			get => SimpleIoc.Default.GetInstance<IOrderTypesRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IPaymentTypesRepository 介面的物件執行個體。
        /// </summary>
		public IPaymentTypesRepository PaymentTypesRepository
		{
			get => SimpleIoc.Default.GetInstance<IPaymentTypesRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IPickListDetailsRepository 介面的物件執行個體。
        /// </summary>
		public IPickListDetailsRepository PickListDetailsRepository
		{
			get => SimpleIoc.Default.GetInstance<IPickListDetailsRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IPickListRepository 介面的物件執行個體。
        /// </summary>
		public IPickListRepository PickListRepository
		{
			get => SimpleIoc.Default.GetInstance<IPickListRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IProcessingAtlasRepository 介面的物件執行個體。
        /// </summary>
		public IProcessingAtlasRepository ProcessingAtlasRepository
		{
			get => SimpleIoc.Default.GetInstance<IProcessingAtlasRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IProfileRepository 介面的物件執行個體。
        /// </summary>
		public IProfileRepository ProfileRepository
		{
			get => SimpleIoc.Default.GetInstance<IProfileRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IProjectContractRepository 介面的物件執行個體。
        /// </summary>
		public IProjectContractRepository ProjectContractRepository
		{
			get => SimpleIoc.Default.GetInstance<IProjectContractRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IProjectItemCostRepository 介面的物件執行個體。
        /// </summary>
		public IProjectItemCostRepository ProjectItemCostRepository
		{
			get => SimpleIoc.Default.GetInstance<IProjectItemCostRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IProjectsRepository 介面的物件執行個體。
        /// </summary>
		public IProjectsRepository ProjectsRepository
		{
			get => SimpleIoc.Default.GetInstance<IProjectsRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IPromissoryNoteManagementRepository 介面的物件執行個體。
        /// </summary>
		public IPromissoryNoteManagementRepository PromissoryNoteManagementRepository
		{
			get => SimpleIoc.Default.GetInstance<IPromissoryNoteManagementRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IReceiveDetailsRepository 介面的物件執行個體。
        /// </summary>
		public IReceiveDetailsRepository ReceiveDetailsRepository
		{
			get => SimpleIoc.Default.GetInstance<IReceiveDetailsRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IReceiveRepository 介面的物件執行個體。
        /// </summary>
		public IReceiveRepository ReceiveRepository
		{
			get => SimpleIoc.Default.GetInstance<IReceiveRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IRequiredDetailsRepository 介面的物件執行個體。
        /// </summary>
		public IRequiredDetailsRepository RequiredDetailsRepository
		{
			get => SimpleIoc.Default.GetInstance<IRequiredDetailsRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IRequiredRepository 介面的物件執行個體。
        /// </summary>
		public IRequiredRepository RequiredRepository
		{
			get => SimpleIoc.Default.GetInstance<IRequiredRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IReturnDetailsRepository 介面的物件執行個體。
        /// </summary>
		public IReturnDetailsRepository ReturnDetailsRepository
		{
			get => SimpleIoc.Default.GetInstance<IReturnDetailsRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IReturnsRepository 介面的物件執行個體。
        /// </summary>
		public IReturnsRepository ReturnsRepository
		{
			get => SimpleIoc.Default.GetInstance<IReturnsRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IRolesRepository 介面的物件執行個體。
        /// </summary>
		public IRolesRepository RolesRepository
		{
			get => SimpleIoc.Default.GetInstance<IRolesRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IShopFlowDetailRepository 介面的物件執行個體。
        /// </summary>
		public IShopFlowDetailRepository ShopFlowDetailRepository
		{
			get => SimpleIoc.Default.GetInstance<IShopFlowDetailRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IShopFlowHistoryRepository 介面的物件執行個體。
        /// </summary>
		public IShopFlowHistoryRepository ShopFlowHistoryRepository
		{
			get => SimpleIoc.Default.GetInstance<IShopFlowHistoryRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IShopFlowRepository 介面的物件執行個體。
        /// </summary>
		public IShopFlowRepository ShopFlowRepository
		{
			get => SimpleIoc.Default.GetInstance<IShopFlowRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IStatesRepository 介面的物件執行個體。
        /// </summary>
		public IStatesRepository StatesRepository
		{
			get => SimpleIoc.Default.GetInstance<IStatesRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IStocksRepository 介面的物件執行個體。
        /// </summary>
		public IStocksRepository StocksRepository
		{
			get => SimpleIoc.Default.GetInstance<IStocksRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 ISupplierTranscationItemRepository 介面的物件執行個體。
        /// </summary>
		public ISupplierTranscationItemRepository SupplierTranscationItemRepository
		{
			get => SimpleIoc.Default.GetInstance<ISupplierTranscationItemRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 ITicketPeriodRepository 介面的物件執行個體。
        /// </summary>
		public ITicketPeriodRepository TicketPeriodRepository
		{
			get => SimpleIoc.Default.GetInstance<ITicketPeriodRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 ITicketTypesRepository 介面的物件執行個體。
        /// </summary>
		public ITicketTypesRepository TicketTypesRepository
		{
			get => SimpleIoc.Default.GetInstance<ITicketTypesRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 ITranscationCategoriesRepository 介面的物件執行個體。
        /// </summary>
		public ITranscationCategoriesRepository TranscationCategoriesRepository
		{
			get => SimpleIoc.Default.GetInstance<ITranscationCategoriesRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IUsersRepository 介面的物件執行個體。
        /// </summary>
		public IUsersRepository UsersRepository
		{
			get => SimpleIoc.Default.GetInstance<IUsersRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IView_BussinessItemsListRepository 介面的物件執行個體。
        /// </summary>
		public IView_BussinessItemsListRepository View_BussinessItemsListRepository
		{
			get => SimpleIoc.Default.GetInstance<IView_BussinessItemsListRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IView_ManufacturersBussinessTranscationsRepository 介面的物件執行個體。
        /// </summary>
		public IView_ManufacturersBussinessTranscationsRepository View_ManufacturersBussinessTranscationsRepository
		{
			get => SimpleIoc.Default.GetInstance<IView_ManufacturersBussinessTranscationsRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IView_OrderControlTableRepository 介面的物件執行個體。
        /// </summary>
		public IView_OrderControlTableRepository View_OrderControlTableRepository
		{
			get => SimpleIoc.Default.GetInstance<IView_OrderControlTableRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IView_OrderMaterialValuationRepository 介面的物件執行個體。
        /// </summary>
		public IView_OrderMaterialValuationRepository View_OrderMaterialValuationRepository
		{
			get => SimpleIoc.Default.GetInstance<IView_OrderMaterialValuationRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IView_OrdersRepository 介面的物件執行個體。
        /// </summary>
		public IView_OrdersRepository View_OrdersRepository
		{
			get => SimpleIoc.Default.GetInstance<IView_OrdersRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IView_PickListRepository 介面的物件執行個體。
        /// </summary>
		public IView_PickListRepository View_PickListRepository
		{
			get => SimpleIoc.Default.GetInstance<IView_PickListRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IView_RequiredControlTableRepository 介面的物件執行個體。
        /// </summary>
		public IView_RequiredControlTableRepository View_RequiredControlTableRepository
		{
			get => SimpleIoc.Default.GetInstance<IView_RequiredControlTableRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IView_RequiredFormsRepository 介面的物件執行個體。
        /// </summary>
		public IView_RequiredFormsRepository View_RequiredFormsRepository
		{
			get => SimpleIoc.Default.GetInstance<IView_RequiredFormsRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IView_ShippingListRepository 介面的物件執行個體。
        /// </summary>
		public IView_ShippingListRepository View_ShippingListRepository
		{
			get => SimpleIoc.Default.GetInstance<IView_ShippingListRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IView_ShippingRepository 介面的物件執行個體。
        /// </summary>
		public IView_ShippingRepository View_ShippingRepository
		{
			get => SimpleIoc.Default.GetInstance<IView_ShippingRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IWorkShopsRepository 介面的物件執行個體。
        /// </summary>
		public IWorkShopsRepository WorkShopsRepository
		{
			get => SimpleIoc.Default.GetInstance<IWorkShopsRepository>();
		}
		/// <summary>
        /// 取得IoC容器中的 AbnormalQuality 物件執行個體。
        /// </summary>
		public AbnormalQuality AbnormalQuality
		{
			get => SimpleIoc.Default.GetInstance<AbnormalQuality>();
		}
		/// <summary>
        /// 取得IoC容器中的 AbnormalQualityMetaData 物件執行個體。
        /// </summary>
		public AbnormalQualityMetaData AbnormalQualityMetaData
		{
			get => SimpleIoc.Default.GetInstance<AbnormalQualityMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 AbnormalQualityDetails 物件執行個體。
        /// </summary>
		public AbnormalQualityDetails AbnormalQualityDetails
		{
			get => SimpleIoc.Default.GetInstance<AbnormalQualityDetails>();
		}
		/// <summary>
        /// 取得IoC容器中的 AbnormalQualityDetailsMetaData 物件執行個體。
        /// </summary>
		public AbnormalQualityDetailsMetaData AbnormalQualityDetailsMetaData
		{
			get => SimpleIoc.Default.GetInstance<AbnormalQualityDetailsMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 AccessLog 物件執行個體。
        /// </summary>
		public AccessLog AccessLog
		{
			get => SimpleIoc.Default.GetInstance<AccessLog>();
		}
		/// <summary>
        /// 取得IoC容器中的 AccessLogMetaData 物件執行個體。
        /// </summary>
		public AccessLogMetaData AccessLogMetaData
		{
			get => SimpleIoc.Default.GetInstance<AccessLogMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 BOM 物件執行個體。
        /// </summary>
		public BOM BOM
		{
			get => SimpleIoc.Default.GetInstance<BOM>();
		}
		/// <summary>
        /// 取得IoC容器中的 BOMMetaData 物件執行個體。
        /// </summary>
		public BOMMetaData BOMMetaData
		{
			get => SimpleIoc.Default.GetInstance<BOMMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 ConstructionAtlas 物件執行個體。
        /// </summary>
		public ConstructionAtlas ConstructionAtlas
		{
			get => SimpleIoc.Default.GetInstance<ConstructionAtlas>();
		}
		/// <summary>
        /// 取得IoC容器中的 ConstructionAtlasMetaData 物件執行個體。
        /// </summary>
		public ConstructionAtlasMetaData ConstructionAtlasMetaData
		{
			get => SimpleIoc.Default.GetInstance<ConstructionAtlasMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 Contacts 物件執行個體。
        /// </summary>
		public Contacts Contacts
		{
			get => SimpleIoc.Default.GetInstance<Contacts>();
		}
		/// <summary>
        /// 取得IoC容器中的 ContactsMetaData 物件執行個體。
        /// </summary>
		public ContactsMetaData ContactsMetaData
		{
			get => SimpleIoc.Default.GetInstance<ContactsMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 ControlTableDetails 物件執行個體。
        /// </summary>
		public ControlTableDetails ControlTableDetails
		{
			get => SimpleIoc.Default.GetInstance<ControlTableDetails>();
		}
		/// <summary>
        /// 取得IoC容器中的 ControlTableDetailsMetaData 物件執行個體。
        /// </summary>
		public ControlTableDetailsMetaData ControlTableDetailsMetaData
		{
			get => SimpleIoc.Default.GetInstance<ControlTableDetailsMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 ControlTables 物件執行個體。
        /// </summary>
		public ControlTables ControlTables
		{
			get => SimpleIoc.Default.GetInstance<ControlTables>();
		}
		/// <summary>
        /// 取得IoC容器中的 ControlTablesMetaData 物件執行個體。
        /// </summary>
		public ControlTablesMetaData ControlTablesMetaData
		{
			get => SimpleIoc.Default.GetInstance<ControlTablesMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 EncodingRecords 物件執行個體。
        /// </summary>
		public EncodingRecords EncodingRecords
		{
			get => SimpleIoc.Default.GetInstance<EncodingRecords>();
		}
		/// <summary>
        /// 取得IoC容器中的 EncodingRecordsMetaData 物件執行個體。
        /// </summary>
		public EncodingRecordsMetaData EncodingRecordsMetaData
		{
			get => SimpleIoc.Default.GetInstance<EncodingRecordsMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 Engineering 物件執行個體。
        /// </summary>
		public Engineering Engineering
		{
			get => SimpleIoc.Default.GetInstance<Engineering>();
		}
		/// <summary>
        /// 取得IoC容器中的 EngineeringMetaData 物件執行個體。
        /// </summary>
		public EngineeringMetaData EngineeringMetaData
		{
			get => SimpleIoc.Default.GetInstance<EngineeringMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 Inventory 物件執行個體。
        /// </summary>
		public Inventory Inventory
		{
			get => SimpleIoc.Default.GetInstance<Inventory>();
		}
		/// <summary>
        /// 取得IoC容器中的 InventoryMetaData 物件執行個體。
        /// </summary>
		public InventoryMetaData InventoryMetaData
		{
			get => SimpleIoc.Default.GetInstance<InventoryMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 InvoiceDetails 物件執行個體。
        /// </summary>
		public InvoiceDetails InvoiceDetails
		{
			get => SimpleIoc.Default.GetInstance<InvoiceDetails>();
		}
		/// <summary>
        /// 取得IoC容器中的 InvoiceDetailsMetaData 物件執行個體。
        /// </summary>
		public InvoiceDetailsMetaData InvoiceDetailsMetaData
		{
			get => SimpleIoc.Default.GetInstance<InvoiceDetailsMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 InvoiceDetails_Material 物件執行個體。
        /// </summary>
		public InvoiceDetails_Material InvoiceDetails_Material
		{
			get => SimpleIoc.Default.GetInstance<InvoiceDetails_Material>();
		}
		/// <summary>
        /// 取得IoC容器中的 InvoiceDetails_MaterialMetaData 物件執行個體。
        /// </summary>
		public InvoiceDetails_MaterialMetaData InvoiceDetails_MaterialMetaData
		{
			get => SimpleIoc.Default.GetInstance<InvoiceDetails_MaterialMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 InvoiceDetails_Miscellaneous 物件執行個體。
        /// </summary>
		public InvoiceDetails_Miscellaneous InvoiceDetails_Miscellaneous
		{
			get => SimpleIoc.Default.GetInstance<InvoiceDetails_Miscellaneous>();
		}
		/// <summary>
        /// 取得IoC容器中的 InvoiceDetails_MiscellaneousMetaData 物件執行個體。
        /// </summary>
		public InvoiceDetails_MiscellaneousMetaData InvoiceDetails_MiscellaneousMetaData
		{
			get => SimpleIoc.Default.GetInstance<InvoiceDetails_MiscellaneousMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 Invoices 物件執行個體。
        /// </summary>
		public Invoices Invoices
		{
			get => SimpleIoc.Default.GetInstance<Invoices>();
		}
		/// <summary>
        /// 取得IoC容器中的 InvoicesMetaData 物件執行個體。
        /// </summary>
		public InvoicesMetaData InvoicesMetaData
		{
			get => SimpleIoc.Default.GetInstance<InvoicesMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 Manufacturers 物件執行個體。
        /// </summary>
		public Manufacturers Manufacturers
		{
			get => SimpleIoc.Default.GetInstance<Manufacturers>();
		}
		/// <summary>
        /// 取得IoC容器中的 ManufacturersMetaData 物件執行個體。
        /// </summary>
		public ManufacturersMetaData ManufacturersMetaData
		{
			get => SimpleIoc.Default.GetInstance<ManufacturersMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 ManufacturersBussinessItems 物件執行個體。
        /// </summary>
		public ManufacturersBussinessItems ManufacturersBussinessItems
		{
			get => SimpleIoc.Default.GetInstance<ManufacturersBussinessItems>();
		}
		/// <summary>
        /// 取得IoC容器中的 ManufacturersBussinessItemsMetaData 物件執行個體。
        /// </summary>
		public ManufacturersBussinessItemsMetaData ManufacturersBussinessItemsMetaData
		{
			get => SimpleIoc.Default.GetInstance<ManufacturersBussinessItemsMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 ManufacturersFactories 物件執行個體。
        /// </summary>
		public ManufacturersFactories ManufacturersFactories
		{
			get => SimpleIoc.Default.GetInstance<ManufacturersFactories>();
		}
		/// <summary>
        /// 取得IoC容器中的 ManufacturersFactoriesMetaData 物件執行個體。
        /// </summary>
		public ManufacturersFactoriesMetaData ManufacturersFactoriesMetaData
		{
			get => SimpleIoc.Default.GetInstance<ManufacturersFactoriesMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 MaterialCategories 物件執行個體。
        /// </summary>
		public MaterialCategories MaterialCategories
		{
			get => SimpleIoc.Default.GetInstance<MaterialCategories>();
		}
		/// <summary>
        /// 取得IoC容器中的 MaterialCategoriesMetaData 物件執行個體。
        /// </summary>
		public MaterialCategoriesMetaData MaterialCategoriesMetaData
		{
			get => SimpleIoc.Default.GetInstance<MaterialCategoriesMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 MaterialEstimation 物件執行個體。
        /// </summary>
		public MaterialEstimation MaterialEstimation
		{
			get => SimpleIoc.Default.GetInstance<MaterialEstimation>();
		}
		/// <summary>
        /// 取得IoC容器中的 MaterialEstimationMetaData 物件執行個體。
        /// </summary>
		public MaterialEstimationMetaData MaterialEstimationMetaData
		{
			get => SimpleIoc.Default.GetInstance<MaterialEstimationMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 Materials 物件執行個體。
        /// </summary>
		public Materials Materials
		{
			get => SimpleIoc.Default.GetInstance<Materials>();
		}
		/// <summary>
        /// 取得IoC容器中的 MaterialsMetaData 物件執行個體。
        /// </summary>
		public MaterialsMetaData MaterialsMetaData
		{
			get => SimpleIoc.Default.GetInstance<MaterialsMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 Membership 物件執行個體。
        /// </summary>
		public Membership Membership
		{
			get => SimpleIoc.Default.GetInstance<Membership>();
		}
		/// <summary>
        /// 取得IoC容器中的 MembershipMetaData 物件執行個體。
        /// </summary>
		public MembershipMetaData MembershipMetaData
		{
			get => SimpleIoc.Default.GetInstance<MembershipMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 Molds 物件執行個體。
        /// </summary>
		public Molds Molds
		{
			get => SimpleIoc.Default.GetInstance<Molds>();
		}
		/// <summary>
        /// 取得IoC容器中的 MoldsMetaData 物件執行個體。
        /// </summary>
		public MoldsMetaData MoldsMetaData
		{
			get => SimpleIoc.Default.GetInstance<MoldsMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 MoldsInProjects 物件執行個體。
        /// </summary>
		public MoldsInProjects MoldsInProjects
		{
			get => SimpleIoc.Default.GetInstance<MoldsInProjects>();
		}
		/// <summary>
        /// 取得IoC容器中的 MoldsInProjectsMetaData 物件執行個體。
        /// </summary>
		public MoldsInProjectsMetaData MoldsInProjectsMetaData
		{
			get => SimpleIoc.Default.GetInstance<MoldsInProjectsMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 MoldUseStatus 物件執行個體。
        /// </summary>
		public MoldUseStatus MoldUseStatus
		{
			get => SimpleIoc.Default.GetInstance<MoldUseStatus>();
		}
		/// <summary>
        /// 取得IoC容器中的 MoldUseStatusMetaData 物件執行個體。
        /// </summary>
		public MoldUseStatusMetaData MoldUseStatusMetaData
		{
			get => SimpleIoc.Default.GetInstance<MoldUseStatusMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 OrderControlTableDetails 物件執行個體。
        /// </summary>
		public OrderControlTableDetails OrderControlTableDetails
		{
			get => SimpleIoc.Default.GetInstance<OrderControlTableDetails>();
		}
		/// <summary>
        /// 取得IoC容器中的 OrderControlTableDetailsMetaData 物件執行個體。
        /// </summary>
		public OrderControlTableDetailsMetaData OrderControlTableDetailsMetaData
		{
			get => SimpleIoc.Default.GetInstance<OrderControlTableDetailsMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 OrderDetails 物件執行個體。
        /// </summary>
		public OrderDetails OrderDetails
		{
			get => SimpleIoc.Default.GetInstance<OrderDetails>();
		}
		/// <summary>
        /// 取得IoC容器中的 OrderDetailsMetaData 物件執行個體。
        /// </summary>
		public OrderDetailsMetaData OrderDetailsMetaData
		{
			get => SimpleIoc.Default.GetInstance<OrderDetailsMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 OrderMaterialValuation 物件執行個體。
        /// </summary>
		public OrderMaterialValuation OrderMaterialValuation
		{
			get => SimpleIoc.Default.GetInstance<OrderMaterialValuation>();
		}
		/// <summary>
        /// 取得IoC容器中的 OrderMaterialValuationMetaData 物件執行個體。
        /// </summary>
		public OrderMaterialValuationMetaData OrderMaterialValuationMetaData
		{
			get => SimpleIoc.Default.GetInstance<OrderMaterialValuationMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 OrderMiscellaneous 物件執行個體。
        /// </summary>
		public OrderMiscellaneous OrderMiscellaneous
		{
			get => SimpleIoc.Default.GetInstance<OrderMiscellaneous>();
		}
		/// <summary>
        /// 取得IoC容器中的 OrderMiscellaneousMetaData 物件執行個體。
        /// </summary>
		public OrderMiscellaneousMetaData OrderMiscellaneousMetaData
		{
			get => SimpleIoc.Default.GetInstance<OrderMiscellaneousMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 Orders 物件執行個體。
        /// </summary>
		public Orders Orders
		{
			get => SimpleIoc.Default.GetInstance<Orders>();
		}
		/// <summary>
        /// 取得IoC容器中的 OrdersMetaData 物件執行個體。
        /// </summary>
		public OrdersMetaData OrdersMetaData
		{
			get => SimpleIoc.Default.GetInstance<OrdersMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 OrderTypes 物件執行個體。
        /// </summary>
		public OrderTypes OrderTypes
		{
			get => SimpleIoc.Default.GetInstance<OrderTypes>();
		}
		/// <summary>
        /// 取得IoC容器中的 OrderTypesMetaData 物件執行個體。
        /// </summary>
		public OrderTypesMetaData OrderTypesMetaData
		{
			get => SimpleIoc.Default.GetInstance<OrderTypesMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 PaymentTypes 物件執行個體。
        /// </summary>
		public PaymentTypes PaymentTypes
		{
			get => SimpleIoc.Default.GetInstance<PaymentTypes>();
		}
		/// <summary>
        /// 取得IoC容器中的 PaymentTypesMetaData 物件執行個體。
        /// </summary>
		public PaymentTypesMetaData PaymentTypesMetaData
		{
			get => SimpleIoc.Default.GetInstance<PaymentTypesMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 PickList 物件執行個體。
        /// </summary>
		public PickList PickList
		{
			get => SimpleIoc.Default.GetInstance<PickList>();
		}
		/// <summary>
        /// 取得IoC容器中的 PickListMetaData 物件執行個體。
        /// </summary>
		public PickListMetaData PickListMetaData
		{
			get => SimpleIoc.Default.GetInstance<PickListMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 PickListDetails 物件執行個體。
        /// </summary>
		public PickListDetails PickListDetails
		{
			get => SimpleIoc.Default.GetInstance<PickListDetails>();
		}
		/// <summary>
        /// 取得IoC容器中的 PickListDetailsMetaData 物件執行個體。
        /// </summary>
		public PickListDetailsMetaData PickListDetailsMetaData
		{
			get => SimpleIoc.Default.GetInstance<PickListDetailsMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 ProcessingAtlas 物件執行個體。
        /// </summary>
		public ProcessingAtlas ProcessingAtlas
		{
			get => SimpleIoc.Default.GetInstance<ProcessingAtlas>();
		}
		/// <summary>
        /// 取得IoC容器中的 ProcessingAtlasMetaData 物件執行個體。
        /// </summary>
		public ProcessingAtlasMetaData ProcessingAtlasMetaData
		{
			get => SimpleIoc.Default.GetInstance<ProcessingAtlasMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 Profile 物件執行個體。
        /// </summary>
		public Profile Profile
		{
			get => SimpleIoc.Default.GetInstance<Profile>();
		}
		/// <summary>
        /// 取得IoC容器中的 ProfileMetaData 物件執行個體。
        /// </summary>
		public ProfileMetaData ProfileMetaData
		{
			get => SimpleIoc.Default.GetInstance<ProfileMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 ProjectContract 物件執行個體。
        /// </summary>
		public ProjectContract ProjectContract
		{
			get => SimpleIoc.Default.GetInstance<ProjectContract>();
		}
		/// <summary>
        /// 取得IoC容器中的 ProjectContractMetaData 物件執行個體。
        /// </summary>
		public ProjectContractMetaData ProjectContractMetaData
		{
			get => SimpleIoc.Default.GetInstance<ProjectContractMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 ProjectItemCost 物件執行個體。
        /// </summary>
		public ProjectItemCost ProjectItemCost
		{
			get => SimpleIoc.Default.GetInstance<ProjectItemCost>();
		}
		/// <summary>
        /// 取得IoC容器中的 ProjectItemCostMetaData 物件執行個體。
        /// </summary>
		public ProjectItemCostMetaData ProjectItemCostMetaData
		{
			get => SimpleIoc.Default.GetInstance<ProjectItemCostMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 Projects 物件執行個體。
        /// </summary>
		public Projects Projects
		{
			get => SimpleIoc.Default.GetInstance<Projects>();
		}
		/// <summary>
        /// 取得IoC容器中的 ProjectsMetaData 物件執行個體。
        /// </summary>
		public ProjectsMetaData ProjectsMetaData
		{
			get => SimpleIoc.Default.GetInstance<ProjectsMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 PromissoryNoteManagement 物件執行個體。
        /// </summary>
		public PromissoryNoteManagement PromissoryNoteManagement
		{
			get => SimpleIoc.Default.GetInstance<PromissoryNoteManagement>();
		}
		/// <summary>
        /// 取得IoC容器中的 PromissoryNoteManagementMetaData 物件執行個體。
        /// </summary>
		public PromissoryNoteManagementMetaData PromissoryNoteManagementMetaData
		{
			get => SimpleIoc.Default.GetInstance<PromissoryNoteManagementMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 Receive 物件執行個體。
        /// </summary>
		public Receive Receive
		{
			get => SimpleIoc.Default.GetInstance<Receive>();
		}
		/// <summary>
        /// 取得IoC容器中的 ReceiveMetaData 物件執行個體。
        /// </summary>
		public ReceiveMetaData ReceiveMetaData
		{
			get => SimpleIoc.Default.GetInstance<ReceiveMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 ReceiveDetails 物件執行個體。
        /// </summary>
		public ReceiveDetails ReceiveDetails
		{
			get => SimpleIoc.Default.GetInstance<ReceiveDetails>();
		}
		/// <summary>
        /// 取得IoC容器中的 ReceiveDetailsMetaData 物件執行個體。
        /// </summary>
		public ReceiveDetailsMetaData ReceiveDetailsMetaData
		{
			get => SimpleIoc.Default.GetInstance<ReceiveDetailsMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 Required 物件執行個體。
        /// </summary>
		public Required Required
		{
			get => SimpleIoc.Default.GetInstance<Required>();
		}
		/// <summary>
        /// 取得IoC容器中的 RequiredMetaData 物件執行個體。
        /// </summary>
		public RequiredMetaData RequiredMetaData
		{
			get => SimpleIoc.Default.GetInstance<RequiredMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 RequiredDetails 物件執行個體。
        /// </summary>
		public RequiredDetails RequiredDetails
		{
			get => SimpleIoc.Default.GetInstance<RequiredDetails>();
		}
		/// <summary>
        /// 取得IoC容器中的 RequiredDetailsMetaData 物件執行個體。
        /// </summary>
		public RequiredDetailsMetaData RequiredDetailsMetaData
		{
			get => SimpleIoc.Default.GetInstance<RequiredDetailsMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 ReturnDetails 物件執行個體。
        /// </summary>
		public ReturnDetails ReturnDetails
		{
			get => SimpleIoc.Default.GetInstance<ReturnDetails>();
		}
		/// <summary>
        /// 取得IoC容器中的 ReturnDetailsMetaData 物件執行個體。
        /// </summary>
		public ReturnDetailsMetaData ReturnDetailsMetaData
		{
			get => SimpleIoc.Default.GetInstance<ReturnDetailsMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 Returns 物件執行個體。
        /// </summary>
		public Returns Returns
		{
			get => SimpleIoc.Default.GetInstance<Returns>();
		}
		/// <summary>
        /// 取得IoC容器中的 ReturnsMetaData 物件執行個體。
        /// </summary>
		public ReturnsMetaData ReturnsMetaData
		{
			get => SimpleIoc.Default.GetInstance<ReturnsMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 Roles 物件執行個體。
        /// </summary>
		public Roles Roles
		{
			get => SimpleIoc.Default.GetInstance<Roles>();
		}
		/// <summary>
        /// 取得IoC容器中的 RolesMetaData 物件執行個體。
        /// </summary>
		public RolesMetaData RolesMetaData
		{
			get => SimpleIoc.Default.GetInstance<RolesMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 ShopFlow 物件執行個體。
        /// </summary>
		public ShopFlow ShopFlow
		{
			get => SimpleIoc.Default.GetInstance<ShopFlow>();
		}
		/// <summary>
        /// 取得IoC容器中的 ShopFlowMetaData 物件執行個體。
        /// </summary>
		public ShopFlowMetaData ShopFlowMetaData
		{
			get => SimpleIoc.Default.GetInstance<ShopFlowMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 ShopFlowDetail 物件執行個體。
        /// </summary>
		public ShopFlowDetail ShopFlowDetail
		{
			get => SimpleIoc.Default.GetInstance<ShopFlowDetail>();
		}
		/// <summary>
        /// 取得IoC容器中的 ShopFlowDetailMetaData 物件執行個體。
        /// </summary>
		public ShopFlowDetailMetaData ShopFlowDetailMetaData
		{
			get => SimpleIoc.Default.GetInstance<ShopFlowDetailMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 ShopFlowHistory 物件執行個體。
        /// </summary>
		public ShopFlowHistory ShopFlowHistory
		{
			get => SimpleIoc.Default.GetInstance<ShopFlowHistory>();
		}
		/// <summary>
        /// 取得IoC容器中的 ShopFlowHistoryMetaData 物件執行個體。
        /// </summary>
		public ShopFlowHistoryMetaData ShopFlowHistoryMetaData
		{
			get => SimpleIoc.Default.GetInstance<ShopFlowHistoryMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 SplitString_Result 物件執行個體。
        /// </summary>
		public SplitString_Result SplitString_Result
		{
			get => SimpleIoc.Default.GetInstance<SplitString_Result>();
		}
		/// <summary>
        /// 取得IoC容器中的 SplitString_ResultMetaData 物件執行個體。
        /// </summary>
		public SplitString_ResultMetaData SplitString_ResultMetaData
		{
			get => SimpleIoc.Default.GetInstance<SplitString_ResultMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 States 物件執行個體。
        /// </summary>
		public States States
		{
			get => SimpleIoc.Default.GetInstance<States>();
		}
		/// <summary>
        /// 取得IoC容器中的 StatesMetaData 物件執行個體。
        /// </summary>
		public StatesMetaData StatesMetaData
		{
			get => SimpleIoc.Default.GetInstance<StatesMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 Stocks 物件執行個體。
        /// </summary>
		public Stocks Stocks
		{
			get => SimpleIoc.Default.GetInstance<Stocks>();
		}
		/// <summary>
        /// 取得IoC容器中的 StocksMetaData 物件執行個體。
        /// </summary>
		public StocksMetaData StocksMetaData
		{
			get => SimpleIoc.Default.GetInstance<StocksMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 SupplierTranscationItem 物件執行個體。
        /// </summary>
		public SupplierTranscationItem SupplierTranscationItem
		{
			get => SimpleIoc.Default.GetInstance<SupplierTranscationItem>();
		}
		/// <summary>
        /// 取得IoC容器中的 SupplierTranscationItemMetaData 物件執行個體。
        /// </summary>
		public SupplierTranscationItemMetaData SupplierTranscationItemMetaData
		{
			get => SimpleIoc.Default.GetInstance<SupplierTranscationItemMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 TicketPeriod 物件執行個體。
        /// </summary>
		public TicketPeriod TicketPeriod
		{
			get => SimpleIoc.Default.GetInstance<TicketPeriod>();
		}
		/// <summary>
        /// 取得IoC容器中的 TicketPeriodMetaData 物件執行個體。
        /// </summary>
		public TicketPeriodMetaData TicketPeriodMetaData
		{
			get => SimpleIoc.Default.GetInstance<TicketPeriodMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 TicketTypes 物件執行個體。
        /// </summary>
		public TicketTypes TicketTypes
		{
			get => SimpleIoc.Default.GetInstance<TicketTypes>();
		}
		/// <summary>
        /// 取得IoC容器中的 TicketTypesMetaData 物件執行個體。
        /// </summary>
		public TicketTypesMetaData TicketTypesMetaData
		{
			get => SimpleIoc.Default.GetInstance<TicketTypesMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 TradingItems 物件執行個體。
        /// </summary>
		public TradingItems TradingItems
		{
			get => SimpleIoc.Default.GetInstance<TradingItems>();
		}
		/// <summary>
        /// 取得IoC容器中的 TradingItemsMetaData 物件執行個體。
        /// </summary>
		public TradingItemsMetaData TradingItemsMetaData
		{
			get => SimpleIoc.Default.GetInstance<TradingItemsMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 TranscationCategories 物件執行個體。
        /// </summary>
		public TranscationCategories TranscationCategories
		{
			get => SimpleIoc.Default.GetInstance<TranscationCategories>();
		}
		/// <summary>
        /// 取得IoC容器中的 TranscationCategoriesMetaData 物件執行個體。
        /// </summary>
		public TranscationCategoriesMetaData TranscationCategoriesMetaData
		{
			get => SimpleIoc.Default.GetInstance<TranscationCategoriesMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 Users 物件執行個體。
        /// </summary>
		public Users Users
		{
			get => SimpleIoc.Default.GetInstance<Users>();
		}
		/// <summary>
        /// 取得IoC容器中的 UsersMetaData 物件執行個體。
        /// </summary>
		public UsersMetaData UsersMetaData
		{
			get => SimpleIoc.Default.GetInstance<UsersMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 View_BussinessItemsList 物件執行個體。
        /// </summary>
		public View_BussinessItemsList View_BussinessItemsList
		{
			get => SimpleIoc.Default.GetInstance<View_BussinessItemsList>();
		}
		/// <summary>
        /// 取得IoC容器中的 View_BussinessItemsListMetaData 物件執行個體。
        /// </summary>
		public View_BussinessItemsListMetaData View_BussinessItemsListMetaData
		{
			get => SimpleIoc.Default.GetInstance<View_BussinessItemsListMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 View_ManufacturersBussinessTranscations 物件執行個體。
        /// </summary>
		public View_ManufacturersBussinessTranscations View_ManufacturersBussinessTranscations
		{
			get => SimpleIoc.Default.GetInstance<View_ManufacturersBussinessTranscations>();
		}
		/// <summary>
        /// 取得IoC容器中的 View_ManufacturersBussinessTranscationsMetaData 物件執行個體。
        /// </summary>
		public View_ManufacturersBussinessTranscationsMetaData View_ManufacturersBussinessTranscationsMetaData
		{
			get => SimpleIoc.Default.GetInstance<View_ManufacturersBussinessTranscationsMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 View_ObtainMaterial 物件執行個體。
        /// </summary>
		public View_ObtainMaterial View_ObtainMaterial
		{
			get => SimpleIoc.Default.GetInstance<View_ObtainMaterial>();
		}
		/// <summary>
        /// 取得IoC容器中的 View_ObtainMaterialMetaData 物件執行個體。
        /// </summary>
		public View_ObtainMaterialMetaData View_ObtainMaterialMetaData
		{
			get => SimpleIoc.Default.GetInstance<View_ObtainMaterialMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 View_OrderControlTable 物件執行個體。
        /// </summary>
		public View_OrderControlTable View_OrderControlTable
		{
			get => SimpleIoc.Default.GetInstance<View_OrderControlTable>();
		}
		/// <summary>
        /// 取得IoC容器中的 View_OrderControlTableMetaData 物件執行個體。
        /// </summary>
		public View_OrderControlTableMetaData View_OrderControlTableMetaData
		{
			get => SimpleIoc.Default.GetInstance<View_OrderControlTableMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 View_OrderMaterialValuation 物件執行個體。
        /// </summary>
		public View_OrderMaterialValuation View_OrderMaterialValuation
		{
			get => SimpleIoc.Default.GetInstance<View_OrderMaterialValuation>();
		}
		/// <summary>
        /// 取得IoC容器中的 View_OrderMaterialValuationMetaData 物件執行個體。
        /// </summary>
		public View_OrderMaterialValuationMetaData View_OrderMaterialValuationMetaData
		{
			get => SimpleIoc.Default.GetInstance<View_OrderMaterialValuationMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 View_Orders 物件執行個體。
        /// </summary>
		public View_Orders View_Orders
		{
			get => SimpleIoc.Default.GetInstance<View_Orders>();
		}
		/// <summary>
        /// 取得IoC容器中的 View_OrdersMetaData 物件執行個體。
        /// </summary>
		public View_OrdersMetaData View_OrdersMetaData
		{
			get => SimpleIoc.Default.GetInstance<View_OrdersMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 View_PickList 物件執行個體。
        /// </summary>
		public View_PickList View_PickList
		{
			get => SimpleIoc.Default.GetInstance<View_PickList>();
		}
		/// <summary>
        /// 取得IoC容器中的 View_PickListMetaData 物件執行個體。
        /// </summary>
		public View_PickListMetaData View_PickListMetaData
		{
			get => SimpleIoc.Default.GetInstance<View_PickListMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 View_RequiredControlTable 物件執行個體。
        /// </summary>
		public View_RequiredControlTable View_RequiredControlTable
		{
			get => SimpleIoc.Default.GetInstance<View_RequiredControlTable>();
		}
		/// <summary>
        /// 取得IoC容器中的 View_RequiredControlTableMetaData 物件執行個體。
        /// </summary>
		public View_RequiredControlTableMetaData View_RequiredControlTableMetaData
		{
			get => SimpleIoc.Default.GetInstance<View_RequiredControlTableMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 View_RequiredForms 物件執行個體。
        /// </summary>
		public View_RequiredForms View_RequiredForms
		{
			get => SimpleIoc.Default.GetInstance<View_RequiredForms>();
		}
		/// <summary>
        /// 取得IoC容器中的 View_RequiredFormsMetaData 物件執行個體。
        /// </summary>
		public View_RequiredFormsMetaData View_RequiredFormsMetaData
		{
			get => SimpleIoc.Default.GetInstance<View_RequiredFormsMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 View_Shipping 物件執行個體。
        /// </summary>
		public View_Shipping View_Shipping
		{
			get => SimpleIoc.Default.GetInstance<View_Shipping>();
		}
		/// <summary>
        /// 取得IoC容器中的 View_ShippingMetaData 物件執行個體。
        /// </summary>
		public View_ShippingMetaData View_ShippingMetaData
		{
			get => SimpleIoc.Default.GetInstance<View_ShippingMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 View_ShippingList 物件執行個體。
        /// </summary>
		public View_ShippingList View_ShippingList
		{
			get => SimpleIoc.Default.GetInstance<View_ShippingList>();
		}
		/// <summary>
        /// 取得IoC容器中的 View_ShippingListMetaData 物件執行個體。
        /// </summary>
		public View_ShippingListMetaData View_ShippingListMetaData
		{
			get => SimpleIoc.Default.GetInstance<View_ShippingListMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 WorkShops 物件執行個體。
        /// </summary>
		public WorkShops WorkShops
		{
			get => SimpleIoc.Default.GetInstance<WorkShops>();
		}
		/// <summary>
        /// 取得IoC容器中的 WorkShopsMetaData 物件執行個體。
        /// </summary>
		public WorkShopsMetaData WorkShopsMetaData
		{
			get => SimpleIoc.Default.GetInstance<WorkShopsMetaData>();
		}
		/// <summary>
        /// 取得IoC容器中的 TokikuEntities 物件執行個體。
        /// </summary>
		public TokikuEntities TokikuEntities
		{
			get => SimpleIoc.Default.GetInstance<TokikuEntities>();
		}
		/// <summary>
        /// 取得IoC容器中的 AluminumExtrusionOrderEntity 物件執行個體。
        /// </summary>
		public AluminumExtrusionOrderEntity AluminumExtrusionOrderEntity
		{
			get => SimpleIoc.Default.GetInstance<AluminumExtrusionOrderEntity>();
		}
		/// <summary>
        /// 取得IoC容器中的 AluminumExtrusionOrderListEntity 物件執行個體。
        /// </summary>
		public AluminumExtrusionOrderListEntity AluminumExtrusionOrderListEntity
		{
			get => SimpleIoc.Default.GetInstance<AluminumExtrusionOrderListEntity>();
		}
		/// <summary>
        /// 取得IoC容器中的 AluminumExtrusionOrderMaterialValuationEntity 物件執行個體。
        /// </summary>
		public AluminumExtrusionOrderMaterialValuationEntity AluminumExtrusionOrderMaterialValuationEntity
		{
			get => SimpleIoc.Default.GetInstance<AluminumExtrusionOrderMaterialValuationEntity>();
		}
		/// <summary>
        /// 取得IoC容器中的 AluminumExtrusionOrderMiscellaneousEntity 物件執行個體。
        /// </summary>
		public AluminumExtrusionOrderMiscellaneousEntity AluminumExtrusionOrderMiscellaneousEntity
		{
			get => SimpleIoc.Default.GetInstance<AluminumExtrusionOrderMiscellaneousEntity>();
		}
		/// <summary>
        /// 取得IoC容器中的 ContractManagementEntity 物件執行個體。
        /// </summary>
		public ContractManagementEntity ContractManagementEntity
		{
			get => SimpleIoc.Default.GetInstance<ContractManagementEntity>();
		}
		/// <summary>
        /// 取得IoC容器中的 InventoryListEntity 物件執行個體。
        /// </summary>
		public InventoryListEntity InventoryListEntity
		{
			get => SimpleIoc.Default.GetInstance<InventoryListEntity>();
		}
		/// <summary>
        /// 取得IoC容器中的 MainWindowEntity 物件執行個體。
        /// </summary>
		public MainWindowEntity MainWindowEntity
		{
			get => SimpleIoc.Default.GetInstance<MainWindowEntity>();
		}
		/// <summary>
        /// 取得IoC容器中的 ManufacturersEnter 物件執行個體。
        /// </summary>
		public ManufacturersEnter ManufacturersEnter
		{
			get => SimpleIoc.Default.GetInstance<ManufacturersEnter>();
		}
		/// <summary>
        /// 取得IoC容器中的 MoldsEnter 物件執行個體。
        /// </summary>
		public MoldsEnter MoldsEnter
		{
			get => SimpleIoc.Default.GetInstance<MoldsEnter>();
		}
		/// <summary>
        /// 取得IoC容器中的 ProcessingAtlasDetailEntity 物件執行個體。
        /// </summary>
		public ProcessingAtlasDetailEntity ProcessingAtlasDetailEntity
		{
			get => SimpleIoc.Default.GetInstance<ProcessingAtlasDetailEntity>();
		}
		/// <summary>
        /// 取得IoC容器中的 ProjectListEntity 物件執行個體。
        /// </summary>
		public ProjectListEntity ProjectListEntity
		{
			get => SimpleIoc.Default.GetInstance<ProjectListEntity>();
		}
		/// <summary>
        /// 取得IoC容器中的 PromissoryNoteManagementEntity 物件執行個體。
        /// </summary>
		public PromissoryNoteManagementEntity PromissoryNoteManagementEntity
		{
			get => SimpleIoc.Default.GetInstance<PromissoryNoteManagementEntity>();
		}
		/// <summary>
        /// 取得IoC容器中的 RecvMaterialListEntity 物件執行個體。
        /// </summary>
		public RecvMaterialListEntity RecvMaterialListEntity
		{
			get => SimpleIoc.Default.GetInstance<RecvMaterialListEntity>();
		}
		/// <summary>
        /// 取得IoC容器中的 SystemMembersEntity 物件執行個體。
        /// </summary>
		public SystemMembersEntity SystemMembersEntity
		{
			get => SimpleIoc.Default.GetInstance<SystemMembersEntity>();
		}
		/// <summary>
        /// 取得IoC容器中的 SystemRolesEntity 物件執行個體。
        /// </summary>
		public SystemRolesEntity SystemRolesEntity
		{
			get => SimpleIoc.Default.GetInstance<SystemRolesEntity>();
		}
	}
}
