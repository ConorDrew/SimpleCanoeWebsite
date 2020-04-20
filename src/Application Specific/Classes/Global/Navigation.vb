Imports System.Collections.Generic

Public Class Navigation

#Region "Functions"

    Public Shared Function Navigate(ByVal MenuType As Entity.Sys.Enums.MenuTypes) As Boolean

        If IsLowResolution Then
            MainForm.pnlMiddle.Size = New Size(Entity.Sys.Consts.MidPanelSmallSize, MainForm.Height)
            MainForm.btnAddNew.Text = "Add"
        Else
            MainForm.pnlMiddle.Size = New Size(Entity.Sys.Consts.MidPanelLargeSize, MainForm.Height)
            MainForm.splitMiddleAndRight.Visible = False
            MainForm.splitMiddleAndRight.Enabled = False
            MainForm.btnAddNew.Width = MainForm.btnAddNew.MaximumSize.Width
            MainForm.btnDelete.Width = MainForm.btnDelete.MaximumSize.Width
            MainForm.btnExport.Width = MainForm.btnExport.MaximumSize.Width
        End If

        If Not Close_Middle() Then
            Return False
        End If

        For Each form As Form In MainForm.MdiChildren
            form.Dispose()
        Next

        Dim ssm As Entity.Sys.Enums.SecuritySystemModules = Entity.Sys.Enums.SecuritySystemModules.None

        Select Case MenuType
            Case Entity.Sys.Enums.MenuTypes.NONE
                ssm = Entity.Sys.Enums.SecuritySystemModules.None
            Case Entity.Sys.Enums.MenuTypes.Customers
                ssm = Entity.Sys.Enums.SecuritySystemModules.Customers
            Case Entity.Sys.Enums.MenuTypes.Spares
                ssm = Entity.Sys.Enums.SecuritySystemModules.Spares
            Case Entity.Sys.Enums.MenuTypes.Staff
                ssm = Entity.Sys.Enums.SecuritySystemModules.Staff
            Case Entity.Sys.Enums.MenuTypes.Jobs
                ssm = Entity.Sys.Enums.SecuritySystemModules.Jobs
            Case Entity.Sys.Enums.MenuTypes.Invoicing
                ssm = Entity.Sys.Enums.SecuritySystemModules.Invoicing
            Case Entity.Sys.Enums.MenuTypes.Reports
                ssm = Entity.Sys.Enums.SecuritySystemModules.Reports
            Case Entity.Sys.Enums.MenuTypes.Setup
                ssm = Entity.Sys.Enums.SecuritySystemModules.Setup
            Case Entity.Sys.Enums.MenuTypes.FleetVan
                ssm = Entity.Sys.Enums.SecuritySystemModules.None
        End Select

        If loggedInUser.HasAccessToModule(ssm) = False Then
            Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
            msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
            Throw New Security.SecurityException(msg)
        End If

        MainForm.SelectedMenu = MenuType

        Select Case MenuType
            Case Entity.Sys.Enums.MenuTypes.NONE
                MainForm.MenuBar.btnCustomer.IAmSelected = False
                MainForm.MenuBar.btnSpares.IAmSelected = False
                MainForm.MenuBar.btnStaff.IAmSelected = False
                MainForm.MenuBar.btnJobs.IAmSelected = False
                MainForm.MenuBar.btnInvoicing.IAmSelected = False
                MainForm.MenuBar.btnReports.IAmSelected = False
                MainForm.MenuBar.btnVan.IAmSelected = False
                MainForm.MenuBar.lblTitle.Text = "HOME"
            Case Entity.Sys.Enums.MenuTypes.Customers
                MainForm.MenuBar.btnCustomer.IAmSelected = True
                MainForm.MenuBar.btnSpares.IAmSelected = False
                MainForm.MenuBar.btnStaff.IAmSelected = False
                MainForm.MenuBar.btnJobs.IAmSelected = False
                MainForm.MenuBar.btnInvoicing.IAmSelected = False
                MainForm.MenuBar.btnReports.IAmSelected = False
                MainForm.MenuBar.btnVan.IAmSelected = False
                MainForm.MenuBar.lblTitle.Text = "CUSTOMERS"

            Case Entity.Sys.Enums.MenuTypes.Spares
                MainForm.MenuBar.btnCustomer.IAmSelected = False
                MainForm.MenuBar.btnSpares.IAmSelected = True
                MainForm.MenuBar.btnStaff.IAmSelected = False
                MainForm.MenuBar.btnJobs.IAmSelected = False
                MainForm.MenuBar.btnInvoicing.IAmSelected = False
                MainForm.MenuBar.btnReports.IAmSelected = False
                MainForm.MenuBar.btnVan.IAmSelected = False
                MainForm.MenuBar.lblTitle.Text = "SPARES"
            Case Entity.Sys.Enums.MenuTypes.Staff
                MainForm.MenuBar.btnCustomer.IAmSelected = False
                MainForm.MenuBar.btnSpares.IAmSelected = False
                MainForm.MenuBar.btnStaff.IAmSelected = True
                MainForm.MenuBar.btnJobs.IAmSelected = False
                MainForm.MenuBar.btnInvoicing.IAmSelected = False
                MainForm.MenuBar.btnReports.IAmSelected = False
                MainForm.MenuBar.btnVan.IAmSelected = False
                MainForm.MenuBar.lblTitle.Text = "STAFF"
            Case Entity.Sys.Enums.MenuTypes.Jobs
                MainForm.MenuBar.btnCustomer.IAmSelected = False
                MainForm.MenuBar.btnSpares.IAmSelected = False
                MainForm.MenuBar.btnStaff.IAmSelected = False
                MainForm.MenuBar.btnJobs.IAmSelected = True
                MainForm.MenuBar.btnInvoicing.IAmSelected = False
                MainForm.MenuBar.btnReports.IAmSelected = False
                MainForm.MenuBar.btnVan.IAmSelected = False
                MainForm.MenuBar.lblTitle.Text = "JOBS"
            Case Entity.Sys.Enums.MenuTypes.Invoicing
                MainForm.MenuBar.btnCustomer.IAmSelected = False
                MainForm.MenuBar.btnSpares.IAmSelected = False
                MainForm.MenuBar.btnStaff.IAmSelected = False
                MainForm.MenuBar.btnJobs.IAmSelected = False
                MainForm.MenuBar.btnInvoicing.IAmSelected = True
                MainForm.MenuBar.btnReports.IAmSelected = False
                MainForm.MenuBar.btnVan.IAmSelected = False
                MainForm.MenuBar.lblTitle.Text = "INVOICING"
            Case Entity.Sys.Enums.MenuTypes.Reports
                MainForm.MenuBar.btnCustomer.IAmSelected = False
                MainForm.MenuBar.btnSpares.IAmSelected = False
                MainForm.MenuBar.btnStaff.IAmSelected = False
                MainForm.MenuBar.btnJobs.IAmSelected = False
                MainForm.MenuBar.btnInvoicing.IAmSelected = False
                MainForm.MenuBar.btnReports.IAmSelected = True
                MainForm.MenuBar.btnVan.IAmSelected = False
                MainForm.MenuBar.lblTitle.Text = "REPORTS"
            Case Entity.Sys.Enums.MenuTypes.FleetVan
                MainForm.MenuBar.btnCustomer.IAmSelected = False
                MainForm.MenuBar.btnSpares.IAmSelected = False
                MainForm.MenuBar.btnStaff.IAmSelected = False
                MainForm.MenuBar.btnJobs.IAmSelected = False
                MainForm.MenuBar.btnInvoicing.IAmSelected = False
                MainForm.MenuBar.btnReports.IAmSelected = False
                MainForm.MenuBar.btnVan.IAmSelected = True
                MainForm.MenuBar.lblTitle.Text = "FLEET"
            Case Entity.Sys.Enums.MenuTypes.Setup
                MainForm.MenuBar.btnCustomer.IAmSelected = False
                MainForm.MenuBar.btnSpares.IAmSelected = False
                MainForm.MenuBar.btnStaff.IAmSelected = False
                MainForm.MenuBar.btnJobs.IAmSelected = False
                MainForm.MenuBar.btnInvoicing.IAmSelected = False
                MainForm.MenuBar.btnReports.IAmSelected = False
                MainForm.MenuBar.btnVan.IAmSelected = False
                MainForm.MenuBar.lblTitle.Text = "SETUP"
        End Select

        Set_Search_Control(MenuType)
        Set_Sub_Menu_Control(MenuType)

        CurrentCustomerID = 0
        CurrentPropertyID = 0

        Return True
    End Function

    Private Shared Sub Set_Search_Control(ByVal MenuType As Entity.Sys.Enums.MenuTypes)
        MainForm.MenuBar.pnlSearch.Controls.Clear()

        Dim ctrl As ISearchControl = Nothing

        Select Case MenuType
            Case Entity.Sys.Enums.MenuTypes.NONE
                MainForm.MenuBar.pnlSearch.Height = 1
                Exit Sub
            Case Entity.Sys.Enums.MenuTypes.Customers
                ctrl = New UCSearchCustomers
                MainForm.MenuBar.pnlSearch.Height = CType(ctrl, UCSearchCustomers).Height
            Case Entity.Sys.Enums.MenuTypes.Spares
                ctrl = New UCSearchSpares
                MainForm.MenuBar.pnlSearch.Height = CType(ctrl, UCSearchSpares).Height
            Case Entity.Sys.Enums.MenuTypes.Staff
                ctrl = New UCSearchStaff
                MainForm.MenuBar.pnlSearch.Height = CType(ctrl, UCSearchStaff).Height
            Case Entity.Sys.Enums.MenuTypes.Setup
                'ADD NO CONTROL
                MainForm.MenuBar.pnlSearch.Height = 1
                Exit Sub
            Case Entity.Sys.Enums.MenuTypes.Jobs
                'ctrl = New UCSearchJobs
                'MainForm.MenuBar.pnlSearch.Height = CType(ctrl, UCSearchJobs).Height
            Case Entity.Sys.Enums.MenuTypes.FleetVan
                ctrl = New UCSearchFleetVan
                MainForm.MenuBar.pnlSearch.Height = CType(ctrl, UCSearchFleetVan).Height
            Case Else
                MainForm.MenuBar.pnlSearch.Height = 1
                Exit Sub
        End Select

        MainForm.MenuBar.pnlSearch.Controls.Add(ctrl)
    End Sub

    Private Shared Sub Set_Sub_Menu_Control(ByVal MenuType As Entity.Sys.Enums.MenuTypes)
        MainForm.MenuBar.pnlSubMenu.Controls.Clear()

        Select Case MenuType
            Case Entity.Sys.Enums.MenuTypes.NONE
                'DO NOTHING
            Case Entity.Sys.Enums.MenuTypes.Customers
                'CUSTOMERS / SITES / ASSETS MUST BE ADDED 1st, 2nd and 3rd - IF NOT, TELL TONY BENNETT
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Show All Customers", Entity.Sys.Enums.TableNames.tblCustomer))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Show All Sites", Entity.Sys.Enums.TableNames.tblSite))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Show All Appliances", Entity.Sys.Enums.TableNames.tblAsset))
                If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.JobWizard) Then
                    MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Job Wizard", "FRMJobWizard"))
                End If

            Case Entity.Sys.Enums.MenuTypes.Spares
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Show All Warehouses", Entity.Sys.Enums.TableNames.tblWarehouse))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Show All Suppliers", Entity.Sys.Enums.TableNames.tblSupplier))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Show All Products", Entity.Sys.Enums.TableNames.tblProduct))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Show All Part Packs", Entity.Sys.Enums.TableNames.tblPartPack))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Place Order", "FRMOrder"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Show All Orders", "FRMOrderManager"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Stock Take", "FRMStockTake"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("I.P.T", "FRMStockMove"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Parts To Be Credited", "FRMPartsToBeCreditedManager"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("PO Invoice Authorisation", "FRMPOInvoiceAuthorisation"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Add Types, Makes or Models", "FRMTypeMakeModel"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Stock Profiles", Entity.Sys.Enums.TableNames.tblvan2))
                If IsGasway Then MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("PO Invoice Importer", "FRMPartsInvoiceImport"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("PO Invoice Importer Mk2", "FRMSupplierInvoiceImporter"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Equipment Used Report", "FRMEquipmentUsed"))

            Case Entity.Sys.Enums.MenuTypes.Staff
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Show All Users", "FRMUsers"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Show All Equipment", Entity.Sys.Enums.TableNames.tblEquipment))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Show All Engineers", Entity.Sys.Enums.TableNames.tblEngineer))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Show All Subcontractors", Entity.Sys.Enums.TableNames.tblSubcontractor))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Show All User Quals", Entity.Sys.Enums.TableNames.tblUserQualification))

            Case Entity.Sys.Enums.MenuTypes.Setup
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Picklists / Settings", "FRMManager"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Checklist Manager", "FRMCheckListManager"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("System History", "FRMHistory"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Override Password", "FRMChangeOverridePassword"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Override Password_Service", "FRMChangeOverridePassword_Service"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Schedule Of Rates", "FRMSystemScheduleOfRate"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Engineer Roles", "FRMEngineerRoles"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Part Categories", "FRMPartCategories"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("VAT Rates", "FRMVATRates"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Standard Sentences", "FRMStandardSentences"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Job Locks", "FRMJobLocks"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Parts Importer", "FRMPartsImport"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Job Skills", "FRMJobSkills"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Customer SOR Job Type Default", "FRMCustomerSORJobType"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Sites Importer", "FRMSitesImport"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Scheduler Settings", "FRMSchedulerSettings"))

            Case Entity.Sys.Enums.MenuTypes.Jobs
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Job Manager", "FRMJobManager"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Visit Manager", "FRMVM"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Quote Manager", "FRMQuoteManager"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Contract Manager", "FRMContractManager"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Engineer Timesheets", "FRMEngineerTimesheets"))
                If IsGasway Then MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Letter Manager", "FRMLetterManager"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Letter Manager MK3", "FRMLetterManagerMK3"))
                If IsGasway Then MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Batch GSR Print", "FRMBatchGSRPrint"))
                If IsGasway Then MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("EICR Job Importer", "FRMJobImport"))
                If IsGasway Then MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("EICR Job Import Manager", "FRMJobImportManager"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Bulk Job Creator", "FRMBulkJobCreation"))

            Case Entity.Sys.Enums.MenuTypes.Reports

                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Engineer Timesheet Rep.", "FRMEngineerTimesheetReport"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Products Last GSR Rep.", "FRMLastGSRReport"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Stock Used", "FRMStockUsed"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Parts Used Report", "FRMPartsUsed"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("I.P.T Audit", "FRMStockMoved"))

            Case Entity.Sys.Enums.MenuTypes.Invoicing
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Ready To Be Invoiced", "FRMInvoiceManager"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Invoiced Manager", "FRMInvoicedManager"))

            Case Entity.Sys.Enums.MenuTypes.FleetVan
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Show All Vans", Entity.Sys.Enums.TableNames.tblFleetVan))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Show All Returned Vans", Entity.Sys.Enums.TableNames.tblFleetReturnedVans))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Show All Van Types", Entity.Sys.Enums.TableNames.tblFleetVanType))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Show All Equipments", Entity.Sys.Enums.TableNames.tblFleetEquipment))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Show All Service Centres", Entity.Sys.Enums.TableNames.tblFleetGarage))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Van Mileage Importer", "FRMFleetVanImporter"))
                MainForm.MenuBar.pnlSubMenu.Controls.Add(New SubMenuNode("Van Manager", "FRMFleetVanManager"))

        End Select
    End Sub

    Public Shared Sub Sub_Menu(ByVal butttonClicked As SubMenuNode)
        If butttonClicked Is Nothing Then
            Exit Sub
        End If

        ResponsiveUI()

        If Not butttonClicked.FormToOpen.Trim.Length = 0 Then
            If Not Close_Middle() Then
                Exit Sub
            End If

            For Each form As Form In MainForm.MdiChildren
                form.Dispose()
            Next

            Select Case butttonClicked.FormToOpen.Trim.ToLower
                Case "FRMBatchGSRPrint".ToLower
                    ShowForm(GetType(FRMBatchGSRPrint), False, Nothing)
                Case "FRMPartsToBeCreditedManager".ToLower
                    ShowForm(GetType(FRMPartsToBeCreditedManager), False, Nothing)
                Case "FRMManager".ToLower
                    If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Compliance) Then
                        ShowForm(GetType(FRMManager), False, Nothing)
                    Else
                        Dim msg As String = "You do not have the necessary security permissions."
                        Throw New Security.SecurityException(msg)
                    End If
                Case "FRMJobManager".ToLower
                    ShowForm(GetType(FRMJobManager), False, Nothing)
                Case "FRMUsers".ToLower
                    If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.IT) Then
                        ShowForm(GetType(FRMUsers), False, New Object() {String.Empty})
                    Else
                        Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
                        msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                        Throw New Security.SecurityException(msg)
                    End If
                Case "FRMChangeOverridePassword".ToLower
                    If loggedInUser.HasAccessToModule() Then
                        ShowForm(GetType(FRMChangeOverridePassword), False, Nothing)
                    Else
                        Dim msg As String = "You do not have the necessary security permissions."
                        Throw New Security.SecurityException(msg)
                    End If
                Case "FRMChangeOverridePassword_Service".ToLower
                    If loggedInUser.HasAccessToModule() Then
                        ShowForm(GetType(FRMChangeOverridePassword_Service), False, Nothing)
                    Else
                        Dim msg As String = "You do not have the necessary security permissions."
                        Throw New Security.SecurityException(msg)
                    End If
                Case "FRMHistory".ToLower
                    If loggedInUser.HasAccessToModule() Then
                        ShowForm(GetType(FRMHistory), False, Nothing)
                    Else
                        Dim msg As String = "You do not have the necessary security permissions."
                        Throw New Security.SecurityException(msg)
                    End If
                Case "FRMStockTake".ToLower
                    If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.StockTake) Then
                        ShowForm(GetType(FRMStockTake), False, Nothing)
                    Else
                        Dim msg As String = "You do not have the necessary security permissions."
                        Throw New Security.SecurityException(msg)
                    End If
                Case "FRMCheckListManager".ToLower
                    ShowForm(GetType(FRMCheckListManager), False, Nothing)
                Case "FRMTypeMakeModel".ToLower
                    ShowForm(GetType(FRMTypeMakeModel), False, Nothing)
                Case "FRMOrder".ToLower
                    If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.CreatePO) = False Then
                        Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
                        msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                        Throw New Security.SecurityException(msg)
                    Else
                        ShowForm(GetType(FRMOrder), False, Nothing)
                    End If
                Case "FRMOrderManager".ToLower
                    Dim _ssmList As New List(Of Entity.Sys.Enums.SecuritySystemModules) From
                    {Entity.Sys.Enums.SecuritySystemModules.CreatePO, Entity.Sys.Enums.SecuritySystemModules.EditPO}

                    If loggedInUser.HasAccessToMulitpleModules(_ssmList) Then
                        ShowForm(GetType(FRMOrderManager), False, Nothing)
                    Else
                        Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
                        msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                        Throw New Security.SecurityException(msg)
                    End If
                Case "FRMJobManager".ToLower
                    ShowForm(GetType(FRMJobManager), False, Nothing)
                Case "FRMJobImport".ToLower
                    ShowForm(GetType(FRMJobImport), False, Nothing)
                Case "FRMJobImportManager".ToLower
                    ShowForm(GetType(FRMJobImportManager), False, Nothing)
                Case "FRMBulkJobCreation".ToLower
                    ShowForm(GetType(FRMBulkJobCreation), False, Nothing)
                Case "FRMJobLocks".ToLower
                    If loggedInUser.HasAccessToModule() Then
                        ShowForm(GetType(FRMJobLocks), False, Nothing)
                    Else
                        Dim msg As String = "You do not have the necessary security permissions."
                        Throw New Security.SecurityException(msg)
                    End If
                Case "FRMVM".ToLower
                    ShowForm(GetType(FRMVisitManager), False, Nothing)
                Case "FRMQuoteManager".ToLower
                    ShowForm(GetType(FRMQuoteManager), False, Nothing)
                Case "FRMContractManager".ToLower
                    ShowForm(GetType(FRMContractManager), False, Nothing)
                Case "FRMSystemScheduleOfRate".ToLower
                    If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Compliance) Then
                        ShowForm(GetType(FRMSystemScheduleOfRate), False, Nothing)
                    Else
                        Dim msg As String = "You do not have the necessary security permissions."
                        Throw New Security.SecurityException(msg)
                    End If
                'Case "FRMTimeSlotRates".ToLower
                '    If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Compliance) Then
                '        ShowForm(GetType(FRMTimeSlotRates), False, Nothing)
                '    Else
                '        Dim msg As String = "You do not have the necessary security permissions."
                '        Throw New Security.SecurityException(msg)
                '    End If
                Case "FRMEngineerRoles".ToLower
                    If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Finance) Then
                        ShowForm(GetType(FRMEngineerRole), False, Nothing)
                    Else
                        Dim msg As String = "You do not have the necessary security permissions."
                        Throw New Security.SecurityException(msg)
                    End If
                Case "FRMInvoiceManager".ToLower
                    ShowForm(GetType(FRMInvoiceManager), False, Nothing)
                Case "FRMInvoicedManager".ToLower
                    ShowForm(GetType(FRMInvoicedManager), False, Nothing)
                Case "FRMJobSkills".ToLower
                    If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Compliance) Then
                        ShowForm(GetType(FRMJobSkills), False, Nothing)
                    Else
                        Dim msg As String = "You do not have the necessary security permissions."
                        Throw New Security.SecurityException(msg)
                    End If
                Case "FRMCustomerSORJobType".ToLower
                    If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Compliance) Then
                        ShowForm(GetType(FRMCustomerSORJobType), False, Nothing)
                    Else
                        Dim msg As String = "You do not have the necessary security permissions."
                        Throw New Security.SecurityException(msg)
                    End If
                Case "FRMPartCategories".ToLower
                    ShowForm(GetType(FRMPartCategories), False, Nothing)
                Case "FRMEngineerTimesheetReport".ToLower
                    ShowForm(GetType(FRMEngineerTimesheetReport), False, Nothing)
                Case "FRMDirectDebitReport".ToLower
                    ShowForm(GetType(FRMDirectDebitReport), False, Nothing)
                Case "FRMVATRates".ToLower
                    ShowForm(GetType(FRMVATRates), False, Nothing)
                Case "FRMLastGSRReport".ToLower
                    ShowForm(GetType(FRMLastGSRReport), False, Nothing)
                Case "FRMStandardSentences".ToLower
                    ShowForm(GetType(FRMStandardSentences), False, Nothing)
                Case "FRMStockValuation".ToLower
                    ShowForm(GetType(FRMStockValuation), False, Nothing)
                Case "FRMStockCategoryValuation".ToLower
                    ShowForm(GetType(FRMStockCategoryValuation), False, Nothing)
                Case "FRMStockUsed".ToLower
                    ShowForm(GetType(FRMStockUsed), False, Nothing)
                Case "FRMStockMove".ToLower
                    ShowForm(GetType(FRMStockMove), False, Nothing)
                Case "FRMStockReplenishment".ToLower
                    ShowForm(GetType(FRMStockReplenishment), False, New Object() {True})
                Case "FRMPartsUsed".ToLower
                    ShowForm(GetType(FRMPartsUsed), False, Nothing)
                Case "FRMStockMoved".ToLower
                    ShowForm(GetType(FRMStockMoved), False, Nothing)
                Case "FRMEngineerTimesheets".ToLower
                    ShowForm(GetType(FRMEngineerTimesheets), False, Nothing)
                Case "FRMPartsImport".ToLower
                    If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.EditParts) Then
                        ShowForm(GetType(FRMPartsImport), False, Nothing)
                    Else
                        Dim msg As String = "You do not have the necessary security permissions."
                        Throw New Security.SecurityException(msg)
                    End If
                Case "FRMPartsInvoiceImport".ToLower
                    If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.POImporter) = False Then
                        Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
                        msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                        Throw New Security.SecurityException(msg)
                    Else
                        ShowForm(GetType(FRMPartsInvoiceImport), False, Nothing)
                    End If
                Case "FRMSupplierInvoiceImporter".ToLower
                    If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.POImporter) = False Then
                        Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
                        msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                        Throw New Security.SecurityException(msg)
                    Else
                        ShowForm(GetType(FRMSupplierInvoiceImporter), False, Nothing)
                    End If
                Case "FRMPOInvoiceAuthorisation".ToLower
                    If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.POAuthorisation) = False Then
                        Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
                        msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                        Throw New Security.SecurityException(msg)
                    Else
                        ShowForm(GetType(FRMPOInvoiceAuthorisation), False, Nothing)
                    End If
                Case "FRMSitesImport".ToLower
                    ShowForm(GetType(FRMImport), False, New Object() {"Sites"})
                Case "FRMLetterManager".ToLower
                    ShowForm(GetType(FRMLetterManager), False, Nothing)
                Case "FRMLetterManagerMK3".ToLower
                    ShowForm(GetType(FRMLetterManagerMK3), False, Nothing)
                Case "FRMFleetVanImporter".ToLower
                    If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Fleet) = False Then
                        Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
                        msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                        Throw New Security.SecurityException(msg)
                    Else
                        ShowForm(GetType(FRMFleetVanImporter), False, Nothing)
                    End If
                Case "FRMFleetVanManager".ToLower
                    If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Fleet) = False Then
                        Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
                        msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                        Throw New Security.SecurityException(msg)
                    Else
                        ShowForm(GetType(FRMFleetVanManager), False, Nothing)
                    End If
                Case "UsePanels".ToLower
                    Select Case butttonClicked.TableToSearch
                        Case Entity.Sys.Enums.TableNames.tblSupplier
                            MainForm.SetSearchResults(DB.Supplier.Supplier_GetAll, Entity.Sys.Enums.PageViewing.Supplier, False, False)
                        Case Entity.Sys.Enums.TableNames.tblCustomer
                            CurrentCustomerID = 0
                            MainForm.SetSearchResults(DB.Customer.Customer_GetAll_Light(loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Customer, False, False)
                        Case Entity.Sys.Enums.TableNames.tblProduct
                            MainForm.SetSearchResults(DB.Product.Product_GetAll, Entity.Sys.Enums.PageViewing.Product, False, False)
                        Case Entity.Sys.Enums.TableNames.tblPart
                            MainForm.SetSearchResults(DB.Part.Part_GetAll, Entity.Sys.Enums.PageViewing.Part, False, False)
                        Case Entity.Sys.Enums.TableNames.tblPartPack
                            MainForm.SetSearchResults(DB.Part.PartPack_GetAll, Entity.Sys.Enums.PageViewing.PartPack, False, False)
                        Case Entity.Sys.Enums.TableNames.tblEngineer
                            MainForm.SetSearchResults(DB.Engineer.Engineer_GetAll_NoSub, Entity.Sys.Enums.PageViewing.Engineer, False, False)
                        Case Entity.Sys.Enums.TableNames.tblEquipment
                            MainForm.SetSearchResults(DB.Engineer.Equipment_GetAll, Entity.Sys.Enums.PageViewing.Equipment, False, False)

                        Case Entity.Sys.Enums.TableNames.tblWarehouse
                            MainForm.SetSearchResults(DB.Warehouse.Warehouse_GetAll, Entity.Sys.Enums.PageViewing.Warehouse, False, False)
                        Case Entity.Sys.Enums.TableNames.tblSubcontractor
                            If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Subcontractor) = False Then
                                Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
                                msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                                Throw New Security.SecurityException(msg)
                            Else
                                MainForm.SetSearchResults(DB.SubContractor.Subcontractor_GetAll, Entity.Sys.Enums.PageViewing.Subcontractor, False, False)
                            End If
                        Case Entity.Sys.Enums.TableNames.tblSite
                            CurrentPropertyID = 0
                            If CurrentCustomerID = 0 Then
                                MainForm.SetSearchResults(DB.Sites.GetAll_Light_New(loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Property, False, False)
                            Else
                                Dim cust As New Entity.Customers.Customer
                                cust = DB.Customer.Customer_Get(CurrentCustomerID)
                                MainForm.SetSearchResults(DB.Sites.GetForCustomer_Light(CurrentCustomerID, loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Property, False, False, cust.Name & " (" & cust.AccountNumber & ")")
                            End If
                        Case Entity.Sys.Enums.TableNames.tblAsset
                            If CurrentPropertyID = 0 Then
                                MainForm.SetSearchResults(DB.Asset.Asset_GetAll(loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Asset, False, False)
                            Else
                                Dim site As New Entity.Sites.Site
                                site = DB.Sites.Get(CurrentPropertyID)
                                Dim cust As New Entity.Customers.Customer
                                cust = DB.Customer.Customer_Get(site.CustomerID)
                                MainForm.SetSearchResults(DB.Asset.Asset_GetForSite(CurrentPropertyID), Entity.Sys.Enums.PageViewing.Asset, False, False, site.Address1 & ", " & site.Postcode & " (" & cust.AccountNumber & ")")
                            End If
                        Case Entity.Sys.Enums.TableNames.tblVan
                            MainForm.SetSearchResults(DB.Van.Van_GetAll(True), Entity.Sys.Enums.PageViewing.Van, False, False)
                        Case Entity.Sys.Enums.TableNames.tblvan2
                            MainForm.SetSearchResults(DB.Van.Van_GetAll(True), Entity.Sys.Enums.PageViewing.StockProfile, False, False)
                        Case Entity.Sys.Enums.TableNames.tblFleetVan
                            MainForm.SetSearchResults(DB.FleetVan.GetAll(), Entity.Sys.Enums.PageViewing.FleetVan, False, False)
                        Case Entity.Sys.Enums.TableNames.tblFleetReturnedVans
                            MainForm.SetSearchResults(DB.FleetVan.GetAll_Returned(), Entity.Sys.Enums.PageViewing.FleetVan, False, False)
                        Case Entity.Sys.Enums.TableNames.tblFleetVanType
                            MainForm.SetSearchResults(DB.FleetVanType.GetAll(), Entity.Sys.Enums.PageViewing.FleetVanType, False, False)
                        Case Entity.Sys.Enums.TableNames.tblFleetEquipment
                            MainForm.SetSearchResults(DB.FleetEquipment.GetAll(), Entity.Sys.Enums.PageViewing.FleetEquipment, False, False)
                        Case Entity.Sys.Enums.TableNames.tblFleetGarage
                            MainForm.SetSearchResults(DB.Sites.GetAll_FleetGarage(loggedInUser.UserID),
                                                      Entity.Sys.Enums.PageViewing.Property, False, False)
                        Case Entity.Sys.Enums.TableNames.tblUserQualification
                            Dim _ssmList As New List(Of Entity.Sys.Enums.SecuritySystemModules) From
                                {Entity.Sys.Enums.SecuritySystemModules.Compliance, Entity.Sys.Enums.SecuritySystemModules.IT}
                            MainForm.SetSearchResults(DB.User.GetAll_NoEngineers, Entity.Sys.Enums.PageViewing.UserQuals, False, False)
                    End Select
                Case "FRMBatchVisitCosts".ToLower
                    ShowForm(GetType(FRMBatchVisitCosts), False, Nothing)
                Case "FRMJobWizard".ToLower
                    ShowForm(GetType(FRMJobWizard), False, Nothing)
                Case "FRMEquipmentUsed".ToLower
                    ShowForm(GetType(FRMEquipmentUsed), False, Nothing)
                Case "FRMSchedulerSettings".ToLower
                    ShowForm(GetType(FRMSchedulerSettings), False, Nothing)
            End Select
        End If
    End Sub

    Public Shared Function Close_Middle() As Boolean
        If Close_Right() Then
            MainForm.pnlMiddle.Visible = False
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function Close_Right() As Boolean
        If MainForm.pnlRight.Visible Then
            If ControlChanged = True Then

                If ShowMessage("Would you like to save before data pane closes? (Any changes made will be lost)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    If CType(MainForm.pnlContent.Controls(0), IUserControl).Save() Then
                        MainForm.pnlRight.Visible = False
                        MainForm.pnlContent.Controls.Clear()
                        Return True
                    Else
                        Return False
                    End If
                Else
                    MainForm.pnlRight.Visible = False
                    MainForm.pnlContent.Controls.Clear()
                    Return True
                End If
            Else
                MainForm.pnlRight.Visible = False
                MainForm.pnlContent.Controls.Clear()
                Return True
            End If
        Else
            Return True
        End If
    End Function

    Public Shared Sub Show_Right()

        If Entity.Sys.Helper.MakeIntegerValid(MainForm?.pnlContent.Controls.Count) = 0 Then
            Exit Sub
        End If

        MainForm.pnlRight.Visible = False
        Dim locationX As Integer = MainForm.pnlLeft.Width + MainForm.pnlMiddle.Width + 7
        Dim locationY As Integer = MainForm.pnlMiddle.Location.Y
        MainForm.pnlRight.Location = New Point(locationX, locationY)
        MainForm.pnlRight.Size = New Size(MainForm.Width - locationX - 10, MainForm.pnlMiddle.Height)
        MainForm.pnlRight.Visible = True

    End Sub

    Public Shared Sub ResponsiveUI()
        If MainForm.pnlMiddle.Width < Entity.Sys.Consts.MidPanelResizeTrigger Then
            MainForm.btnDelete.Text = "Del"
        Else
            MainForm.btnDelete.Text = "Delete"
        End If
    End Sub

#End Region

End Class