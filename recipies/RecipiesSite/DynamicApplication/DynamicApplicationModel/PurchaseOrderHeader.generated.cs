#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using RecipiesModelNS;


namespace RecipiesModelNS	
{
	public partial class PurchaseOrderHeader
	{
		private int _purchaseOrderId;
		public virtual int PurchaseOrderId 
		{ 
		    get
		    {
		        return this._purchaseOrderId;
		    }
		    set
		    {
		        this._purchaseOrderId = value;
		    }
		}
		
		private int? _statusId;
		public virtual int? StatusId 
		{ 
		    get
		    {
		        return this._statusId;
		    }
		    set
		    {
		        this._statusId = value;
		    }
		}
		
		private int? _employeeId;
		public virtual int? EmployeeId 
		{ 
		    get
		    {
		        return this._employeeId;
		    }
		    set
		    {
		        this._employeeId = value;
		    }
		}
		
		private int? _vendorId;
		public virtual int? VendorId 
		{ 
		    get
		    {
		        return this._vendorId;
		    }
		    set
		    {
		        this._vendorId = value;
		    }
		}
		
		private int? _shipMethodId;
		public virtual int? ShipMethodId 
		{ 
		    get
		    {
		        return this._shipMethodId;
		    }
		    set
		    {
		        this._shipMethodId = value;
		    }
		}
		
		private DateTime? _orderDate;
		public virtual DateTime? OrderDate 
		{ 
		    get
		    {
		        return this._orderDate;
		    }
		    set
		    {
		        this._orderDate = value;
		    }
		}
		
		private DateTime? _shipDate;
		public virtual DateTime? ShipDate 
		{ 
		    get
		    {
		        return this._shipDate;
		    }
		    set
		    {
		        this._shipDate = value;
		    }
		}
		
		private decimal? _subTotal;
		public virtual decimal? SubTotal 
		{ 
		    get
		    {
		        return this._subTotal;
		    }
		    set
		    {
		        this._subTotal = value;
		    }
		}
		
		private decimal? _vAT;
		public virtual decimal? VAT 
		{ 
		    get
		    {
		        return this._vAT;
		    }
		    set
		    {
		        this._vAT = value;
		    }
		}
		
		private decimal? _freight;
		public virtual decimal? Freight 
		{ 
		    get
		    {
		        return this._freight;
		    }
		    set
		    {
		        this._freight = value;
		    }
		}
		
		private decimal? _totalDue;
		public virtual decimal? TotalDue 
		{ 
		    get
		    {
		        return this._totalDue;
		    }
		}
		
		private string _invoiceNumber;
		public virtual string InvoiceNumber 
		{ 
		    get
		    {
		        return this._invoiceNumber;
		    }
		    set
		    {
		        this._invoiceNumber = value;
		    }
		}
		
		private DateTime? _modifiedDate;
		public virtual DateTime? ModifiedDate 
		{ 
		    get
		    {
		        return this._modifiedDate;
		    }
		    set
		    {
		        this._modifiedDate = value;
		    }
		}
		
		private string _modifiedByUser;
		public virtual string ModifiedByUser 
		{ 
		    get
		    {
		        return this._modifiedByUser;
		    }
		    set
		    {
		        this._modifiedByUser = value;
		    }
		}
		
		private string _notes;
		public virtual string Notes 
		{ 
		    get
		    {
		        return this._notes;
		    }
		    set
		    {
		        this._notes = value;
		    }
		}
		
		private Vendor _vendor;
		public virtual Vendor Vendor 
		{ 
		    get
		    {
		        return this._vendor;
		    }
		    set
		    {
		        this._vendor = value;
		    }
		}
		
		private ShipMethod _shipMethod;
		public virtual ShipMethod ShipMethod 
		{ 
		    get
		    {
		        return this._shipMethod;
		    }
		    set
		    {
		        this._shipMethod = value;
		    }
		}
		
		private PurchaseOrderStatus _purchaseOrderStatus;
		public virtual PurchaseOrderStatus PurchaseOrderStatus 
		{ 
		    get
		    {
		        return this._purchaseOrderStatus;
		    }
		    set
		    {
		        this._purchaseOrderStatus = value;
		    }
		}
		
		private Employee _employee;
		public virtual Employee Employee 
		{ 
		    get
		    {
		        return this._employee;
		    }
		    set
		    {
		        this._employee = value;
		    }
		}
		
		private IList<PurchaseOrderDetail> _purchaseOrderDetails = new List<PurchaseOrderDetail>();
		public virtual IList<PurchaseOrderDetail> PurchaseOrderDetails 
		{ 
		    get
		    {
		        return this._purchaseOrderDetails;
		    }
		}
		
	}
}
