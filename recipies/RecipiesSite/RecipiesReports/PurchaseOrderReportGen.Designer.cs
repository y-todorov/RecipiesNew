namespace RecipiesReports
{
    partial class PurchaseOrderReportGen
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.InstanceReportSource instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group2 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group3 = new Telerik.Reporting.Group();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.dsPurchaseOrderDetails = new Telerik.Reporting.OpenAccessDataSource();
            this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
            this.dsPurchaseOrderHeaders = new Telerik.Reporting.OpenAccessDataSource();
            this.openAccessDataSource1 = new Telerik.Reporting.OpenAccessDataSource();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.labelsGroupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            this.labelsGroupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.labelsGroupHeaderSection2 = new Telerik.Reporting.GroupHeaderSection();
            this.labelsGroupFooterSection2 = new Telerik.Reporting.GroupFooterSection();
            this.pageHeader = new Telerik.Reporting.PageHeaderSection();
            this.reportNameTextBox = new Telerik.Reporting.TextBox();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.shipDateCaptionTextBox = new Telerik.Reporting.TextBox();
            this.shipDateDataTextBox = new Telerik.Reporting.TextBox();
            this.subTotalCaptionTextBox = new Telerik.Reporting.TextBox();
            this.subTotalDataTextBox = new Telerik.Reporting.TextBox();
            this.totalDueCaptionTextBox = new Telerik.Reporting.TextBox();
            this.totalDueDataTextBox = new Telerik.Reporting.TextBox();
            this.vATCaptionTextBox = new Telerik.Reporting.TextBox();
            this.vATDataTextBox = new Telerik.Reporting.TextBox();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.subReport1 = new Telerik.Reporting.SubReport();
            this.textBox1 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // dsPurchaseOrderDetails
            // 
            this.dsPurchaseOrderDetails.ConnectionString = "Data Source=804b3a50-697f-4e00-b7cc-a1e6015cf402.sqlserver.sequelizer.com;Persist" +
    " Security Info=True;User ID=uehevqpfoljtplku;Password=uhffcctREdsiocbJhjETidnG5q" +
    "5jWtB25oyDasHUYHNVtA8EzVMz5NPr4FiTgi3k";
            this.dsPurchaseOrderDetails.Name = "dsPurchaseOrderDetails";
            this.dsPurchaseOrderDetails.ObjectContext = "DynamicApplicationModel.RecipiesModel, DynamicApplicationModel, Version=1.0.0.0, " +
    "Culture=neutral, PublicKeyToken=null";
            this.dsPurchaseOrderDetails.ObjectContextMember = "PurchaseOrderDetails";
            this.dsPurchaseOrderDetails.ProviderName = "System.Data.SqlClient";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // dsPurchaseOrderHeaders
            // 
            this.dsPurchaseOrderHeaders.ConnectionString = "Connection";
            this.dsPurchaseOrderHeaders.Name = "dsPurchaseOrderHeaders";
            this.dsPurchaseOrderHeaders.ObjectContext = "DynamicApplicationModel.RecipiesModel, DynamicApplicationModel, Version=1.0.0.0, " +
    "Culture=neutral, PublicKeyToken=null";
            this.dsPurchaseOrderHeaders.ObjectContextMember = "PurchaseOrderHeaders";
            // 
            // openAccessDataSource1
            // 
            this.openAccessDataSource1.Name = "openAccessDataSource1";
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.Style.Visible = false;
            // 
            // labelsGroupHeaderSection1
            // 
            this.labelsGroupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.44166669249534607D);
            this.labelsGroupHeaderSection1.Name = "labelsGroupHeaderSection1";
            this.labelsGroupHeaderSection1.PrintOnEveryPage = true;
            // 
            // labelsGroupFooterSection1
            // 
            this.labelsGroupFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.labelsGroupFooterSection1.Name = "labelsGroupFooterSection1";
            this.labelsGroupFooterSection1.Style.Visible = false;
            // 
            // labelsGroupHeaderSection2
            // 
            this.labelsGroupHeaderSection2.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.labelsGroupHeaderSection2.Name = "labelsGroupHeaderSection2";
            this.labelsGroupHeaderSection2.PrintOnEveryPage = true;
            // 
            // labelsGroupFooterSection2
            // 
            this.labelsGroupFooterSection2.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.labelsGroupFooterSection2.Name = "labelsGroupFooterSection2";
            this.labelsGroupFooterSection2.Style.Visible = false;
            // 
            // pageHeader
            // 
            this.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0.44166669249534607D);
            this.pageHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.reportNameTextBox});
            this.pageHeader.Name = "pageHeader";
            // 
            // reportNameTextBox
            // 
            this.reportNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.reportNameTextBox.Name = "reportNameTextBox";
            this.reportNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4166665077209473D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.reportNameTextBox.StyleName = "PageInfo";
            this.reportNameTextBox.Value = "PurchaseOrderReportGen";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.44166669249534607D);
            this.pageFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.currentTimeTextBox,
            this.pageInfoTextBox});
            this.pageFooter.Name = "pageFooter";
            // 
            // currentTimeTextBox
            // 
            this.currentTimeTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.currentTimeTextBox.Name = "currentTimeTextBox";
            this.currentTimeTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.1979167461395264D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.currentTimeTextBox.StyleName = "PageInfo";
            this.currentTimeTextBox.Value = "=NOW()";
            // 
            // pageInfoTextBox
            // 
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.2395832538604736D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.1979167461395264D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.Value = "=PageNumber";
            // 
            // reportHeader
            // 
            this.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(1.2290682792663574D);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBox,
            this.shipDateCaptionTextBox,
            this.shipDateDataTextBox,
            this.subTotalCaptionTextBox,
            this.subTotalDataTextBox,
            this.totalDueCaptionTextBox,
            this.totalDueDataTextBox,
            this.vATCaptionTextBox,
            this.vATDataTextBox});
            this.reportHeader.Name = "reportHeader";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4583334922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.787401556968689D));
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "PurchaseOrderReportGen";
            // 
            // shipDateCaptionTextBox
            // 
            this.shipDateCaptionTextBox.CanGrow = true;
            this.shipDateCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.80823493003845215D));
            this.shipDateCaptionTextBox.Name = "shipDateCaptionTextBox";
            this.shipDateCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.78385418653488159D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.shipDateCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.shipDateCaptionTextBox.StyleName = "Caption";
            this.shipDateCaptionTextBox.Value = "Ship Date:";
            // 
            // shipDateDataTextBox
            // 
            this.shipDateDataTextBox.CanGrow = true;
            this.shipDateDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.82552081346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.80823493003845215D));
            this.shipDateDataTextBox.Name = "shipDateDataTextBox";
            this.shipDateDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.78385418653488159D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.shipDateDataTextBox.StyleName = "Data";
            this.shipDateDataTextBox.Value = "=Fields.ShipDate";
            // 
            // subTotalCaptionTextBox
            // 
            this.subTotalCaptionTextBox.CanGrow = true;
            this.subTotalCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.6302083730697632D), Telerik.Reporting.Drawing.Unit.Inch(0.80823493003845215D));
            this.subTotalCaptionTextBox.Name = "subTotalCaptionTextBox";
            this.subTotalCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.78385418653488159D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.subTotalCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.subTotalCaptionTextBox.StyleName = "Caption";
            this.subTotalCaptionTextBox.Value = "Sub Total:";
            // 
            // subTotalDataTextBox
            // 
            this.subTotalDataTextBox.CanGrow = true;
            this.subTotalDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.4348957538604736D), Telerik.Reporting.Drawing.Unit.Inch(0.80823493003845215D));
            this.subTotalDataTextBox.Name = "subTotalDataTextBox";
            this.subTotalDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.78385418653488159D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.subTotalDataTextBox.StyleName = "Data";
            this.subTotalDataTextBox.Value = "=Fields.SubTotal";
            // 
            // totalDueCaptionTextBox
            // 
            this.totalDueCaptionTextBox.CanGrow = true;
            this.totalDueCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.2395832538604736D), Telerik.Reporting.Drawing.Unit.Inch(0.80823493003845215D));
            this.totalDueCaptionTextBox.Name = "totalDueCaptionTextBox";
            this.totalDueCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.78385418653488159D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.totalDueCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.totalDueCaptionTextBox.StyleName = "Caption";
            this.totalDueCaptionTextBox.Value = "Total Due:";
            // 
            // totalDueDataTextBox
            // 
            this.totalDueDataTextBox.CanGrow = true;
            this.totalDueDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.0442709922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.80823493003845215D));
            this.totalDueDataTextBox.Name = "totalDueDataTextBox";
            this.totalDueDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.78385418653488159D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.totalDueDataTextBox.StyleName = "Data";
            this.totalDueDataTextBox.Value = "=Fields.TotalDue";
            // 
            // vATCaptionTextBox
            // 
            this.vATCaptionTextBox.CanGrow = true;
            this.vATCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.8489584922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.80823493003845215D));
            this.vATCaptionTextBox.Name = "vATCaptionTextBox";
            this.vATCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.78385418653488159D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.vATCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.vATCaptionTextBox.StyleName = "Caption";
            this.vATCaptionTextBox.Value = "VAT:";
            // 
            // vATDataTextBox
            // 
            this.vATDataTextBox.CanGrow = true;
            this.vATDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.6536459922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.80823493003845215D));
            this.vATDataTextBox.Name = "vATDataTextBox";
            this.vATDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.78385418653488159D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.vATDataTextBox.StyleName = "Data";
            this.vATDataTextBox.Value = "=Fields.VAT";
            // 
            // reportFooter
            // 
            this.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.reportFooter.Name = "reportFooter";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(1.6250985860824585D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subReport1,
            this.textBox1});
            this.detail.Name = "detail";
            // 
            // subReport1
            // 
            this.subReport1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1000000610947609D), Telerik.Reporting.Drawing.Unit.Inch(0.22509860992431641D));
            this.subReport1.Name = "subReport1";
            instanceReportSource1.ReportDocument = null;
            this.subReport1.ReportSource = instanceReportSource1;
            this.subReport1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.2000007629394531D), Telerik.Reporting.Drawing.Unit.Inch(1.2000001668930054D));
            // 
            // textBox1
            // 
            this.textBox1.Bindings.Add(new Telerik.Reporting.Binding("Value", "=Fields.OrderDate"));
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D), Telerik.Reporting.Drawing.Unit.Inch(0.62509852647781372D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1999999284744263D), Telerik.Reporting.Drawing.Unit.Inch(0.3999999463558197D));
            this.textBox1.Value = "textBox1";
            // 
            // PurchaseOrderReportGen
            // 
            this.DataSource = this.dsPurchaseOrderHeaders;
            group1.GroupFooter = this.labelsGroupFooterSection;
            group1.GroupHeader = this.labelsGroupHeaderSection;
            group1.Name = "labelsGroup";
            group2.GroupFooter = this.labelsGroupFooterSection1;
            group2.GroupHeader = this.labelsGroupHeaderSection1;
            group2.Name = "labelsGroup1";
            group3.GroupFooter = this.labelsGroupFooterSection2;
            group3.GroupHeader = this.labelsGroupHeaderSection2;
            group3.Name = "labelsGroup2";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1,
            group2,
            group3});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.labelsGroupHeaderSection,
            this.labelsGroupFooterSection,
            this.labelsGroupHeaderSection1,
            this.labelsGroupFooterSection1,
            this.labelsGroupHeaderSection2,
            this.labelsGroupFooterSection2,
            this.pageHeader,
            this.pageFooter,
            this.reportHeader,
            this.reportFooter,
            this.detail});
            this.Name = "PurchaseOrderReportGen";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule1.Style.Color = System.Drawing.Color.Black;
            styleRule1.Style.Font.Bold = true;
            styleRule1.Style.Font.Italic = false;
            styleRule1.Style.Font.Name = "Tahoma";
            styleRule1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            styleRule1.Style.Font.Strikeout = false;
            styleRule1.Style.Font.Underline = false;
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule2.Style.Color = System.Drawing.Color.Black;
            styleRule2.Style.Font.Name = "Tahoma";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule3.Style.Font.Name = "Tahoma";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule4.Style.Font.Name = "Tahoma";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.4583334922790527D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.OpenAccessDataSource dsPurchaseOrderDetails;
        private Telerik.Reporting.ObjectDataSource objectDataSource1;
        private Telerik.Reporting.OpenAccessDataSource dsPurchaseOrderHeaders;
        private Telerik.Reporting.OpenAccessDataSource openAccessDataSource1;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection1;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection1;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection2;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection2;
        private Telerik.Reporting.PageHeaderSection pageHeader;
        private Telerik.Reporting.TextBox reportNameTextBox;
        private Telerik.Reporting.PageFooterSection pageFooter;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private Telerik.Reporting.ReportHeaderSection reportHeader;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.TextBox shipDateCaptionTextBox;
        private Telerik.Reporting.TextBox shipDateDataTextBox;
        private Telerik.Reporting.TextBox subTotalCaptionTextBox;
        private Telerik.Reporting.TextBox subTotalDataTextBox;
        private Telerik.Reporting.TextBox totalDueCaptionTextBox;
        private Telerik.Reporting.TextBox totalDueDataTextBox;
        private Telerik.Reporting.TextBox vATCaptionTextBox;
        private Telerik.Reporting.TextBox vATDataTextBox;
        private Telerik.Reporting.ReportFooterSection reportFooter;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.SubReport subReport1;
        private Telerik.Reporting.TextBox textBox1;
    }
}