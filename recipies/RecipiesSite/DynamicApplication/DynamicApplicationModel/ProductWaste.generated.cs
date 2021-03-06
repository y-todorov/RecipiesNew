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
	public partial class ProductWaste
	{
		private int _productWasteId;
		public virtual int ProductWasteId 
		{ 
		    get
		    {
		        return this._productWasteId;
		    }
		    set
		    {
		        this._productWasteId = value;
		    }
		}
		
		private int? _productId;
		public virtual int? ProductId 
		{ 
		    get
		    {
		        return this._productId;
		    }
		    set
		    {
		        this._productId = value;
		    }
		}
		
		private int? _unitMeasureId;
		public virtual int? UnitMeasureId 
		{ 
		    get
		    {
		        return this._unitMeasureId;
		    }
		    set
		    {
		        this._unitMeasureId = value;
		    }
		}
		
		private double? _quantity;
		public virtual double? Quantity 
		{ 
		    get
		    {
		        return this._quantity;
		    }
		    set
		    {
		        this._quantity = value;
		    }
		}
		
		private double _wasteValue;
		public virtual double WasteValue 
		{ 
		    get
		    {
		        return this._wasteValue;
		    }
		}
		
		private decimal? _unitPrice;
		public virtual decimal? UnitPrice 
		{ 
		    get
		    {
		        return this._unitPrice;
		    }
		    set
		    {
		        this._unitPrice = value;
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
		
		private UnitMeasure _unitMeasure;
		public virtual UnitMeasure UnitMeasure 
		{ 
		    get
		    {
		        return this._unitMeasure;
		    }
		    set
		    {
		        this._unitMeasure = value;
		    }
		}
		
		private Product _product;
		public virtual Product Product 
		{ 
		    get
		    {
		        return this._product;
		    }
		    set
		    {
		        this._product = value;
		    }
		}
		
	}
}
