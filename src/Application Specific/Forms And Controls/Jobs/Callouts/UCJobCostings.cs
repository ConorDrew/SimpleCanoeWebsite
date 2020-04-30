using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
    public class UCJobCostings : UCBase
    {
        public UCJobCostings()
        {
            
            
            base.Load += UCJobCost_Load;
        }

        

        public UCJobCostings(int IDToLinkToIn) : base()
        {
            base.Load += UCJobCost_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            IDToLinkTo = IDToLinkToIn;
            Dock = DockStyle.Fill;
        }

        // Form overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components is null))
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            SuspendLayout();
            //
            // UCJobCostings
            //
            Name = "UCJobCostings";
            Size = new Size(504, 560);
            ResumeLayout(false);
        }

        
        

        private Entity.JobInstalls.JobInstall _JI;

        private Entity.JobInstalls.JobInstall JI
        {
            get
            {
                return _JI;
            }

            set
            {
                _JI = value;
            }
        }

        private int _IDToLinkTo = 0;

        public int IDToLinkTo
        {
            get
            {
                return _IDToLinkTo;
            }

            set
            {
                _IDToLinkTo = value;
                if (IDToLinkTo == 0)
                {
                }
                else
                {
                }
            }
        }

        private DataView _dvDocuments;
        // Public Property Documents() As DataView
        // Get
        // Return _dvDocuments
        // End Get
        // Set(ByVal value As DataView)
        // _dvDocuments = value
        // _dvDocuments.Table.TableName = Entity.Sys.Enums.TableNames.tblDocuments.ToString
        // _dvDocuments.AllowNew = False
        // _dvDocuments.AllowEdit = False
        // _dvDocuments.AllowDelete = False
        // Me.dgDocuments.DataSource = Documents
        // End Set
        // End Property

        // Private ReadOnly Property SelectedDocumentDataRow() As DataRow
        // Get
        // If Not Me.dgDocuments.CurrentRowIndex = -1 Then
        // Return Documents(Me.dgDocuments.CurrentRowIndex).Row
        // Else
        // Return Nothing
        // End If
        // End Get
        // End Property

        
        

        private void SetupDocumentsDataGrid()
        {
        }

        private void UCJobCost_Load(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            // UCLogCallout.OnCostings = Me
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // ShowForm(GetType(FRMDocuments), True, New Object() {EntityToLinkTo, Entity.Sys.Helper.MakeIntegerValid(IDToLinkTo), 0, Me})
        }

        // Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        // If SelectedDocumentDataRow Is Nothing Then
        // ShowMessage("Please select a document to delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        // Exit Sub
        // End If

        // If ShowMessage("Are you sure you want to delete the selected record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
        // Exit Sub
        // End If

        // DB.Documents.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedDocumentDataRow.Item("DocumentID")))
        // ' Documents = DB.Documents.Documents_GetAll_For_Entity_ID(EntityToLinkTo, IDToLinkTo)
        // 'JUST REFERESH THROUGH THE PROPERTY
        // IDToLinkTo = IDToLinkTo

        // End Sub

        // Private Sub dgDocuments_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        // If SelectedDocumentDataRow Is Nothing Then
        // Exit Sub
        // End If

        // ShowForm(GetType(FRMDocuments), True, New Object() {CType(SelectedDocumentDataRow.Item("TableEnumID"), Entity.Sys.Enums.TableNames), Entity.Sys.Helper.MakeIntegerValid(IDToLinkTo), Entity.Sys.Helper.MakeIntegerValid(SelectedDocumentDataRow.Item("DocumentID")), Me})
        // End Sub

        
        

        public void Populate()
        {
        }

        
    }
}