using System;
using System.Windows;
using DevExpress.Xpf.PivotGrid;
using DevExpress.XtraPivotGrid;
using FormattingViaEvents.DataSet1TableAdapters;

namespace FormattingViaEvents {
    public partial class MainWindow : Window {
        FormattingViaEvents.DataSet1.SalesPersonDataTable salesPersonDataTable =
            new FormattingViaEvents.DataSet1.SalesPersonDataTable();
        SalesPersonTableAdapter salesPersonDataAdapter = new SalesPersonTableAdapter();
        public MainWindow() {
            InitializeComponent();
            pivotGridControl1.DataSource = salesPersonDataTable;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            salesPersonDataAdapter.Fill(salesPersonDataTable);
        }
        private void pivotGridControl1_CustomCellDisplayText(object sender,
            PivotCellDisplayTextEventArgs e) {
                if (e.RowValueType != PivotGridValueType.GrandTotal ||
                    e.ColumnValueType == PivotGridValueType.GrandTotal ||
                    e.ColumnValueType == PivotGridValueType.Total) return;
                if (Convert.ToSingle(e.Value) < 50000)
                    e.DisplayText = "Low";
                else if (Convert.ToSingle(e.Value) > 100000)
                    e.DisplayText = "High";
                else
                    e.DisplayText = "Middle";
        }
    }
}
