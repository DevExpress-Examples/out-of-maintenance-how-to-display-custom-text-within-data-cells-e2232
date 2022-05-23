Imports System
Imports System.Windows
Imports DevExpress.Xpf.PivotGrid
Imports FormattingViaEvents.DataSet1TableAdapters

Namespace FormattingViaEvents

    Public Partial Class MainWindow
        Inherits Window

        Private salesPersonDataTable As DataSet1.SalesPersonDataTable = New DataSet1.SalesPersonDataTable()

        Private salesPersonDataAdapter As SalesPersonTableAdapter = New SalesPersonTableAdapter()

        Public Sub New()
            Me.InitializeComponent()
            Me.pivotGridControl1.DataSource = salesPersonDataTable
        End Sub

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            salesPersonDataAdapter.Fill(salesPersonDataTable)
        End Sub

        Private Sub pivotGridControl1_CustomCellDisplayText(ByVal sender As Object, ByVal e As PivotCellDisplayTextEventArgs)
            If e.RowValueType <> FieldValueType.GrandTotal OrElse e.ColumnValueType = FieldValueType.GrandTotal OrElse e.ColumnValueType = FieldValueType.Total Then Return
            If Convert.ToSingle(e.Value) < 50000 Then
                e.DisplayText = "Low"
            ElseIf Convert.ToSingle(e.Value) > 100000 Then
                e.DisplayText = "High"
            Else
                e.DisplayText = "Middle"
            End If
        End Sub
    End Class
End Namespace
