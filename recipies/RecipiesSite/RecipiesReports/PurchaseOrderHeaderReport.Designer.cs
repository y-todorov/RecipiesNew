namespace RecipiesReports
{
    partial class PurchaseOrderHeaderReport
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseOrderHeaderReport));
            Telerik.Reporting.InstanceReportSource instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.orderDateCaptionTextBox = new Telerik.Reporting.TextBox();
            this.orderDateDataTextBox = new Telerik.Reporting.TextBox();
            this.shipDateCaptionTextBox = new Telerik.Reporting.TextBox();
            this.shipDateDataTextBox = new Telerik.Reporting.TextBox();
            this.shipMethodCaptionTextBox = new Telerik.Reporting.TextBox();
            this.vATCaptionTextBox = new Telerik.Reporting.TextBox();
            this.vATDataTextBox = new Telerik.Reporting.TextBox();
            this.vendorCaptionTextBox = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.openAccessDataSourcePurchaseOrderHeader = new Telerik.Reporting.OpenAccessDataSource();
            this.detail = new Telerik.Reporting.DetailSection();
            this.subReport1 = new Telerik.Reporting.SubReport();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.barcode1 = new Telerik.Reporting.Barcode();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.Style.Visible = false;
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(1.6000001430511475D);
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.5751404762268066D), Telerik.Reporting.Drawing.Unit.Inch(0.850019633769989D));
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "PurchaseOrder";
            // 
            // textBox2
            // 
            this.textBox2.CanGrow = true;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.800000011920929D), Telerik.Reporting.Drawing.Unit.Inch(0.85013788938522339D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52470237016677856D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox2.StyleName = "Data";
            this.textBox2.Value = "=Fields.Employee.FirstName";
            // 
            // textBox4
            // 
            this.textBox4.CanGrow = true;
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.9247815608978271D), Telerik.Reporting.Drawing.Unit.Inch(1.1542540788650513D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.87521868944168091D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox4.StyleName = "Data";
            this.textBox4.Value = "=Fields.Employee.LastName";
            // 
            // textBox3
            // 
            this.textBox3.CanGrow = true;
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.4000003337860107D), Telerik.Reporting.Drawing.Unit.Inch(1.1501377820968628D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52470237016677856D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox3.StyleName = "Caption";
            this.textBox3.Value = "Employee Last Name:";
            // 
            // orderDateCaptionTextBox
            // 
            this.orderDateCaptionTextBox.CanGrow = true;
            this.orderDateCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.14315478503704071D), Telerik.Reporting.Drawing.Unit.Inch(1.3500984907150269D));
            this.orderDateCaptionTextBox.Name = "orderDateCaptionTextBox";
            this.orderDateCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52470237016677856D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.orderDateCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.orderDateCaptionTextBox.StyleName = "Caption";
            this.orderDateCaptionTextBox.Value = "Order Date:";
            // 
            // orderDateDataTextBox
            // 
            this.orderDateDataTextBox.CanGrow = true;
            this.orderDateDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.688690185546875D), Telerik.Reporting.Drawing.Unit.Inch(1.3500984907150269D));
            this.orderDateDataTextBox.Name = "orderDateDataTextBox";
            this.orderDateDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52470237016677856D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.orderDateDataTextBox.StyleName = "Data";
            this.orderDateDataTextBox.Value = "=Fields.OrderDate";
            // 
            // shipDateCaptionTextBox
            // 
            this.shipDateCaptionTextBox.CanGrow = true;
            this.shipDateCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.3257346153259277D), Telerik.Reporting.Drawing.Unit.Inch(1.2502166032791138D));
            this.shipDateCaptionTextBox.Name = "shipDateCaptionTextBox";
            this.shipDateCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52470237016677856D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.shipDateCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.shipDateCaptionTextBox.StyleName = "Caption";
            this.shipDateCaptionTextBox.Value = "Ship Date:";
            // 
            // shipDateDataTextBox
            // 
            this.shipDateDataTextBox.CanGrow = true;
            this.shipDateDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.8505158424377441D), Telerik.Reporting.Drawing.Unit.Inch(1.2502166032791138D));
            this.shipDateDataTextBox.Name = "shipDateDataTextBox";
            this.shipDateDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52470237016677856D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.shipDateDataTextBox.StyleName = "Data";
            this.shipDateDataTextBox.Value = "=Fields.ShipDate";
            // 
            // shipMethodCaptionTextBox
            // 
            this.shipMethodCaptionTextBox.CanGrow = true;
            this.shipMethodCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.3257346153259277D), Telerik.Reporting.Drawing.Unit.Inch(0.85013788938522339D));
            this.shipMethodCaptionTextBox.Name = "shipMethodCaptionTextBox";
            this.shipMethodCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52470237016677856D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.shipMethodCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.shipMethodCaptionTextBox.StyleName = "Caption";
            this.shipMethodCaptionTextBox.Value = "Ship Method:";
            // 
            // vATCaptionTextBox
            // 
            this.vATCaptionTextBox.CanGrow = true;
            this.vATCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.5000786781311035D), Telerik.Reporting.Drawing.Unit.Inch(1.0290685892105103D));
            this.vATCaptionTextBox.Name = "vATCaptionTextBox";
            this.vATCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52470237016677856D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.vATCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.vATCaptionTextBox.StyleName = "Caption";
            this.vATCaptionTextBox.Value = "VAT:";
            // 
            // vATDataTextBox
            // 
            this.vATDataTextBox.CanGrow = true;
            this.vATDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.0752196311950684D), Telerik.Reporting.Drawing.Unit.Inch(1.0290685892105103D));
            this.vATDataTextBox.Name = "vATDataTextBox";
            this.vATDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52470237016677856D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.vATDataTextBox.StyleName = "Data";
            this.vATDataTextBox.Value = "=Fields.VAT";
            // 
            // vendorCaptionTextBox
            // 
            this.vendorCaptionTextBox.CanGrow = true;
            this.vendorCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.6000003814697266D), Telerik.Reporting.Drawing.Unit.Inch(1.0290685892105103D));
            this.vendorCaptionTextBox.Name = "vendorCaptionTextBox";
            this.vendorCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52470237016677856D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.vendorCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.vendorCaptionTextBox.StyleName = "Caption";
            this.vendorCaptionTextBox.Value = "Vendor:";
            // 
            // textBox1
            // 
            this.textBox1.CanGrow = true;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.27521887421607971D), Telerik.Reporting.Drawing.Unit.Inch(0.85013788938522339D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52470237016677856D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox1.StyleName = "Caption";
            this.textBox1.Value = "Employee First Name:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2D), Telerik.Reporting.Drawing.Unit.Inch(0.041942119598388672D));
            this.pictureBox1.MimeType = "image/png";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.5D), Telerik.Reporting.Drawing.Unit.Inch(0.80811691284179688D));
            this.pictureBox1.Value = ((object)(resources.GetObject("pictureBox1.Value")));
            // 
            // openAccessDataSourcePurchaseOrderHeader
            // 
            this.openAccessDataSourcePurchaseOrderHeader.ConnectionString = "Connection";
            this.openAccessDataSourcePurchaseOrderHeader.Name = "openAccessDataSourcePurchaseOrderHeader";
            this.openAccessDataSourcePurchaseOrderHeader.ObjectContext = "RecipiesModelNS.RecipiesModel, DynamicApplicationModel, Version=1.0.0.0, Culture=" +
    "neutral, PublicKeyToken=null";
            this.openAccessDataSourcePurchaseOrderHeader.ObjectContextMember = "PurchaseOrderHeaders";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(2.5290687084198D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subReport1,
            this.titleTextBox,
            this.textBox2,
            this.textBox4,
            this.textBox3,
            this.orderDateCaptionTextBox,
            this.orderDateDataTextBox,
            this.shipDateCaptionTextBox,
            this.shipDateDataTextBox,
            this.shipMethodCaptionTextBox,
            this.vATCaptionTextBox,
            this.vATDataTextBox,
            this.vendorCaptionTextBox,
            this.textBox1,
            this.pictureBox1,
            this.textBox5,
            this.textBox6,
            this.barcode1});
            this.detail.Name = "detail";
            // 
            // subReport1
            // 
            this.subReport1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(2.3000004291534424D));
            this.subReport1.Name = "subReport1";
            instanceReportSource1.ReportDocument = null;
            this.subReport1.ReportSource = instanceReportSource1;
            this.subReport1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.5751008987426758D), Telerik.Reporting.Drawing.Unit.Inch(0.22902868688106537D));
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.8505158424377441D), Telerik.Reporting.Drawing.Unit.Inch(0.85013788938522339D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52470272779464722D), Telerik.Reporting.Drawing.Unit.Inch(0.3999999463558197D));
            this.textBox5.Value = "=Fields.ShipMethod.Name";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.6000003814697266D), Telerik.Reporting.Drawing.Unit.Inch(1.4291473627090454D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52470207214355469D), Telerik.Reporting.Drawing.Unit.Inch(0.40000009536743164D));
            this.textBox6.Value = "=Fields.Vendor.Name";
            // 
            // barcode1
            // 
            this.barcode1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.6000003814697266D), Telerik.Reporting.Drawing.Unit.Inch(0.041942279785871506D));
            this.barcode1.Name = "barcode1";
            this.barcode1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.675140380859375D), Telerik.Reporting.Drawing.Unit.Inch(0.72906851768493652D));
            this.barcode1.Value = "= Fields.PurchaseOrderId";
            // 
            // PurchaseOrderHeaderReport
            // 
            this.DataSource = this.openAccessDataSourcePurchaseOrderHeader;
            group1.GroupFooter = this.labelsGroupFooterSection;
            group1.GroupHeader = this.labelsGroupHeaderSection;
            group1.Name = "labelsGroup";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.labelsGroupHeaderSection,
            this.labelsGroupFooterSection,
            this.detail});
            this.Name = "PurchaseOrderHeaderReport";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
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
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(7.5751404762268066D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.OpenAccessDataSource openAccessDataSourcePurchaseOrderHeader;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.SubReport subReport1;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox orderDateCaptionTextBox;
        private Telerik.Reporting.TextBox orderDateDataTextBox;
        private Telerik.Reporting.TextBox shipDateCaptionTextBox;
        private Telerik.Reporting.TextBox shipDateDataTextBox;
        private Telerik.Reporting.TextBox shipMethodCaptionTextBox;
        private Telerik.Reporting.TextBox vATCaptionTextBox;
        private Telerik.Reporting.TextBox vATDataTextBox;
        private Telerik.Reporting.TextBox vendorCaptionTextBox;
        private Telerik.Reporting.PictureBox pictureBox1;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.Barcode barcode1;

    }
}