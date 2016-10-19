using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IVG.Strike.EncounterBuilderWPF.Views
{
    /// <summary>
    /// Interaction logic for MonsterPrintPreview.xaml
    /// </summary>
    public partial class MonsterPrintPreview : Window
    {
        private List<Models.MonsterPrintModel> _monsters;
        public MonsterPrintPreview(List<Models.MonsterPrintModel> monsters)
        {
            InitializeComponent();

            _monsters = monsters;
            _reportViewer.Load += ReportViewer_Load;
        }

        private bool _isReportViewerLoaded;

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            if (!_isReportViewerLoaded)
            {
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

                reportDataSource1.Name = "MonsterDS"; //Name of the report dataset in our .RDLC file
                reportDataSource1.Value = _monsters;
                this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
                this._reportViewer.LocalReport.ReportEmbeddedResource = "IVG.Strike.EncounterBuilderWPF.Reports.StrikeEncounter.rdlc";

                this._reportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                _reportViewer.RefreshReport();

                _isReportViewerLoaded = true;
            }
        }
    }
}
