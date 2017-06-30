﻿TokikuNew
	Base - 公用基底類別定義
	Controls - 自定義控制項
		ClosableTab.xaml - 可關閉頁籤顯示樣板
		ClosableTabItem.cs - 可關閉頁籤控制項(擴充)
		CustomDataGrid.cs - 可處理來自系統命令的DataGrid擴充控制項
		DockBar.xaml - 操作文件檢視模式的工具列
		SearchBar.xaml - 共用的搜尋框
	Frame - 對話框與獨立視窗功能
		ClientSelectionDialog.xaml
		ConstructionAtlasEditorDialog.xaml
		OptionWindow.xaml
		ProjectSelectionWindow.xaml
		StartUpWindow.xaml
	Helpers - 自定義工具類別
		ClipboardHelper.cs - 操作Windows剪貼簿工具類別
		DocumentLifeCircle.cs - 文件生命週期代碼列舉
		SwitchFieldMode.cs - 識別切換的控制項列舉
		ThemeManager.cs - WPF主題管理工具類別
	Resources - WPF應用程式資源
		16x16.png - Windows 視窗Icon圖示檔
		Global.xaml - 應用程式共用資源
		MyTheme.xaml - 自訂主題檔案
		segmdl2.ttf - 應用程式圖示化所需要的字型檔
		SystemStrings.xaml - 應用程式全球化字串檔案
		TokikuLogo.gif - 啟動畫面的圖檔
	Themes - WPF佈景主題XAML定義檔
		BureauBlack.xaml - Bureau Black 主題檔
		BureauBlue.xaml - Bureau Blue主題檔
		ExpressionDark.xaml - Expression Dark 主題檔
		ExpressionLight.xaml - 主題檔
		ShinyBlue.xaml - 主題檔
		ShinyRed.xaml - 主題檔
		WhistlerBlue.xaml - 主題檔
	ValueConverters - WPF內容值轉換類別
		BooleanToVisibilityValueConveter.cs - 將布林值與可視視覺狀態值做轉換
		DocumentLifeCycleStateToVisibilityValueConverter.cs - 將文件生命週期列舉轉換為可視視覺狀態列舉值
		NOTGateValueConverter.cs - 將布林型態內容值做NOT運算
		Number2DateTimeValueConverter.cs - 將常整數轉換為日期時間
		RadioButtonSwitchValueConverter.cs - Radio Button切換轉換
		ReadModeToDisabledValueConverter.cs - 將文件處於讀取模式時設定為關閉
		ReadModeToEnabledValueConverter.cs - 將文件處於讀取模式時設定為顯示/啟用
		ReadModeToVisibilityValueConverter.cs - 將文件處於讀取模式時的可視視覺狀態轉換
		ReplyContentValueConverter.cs - 施工圖集的回覆代碼轉換為對應的文字
		StatesCodeToTextValueConverter.cs - 進度代碼轉換為對應的文字
		VoidToStateTextValueConverter.cs - 將停用狀態轉換為對應的文字
	Views
		AluminumExtrusion - 鋁擠型加工相關表單
			AluminumExtrusionOrderListView.xaml - 鋁擠型訂製單列表
			AluminumExtrusionOrderSheetView.xaml - 鋁擠型訂製單
				├ AluminumExtrusionOrderView.xaml - 鋁擠型訂製單
				├ AluminumExtrusionOrderMaterialValuationView.xaml - 鋁擠型材質估價
				└ AluminumExtrusionOrderMiscellaneousView.xaml - 鋁擠型雜項
			ProcessingAtlasDetailView.xaml - 鋁擠型加工圖集明細表
			InvoiceView.xaml - 請款單
			RecvMaterialView.xaml - 收料單
		ContactPerson
			ContactPersonManageView.xaml - 聯絡人管理
		ControlTables - 管控表
			ControlTableView.xaml - 鋁擠型管控表
			GlassView.xaml - 玻璃管控表
			HardwareView.xaml - 五金管控表(其他材料)
			InvoiceViewListView.xaml - 請款單列表
			ReturnListView.xaml - 退貨單列表
			ReturnView.xaml - 退貨單
			ShippingListView.xaml - 出貨單列表
			ShippingView.xaml - 出貨單
			AluminumPlateView.xaml - 鋁板管控表
			IronPartsView.xaml - 鐵件管控表
		CRM - 客戶關係管理
			ClientListView.xaml - 客戶列表
			ClientManageView.xaml - 客戶主檔
		Finance - 財務管理
			CostEstimateView.xaml - 專案成本估算
			PaymentTypesManageView.xaml - 支付方式管理
			PromissoryNoteManagementViewUC.xaml - 本票管理
		Forms - 簽核流程相關表單
		Manufacturers - 廠商相關
			ManufacturersManageView.xaml - 廠商主檔
			VendorListView.xaml - 廠商列表
		MES - 生產管理系統相關
			MaterialsTotalView.xaml - 模具總表
		Projects
			AssemblyTableView.xaml - 組裝總表
			ConstructionAtlasView.xaml - 施工圖集
			ContractListView.xaml - 合約列表
			WorkItemListView.xaml - 工程項目列表
			ProcessingAtlasView.xaml - 加工圖集
			ProjectManagerView.xaml - 專案主檔
			ProjectSelectListView.xaml - 專案列表
			ProjectViewer.xaml - 單一專案檢視
			SupplierForProjects.xaml - 專案供應商清單
App.config - 應用程式組態設定檔
App.xaml - 應用程式進入點(等同WinForm的Program類別)，包含定義預設的主題等都在這個檔案引用。
MainWindow.xaml - 東菊ERP系統主視窗
packages.config - 專案的NuGet套件安裝清單檔案
ReadMe.txt - 本說明檔案
