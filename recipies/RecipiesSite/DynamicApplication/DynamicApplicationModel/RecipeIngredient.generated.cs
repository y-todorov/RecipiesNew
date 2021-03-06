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
	public partial class RecipeIngredient
	{
		private int _recipeIngredientId;
		public virtual int RecipeIngredientId 
		{ 
		    get
		    {
		        return this._recipeIngredientId;
		    }
		    set
		    {
		        this._recipeIngredientId = value;
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
		
		private double? _quantityPerPortion;
		public virtual double? QuantityPerPortion 
		{ 
		    get
		    {
		        return this._quantityPerPortion;
		    }
		    set
		    {
		        this._quantityPerPortion = value;
		    }
		}
		
		private decimal? _cost;
		public virtual decimal? Cost 
		{ 
		    get
		    {
		        return this._cost;
		    }
		    set
		    {
		        this._cost = value;
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
		
		private double _totalValue;
		public virtual double TotalValue 
		{ 
		    get
		    {
		        return this._totalValue;
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
