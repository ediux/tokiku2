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

		public static CompositionsRepository GetCompositionsRepository()
		{
			var repository = new CompositionsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static CompositionsRepository GetCompositionsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new CompositionsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static CompositionTypesRepository GetCompositionTypesRepository()
		{
			var repository = new CompositionTypesRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static CompositionTypesRepository GetCompositionTypesRepository(IUnitOfWork unitOfWork)
		{
			var repository = new CompositionTypesRepository();
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