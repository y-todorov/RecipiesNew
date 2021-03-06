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
	public partial class RecipeWaste
	{
		private int _recipeWasteId;
		public virtual int RecipeWasteId 
		{ 
		    get
		    {
		        return this._recipeWasteId;
		    }
		    set
		    {
		        this._recipeWasteId = value;
		    }
		}
		
		private int? _recipeId;
		public virtual int? RecipeId 
		{ 
		    get
		    {
		        return this._recipeId;
		    }
		    set
		    {
		        this._recipeId = value;
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
		
		private Recipe _recipe;
		public virtual Recipe Recipe 
		{ 
		    get
		    {
		        return this._recipe;
		    }
		    set
		    {
		        this._recipe = value;
		    }
		}
		
	}
}
