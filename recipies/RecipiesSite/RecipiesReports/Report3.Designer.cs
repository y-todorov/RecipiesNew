namespace RecipiesReports
{
    partial class Report3
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group2 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group3 = new Telerik.Reporting.Group();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.openAccessDataSource1 = new Telerik.Reporting.OpenAccessDataSource();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.openAccessDataSource2 = new Telerik.Reporting.OpenAccessDataSource();
            this.productNameGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.productNameGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.labelsGroupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            this.labelsGroupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.stockedQuantityCaptionTextBox = new Telerik.Reporting.TextBox();
            this.returnedQuantityCaptionTextBox = new Telerik.Reporting.TextBox();
            this.receivedQuantityCaptionTextBox = new Telerik.Reporting.TextBox();
            this.pageHeader = new Telerik.Reporting.PageHeaderSection();
            this.reportNameTextBox = new Telerik.Reporting.TextBox();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.stockedQuantityDataTextBox = new Telerik.Reporting.TextBox();
            this.returnedQuantityDataTextBox = new Telerik.Reporting.TextBox();
            this.receivedQuantityDataTextBox = new Telerik.Reporting.TextBox();
            this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // openAccessDataSource1
            // 
            this.openAccessDataSource1.ConnectionString = "Connection";
            this.openAccessDataSource1.Name = "openAccessDataSource1";
            this.openAccessDataSource1.ObjectContext = "DynamicApplicationModel.RecipiesModel, DynamicApplicationModel, Version=1.0.0.0, " +
    "Culture=neutral, PublicKeyToken=null";
            this.openAccessDataSource1.ObjectContextMember = "PurchaseOrderHeaders";
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
            // openAccessDataSource2
            // 
            this.openAccessDataSource2.ConnectionString = "Connection";
            this.openAccessDataSource2.Name = "openAccessDataSource2";
            this.openAccessDataSource2.ObjectContext = "DynamicApplicationModel.RecipiesModel, DynamicApplicationModel, Version=1.0.0.0, " +
    "Culture=neutral, PublicKeyToken=null";
            this.openAccessDataSource2.ObjectContextMember = "PurchaseOrderDetails";
            // 
            // productNameGroupHeaderSection
            // 
            this.productNameGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.44166669249534607D);
            this.productNameGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.textBox2});
            this.productNameGroupHeaderSection.Name = "productNameGroupHeaderSection";
            // 
            // productNameGroupFooterSection
            // 
            this.productNameGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.productNameGroupFooterSection.Name = "productNameGroupFooterSection";
            // 
            // textBox1
            // 
            this.textBox1.CanGrow = true;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox1.StyleName = "Caption";
            this.textBox1.Value = "Product Name:";
            // 
            // textBox2
            // 
            this.textBox2.CanGrow = true;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2416666746139526D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.1750001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox2.StyleName = "Data";
            this.textBox2.Value = "=Fields.Product.Name";
            // 
            // labelsGroupHeaderSection1
            // 
            this.labelsGroupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.44166669249534607D);
            this.labelsGroupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.stockedQuantityCaptionTextBox,
            this.returnedQuantityCaptionTextBox,
            this.receivedQuantityCaptionTextBox});
            this.labelsGroupHeaderSection1.Name = "labelsGroupHeaderSection1";
            this.labelsGroupHeaderSection1.PrintOnEveryPage = true;
            // 
            // labelsGroupFooterSection1
            // 
            this.labelsGroupFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.labelsGroupFooterSection1.Name = "labelsGroupFooterSection1";
            this.labelsGroupFooterSection1.Style.Visible = false;
            // 
            // stockedQuantityCaptionTextBox
            // 
            this.stockedQuantityCaptionTextBox.CanGrow = true;
            this.stockedQuantityCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.stockedQuantityCaptionTextBox.Name = "stockedQuantityCaptionTextBox";
            this.stockedQuantityCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.125D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.stockedQuantityCaptionTextBox.StyleName = "Caption";
            this.stockedQuantityCaptionTextBox.Value = "Stocked Quantity";
            // 
            // returnedQuantityCaptionTextBox
            // 
            this.returnedQuantityCaptionTextBox.CanGrow = true;
            this.returnedQuantityCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.1666667461395264D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.returnedQuantityCaptionTextBox.Name = "returnedQuantityCaptionTextBox";
            this.returnedQuantityCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.125D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.returnedQuantityCaptionTextBox.StyleName = "Caption";
            this.returnedQuantityCaptionTextBox.Value = "Returned Quantity";
            // 
            // receivedQuantityCaptionTextBox
            // 
            this.receivedQuantityCaptionTextBox.CanGrow = true;
            this.receivedQuantityCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.3125D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.receivedQuantityCaptionTextBox.Name = "receivedQuantityCaptionTextBox";
            this.receivedQuantityCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.125D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.receivedQuantityCaptionTextBox.StyleName = "Caption";
            this.receivedQuantityCaptionTextBox.Value = "Received Quantity";
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
            this.reportNameTextBox.Value = "Report3";
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
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox12});
            this.reportHeader.Name = "reportHeader";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4583334922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.787401556968689D));
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "Report3";
            // 
            // textBox3
            // 
            this.textBox3.CanGrow = true;
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.80823493003845215D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.62291663885116577D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox3.StyleName = "Caption";
            this.textBox3.Value = "Purchase Order Header Sub Total:";
            // 
            // textBox4
            // 
            this.textBox4.CanGrow = true;
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.66458332538604736D), Telerik.Reporting.Drawing.Unit.Inch(0.80823493003845215D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.62291663885116577D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox4.StyleName = "Data";
            this.textBox4.Value = "=Fields.PurchaseOrderHeader.SubTotal";
            // 
            // textBox5
            // 
            this.textBox5.CanGrow = true;
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.3083332777023315D), Telerik.Reporting.Drawing.Unit.Inch(0.80823493003845215D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.62291663885116577D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox5.StyleName = "Caption";
            this.textBox5.Value = "Purchase Order Header Freight:";
            // 
            // textBox6
            // 
            this.textBox6.CanGrow = true;
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.9520833492279053D), Telerik.Reporting.Drawing.Unit.Inch(0.80823493003845215D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.62291663885116577D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox6.StyleName = "Data";
            this.textBox6.Value = "=Fields.PurchaseOrderHeader.Freight";
            // 
            // textBox7
            // 
            this.textBox7.CanGrow = true;
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.5958333015441895D), Telerik.Reporting.Drawing.Unit.Inch(0.80823493003845215D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.62291663885116577D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox7.StyleName = "Caption";
            this.textBox7.Value = "Purchase Order Header Total Due:";
            // 
            // textBox8
            // 
            this.textBox8.CanGrow = true;
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.2395832538604736D), Telerik.Reporting.Drawing.Unit.Inch(0.80823493003845215D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.62291663885116577D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox8.StyleName = "Data";
            this.textBox8.Value = "=Fields.PurchaseOrderHeader.TotalDue";
            // 
            // textBox9
            // 
            this.textBox9.CanGrow = true;
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.8833334445953369D), Telerik.Reporting.Drawing.Unit.Inch(0.80823493003845215D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.62291663885116577D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox9.StyleName = "Caption";
            this.textBox9.Value = "Purchase Order Header Employee First Name:";
            // 
            // textBox10
            // 
            this.textBox10.CanGrow = true;
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.5270833969116211D), Telerik.Reporting.Drawing.Unit.Inch(0.80823493003845215D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.62291663885116577D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox10.StyleName = "Data";
            this.textBox10.Value = "=Fields.PurchaseOrderHeader.Employee.FirstName";
            // 
            // textBox11
            // 
            this.textBox11.CanGrow = true;
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1708331108093262D), Telerik.Reporting.Drawing.Unit.Inch(0.80823493003845215D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.62291663885116577D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox11.StyleName = "Caption";
            this.textBox11.Value = "Purchase Order Header Employee Last Name:";
            // 
            // textBox12
            // 
            this.textBox12.CanGrow = true;
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.8145833015441895D), Telerik.Reporting.Drawing.Unit.Inch(0.80823493003845215D));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.62291663885116577D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox12.StyleName = "Data";
            this.textBox12.Value = "=Fields.PurchaseOrderHeader.Employee.LastName";
            // 
            // reportFooter
            // 
            this.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.reportFooter.Name = "reportFooter";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.44166669249534607D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.stockedQuantityDataTextBox,
            this.returnedQuantityDataTextBox,
            this.receivedQuantityDataTextBox});
            this.detail.Name = "detail";
            // 
            // stockedQuantityDataTextBox
            // 
            this.stockedQuantityDataTextBox.CanGrow = true;
            this.stockedQuantityDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.stockedQuantityDataTextBox.Name = "stockedQuantityDataTextBox";
            this.stockedQuantityDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.125D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.stockedQuantityDataTextBox.StyleName = "Data";
            this.stockedQuantityDataTextBox.Value = "=Fields.StockedQuantity";
            // 
            // returnedQuantityDataTextBox
            // 
            this.returnedQuantityDataTextBox.CanGrow = true;
            this.returnedQuantityDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.1666667461395264D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.returnedQuantityDataTextBox.Name = "returnedQuantityDataTextBox";
            this.returnedQuantityDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.125D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.returnedQuantityDataTextBox.StyleName = "Data";
            this.returnedQuantityDataTextBox.Value = "=Fields.ReturnedQuantity";
            // 
            // receivedQuantityDataTextBox
            // 
            this.receivedQuantityDataTextBox.CanGrow = true;
            this.receivedQuantityDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.3125D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.receivedQuantityDataTextBox.Name = "receivedQuantityDataTextBox";
            this.receivedQuantityDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.125D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.receivedQuantityDataTextBox.StyleName = "Data";
            this.receivedQuantityDataTextBox.Value = "=Fields.ReceivedQuantity";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataMember = "PurchaseOrderDetails";
            this.objectDataSource1.DataSource = "DynamicApplicationModel.RecipiesModel, DynamicApplicationModel, Version=1.0.0.0, " +
    "Culture=neutral, PublicKeyToken=null";
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // Report3
            // 
            this.DataSource = this.openAccessDataSource2;
            group1.GroupFooter = this.labelsGroupFooterSection;
            group1.GroupHeader = this.labelsGroupHeaderSection;
            group1.Name = "labelsGroup";
            group2.GroupFooter = this.productNameGroupFooterSection;
            group2.GroupHeader = this.productNameGroupHeaderSection;
            group2.Groupings.Add(new Telerik.Reporting.Grouping("=Fields.Product.Name"));
            group2.Name = "productNameGroup";
            group3.GroupFooter = this.labelsGroupFooterSection1;
            group3.GroupHeader = this.labelsGroupHeaderSection1;
            group3.Name = "labelsGroup1";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1,
            group2,
            group3});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.labelsGroupHeaderSection,
            this.labelsGroupFooterSection,
            this.productNameGroupHeaderSection,
            this.productNameGroupFooterSection,
            this.labelsGroupHeaderSection1,
            this.labelsGroupFooterSection1,
            this.pageHeader,
            this.pageFooter,
            this.reportHeader,
            this.reportFooter,
            this.detail});
            this.Name = "Report3";
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

        private Telerik.Reporting.OpenAccessDataSource openAccessDataSource1;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection;
        private Telerik.Reporting.OpenAccessDataSource openAccessDataSource2;
        private Telerik.Reporting.GroupHeaderSection productNameGroupHeaderSection;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.GroupFooterSection productNameGroupFooterSection;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection1;
        private Telerik.Reporting.TextBox stockedQuantityCaptionTextBox;
        private Telerik.Reporting.TextBox returnedQuantityCaptionTextBox;
        private Telerik.Reporting.TextBox receivedQuantityCaptionTextBox;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection1;
        private Telerik.Reporting.PageHeaderSection pageHeader;
        private Telerik.Reporting.TextBox reportNameTextBox;
        private Telerik.Reporting.PageFooterSection pageFooter;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private Telerik.Reporting.ReportHeaderSection reportHeader;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.ReportFooterSection reportFooter;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox stockedQuantityDataTextBox;
        private Telerik.Reporting.TextBox returnedQuantityDataTextBox;
        private Telerik.Reporting.TextBox receivedQuantityDataTextBox;
        private Telerik.Reporting.ObjectDataSource objectDataSource1;

    }
}