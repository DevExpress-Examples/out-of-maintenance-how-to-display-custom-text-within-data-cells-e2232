Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows
Imports DevExpress.Xpf.PivotGrid
Imports DevExpress.XtraPivotGrid
Imports DXPivotGrid_FormattingViaEvents_VB.nwindDataSetTableAdapters

Namespace DXPivotGrid_FormattingViaEvents_VB
    Partial Public Class MainWindow
        Inherits Window
        Private salesPersonDataTable As New nwindDataSet.SalesPersonDataTable()
        Private salesPersonDataAdapter As New SalesPersonTableAdapter()
        Public Sub New()
            InitializeComponent()
            pivotGridControl1.DataSource = salesPersonDataTable
            pivotGridControl1.PrefilterString = "[Country] == 'UK' OR [Country] == 'USA'"

        End Sub
        Protected Sub pivotGridControl1_CustomCellDisplayText(ByVal sender As Object, _
                                                    ByVal e As PivotCellDisplayTextEventArgs)
            If e.RowValueType <> PivotGridValueType.GrandTotal OrElse
                e.ColumnValueType = PivotGridValueType.GrandTotal OrElse
                e.ColumnValueType = PivotGridValueType.Total Then
                Return
            End If
            If Convert.ToSingle(e.Value) < 50000 Then
                e.DisplayText = "Low"
            ElseIf Convert.ToSingle(e.Value) > 100000 Then
                e.DisplayText = "High"
            Else
                e.DisplayText = "Middle"
            End If
        End Sub
        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            salesPersonDataAdapter.Fill(salesPersonDataTable)
        End Sub
    End Class
End Namespace

