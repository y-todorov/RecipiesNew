﻿#pragma warning disable 1591
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
	public partial class RecipiesModel : OpenAccessContext, IRecipiesModelUnitOfWork
	{
		private static string connectionStringName = @"Connection";
			
		private static BackendConfiguration backend = GetBackendConfiguration();
		
			
		private static MetadataSource metadataSource = XmlMetadataSource.FromAssemblyResource("EntitiesModel.rlinq");
	
		public RecipiesModel()
			:base(connectionStringName, backend, metadataSource)
		{ }
		
		public RecipiesModel(string connection)
			:base(connection, backend, metadataSource)
		{ }
	
		public RecipiesModel(BackendConfiguration backendConfiguration)
			:base(connectionStringName, backendConfiguration, metadataSource)
		{ }
			
		public RecipiesModel(string connection, MetadataSource metadataSource)
			:base(connection, backend, metadataSource)
		{ }
		
		public RecipiesModel(string connection, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
			:base(connection, backendConfiguration, metadataSource)
		{ }
			
		public IQueryable<Vendor> Vendors 
		{
	    	get
	    	{
	        	return this.GetAll<Vendor>();
	    	}
		}
		
		public IQueryable<UnitMeasure> UnitMeasures 
		{
	    	get
	    	{
	        	return this.GetAll<UnitMeasure>();
	    	}
		}
		
		public IQueryable<Store> Stores 
		{
	    	get
	    	{
	        	return this.GetAll<Store>();
	    	}
		}
		
		public IQueryable<ShipMethod> ShipMethods 
		{
	    	get
	    	{
	        	return this.GetAll<ShipMethod>();
	    	}
		}
		
		public IQueryable<Shift> Shifts 
		{
	    	get
	    	{
	        	return this.GetAll<Shift>();
	    	}
		}
		
		public IQueryable<SalesOrderStatus> SalesOrderStatus 
		{
	    	get
	    	{
	        	return this.GetAll<SalesOrderStatus>();
	    	}
		}
		
		public IQueryable<SalesOrderHeader> SalesOrderHeaders 
		{
	    	get
	    	{
	        	return this.GetAll<SalesOrderHeader>();
	    	}
		}
		
		public IQueryable<SalesOrderDetail> SalesOrderDetails 
		{
	    	get
	    	{
	        	return this.GetAll<SalesOrderDetail>();
	    	}
		}
		
		public IQueryable<RecipeIngredient> RecipeIngredients 
		{
	    	get
	    	{
	        	return this.GetAll<RecipeIngredient>();
	    	}
		}
		
		public IQueryable<Recipe> Recipes 
		{
	    	get
	    	{
	        	return this.GetAll<Recipe>();
	    	}
		}
		
		public IQueryable<PurchaseOrderStatus> PurchaseOrderStatus 
		{
	    	get
	    	{
	        	return this.GetAll<PurchaseOrderStatus>();
	    	}
		}
		
		public IQueryable<PurchaseOrderHeader> PurchaseOrderHeaders 
		{
	    	get
	    	{
	        	return this.GetAll<PurchaseOrderHeader>();
	    	}
		}
		
		public IQueryable<PurchaseOrderDetail> PurchaseOrderDetails 
		{
	    	get
	    	{
	        	return this.GetAll<PurchaseOrderDetail>();
	    	}
		}
		
		public IQueryable<ProductVendor> ProductVendors 
		{
	    	get
	    	{
	        	return this.GetAll<ProductVendor>();
	    	}
		}
		
		public IQueryable<ProductHistory> ProductHistories 
		{
	    	get
	    	{
	        	return this.GetAll<ProductHistory>();
	    	}
		}
		
		public IQueryable<ProductCategory> ProductCategories 
		{
	    	get
	    	{
	        	return this.GetAll<ProductCategory>();
	    	}
		}
		
		public IQueryable<Product> Products 
		{
	    	get
	    	{
	        	return this.GetAll<Product>();
	    	}
		}
		
		public IQueryable<Inventory> Inventories 
		{
	    	get
	    	{
	        	return this.GetAll<Inventory>();
	    	}
		}
		
		public IQueryable<EmployeeDepartment> EmployeeDepartments 
		{
	    	get
	    	{
	        	return this.GetAll<EmployeeDepartment>();
	    	}
		}
		
		public IQueryable<Employee> Employees 
		{
	    	get
	    	{
	        	return this.GetAll<Employee>();
	    	}
		}
		
		public IQueryable<EmailTemplate> EmailTemplates 
		{
	    	get
	    	{
	        	return this.GetAll<EmailTemplate>();
	    	}
		}
		
		public IQueryable<Department> Departments 
		{
	    	get
	    	{
	        	return this.GetAll<Department>();
	    	}
		}
		
		public IQueryable<Customer> Customers 
		{
	    	get
	    	{
	        	return this.GetAll<Customer>();
	    	}
		}
		
		public IQueryable<PaymentType> PaymentTypes 
		{
	    	get
	    	{
	        	return this.GetAll<PaymentType>();
	    	}
		}
		
		public IQueryable<RecipeWaste> RecipeWastes 
		{
	    	get
	    	{
	        	return this.GetAll<RecipeWaste>();
	    	}
		}
		
		public IQueryable<ProductWaste> ProductWastes 
		{
	    	get
	    	{
	        	return this.GetAll<ProductWaste>();
	    	}
		}
		
		public static BackendConfiguration GetBackendConfiguration()
		{
			BackendConfiguration backend = new BackendConfiguration();
			backend.Backend = "Azure";
			backend.ProviderName = "System.Data.SqlClient";
			backend.Logging.LogEventsToTrace = false;
			backend.Logging.MetricStoreSnapshotInterval = 0;
			return backend;
		}
	}

	public interface IRecipiesModelUnitOfWork : IUnitOfWork
	{
		IQueryable<Vendor> Vendors 
		{ 
			get;
		}

		IQueryable<UnitMeasure> UnitMeasures 
		{ 
			get;
		}

		IQueryable<Store> Stores 
		{ 
			get;
		}

		IQueryable<ShipMethod> ShipMethods 
		{ 
			get;
		}

		IQueryable<Shift> Shifts 
		{ 
			get;
		}

		IQueryable<SalesOrderStatus> SalesOrderStatus 
		{ 
			get;
		}

		IQueryable<SalesOrderHeader> SalesOrderHeaders 
		{ 
			get;
		}

		IQueryable<SalesOrderDetail> SalesOrderDetails 
		{ 
			get;
		}

		IQueryable<RecipeIngredient> RecipeIngredients 
		{ 
			get;
		}

		IQueryable<Recipe> Recipes 
		{ 
			get;
		}

		IQueryable<PurchaseOrderStatus> PurchaseOrderStatus 
		{ 
			get;
		}

		IQueryable<PurchaseOrderHeader> PurchaseOrderHeaders 
		{ 
			get;
		}

		IQueryable<PurchaseOrderDetail> PurchaseOrderDetails 
		{ 
			get;
		}

		IQueryable<ProductVendor> ProductVendors 
		{ 
			get;
		}

		IQueryable<ProductHistory> ProductHistories 
		{ 
			get;
		}

		IQueryable<ProductCategory> ProductCategories 
		{ 
			get;
		}

		IQueryable<Product> Products 
		{ 
			get;
		}

		IQueryable<Inventory> Inventories 
		{ 
			get;
		}

		IQueryable<EmployeeDepartment> EmployeeDepartments 
		{ 
			get;
		}

		IQueryable<Employee> Employees 
		{ 
			get;
		}

		IQueryable<EmailTemplate> EmailTemplates 
		{ 
			get;
		}

		IQueryable<Department> Departments 
		{ 
			get;
		}

		IQueryable<Customer> Customers 
		{ 
			get;
		}

		IQueryable<PaymentType> PaymentTypes 
		{ 
			get;
		}

		IQueryable<RecipeWaste> RecipeWastes 
		{ 
			get;
		}

		IQueryable<ProductWaste> ProductWastes 
		{ 
			get;
		}

	}
}
#pragma warning restore 1591

