using System;

namespace Tokiku.Entity
{
	public static class RepositoryHelper
	{
		public static IUnitOfWork GetUnitOfWork()
		{
			return new EFUnitOfWork();
		}

		public static TUnitOfWork GetUnitOfWork<TUnitOfWork>() where TUnitOfWork : IUnitOfWork
        {
            return Activator.CreateInstance<TUnitOfWork>();
        }
		
		
		public static AccessLogRepository GetAccessLogRepository()
		{
			var repository = new AccessLogRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static AccessLogRepository GetAccessLogRepository(IUnitOfWork unitOfWork)
		{
			var repository = new AccessLogRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static BOMRepository GetBOMRepository()
		{
			var repository = new BOMRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static BOMRepository GetBOMRepository(IUnitOfWork unitOfWork)
		{
			var repository = new BOMRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ConstructionAtlasRepository GetConstructionAtlasRepository()
		{
			var repository = new ConstructionAtlasRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ConstructionAtlasRepository GetConstructionAtlasRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ConstructionAtlasRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ContactsRepository GetContactsRepository()
		{
			var repository = new ContactsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ContactsRepository GetContactsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ContactsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ControlTableDetailsRepository GetControlTableDetailsRepository()
		{
			var repository = new ControlTableDetailsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ControlTableDetailsRepository GetControlTableDetailsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ControlTableDetailsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ControlTablesRepository GetControlTablesRepository()
		{
			var repository = new ControlTablesRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ControlTablesRepository GetControlTablesRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ControlTablesRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static EncodingRecordsRepository GetEncodingRecordsRepository()
		{
			var repository = new EncodingRecordsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static EncodingRecordsRepository GetEncodingRecordsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new EncodingRecordsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static EngineeringRepository GetEngineeringRepository()
		{
			var repository = new EngineeringRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static EngineeringRepository GetEngineeringRepository(IUnitOfWork unitOfWork)
		{
			var repository = new EngineeringRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static InventoryRepository GetInventoryRepository()
		{
			var repository = new InventoryRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static InventoryRepository GetInventoryRepository(IUnitOfWork unitOfWork)
		{
			var repository = new InventoryRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static InvoiceDetailsRepository GetInvoiceDetailsRepository()
		{
			var repository = new InvoiceDetailsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static InvoiceDetailsRepository GetInvoiceDetailsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new InvoiceDetailsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static InvoiceDetails_MaterialRepository GetInvoiceDetails_MaterialRepository()
		{
			var repository = new InvoiceDetails_MaterialRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static InvoiceDetails_MaterialRepository GetInvoiceDetails_MaterialRepository(IUnitOfWork unitOfWork)
		{
			var repository = new InvoiceDetails_MaterialRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static InvoiceDetails_MiscellaneousRepository GetInvoiceDetails_MiscellaneousRepository()
		{
			var repository = new InvoiceDetails_MiscellaneousRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static InvoiceDetails_MiscellaneousRepository GetInvoiceDetails_MiscellaneousRepository(IUnitOfWork unitOfWork)
		{
			var repository = new InvoiceDetails_MiscellaneousRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static InvoicesRepository GetInvoicesRepository()
		{
			var repository = new InvoicesRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static InvoicesRepository GetInvoicesRepository(IUnitOfWork unitOfWork)
		{
			var repository = new InvoicesRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ManufacturersRepository GetManufacturersRepository()
		{
			var repository = new ManufacturersRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ManufacturersRepository GetManufacturersRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ManufacturersRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ManufacturersBussinessItemsRepository GetManufacturersBussinessItemsRepository()
		{
			var repository = new ManufacturersBussinessItemsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ManufacturersBussinessItemsRepository GetManufacturersBussinessItemsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ManufacturersBussinessItemsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ManufacturersFactoriesRepository GetManufacturersFactoriesRepository()
		{
			var repository = new ManufacturersFactoriesRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ManufacturersFactoriesRepository GetManufacturersFactoriesRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ManufacturersFactoriesRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static MaterialCategoriesRepository GetMaterialCategoriesRepository()
		{
			var repository = new MaterialCategoriesRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static MaterialCategoriesRepository GetMaterialCategoriesRepository(IUnitOfWork unitOfWork)
		{
			var repository = new MaterialCategoriesRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static MaterialEstimationRepository GetMaterialEstimationRepository()
		{
			var repository = new MaterialEstimationRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static MaterialEstimationRepository GetMaterialEstimationRepository(IUnitOfWork unitOfWork)
		{
			var repository = new MaterialEstimationRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static MaterialsRepository GetMaterialsRepository()
		{
			var repository = new MaterialsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static MaterialsRepository GetMaterialsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new MaterialsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static MembershipRepository GetMembershipRepository()
		{
			var repository = new MembershipRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static MembershipRepository GetMembershipRepository(IUnitOfWork unitOfWork)
		{
			var repository = new MembershipRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static MoldsRepository GetMoldsRepository()
		{
			var repository = new MoldsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static MoldsRepository GetMoldsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new MoldsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static MoldsInProjectsRepository GetMoldsInProjectsRepository()
		{
			var repository = new MoldsInProjectsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static MoldsInProjectsRepository GetMoldsInProjectsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new MoldsInProjectsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static MoldUseStatusRepository GetMoldUseStatusRepository()
		{
			var repository = new MoldUseStatusRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static MoldUseStatusRepository GetMoldUseStatusRepository(IUnitOfWork unitOfWork)
		{
			var repository = new MoldUseStatusRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static OrderControlTableDetailsRepository GetOrderControlTableDetailsRepository()
		{
			var repository = new OrderControlTableDetailsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static OrderControlTableDetailsRepository GetOrderControlTableDetailsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new OrderControlTableDetailsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static OrderDetailsRepository GetOrderDetailsRepository()
		{
			var repository = new OrderDetailsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static OrderDetailsRepository GetOrderDetailsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new OrderDetailsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static OrderMaterialValuationRepository GetOrderMaterialValuationRepository()
		{
			var repository = new OrderMaterialValuationRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static OrderMaterialValuationRepository GetOrderMaterialValuationRepository(IUnitOfWork unitOfWork)
		{
			var repository = new OrderMaterialValuationRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static OrderMiscellaneousRepository GetOrderMiscellaneousRepository()
		{
			var repository = new OrderMiscellaneousRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static OrderMiscellaneousRepository GetOrderMiscellaneousRepository(IUnitOfWork unitOfWork)
		{
			var repository = new OrderMiscellaneousRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static OrdersRepository GetOrdersRepository()
		{
			var repository = new OrdersRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static OrdersRepository GetOrdersRepository(IUnitOfWork unitOfWork)
		{
			var repository = new OrdersRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static OrderTypesRepository GetOrderTypesRepository()
		{
			var repository = new OrderTypesRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static OrderTypesRepository GetOrderTypesRepository(IUnitOfWork unitOfWork)
		{
			var repository = new OrderTypesRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static PaymentTypesRepository GetPaymentTypesRepository()
		{
			var repository = new PaymentTypesRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static PaymentTypesRepository GetPaymentTypesRepository(IUnitOfWork unitOfWork)
		{
			var repository = new PaymentTypesRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static PickListRepository GetPickListRepository()
		{
			var repository = new PickListRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static PickListRepository GetPickListRepository(IUnitOfWork unitOfWork)
		{
			var repository = new PickListRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static PickListDetailsRepository GetPickListDetailsRepository()
		{
			var repository = new PickListDetailsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static PickListDetailsRepository GetPickListDetailsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new PickListDetailsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ProcessingAtlasRepository GetProcessingAtlasRepository()
		{
			var repository = new ProcessingAtlasRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ProcessingAtlasRepository GetProcessingAtlasRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ProcessingAtlasRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ProfileRepository GetProfileRepository()
		{
			var repository = new ProfileRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ProfileRepository GetProfileRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ProfileRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ProjectContractRepository GetProjectContractRepository()
		{
			var repository = new ProjectContractRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ProjectContractRepository GetProjectContractRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ProjectContractRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ProjectItemCostRepository GetProjectItemCostRepository()
		{
			var repository = new ProjectItemCostRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ProjectItemCostRepository GetProjectItemCostRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ProjectItemCostRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ProjectsRepository GetProjectsRepository()
		{
			var repository = new ProjectsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ProjectsRepository GetProjectsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ProjectsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static PromissoryNoteManagementRepository GetPromissoryNoteManagementRepository()
		{
			var repository = new PromissoryNoteManagementRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static PromissoryNoteManagementRepository GetPromissoryNoteManagementRepository(IUnitOfWork unitOfWork)
		{
			var repository = new PromissoryNoteManagementRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ReceiveRepository GetReceiveRepository()
		{
			var repository = new ReceiveRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ReceiveRepository GetReceiveRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ReceiveRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ReceiveDetailsRepository GetReceiveDetailsRepository()
		{
			var repository = new ReceiveDetailsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ReceiveDetailsRepository GetReceiveDetailsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ReceiveDetailsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static RequiredRepository GetRequiredRepository()
		{
			var repository = new RequiredRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static RequiredRepository GetRequiredRepository(IUnitOfWork unitOfWork)
		{
			var repository = new RequiredRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static RequiredDetailsRepository GetRequiredDetailsRepository()
		{
			var repository = new RequiredDetailsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static RequiredDetailsRepository GetRequiredDetailsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new RequiredDetailsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ReturnDetailsRepository GetReturnDetailsRepository()
		{
			var repository = new ReturnDetailsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ReturnDetailsRepository GetReturnDetailsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ReturnDetailsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ReturnsRepository GetReturnsRepository()
		{
			var repository = new ReturnsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ReturnsRepository GetReturnsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ReturnsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static RolesRepository GetRolesRepository()
		{
			var repository = new RolesRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static RolesRepository GetRolesRepository(IUnitOfWork unitOfWork)
		{
			var repository = new RolesRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ShopFlowRepository GetShopFlowRepository()
		{
			var repository = new ShopFlowRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ShopFlowRepository GetShopFlowRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ShopFlowRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ShopFlowDetailRepository GetShopFlowDetailRepository()
		{
			var repository = new ShopFlowDetailRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ShopFlowDetailRepository GetShopFlowDetailRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ShopFlowDetailRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ShopFlowHistoryRepository GetShopFlowHistoryRepository()
		{
			var repository = new ShopFlowHistoryRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ShopFlowHistoryRepository GetShopFlowHistoryRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ShopFlowHistoryRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static StatesRepository GetStatesRepository()
		{
			var repository = new StatesRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static StatesRepository GetStatesRepository(IUnitOfWork unitOfWork)
		{
			var repository = new StatesRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static StocksRepository GetStocksRepository()
		{
			var repository = new StocksRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static StocksRepository GetStocksRepository(IUnitOfWork unitOfWork)
		{
			var repository = new StocksRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static SupplierTranscationItemRepository GetSupplierTranscationItemRepository()
		{
			var repository = new SupplierTranscationItemRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static SupplierTranscationItemRepository GetSupplierTranscationItemRepository(IUnitOfWork unitOfWork)
		{
			var repository = new SupplierTranscationItemRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static TicketPeriodRepository GetTicketPeriodRepository()
		{
			var repository = new TicketPeriodRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static TicketPeriodRepository GetTicketPeriodRepository(IUnitOfWork unitOfWork)
		{
			var repository = new TicketPeriodRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static TicketTypesRepository GetTicketTypesRepository()
		{
			var repository = new TicketTypesRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static TicketTypesRepository GetTicketTypesRepository(IUnitOfWork unitOfWork)
		{
			var repository = new TicketTypesRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static TranscationCategoriesRepository GetTranscationCategoriesRepository()
		{
			var repository = new TranscationCategoriesRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static TranscationCategoriesRepository GetTranscationCategoriesRepository(IUnitOfWork unitOfWork)
		{
			var repository = new TranscationCategoriesRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static UsersRepository GetUsersRepository()
		{
			var repository = new UsersRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static UsersRepository GetUsersRepository(IUnitOfWork unitOfWork)
		{
			var repository = new UsersRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static View_BussinessItemsListRepository GetView_BussinessItemsListRepository()
		{
			var repository = new View_BussinessItemsListRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static View_BussinessItemsListRepository GetView_BussinessItemsListRepository(IUnitOfWork unitOfWork)
		{
			var repository = new View_BussinessItemsListRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static View_ManufacturersBussinessTranscationsRepository GetView_ManufacturersBussinessTranscationsRepository()
		{
			var repository = new View_ManufacturersBussinessTranscationsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static View_ManufacturersBussinessTranscationsRepository GetView_ManufacturersBussinessTranscationsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new View_ManufacturersBussinessTranscationsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static View_OrderControlTableRepository GetView_OrderControlTableRepository()
		{
			var repository = new View_OrderControlTableRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static View_OrderControlTableRepository GetView_OrderControlTableRepository(IUnitOfWork unitOfWork)
		{
			var repository = new View_OrderControlTableRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static View_OrderMaterialValuationRepository GetView_OrderMaterialValuationRepository()
		{
			var repository = new View_OrderMaterialValuationRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static View_OrderMaterialValuationRepository GetView_OrderMaterialValuationRepository(IUnitOfWork unitOfWork)
		{
			var repository = new View_OrderMaterialValuationRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static View_OrdersRepository GetView_OrdersRepository()
		{
			var repository = new View_OrdersRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static View_OrdersRepository GetView_OrdersRepository(IUnitOfWork unitOfWork)
		{
			var repository = new View_OrdersRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static View_PickListRepository GetView_PickListRepository()
		{
			var repository = new View_PickListRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static View_PickListRepository GetView_PickListRepository(IUnitOfWork unitOfWork)
		{
			var repository = new View_PickListRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static View_RequiredControlTableRepository GetView_RequiredControlTableRepository()
		{
			var repository = new View_RequiredControlTableRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static View_RequiredControlTableRepository GetView_RequiredControlTableRepository(IUnitOfWork unitOfWork)
		{
			var repository = new View_RequiredControlTableRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static View_RequiredFormsRepository GetView_RequiredFormsRepository()
		{
			var repository = new View_RequiredFormsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static View_RequiredFormsRepository GetView_RequiredFormsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new View_RequiredFormsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static View_ShippingRepository GetView_ShippingRepository()
		{
			var repository = new View_ShippingRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static View_ShippingRepository GetView_ShippingRepository(IUnitOfWork unitOfWork)
		{
			var repository = new View_ShippingRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static WorkShopsRepository GetWorkShopsRepository()
		{
			var repository = new WorkShopsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static WorkShopsRepository GetWorkShopsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new WorkShopsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		
	}
}