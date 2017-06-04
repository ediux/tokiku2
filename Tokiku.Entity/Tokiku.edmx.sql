
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/04/2017 08:58:07
-- Generated from EDMX file: C:\Users\ediux\documents\visual studio 2017\Projects\TokikuNew\Tokiku.Entity\Tokiku.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Tokiku2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__aspnet_Me__UserI__164452B1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Membership] DROP CONSTRAINT [FK__aspnet_Me__UserI__164452B1];
GO
IF OBJECT_ID(N'[dbo].[FK__aspnet_Pr__UserI__1FCDBCEB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Profile] DROP CONSTRAINT [FK__aspnet_Pr__UserI__1FCDBCEB];
GO
IF OBJECT_ID(N'[dbo].[FK__aspnet_Us__RoleI__1BFD2C07]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersInRoles] DROP CONSTRAINT [FK__aspnet_Us__RoleI__1BFD2C07];
GO
IF OBJECT_ID(N'[dbo].[FK__aspnet_Us__UserI__1CF15040]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersInRoles] DROP CONSTRAINT [FK__aspnet_Us__UserI__1CF15040];
GO
IF OBJECT_ID(N'[dbo].[FK_BOM_Materials]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BOM] DROP CONSTRAINT [FK_BOM_Materials];
GO
IF OBJECT_ID(N'[dbo].[FK_BOM_ShopFlowHistory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BOM] DROP CONSTRAINT [FK_BOM_ShopFlowHistory];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientsInProjects_Manufacturers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClientsInProjects] DROP CONSTRAINT [FK_ClientsInProjects_Manufacturers];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientsInProjects_Projects]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClientsInProjects] DROP CONSTRAINT [FK_ClientsInProjects_Projects];
GO
IF OBJECT_ID(N'[dbo].[FK_Compositions_CompositionTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Compositions] DROP CONSTRAINT [FK_Compositions_CompositionTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_Compositions_Engineering]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Compositions] DROP CONSTRAINT [FK_Compositions_Engineering];
GO
IF OBJECT_ID(N'[dbo].[FK_ContractsInManufacturers_Contacts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContractsInManufacturers] DROP CONSTRAINT [FK_ContractsInManufacturers_Contacts];
GO
IF OBJECT_ID(N'[dbo].[FK_ContractsInManufacturers_Manufacturers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContractsInManufacturers] DROP CONSTRAINT [FK_ContractsInManufacturers_Manufacturers];
GO
IF OBJECT_ID(N'[dbo].[FK_Engineering_ProjectContract]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Engineering] DROP CONSTRAINT [FK_Engineering_ProjectContract];
GO
IF OBJECT_ID(N'[dbo].[FK_Engineering_States]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Engineering] DROP CONSTRAINT [FK_Engineering_States];
GO
IF OBJECT_ID(N'[dbo].[FK_Manufacturers_PaymentTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Manufacturers] DROP CONSTRAINT [FK_Manufacturers_PaymentTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_ManufacturersBussinessItems_MaterialCategories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ManufacturersBussinessItems] DROP CONSTRAINT [FK_ManufacturersBussinessItems_MaterialCategories];
GO
IF OBJECT_ID(N'[dbo].[FK_ManufacturersBussinessItems_PaymentTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ManufacturersBussinessItems] DROP CONSTRAINT [FK_ManufacturersBussinessItems_PaymentTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_ManufacturersBussinessItems_TicketTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ManufacturersBussinessItems] DROP CONSTRAINT [FK_ManufacturersBussinessItems_TicketTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_Materials_MaterialCategories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Materials] DROP CONSTRAINT [FK_Materials_MaterialCategories];
GO
IF OBJECT_ID(N'[dbo].[FK_Materials_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Materials] DROP CONSTRAINT [FK_Materials_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectContract_Manufacturers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectContract] DROP CONSTRAINT [FK_ProjectContract_Manufacturers];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectContract_Projects]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectContract] DROP CONSTRAINT [FK_ProjectContract_Projects];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectContract_States]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectContract] DROP CONSTRAINT [FK_ProjectContract_States];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectContract_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectContract] DROP CONSTRAINT [FK_ProjectContract_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Projects_States]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [FK_Projects_States];
GO
IF OBJECT_ID(N'[dbo].[FK_PromissoryNoteManagement_ProjectContract]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PromissoryNoteManagement] DROP CONSTRAINT [FK_PromissoryNoteManagement_ProjectContract];
GO
IF OBJECT_ID(N'[dbo].[FK_PromissoryNoteManagement_TicketTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PromissoryNoteManagement] DROP CONSTRAINT [FK_PromissoryNoteManagement_TicketTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_PromissoryNoteManagement_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PromissoryNoteManagement] DROP CONSTRAINT [FK_PromissoryNoteManagement_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_ShopFlowDetail_ShopFlow]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShopFlowDetail] DROP CONSTRAINT [FK_ShopFlowDetail_ShopFlow];
GO
IF OBJECT_ID(N'[dbo].[FK_ShopFlowDetail_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShopFlowDetail] DROP CONSTRAINT [FK_ShopFlowDetail_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_ShopFlowDetail_WorkShops]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShopFlowDetail] DROP CONSTRAINT [FK_ShopFlowDetail_WorkShops];
GO
IF OBJECT_ID(N'[dbo].[FK_ShopFlowHistory_Engineering]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShopFlowHistory] DROP CONSTRAINT [FK_ShopFlowHistory_Engineering];
GO
IF OBJECT_ID(N'[dbo].[FK_ShopFlowHistory_ShopFlowHistory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShopFlowHistory] DROP CONSTRAINT [FK_ShopFlowHistory_ShopFlowHistory];
GO
IF OBJECT_ID(N'[dbo].[FK_ShopFlowHistory_States]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShopFlowHistory] DROP CONSTRAINT [FK_ShopFlowHistory_States];
GO
IF OBJECT_ID(N'[dbo].[FK_ShopFlowHistory_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShopFlowHistory] DROP CONSTRAINT [FK_ShopFlowHistory_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkShops_Manufacturers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkShops] DROP CONSTRAINT [FK_WorkShops_Manufacturers];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AccessLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccessLog];
GO
IF OBJECT_ID(N'[dbo].[BOM]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BOM];
GO
IF OBJECT_ID(N'[dbo].[ClientsInProjects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClientsInProjects];
GO
IF OBJECT_ID(N'[dbo].[Compositions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Compositions];
GO
IF OBJECT_ID(N'[dbo].[CompositionTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompositionTypes];
GO
IF OBJECT_ID(N'[dbo].[Contacts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contacts];
GO
IF OBJECT_ID(N'[dbo].[ContractsInManufacturers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContractsInManufacturers];
GO
IF OBJECT_ID(N'[dbo].[Engineering]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Engineering];
GO
IF OBJECT_ID(N'[dbo].[Manufacturers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Manufacturers];
GO
IF OBJECT_ID(N'[dbo].[ManufacturersBussinessItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ManufacturersBussinessItems];
GO
IF OBJECT_ID(N'[dbo].[MaterialCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MaterialCategories];
GO
IF OBJECT_ID(N'[dbo].[Materials]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Materials];
GO
IF OBJECT_ID(N'[dbo].[Membership]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Membership];
GO
IF OBJECT_ID(N'[dbo].[PaymentTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentTypes];
GO
IF OBJECT_ID(N'[dbo].[Profile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Profile];
GO
IF OBJECT_ID(N'[dbo].[ProjectContract]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectContract];
GO
IF OBJECT_ID(N'[dbo].[Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects];
GO
IF OBJECT_ID(N'[dbo].[PromissoryNoteManagement]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PromissoryNoteManagement];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[ShopFlow]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShopFlow];
GO
IF OBJECT_ID(N'[dbo].[ShopFlowDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShopFlowDetail];
GO
IF OBJECT_ID(N'[dbo].[ShopFlowHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShopFlowHistory];
GO
IF OBJECT_ID(N'[dbo].[States]', 'U') IS NOT NULL
    DROP TABLE [dbo].[States];
GO
IF OBJECT_ID(N'[dbo].[TicketTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketTypes];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[UsersInRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersInRoles];
GO
IF OBJECT_ID(N'[dbo].[WorkShops]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkShops];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Contacts'
CREATE TABLE [dbo].[Contacts] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(15)  NOT NULL,
    [Dep] nvarchar(50)  NOT NULL,
    [Title] nvarchar(50)  NULL,
    [Phone] nvarchar(10)  NULL,
    [ExtensionNumber] nvarchar(6)  NULL,
    [Mobile] nvarchar(10)  NULL,
    [Fax] nvarchar(10)  NULL,
    [IsPrincipal] bit  NOT NULL,
    [Void] bit  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [CreateUserId] uniqueidentifier  NOT NULL,
    [EMail] nvarchar(250)  NULL,
    [IsDefault] bit  NOT NULL,
    [Comment] nvarchar(max)  NULL
);
GO

-- Creating table 'Membership'
CREATE TABLE [dbo].[Membership] (
    [UserId] uniqueidentifier  NOT NULL,
    [Password] nvarchar(128)  NOT NULL,
    [PasswordFormat] int  NOT NULL,
    [PasswordSalt] nvarchar(128)  NOT NULL,
    [MobilePIN] nvarchar(16)  NULL,
    [Email] nvarchar(256)  NULL,
    [LoweredEmail] nvarchar(256)  NULL,
    [PasswordQuestion] nvarchar(256)  NULL,
    [PasswordAnswer] nvarchar(128)  NULL,
    [IsApproved] bit  NOT NULL,
    [IsLockedOut] bit  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [LastLoginDate] datetime  NOT NULL,
    [LastPasswordChangedDate] datetime  NOT NULL,
    [LastLockoutDate] datetime  NOT NULL,
    [FailedPasswordAttemptCount] int  NOT NULL,
    [FailedPasswordAttemptWindowStart] datetime  NOT NULL,
    [FailedPasswordAnswerAttemptCount] int  NOT NULL,
    [FailedPasswordAnswerAttemptWindowStart] datetime  NOT NULL,
    [Comment] nvarchar(max)  NULL
);
GO

-- Creating table 'Profile'
CREATE TABLE [dbo].[Profile] (
    [UserId] uniqueidentifier  NOT NULL,
    [PropertyNames] nvarchar(max)  NOT NULL,
    [PropertyValuesString] nvarchar(max)  NOT NULL,
    [PropertyValuesBinary] varbinary(max)  NOT NULL,
    [LastUpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleId] uniqueidentifier  NOT NULL,
    [RoleName] nvarchar(256)  NOT NULL,
    [LoweredRoleName] nvarchar(256)  NOT NULL,
    [Description] nvarchar(256)  NULL
);
GO

-- Creating table 'States'
CREATE TABLE [dbo].[States] (
    [Id] tinyint  NOT NULL,
    [StateName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] uniqueidentifier  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [LoweredUserName] nvarchar(256)  NOT NULL,
    [MobileAlias] nvarchar(16)  NULL,
    [IsAnonymous] bit  NOT NULL,
    [LastActivityDate] datetime  NOT NULL
);
GO

-- Creating table 'ShopFlowHistory'
CREATE TABLE [dbo].[ShopFlowHistory] (
    [Id] uniqueidentifier  NOT NULL,
    [EngineeringId] uniqueidentifier  NOT NULL,
    [ShopId] uniqueidentifier  NULL,
    [State] tinyint  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [CreateUserId] uniqueidentifier  NOT NULL,
    [ShopFlowId] uniqueidentifier  NULL
);
GO

-- Creating table 'Materials'
CREATE TABLE [dbo].[Materials] (
    [Id] uniqueidentifier  NOT NULL,
    [MaterialCategoryId] uniqueidentifier  NOT NULL,
    [ManufacturersId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [UnitPrice] real  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [CreateUserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'MaterialCategories'
CREATE TABLE [dbo].[MaterialCategories] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(50)  NULL,
    [CreateTime] datetime  NOT NULL,
    [CreateUserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'PromissoryNoteManagement'
CREATE TABLE [dbo].[PromissoryNoteManagement] (
    [Id] uniqueidentifier  NOT NULL,
    [ProjectContractId] uniqueidentifier  NULL,
    [TicketTypeId] tinyint  NOT NULL,
    [Amount] real  NOT NULL,
    [OpenDate] datetime  NOT NULL,
    [RecoveryDate] datetime  NULL,
    [CreateTime] datetime  NOT NULL,
    [CreateUserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'TicketTypes'
CREATE TABLE [dbo].[TicketTypes] (
    [Id] tinyint  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [IsPromissoryNote] bit  NOT NULL
);
GO

-- Creating table 'BOM'
CREATE TABLE [dbo].[BOM] (
    [Id] uniqueidentifier  NOT NULL,
    [ShopFlowId] uniqueidentifier  NULL,
    [MaterialsId] uniqueidentifier  NOT NULL,
    [Amount] real  NOT NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [Id] uniqueidentifier  NOT NULL,
    [Code] nvarchar(50)  NOT NULL,
    [ProjectName] nvarchar(50)  NOT NULL,
    [ShortName] nvarchar(25)  NULL,
    [ProjectSigningDate] datetime  NOT NULL,
    [SiteAddress] nvarchar(250)  NULL,
    [ClientId] uniqueidentifier  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [CreateUserId] uniqueidentifier  NOT NULL,
    [Comment] nvarchar(max)  NULL,
    [Void] bit  NOT NULL,
    [State] tinyint  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [CompletionDate] datetime  NULL,
    [OpenDate] datetime  NULL,
    [WarrantyDate] datetime  NULL,
    [Architect] nvarchar(50)  NULL,
    [BuildingHeightAboveground] int  NULL,
    [BuildingHeightUnderground] int  NULL,
    [BuildingCompany] nvarchar(50)  NULL,
    [SupervisionUnit] nvarchar(50)  NULL,
    [Area] real  NULL,
    [PaymentType] tinyint  NULL,
    [CheckoutDay] tinyint  NULL,
    [PaymentDay] tinyint  NULL
);
GO

-- Creating table 'AccessLog'
CREATE TABLE [dbo].[AccessLog] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [DataId] uniqueidentifier  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [ActionCode] tinyint  NOT NULL
);
GO

-- Creating table 'Manufacturers'
CREATE TABLE [dbo].[Manufacturers] (
    [Id] uniqueidentifier  NOT NULL,
    [Code] nvarchar(15)  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [ShortName] nvarchar(50)  NULL,
    [UniformNumbers] nvarchar(15)  NULL,
    [Phone] nvarchar(10)  NULL,
    [Fax] nvarchar(10)  NULL,
    [eMail] nvarchar(200)  NULL,
    [Address] nvarchar(250)  NULL,
    [FactoryPhone] nvarchar(10)  NULL,
    [FactoryFax] nvarchar(10)  NULL,
    [FactoryAddress] nvarchar(250)  NULL,
    [Comment] nvarchar(max)  NULL,
    [Void] bit  NOT NULL,
    [IsClient] bit  NOT NULL,
    [ContractNumber] nvarchar(50)  NULL,
    [StartDate] datetime  NULL,
    [CompletionDate] datetime  NULL,
    [AccountingCode] nvarchar(50)  NULL,
    [BankName] nvarchar(50)  NULL,
    [BankAccount] nvarchar(50)  NULL,
    [BankAccountName] nvarchar(50)  NULL,
    [CheckNumber] nvarchar(50)  NULL,
    [ContractAmount] real  NULL,
    [AmountDue] real  NULL,
    [PrepaymentGuaranteeAmount] real  NULL,
    [OpenDate] datetime  NULL,
    [PaymentType] tinyint  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [CreateUserId] uniqueidentifier  NOT NULL,
    [Principal] nvarchar(50)  NULL,
    [MainContactPerson] nvarchar(50)  NULL
);
GO

-- Creating table 'PaymentTypes'
CREATE TABLE [dbo].[PaymentTypes] (
    [Id] tinyint  NOT NULL,
    [PaymentTypeName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Engineering'
CREATE TABLE [dbo].[Engineering] (
    [Id] uniqueidentifier  NOT NULL,
    [ProjectContractId] uniqueidentifier  NOT NULL,
    [Code] nvarchar(15)  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [CompletionDate] datetime  NOT NULL,
    [State] tinyint  NULL,
    [WarrantyDate] datetime  NULL,
    [CreateTime] datetime  NOT NULL,
    [CreateUserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Compositions'
CREATE TABLE [dbo].[Compositions] (
    [Id] uniqueidentifier  NOT NULL,
    [EngineeringId] uniqueidentifier  NULL,
    [Order] int  NOT NULL,
    [CompositionTypeId] int  NULL,
    [Code] nvarchar(50)  NOT NULL,
    [SpecDesc] nvarchar(512)  NULL,
    [Amount] real  NOT NULL,
    [Reserved1] nvarchar(200)  NULL,
    [Reserved2] nvarchar(200)  NULL,
    [Reserved3] nvarchar(200)  NULL,
    [Reserved4] nvarchar(200)  NULL,
    [Reserved5] nvarchar(200)  NULL,
    [CreateTime] datetime  NOT NULL,
    [CreateUserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'CompositionTypes'
CREATE TABLE [dbo].[CompositionTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL
);
GO

-- Creating table 'ShopFlow'
CREATE TABLE [dbo].[ShopFlow] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [CreateUserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ShopFlowDetail'
CREATE TABLE [dbo].[ShopFlowDetail] (
    [Id] uniqueidentifier  NOT NULL,
    [ShopFlowId] uniqueidentifier  NULL,
    [WorkShopId] uniqueidentifier  NULL,
    [CreateTime] datetime  NOT NULL,
    [CreateUserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'WorkShops'
CREATE TABLE [dbo].[WorkShops] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [RefId] uniqueidentifier  NULL,
    [Location] nvarchar(50)  NULL,
    [OwnerId] uniqueidentifier  NULL,
    [Void] bit  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [CreateUserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ProjectContract'
CREATE TABLE [dbo].[ProjectContract] (
    [Id] uniqueidentifier  NOT NULL,
    [ProjectId] uniqueidentifier  NULL,
    [ContractorId] uniqueidentifier  NULL,
    [SigningDate] datetime  NOT NULL,
    [ContractNumber] nvarchar(50)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [CompletionDate] datetime  NULL,
    [ContractAmount] real  NULL,
    [AmountDue] real  NULL,
    [PrepaymentGuaranteeAmount] real  NULL,
    [OpenDate] datetime  NULL,
    [PaymentType] tinyint  NULL,
    [WarrantyDate] datetime  NULL,
    [Architect] nvarchar(50)  NULL,
    [BuildingHeightAboveground] int  NULL,
    [BuildingHeightUnderground] int  NULL,
    [BuildingCompany] nvarchar(50)  NULL,
    [SupervisionUnit] nvarchar(50)  NULL,
    [Area] real  NULL,
    [IsAppend] bit  NULL,
    [IsRepair] bit  NULL,
    [State] tinyint  NULL,
    [CheckoutDay] tinyint  NOT NULL,
    [PaymentDay] tinyint  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [CreateUserId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'ManufacturersBussinessItems'
CREATE TABLE [dbo].[ManufacturersBussinessItems] (
    [Id] uniqueidentifier  NOT NULL,
    [MaterialCategoriesId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [TranscationId] int  NOT NULL,
    [PaymentTypeId] tinyint  NOT NULL,
    [TicketTypeId] tinyint  NOT NULL
);
GO

-- Creating table 'UsersInRoles'
CREATE TABLE [dbo].[UsersInRoles] (
    [Roles_RoleId] uniqueidentifier  NOT NULL,
    [Users_UserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ContractsInManufacturers'
CREATE TABLE [dbo].[ContractsInManufacturers] (
    [Contacts_Id] uniqueidentifier  NOT NULL,
    [Manufacturers_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ClientsInProjects'
CREATE TABLE [dbo].[ClientsInProjects] (
    [Clients_Id] uniqueidentifier  NOT NULL,
    [Projects_Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [PK_Contacts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId] in table 'Membership'
ALTER TABLE [dbo].[Membership]
ADD CONSTRAINT [PK_Membership]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [UserId] in table 'Profile'
ALTER TABLE [dbo].[Profile]
ADD CONSTRAINT [PK_Profile]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [RoleId] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [Id] in table 'States'
ALTER TABLE [dbo].[States]
ADD CONSTRAINT [PK_States]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [Id] in table 'ShopFlowHistory'
ALTER TABLE [dbo].[ShopFlowHistory]
ADD CONSTRAINT [PK_ShopFlowHistory]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Materials'
ALTER TABLE [dbo].[Materials]
ADD CONSTRAINT [PK_Materials]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MaterialCategories'
ALTER TABLE [dbo].[MaterialCategories]
ADD CONSTRAINT [PK_MaterialCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PromissoryNoteManagement'
ALTER TABLE [dbo].[PromissoryNoteManagement]
ADD CONSTRAINT [PK_PromissoryNoteManagement]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TicketTypes'
ALTER TABLE [dbo].[TicketTypes]
ADD CONSTRAINT [PK_TicketTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BOM'
ALTER TABLE [dbo].[BOM]
ADD CONSTRAINT [PK_BOM]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AccessLog'
ALTER TABLE [dbo].[AccessLog]
ADD CONSTRAINT [PK_AccessLog]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Manufacturers'
ALTER TABLE [dbo].[Manufacturers]
ADD CONSTRAINT [PK_Manufacturers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PaymentTypes'
ALTER TABLE [dbo].[PaymentTypes]
ADD CONSTRAINT [PK_PaymentTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Engineering'
ALTER TABLE [dbo].[Engineering]
ADD CONSTRAINT [PK_Engineering]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Compositions'
ALTER TABLE [dbo].[Compositions]
ADD CONSTRAINT [PK_Compositions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CompositionTypes'
ALTER TABLE [dbo].[CompositionTypes]
ADD CONSTRAINT [PK_CompositionTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ShopFlow'
ALTER TABLE [dbo].[ShopFlow]
ADD CONSTRAINT [PK_ShopFlow]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ShopFlowDetail'
ALTER TABLE [dbo].[ShopFlowDetail]
ADD CONSTRAINT [PK_ShopFlowDetail]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WorkShops'
ALTER TABLE [dbo].[WorkShops]
ADD CONSTRAINT [PK_WorkShops]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectContract'
ALTER TABLE [dbo].[ProjectContract]
ADD CONSTRAINT [PK_ProjectContract]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ManufacturersBussinessItems'
ALTER TABLE [dbo].[ManufacturersBussinessItems]
ADD CONSTRAINT [PK_ManufacturersBussinessItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Roles_RoleId], [Users_UserId] in table 'UsersInRoles'
ALTER TABLE [dbo].[UsersInRoles]
ADD CONSTRAINT [PK_UsersInRoles]
    PRIMARY KEY CLUSTERED ([Roles_RoleId], [Users_UserId] ASC);
GO

-- Creating primary key on [Contacts_Id], [Manufacturers_Id] in table 'ContractsInManufacturers'
ALTER TABLE [dbo].[ContractsInManufacturers]
ADD CONSTRAINT [PK_ContractsInManufacturers]
    PRIMARY KEY CLUSTERED ([Contacts_Id], [Manufacturers_Id] ASC);
GO

-- Creating primary key on [Clients_Id], [Projects_Id] in table 'ClientsInProjects'
ALTER TABLE [dbo].[ClientsInProjects]
ADD CONSTRAINT [PK_ClientsInProjects]
    PRIMARY KEY CLUSTERED ([Clients_Id], [Projects_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'Membership'
ALTER TABLE [dbo].[Membership]
ADD CONSTRAINT [FK__aspnet_Me__UserI__164452B1]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserId] in table 'Profile'
ALTER TABLE [dbo].[Profile]
ADD CONSTRAINT [FK__aspnet_Pr__UserI__1FCDBCEB]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Roles_RoleId] in table 'UsersInRoles'
ALTER TABLE [dbo].[UsersInRoles]
ADD CONSTRAINT [FK_UsersInRoles_Roles]
    FOREIGN KEY ([Roles_RoleId])
    REFERENCES [dbo].[Roles]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Users_UserId] in table 'UsersInRoles'
ALTER TABLE [dbo].[UsersInRoles]
ADD CONSTRAINT [FK_UsersInRoles_Users]
    FOREIGN KEY ([Users_UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersInRoles_Users'
CREATE INDEX [IX_FK_UsersInRoles_Users]
ON [dbo].[UsersInRoles]
    ([Users_UserId]);
GO

-- Creating foreign key on [State] in table 'ShopFlowHistory'
ALTER TABLE [dbo].[ShopFlowHistory]
ADD CONSTRAINT [FK_ShopFlowHistory_States]
    FOREIGN KEY ([State])
    REFERENCES [dbo].[States]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShopFlowHistory_States'
CREATE INDEX [IX_FK_ShopFlowHistory_States]
ON [dbo].[ShopFlowHistory]
    ([State]);
GO

-- Creating foreign key on [CreateUserId] in table 'ShopFlowHistory'
ALTER TABLE [dbo].[ShopFlowHistory]
ADD CONSTRAINT [FK_ShopFlowHistory_Users]
    FOREIGN KEY ([CreateUserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShopFlowHistory_Users'
CREATE INDEX [IX_FK_ShopFlowHistory_Users]
ON [dbo].[ShopFlowHistory]
    ([CreateUserId]);
GO

-- Creating foreign key on [MaterialCategoryId] in table 'Materials'
ALTER TABLE [dbo].[Materials]
ADD CONSTRAINT [FK_Materials_MaterialCategories]
    FOREIGN KEY ([MaterialCategoryId])
    REFERENCES [dbo].[MaterialCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Materials_MaterialCategories'
CREATE INDEX [IX_FK_Materials_MaterialCategories]
ON [dbo].[Materials]
    ([MaterialCategoryId]);
GO

-- Creating foreign key on [CreateUserId] in table 'Materials'
ALTER TABLE [dbo].[Materials]
ADD CONSTRAINT [FK_Materials_Users]
    FOREIGN KEY ([CreateUserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Materials_Users'
CREATE INDEX [IX_FK_Materials_Users]
ON [dbo].[Materials]
    ([CreateUserId]);
GO

-- Creating foreign key on [TicketTypeId] in table 'PromissoryNoteManagement'
ALTER TABLE [dbo].[PromissoryNoteManagement]
ADD CONSTRAINT [FK_PromissoryNoteManagement_TicketTypes]
    FOREIGN KEY ([TicketTypeId])
    REFERENCES [dbo].[TicketTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PromissoryNoteManagement_TicketTypes'
CREATE INDEX [IX_FK_PromissoryNoteManagement_TicketTypes]
ON [dbo].[PromissoryNoteManagement]
    ([TicketTypeId]);
GO

-- Creating foreign key on [CreateUserId] in table 'PromissoryNoteManagement'
ALTER TABLE [dbo].[PromissoryNoteManagement]
ADD CONSTRAINT [FK_PromissoryNoteManagement_Users]
    FOREIGN KEY ([CreateUserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PromissoryNoteManagement_Users'
CREATE INDEX [IX_FK_PromissoryNoteManagement_Users]
ON [dbo].[PromissoryNoteManagement]
    ([CreateUserId]);
GO

-- Creating foreign key on [MaterialsId] in table 'BOM'
ALTER TABLE [dbo].[BOM]
ADD CONSTRAINT [FK_BOM_Materials]
    FOREIGN KEY ([MaterialsId])
    REFERENCES [dbo].[Materials]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BOM_Materials'
CREATE INDEX [IX_FK_BOM_Materials]
ON [dbo].[BOM]
    ([MaterialsId]);
GO

-- Creating foreign key on [ShopFlowId] in table 'BOM'
ALTER TABLE [dbo].[BOM]
ADD CONSTRAINT [FK_BOM_ShopFlowHistory]
    FOREIGN KEY ([ShopFlowId])
    REFERENCES [dbo].[ShopFlowHistory]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BOM_ShopFlowHistory'
CREATE INDEX [IX_FK_BOM_ShopFlowHistory]
ON [dbo].[BOM]
    ([ShopFlowId]);
GO

-- Creating foreign key on [State] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_Projects_States]
    FOREIGN KEY ([State])
    REFERENCES [dbo].[States]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Projects_States'
CREATE INDEX [IX_FK_Projects_States]
ON [dbo].[Projects]
    ([State]);
GO

-- Creating foreign key on [Contacts_Id] in table 'ContractsInManufacturers'
ALTER TABLE [dbo].[ContractsInManufacturers]
ADD CONSTRAINT [FK_ContractsInManufacturers_Contacts]
    FOREIGN KEY ([Contacts_Id])
    REFERENCES [dbo].[Contacts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Manufacturers_Id] in table 'ContractsInManufacturers'
ALTER TABLE [dbo].[ContractsInManufacturers]
ADD CONSTRAINT [FK_ContractsInManufacturers_Manufacturers]
    FOREIGN KEY ([Manufacturers_Id])
    REFERENCES [dbo].[Manufacturers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractsInManufacturers_Manufacturers'
CREATE INDEX [IX_FK_ContractsInManufacturers_Manufacturers]
ON [dbo].[ContractsInManufacturers]
    ([Manufacturers_Id]);
GO

-- Creating foreign key on [Clients_Id] in table 'ClientsInProjects'
ALTER TABLE [dbo].[ClientsInProjects]
ADD CONSTRAINT [FK_ClientsInProjects_Manufacturers]
    FOREIGN KEY ([Clients_Id])
    REFERENCES [dbo].[Manufacturers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Projects_Id] in table 'ClientsInProjects'
ALTER TABLE [dbo].[ClientsInProjects]
ADD CONSTRAINT [FK_ClientsInProjects_Projects]
    FOREIGN KEY ([Projects_Id])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientsInProjects_Projects'
CREATE INDEX [IX_FK_ClientsInProjects_Projects]
ON [dbo].[ClientsInProjects]
    ([Projects_Id]);
GO

-- Creating foreign key on [PaymentType] in table 'Manufacturers'
ALTER TABLE [dbo].[Manufacturers]
ADD CONSTRAINT [FK_Manufacturers_PaymentTypes]
    FOREIGN KEY ([PaymentType])
    REFERENCES [dbo].[PaymentTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Manufacturers_PaymentTypes'
CREATE INDEX [IX_FK_Manufacturers_PaymentTypes]
ON [dbo].[Manufacturers]
    ([PaymentType]);
GO

-- Creating foreign key on [EngineeringId] in table 'ShopFlowHistory'
ALTER TABLE [dbo].[ShopFlowHistory]
ADD CONSTRAINT [FK_ShopFlowHistory_Engineering]
    FOREIGN KEY ([EngineeringId])
    REFERENCES [dbo].[Engineering]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShopFlowHistory_Engineering'
CREATE INDEX [IX_FK_ShopFlowHistory_Engineering]
ON [dbo].[ShopFlowHistory]
    ([EngineeringId]);
GO

-- Creating foreign key on [CompositionTypeId] in table 'Compositions'
ALTER TABLE [dbo].[Compositions]
ADD CONSTRAINT [FK_Compositions_CompositionTypes]
    FOREIGN KEY ([CompositionTypeId])
    REFERENCES [dbo].[CompositionTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Compositions_CompositionTypes'
CREATE INDEX [IX_FK_Compositions_CompositionTypes]
ON [dbo].[Compositions]
    ([CompositionTypeId]);
GO

-- Creating foreign key on [EngineeringId] in table 'Compositions'
ALTER TABLE [dbo].[Compositions]
ADD CONSTRAINT [FK_Compositions_Engineering]
    FOREIGN KEY ([EngineeringId])
    REFERENCES [dbo].[Engineering]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Compositions_Engineering'
CREATE INDEX [IX_FK_Compositions_Engineering]
ON [dbo].[Compositions]
    ([EngineeringId]);
GO

-- Creating foreign key on [State] in table 'Engineering'
ALTER TABLE [dbo].[Engineering]
ADD CONSTRAINT [FK_Engineering_States]
    FOREIGN KEY ([State])
    REFERENCES [dbo].[States]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Engineering_States'
CREATE INDEX [IX_FK_Engineering_States]
ON [dbo].[Engineering]
    ([State]);
GO

-- Creating foreign key on [RefId] in table 'WorkShops'
ALTER TABLE [dbo].[WorkShops]
ADD CONSTRAINT [FK_WorkShops_Manufacturers]
    FOREIGN KEY ([RefId])
    REFERENCES [dbo].[Manufacturers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkShops_Manufacturers'
CREATE INDEX [IX_FK_WorkShops_Manufacturers]
ON [dbo].[WorkShops]
    ([RefId]);
GO

-- Creating foreign key on [ShopFlowId] in table 'ShopFlowDetail'
ALTER TABLE [dbo].[ShopFlowDetail]
ADD CONSTRAINT [FK_ShopFlowDetail_ShopFlow]
    FOREIGN KEY ([ShopFlowId])
    REFERENCES [dbo].[ShopFlow]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShopFlowDetail_ShopFlow'
CREATE INDEX [IX_FK_ShopFlowDetail_ShopFlow]
ON [dbo].[ShopFlowDetail]
    ([ShopFlowId]);
GO

-- Creating foreign key on [CreateUserId] in table 'ShopFlowDetail'
ALTER TABLE [dbo].[ShopFlowDetail]
ADD CONSTRAINT [FK_ShopFlowDetail_Users]
    FOREIGN KEY ([CreateUserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShopFlowDetail_Users'
CREATE INDEX [IX_FK_ShopFlowDetail_Users]
ON [dbo].[ShopFlowDetail]
    ([CreateUserId]);
GO

-- Creating foreign key on [WorkShopId] in table 'ShopFlowDetail'
ALTER TABLE [dbo].[ShopFlowDetail]
ADD CONSTRAINT [FK_ShopFlowDetail_WorkShops]
    FOREIGN KEY ([WorkShopId])
    REFERENCES [dbo].[WorkShops]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShopFlowDetail_WorkShops'
CREATE INDEX [IX_FK_ShopFlowDetail_WorkShops]
ON [dbo].[ShopFlowDetail]
    ([WorkShopId]);
GO

-- Creating foreign key on [Id] in table 'ShopFlowHistory'
ALTER TABLE [dbo].[ShopFlowHistory]
ADD CONSTRAINT [FK_ShopFlowHistory_ShopFlowHistory]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ShopFlowHistory]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProjectContractId] in table 'Engineering'
ALTER TABLE [dbo].[Engineering]
ADD CONSTRAINT [FK_Engineering_ProjectContract]
    FOREIGN KEY ([ProjectContractId])
    REFERENCES [dbo].[ProjectContract]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Engineering_ProjectContract'
CREATE INDEX [IX_FK_Engineering_ProjectContract]
ON [dbo].[Engineering]
    ([ProjectContractId]);
GO

-- Creating foreign key on [ContractorId] in table 'ProjectContract'
ALTER TABLE [dbo].[ProjectContract]
ADD CONSTRAINT [FK_ProjectContract_Manufacturers]
    FOREIGN KEY ([ContractorId])
    REFERENCES [dbo].[Manufacturers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectContract_Manufacturers'
CREATE INDEX [IX_FK_ProjectContract_Manufacturers]
ON [dbo].[ProjectContract]
    ([ContractorId]);
GO

-- Creating foreign key on [ProjectId] in table 'ProjectContract'
ALTER TABLE [dbo].[ProjectContract]
ADD CONSTRAINT [FK_ProjectContract_Projects]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectContract_Projects'
CREATE INDEX [IX_FK_ProjectContract_Projects]
ON [dbo].[ProjectContract]
    ([ProjectId]);
GO

-- Creating foreign key on [State] in table 'ProjectContract'
ALTER TABLE [dbo].[ProjectContract]
ADD CONSTRAINT [FK_ProjectContract_States]
    FOREIGN KEY ([State])
    REFERENCES [dbo].[States]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectContract_States'
CREATE INDEX [IX_FK_ProjectContract_States]
ON [dbo].[ProjectContract]
    ([State]);
GO

-- Creating foreign key on [CreateUserId] in table 'ProjectContract'
ALTER TABLE [dbo].[ProjectContract]
ADD CONSTRAINT [FK_ProjectContract_Users]
    FOREIGN KEY ([CreateUserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectContract_Users'
CREATE INDEX [IX_FK_ProjectContract_Users]
ON [dbo].[ProjectContract]
    ([CreateUserId]);
GO

-- Creating foreign key on [ProjectContractId] in table 'PromissoryNoteManagement'
ALTER TABLE [dbo].[PromissoryNoteManagement]
ADD CONSTRAINT [FK_PromissoryNoteManagement_ProjectContract]
    FOREIGN KEY ([ProjectContractId])
    REFERENCES [dbo].[ProjectContract]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PromissoryNoteManagement_ProjectContract'
CREATE INDEX [IX_FK_PromissoryNoteManagement_ProjectContract]
ON [dbo].[PromissoryNoteManagement]
    ([ProjectContractId]);
GO

-- Creating foreign key on [MaterialCategoriesId] in table 'ManufacturersBussinessItems'
ALTER TABLE [dbo].[ManufacturersBussinessItems]
ADD CONSTRAINT [FK_ManufacturersBussinessItems_MaterialCategories]
    FOREIGN KEY ([MaterialCategoriesId])
    REFERENCES [dbo].[MaterialCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManufacturersBussinessItems_MaterialCategories'
CREATE INDEX [IX_FK_ManufacturersBussinessItems_MaterialCategories]
ON [dbo].[ManufacturersBussinessItems]
    ([MaterialCategoriesId]);
GO

-- Creating foreign key on [PaymentTypeId] in table 'ManufacturersBussinessItems'
ALTER TABLE [dbo].[ManufacturersBussinessItems]
ADD CONSTRAINT [FK_ManufacturersBussinessItems_PaymentTypes]
    FOREIGN KEY ([PaymentTypeId])
    REFERENCES [dbo].[PaymentTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManufacturersBussinessItems_PaymentTypes'
CREATE INDEX [IX_FK_ManufacturersBussinessItems_PaymentTypes]
ON [dbo].[ManufacturersBussinessItems]
    ([PaymentTypeId]);
GO

-- Creating foreign key on [TicketTypeId] in table 'ManufacturersBussinessItems'
ALTER TABLE [dbo].[ManufacturersBussinessItems]
ADD CONSTRAINT [FK_ManufacturersBussinessItems_TicketTypes]
    FOREIGN KEY ([TicketTypeId])
    REFERENCES [dbo].[TicketTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManufacturersBussinessItems_TicketTypes'
CREATE INDEX [IX_FK_ManufacturersBussinessItems_TicketTypes]
ON [dbo].[ManufacturersBussinessItems]
    ([TicketTypeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------