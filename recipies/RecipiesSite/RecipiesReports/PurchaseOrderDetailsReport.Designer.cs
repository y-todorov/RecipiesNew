namespace RecipiesReports
{
    partial class PurchaseOrderDetailsReport
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox24 = new Telerik.Reporting.TextBox();
            this.textBox25 = new Telerik.Reporting.TextBox();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.productIdCaptionTextBox = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.orderQuantityCaptionTextBox = new Telerik.Reporting.TextBox();
            this.unitPriceCaptionTextBox = new Telerik.Reporting.TextBox();
            this.lineTotalCaptionTextBox = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.dsSalesOrderDetails = new Telerik.Reporting.OpenAccessDataSource();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.htmlTextBox1 = new Telerik.Reporting.HtmlTextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.textBox19 = new Telerik.Reporting.TextBox();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.textBox21 = new Telerik.Reporting.TextBox();
            this.textBox22 = new Telerik.Reporting.TextBox();
            this.textBox23 = new Telerik.Reporting.TextBox();
            this.textBox26 = new Telerik.Reporting.TextBox();
            this.textBox27 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.productIdDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.orderQuantityDataTextBox = new Telerik.Reporting.TextBox();
            this.unitPriceDataTextBox = new Telerik.Reporting.TextBox();
            this.lineTotalDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.odsSalesOrderDetails = new Telerik.Reporting.ObjectDataSource();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.47996059060096741D);
            this.labelsGroupFooterSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox3,
            this.textBox4,
            this.textBox24,
            this.textBox25});
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.PrintOnEveryPage = true;
            this.labelsGroupFooterSection.Style.Visible = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0790872573852539D), Telerik.Reporting.Drawing.Unit.Inch(0.19367137551307678D));
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.StyleName = "Total";
            this.textBox3.Value = "Total";
            // 
            // textBox4
            // 
            this.textBox4.Format = "{0:C2}";
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.0999999046325684D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3374996185302734D), Telerik.Reporting.Drawing.Unit.Inch(0.19363196194171906D));
            this.textBox4.Style.Font.Bold = true;
            this.textBox4.Style.Font.Italic = false;
            this.textBox4.Style.Visible = true;
            this.textBox4.Value = "= Sum(Fields.OrderQuantity * Fields.UnitPrice)";
            // 
            // textBox24
            // 
            this.textBox24.CanGrow = true;
            this.textBox24.Format = "{0:d}";
            this.textBox24.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.7000001668930054D), Telerik.Reporting.Drawing.Unit.Inch(0.19375038146972656D));
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.737459659576416D), Telerik.Reporting.Drawing.Unit.Inch(0.27781406044960022D));
            this.textBox24.StyleName = "Data";
            this.textBox24.Value = "=Fields.PurchaseOrderHeader.Notes";
            // 
            // textBox25
            // 
            this.textBox25.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.19375038146972656D));
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6790879964828491D), Telerik.Reporting.Drawing.Unit.Inch(0.27781406044960022D));
            this.textBox25.Style.Font.Bold = true;
            this.textBox25.StyleName = "Data";
            this.textBox25.Value = "Notes:";
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.44166669249534607D);
            this.labelsGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.productIdCaptionTextBox,
            this.textBox1,
            this.orderQuantityCaptionTextBox,
            this.unitPriceCaptionTextBox,
            this.lineTotalCaptionTextBox,
            this.textBox5});
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            // 
            // productIdCaptionTextBox
            // 
            this.productIdCaptionTextBox.CanGrow = true;
            this.productIdCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.productIdCaptionTextBox.Name = "productIdCaptionTextBox";
            this.productIdCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3374996185302734D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.productIdCaptionTextBox.StyleName = "Caption";
            this.productIdCaptionTextBox.Value = "Product Code";
            // 
            // textBox1
            // 
            this.textBox1.CanGrow = true;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.3376177549362183D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3374996185302734D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox1.StyleName = "Caption";
            this.textBox1.Value = "Product Name";
            // 
            // orderQuantityCaptionTextBox
            // 
            this.orderQuantityCaptionTextBox.CanGrow = true;
            this.orderQuantityCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.4248433113098145D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.orderQuantityCaptionTextBox.Name = "orderQuantityCaptionTextBox";
            this.orderQuantityCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3374996185302734D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.orderQuantityCaptionTextBox.StyleName = "Caption";
            this.orderQuantityCaptionTextBox.Value = "Order Quantity";
            // 
            // unitPriceCaptionTextBox
            // 
            this.unitPriceCaptionTextBox.CanGrow = true;
            this.unitPriceCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.76242208480835D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.unitPriceCaptionTextBox.Name = "unitPriceCaptionTextBox";
            this.unitPriceCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3374996185302734D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.unitPriceCaptionTextBox.StyleName = "Caption";
            this.unitPriceCaptionTextBox.Value = "Unit Price";
            // 
            // lineTotalCaptionTextBox
            // 
            this.lineTotalCaptionTextBox.CanGrow = true;
            this.lineTotalCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.1000003814697266D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.lineTotalCaptionTextBox.Name = "lineTotalCaptionTextBox";
            this.lineTotalCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3374996185302734D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.lineTotalCaptionTextBox.StyleName = "Caption";
            this.lineTotalCaptionTextBox.Value = "Line Total";
            // 
            // textBox5
            // 
            this.textBox5.CanGrow = true;
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.6751964092254639D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.7495683431625366D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox5.StyleName = "Caption";
            this.textBox5.Value = "Unit";
            // 
            // dsSalesOrderDetails
            // 
            this.dsSalesOrderDetails.ConnectionString = "Connection";
            this.dsSalesOrderDetails.Name = "dsSalesOrderDetails";
            this.dsSalesOrderDetails.ObjectContext = "DynamicApplicationModel.RecipiesModel, DynamicApplicationModel, Version=1.0.0.0, " +
    "Culture=neutral, PublicKeyToken=null";
            this.dsSalesOrderDetails.ObjectContextMember = "PurchaseOrderDetails";
            // 
            // reportHeader
            // 
            this.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(1.4735430479049683D);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBox,
            this.textBox7,
            this.htmlTextBox1,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox14,
            this.textBox15,
            this.textBox16,
            this.textBox17,
            this.textBox18,
            this.textBox19,
            this.textBox20,
            this.textBox21,
            this.textBox22,
            this.textBox23,
            this.textBox26,
            this.textBox27});
            this.reportHeader.Name = "reportHeader";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4D), Telerik.Reporting.Drawing.Unit.Inch(3.9378803194267675E-05D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.200000524520874D), Telerik.Reporting.Drawing.Unit.Inch(0.2999606728553772D));
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "Order Details";
            // 
            // textBox7
            // 
            this.textBox7.CanGrow = true;
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.90007895231246948D), Telerik.Reporting.Drawing.Unit.Inch(3.9180118619697168E-05D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.69984227418899536D), Telerik.Reporting.Drawing.Unit.Inch(0.2999606728553772D));
            this.textBox7.StyleName = "Data";
            this.textBox7.Value = "=Fields.PurchaseOrderHeader.Employee.FirstName";
            // 
            // htmlTextBox1
            // 
            this.htmlTextBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0.30088433623313904D));
            this.htmlTextBox1.Name = "htmlTextBox1";
            this.htmlTextBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3D), Telerik.Reporting.Drawing.Unit.Inch(0.79825103282928467D));
            this.htmlTextBox1.Style.Color = System.Drawing.Color.Blue;
            this.htmlTextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(60D);
            this.htmlTextBox1.Value = "BlueBar";
            // 
            // textBox8
            // 
            this.textBox8.CanGrow = true;
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.6000000238418579D), Telerik.Reporting.Drawing.Unit.Inch(3.9180118619697168E-05D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.7000001072883606D), Telerik.Reporting.Drawing.Unit.Inch(0.2999606728553772D));
            this.textBox8.StyleName = "Data";
            this.textBox8.Value = "=Fields.PurchaseOrderHeader.Employee.LastName";
            // 
            // textBox9
            // 
            this.textBox9.CanGrow = true;
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(3.9339065551757812E-05D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.87916678190231323D), Telerik.Reporting.Drawing.Unit.Inch(0.2999606728553772D));
            this.textBox9.Style.Font.Bold = true;
            this.textBox9.StyleName = "Data";
            this.textBox9.Value = "Employee:";
            // 
            // textBox10
            // 
            this.textBox10.CanGrow = true;
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.300079345703125D), Telerik.Reporting.Drawing.Unit.Inch(0.2139427661895752D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0040500164031982D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox10.Style.Font.Bold = true;
            this.textBox10.StyleName = "Data";
            this.textBox10.Value = "BlueBar Address:";
            // 
            // textBox11
            // 
            this.textBox11.CanGrow = true;
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.3376178741455078D), Telerik.Reporting.Drawing.Unit.Inch(3.9339065551757812E-05D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0998809337615967D), Telerik.Reporting.Drawing.Unit.Inch(0.84689450263977051D));
            this.textBox11.Style.Font.Bold = false;
            this.textBox11.StyleName = "Data";
            this.textBox11.Value = "Skerries Inns Holdings Ltd. Harbour Rd, Skerries, Co. Dublin";
            // 
            // textBox12
            // 
            this.textBox12.CanGrow = true;
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.300079345703125D), Telerik.Reporting.Drawing.Unit.Inch(0.84701263904571533D));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0040500164031982D), Telerik.Reporting.Drawing.Unit.Inch(0.25298744440078735D));
            this.textBox12.Style.Font.Bold = true;
            this.textBox12.StyleName = "Data";
            this.textBox12.Value = "Tel:";
            // 
            // textBox13
            // 
            this.textBox13.CanGrow = true;
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.3376193046569824D), Telerik.Reporting.Drawing.Unit.Inch(0.84701269865036011D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0998811721801758D), Telerik.Reporting.Drawing.Unit.Inch(0.25212273001670837D));
            this.textBox13.Style.Font.Bold = false;
            this.textBox13.StyleName = "Data";
            this.textBox13.Value = "01-8490900";
            // 
            // textBox14
            // 
            this.textBox14.CanGrow = true;
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.300079345703125D), Telerik.Reporting.Drawing.Unit.Inch(1.1000789403915405D));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0040500164031982D), Telerik.Reporting.Drawing.Unit.Inch(0.20216217637062073D));
            this.textBox14.Style.Font.Bold = true;
            this.textBox14.StyleName = "Data";
            this.textBox14.Value = "Email:";
            // 
            // textBox15
            // 
            this.textBox15.CanGrow = true;
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.33761739730835D), Telerik.Reporting.Drawing.Unit.Inch(1.0992141962051392D));
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0998811721801758D), Telerik.Reporting.Drawing.Unit.Inch(0.20216228067874908D));
            this.textBox15.Style.Font.Bold = false;
            this.textBox15.StyleName = "Data";
            this.textBox15.Value = "info@bluebar.ie";
            // 
            // textBox16
            // 
            this.textBox16.CanGrow = true;
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.74981689453125D));
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.87916678190231323D), Telerik.Reporting.Drawing.Unit.Inch(0.27781406044960022D));
            this.textBox16.Style.Font.Bold = true;
            this.textBox16.StyleName = "Data";
            this.textBox16.Value = "OrderDate:";
            // 
            // textBox17
            // 
            this.textBox17.CanGrow = true;
            this.textBox17.Format = "{0:d}";
            this.textBox17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.90007895231246948D), Telerik.Reporting.Drawing.Unit.Inch(0.74993515014648438D));
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3999210596084595D), Telerik.Reporting.Drawing.Unit.Inch(0.27781406044960022D));
            this.textBox17.StyleName = "Data";
            this.textBox17.Value = "=Fields.PurchaseOrderHeader.OrderDate";
            // 
            // textBox18
            // 
            this.textBox18.CanGrow = true;
            this.textBox18.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.30088433623313904D));
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.87916678190231323D), Telerik.Reporting.Drawing.Unit.Inch(0.22450557351112366D));
            this.textBox18.Style.Font.Bold = true;
            this.textBox18.StyleName = "Data";
            this.textBox18.Value = "Mobile phone:";
            // 
            // textBox19
            // 
            this.textBox19.CanGrow = true;
            this.textBox19.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.52535057067871094D));
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.87916678190231323D), Telerik.Reporting.Drawing.Unit.Inch(0.22450557351112366D));
            this.textBox19.Style.Font.Bold = true;
            this.textBox19.StyleName = "Data";
            this.textBox19.Value = "Email:";
            // 
            // textBox20
            // 
            this.textBox20.CanGrow = true;
            this.textBox20.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.90007895231246948D), Telerik.Reporting.Drawing.Unit.Inch(0.30076631903648376D));
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.399921178817749D), Telerik.Reporting.Drawing.Unit.Inch(0.22462359070777893D));
            this.textBox20.StyleName = "Data";
            this.textBox20.Value = "=Fields.PurchaseOrderHeader.Employee.MobilePhone";
            // 
            // textBox21
            // 
            this.textBox21.CanGrow = true;
            this.textBox21.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.900079071521759D), Telerik.Reporting.Drawing.Unit.Inch(0.52535057067871094D));
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.399921178817749D), Telerik.Reporting.Drawing.Unit.Inch(0.22462359070777893D));
            this.textBox21.StyleName = "Data";
            this.textBox21.Value = "=Fields.PurchaseOrderHeader.Employee.Email";
            // 
            // textBox22
            // 
            this.textBox22.CanGrow = true;
            this.textBox22.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(1.0277098417282105D));
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1999999284744263D), Telerik.Reporting.Drawing.Unit.Inch(0.22287724912166596D));
            this.textBox22.Style.Font.Bold = true;
            this.textBox22.StyleName = "Data";
            this.textBox22.Value = "Account Number:";
            // 
            // textBox23
            // 
            this.textBox23.CanGrow = true;
            this.textBox23.Format = "{0:d}";
            this.textBox23.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2209123373031616D), Telerik.Reporting.Drawing.Unit.Inch(1.0277098417282105D));
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.7999210357666016D), Telerik.Reporting.Drawing.Unit.Inch(0.22287717461585999D));
            this.textBox23.StyleName = "Data";
            this.textBox23.Value = "=Fields.PurchaseOrderHeader.Vendor.ReportAccountNumber";
            // 
            // textBox26
            // 
            this.textBox26.CanGrow = true;
            this.textBox26.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(1.2506657838821411D));
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1999999284744263D), Telerik.Reporting.Drawing.Unit.Inch(0.22287724912166596D));
            this.textBox26.Style.Font.Bold = true;
            this.textBox26.StyleName = "Data";
            this.textBox26.Value = "Vendor Name:";
            // 
            // textBox27
            // 
            this.textBox27.CanGrow = true;
            this.textBox27.Format = "{0:d}";
            this.textBox27.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2209123373031616D), Telerik.Reporting.Drawing.Unit.Inch(1.2506657838821411D));
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.7999210357666016D), Telerik.Reporting.Drawing.Unit.Inch(0.22287717461585999D));
            this.textBox27.StyleName = "Data";
            this.textBox27.Value = "=Fields.PurchaseOrderHeader.Vendor.Name";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.44166669249534607D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.productIdDataTextBox,
            this.textBox2,
            this.orderQuantityDataTextBox,
            this.unitPriceDataTextBox,
            this.lineTotalDataTextBox,
            this.textBox6});
            this.detail.Name = "detail";
            // 
            // productIdDataTextBox
            // 
            this.productIdDataTextBox.CanGrow = true;
            this.productIdDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.productIdDataTextBox.Name = "productIdDataTextBox";
            this.productIdDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3374996185302734D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.productIdDataTextBox.StyleName = "Data";
            this.productIdDataTextBox.Value = "=Fields.Product.Code";
            // 
            // textBox2
            // 
            this.textBox2.CanGrow = true;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.3584117889404297D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3374996185302734D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox2.StyleName = "Data";
            this.textBox2.Value = "=Fields.Product.Name";
            // 
            // orderQuantityDataTextBox
            // 
            this.orderQuantityDataTextBox.CanGrow = true;
            this.orderQuantityDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.4248433113098145D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.orderQuantityDataTextBox.Name = "orderQuantityDataTextBox";
            this.orderQuantityDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3374996185302734D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.orderQuantityDataTextBox.StyleName = "Data";
            this.orderQuantityDataTextBox.Value = "=Fields.OrderQuantity";
            // 
            // unitPriceDataTextBox
            // 
            this.unitPriceDataTextBox.CanGrow = true;
            this.unitPriceDataTextBox.Format = "{0:C2}";
            this.unitPriceDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.76242208480835D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.unitPriceDataTextBox.Name = "unitPriceDataTextBox";
            this.unitPriceDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3374996185302734D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.unitPriceDataTextBox.StyleName = "Data";
            this.unitPriceDataTextBox.Value = "=Fields.UnitPrice";
            // 
            // lineTotalDataTextBox
            // 
            this.lineTotalDataTextBox.CanGrow = true;
            this.lineTotalDataTextBox.Format = "{0:C2}";
            this.lineTotalDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.1000003814697266D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.lineTotalDataTextBox.Name = "lineTotalDataTextBox";
            this.lineTotalDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3374996185302734D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.lineTotalDataTextBox.StyleName = "Data";
            this.lineTotalDataTextBox.Value = "=Fields.OrderQuantity * Fields.UnitPrice";
            // 
            // textBox6
            // 
            this.textBox6.CanGrow = true;
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.6959903240203857D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.7287744283676148D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox6.StyleName = "Data";
            this.textBox6.Value = "=Fields.UnitMeasure.Name";
            // 
            // odsSalesOrderDetails
            // 
            this.odsSalesOrderDetails.DataMember = "PurchaseOrderDetails";
            this.odsSalesOrderDetails.DataSource = "DynamicApplicationModel.RecipiesModel, DynamicApplicationModel, Version=1.0.0.0, " +
    "Culture=neutral, PublicKeyToken=null";
            this.odsSalesOrderDetails.Name = "odsSalesOrderDetails";
            // 
            // PurchaseOrderDetailsReport
            // 
            this.DataSource = this.dsSalesOrderDetails;
            group1.GroupFooter = this.labelsGroupFooterSection;
            group1.GroupHeader = this.labelsGroupHeaderSection;
            group1.Name = "labelsGroup";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.labelsGroupHeaderSection,
            this.labelsGroupFooterSection,
            this.reportHeader,
            this.detail});
            this.Name = "SalesOrderDetails";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(103)))), ((int)(((byte)(109)))));
            styleRule1.Style.Font.Name = "Book Antiqua";
            styleRule1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(103)))), ((int)(((byte)(109)))));
            styleRule2.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(185)))), ((int)(((byte)(102)))));
            styleRule2.Style.Font.Name = "Book Antiqua";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule3.Style.Font.Name = "Book Antiqua";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule4.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            styleRule4.Style.Font.Name = "Book Antiqua";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(8.4375D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.OpenAccessDataSource dsSalesOrderDetails;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.TextBox productIdCaptionTextBox;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox orderQuantityCaptionTextBox;
        private Telerik.Reporting.TextBox unitPriceCaptionTextBox;
        private Telerik.Reporting.TextBox lineTotalCaptionTextBox;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection;
        private Telerik.Reporting.ReportHeaderSection reportHeader;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox productIdDataTextBox;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox orderQuantityDataTextBox;
        private Telerik.Reporting.TextBox unitPriceDataTextBox;
        private Telerik.Reporting.TextBox lineTotalDataTextBox;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.ObjectDataSource odsSalesOrderDetails;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.HtmlTextBox htmlTextBox1;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.TextBox textBox19;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.TextBox textBox21;
        private Telerik.Reporting.TextBox textBox22;
        private Telerik.Reporting.TextBox textBox23;
        private Telerik.Reporting.TextBox textBox24;
        private Telerik.Reporting.TextBox textBox25;
        private Telerik.Reporting.TextBox textBox26;
        private Telerik.Reporting.TextBox textBox27;

    }
}