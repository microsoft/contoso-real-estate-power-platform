#pragma warning disable CS1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContosoRealEstate.BusinessLogic.Models
{
	
	
	[System.Runtime.Serialization.DataContractAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Dataverse Model Builder", "2.0.0.11")]
	public enum contoso_listing_contoso_features
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Parking = 330650000,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		WashingMachine = 330650001,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Pool = 330650002,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Garden = 330650003,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Gym = 330650004,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Security = 330650005,
	}
	
	/// <summary>
	/// Status of the Listing
	/// </summary>
	[System.Runtime.Serialization.DataContractAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Dataverse Model Builder", "2.0.0.11")]
	public enum contoso_listing_statecode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Active = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Inactive = 1,
	}
	
	/// <summary>
	/// Reason for the status of the Listing
	/// </summary>
	[System.Runtime.Serialization.DataContractAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Dataverse Model Builder", "2.0.0.11")]
	public enum contoso_listing_statuscode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Active = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Inactive = 2,
	}
	
	/// <summary>
	/// This table contains a record of real estate listings
	/// </summary>
	[System.Runtime.Serialization.DataContractAttribute()]
	[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("contoso_listing")]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Dataverse Model Builder", "2.0.0.11")]
	public partial class contoso_listing : Microsoft.Xrm.Sdk.Entity
	{
		
		/// <summary>
		/// Available fields, a the time of codegen, for the contoso_listing entity
		/// </summary>
		public partial class Fields
		{
			public const string contoso_address = "contoso_address";
			public const string contoso_description = "contoso_description";
			public const string contoso_displayname = "contoso_displayname";
			public const string contoso_features = "contoso_features";
			public const string contoso_Image = "contoso_image";
			public const string contoso_Image_Timestamp = "contoso_image_timestamp";
			public const string contoso_Image_URL = "contoso_image_url";
			public const string contoso_ImageId = "contoso_imageid";
			public const string contoso_listingId = "contoso_listingid";
			public const string Id = "contoso_listingid";
			public const string contoso_listingid1 = "contoso_listingid1";
			public const string contoso_Lock = "contoso_lock";
			public const string contoso_MaximumGuests = "contoso_maximumguests";
			public const string contoso_name = "contoso_name";
			public const string contoso_NumberofBathrooms = "contoso_numberofbathrooms";
			public const string contoso_NumberofBedrooms = "contoso_numberofbedrooms";
			public const string contoso_pricepermonth = "contoso_pricepermonth";
			public const string contoso_pricepermonth_Base = "contoso_pricepermonth_base";
			public const string contoso_PrimaryImage = "contoso_primaryimage";
			public const string contoso_Summary = "contoso_summary";
			public const string contoso_TotalParkingSpaces = "contoso_totalparkingspaces";
			public const string CreatedBy = "createdby";
			public const string CreatedOn = "createdon";
			public const string CreatedOnBehalfBy = "createdonbehalfby";
			public const string ExchangeRate = "exchangerate";
			public const string ImportSequenceNumber = "importsequencenumber";
			public const string ModifiedBy = "modifiedby";
			public const string ModifiedOn = "modifiedon";
			public const string ModifiedOnBehalfBy = "modifiedonbehalfby";
			public const string OverriddenCreatedOn = "overriddencreatedon";
			public const string OwnerId = "ownerid";
			public const string OwningBusinessUnit = "owningbusinessunit";
			public const string OwningTeam = "owningteam";
			public const string OwningUser = "owninguser";
			public const string statecode = "statecode";
			public const string statuscode = "statuscode";
			public const string TimeZoneRuleVersionNumber = "timezoneruleversionnumber";
			public const string TransactionCurrencyId = "transactioncurrencyid";
			public const string UTCConversionTimeZoneCode = "utcconversiontimezonecode";
			public const string VersionNumber = "versionnumber";
			public const string contoso_listingfee_listing = "contoso_listingfee_listing";
			public const string contoso_reservation_listing = "contoso_reservation_listing";
		}
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public contoso_listing() : 
				base(EntityLogicalName)
		{
		}
		
		public const string EntityLogicalName = "contoso_listing";
		
		public const string EntityLogicalCollectionName = "contoso_listings";
		
		public const string EntitySetName = "contoso_listings";
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contoso_address")]
		public string contoso_address
		{
			get
			{
				return this.GetAttributeValue<string>("contoso_address");
			}
			set
			{
				this.SetAttributeValue("contoso_address", value);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contoso_description")]
		public string contoso_description
		{
			get
			{
				return this.GetAttributeValue<string>("contoso_description");
			}
			set
			{
				this.SetAttributeValue("contoso_description", value);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contoso_displayname")]
		public string contoso_displayname
		{
			get
			{
				return this.GetAttributeValue<string>("contoso_displayname");
			}
			set
			{
				this.SetAttributeValue("contoso_displayname", value);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contoso_features")]
		public virtual System.Collections.Generic.IEnumerable<contoso_listing_contoso_features> contoso_features
		{
			get
			{
				return EntityOptionSetEnum.GetMultiEnum<contoso_listing_contoso_features>(this, "contoso_features");
			}
			set
			{
				this.SetAttributeValue("contoso_features", EntityOptionSetEnum.GetMultiEnum(this, "contoso_features", value));
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contoso_image")]
		public byte[] contoso_Image
		{
			get
			{
				return this.GetAttributeValue<byte[]>("contoso_image");
			}
			set
			{
				this.SetAttributeValue("contoso_image", value);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contoso_image_timestamp")]
		public System.Nullable<long> contoso_Image_Timestamp
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<long>>("contoso_image_timestamp");
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contoso_image_url")]
		public string contoso_Image_URL
		{
			get
			{
				return this.GetAttributeValue<string>("contoso_image_url");
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contoso_imageid")]
		public System.Nullable<System.Guid> contoso_ImageId
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("contoso_imageid");
			}
		}
		
		/// <summary>
		/// Unique identifier for entity instances
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contoso_listingid")]
		public System.Nullable<System.Guid> contoso_listingId
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("contoso_listingid");
			}
			set
			{
				this.SetAttributeValue("contoso_listingid", value);
				if (value.HasValue)
				{
					base.Id = value.Value;
				}
				else
				{
					base.Id = System.Guid.Empty;
				}
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contoso_listingid")]
		public override System.Guid Id
		{
			get
			{
				return base.Id;
			}
			set
			{
				this.contoso_listingId = value;
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contoso_listingid1")]
		public string contoso_listingid1
		{
			get
			{
				return this.GetAttributeValue<string>("contoso_listingid1");
			}
			set
			{
				this.SetAttributeValue("contoso_listingid1", value);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contoso_lock")]
		public string contoso_Lock
		{
			get
			{
				return this.GetAttributeValue<string>("contoso_lock");
			}
			set
			{
				this.SetAttributeValue("contoso_lock", value);
			}
		}
		
		/// <summary>
		/// Maximum guests that the property can accommodate
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contoso_maximumguests")]
		public System.Nullable<int> contoso_MaximumGuests
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("contoso_maximumguests");
			}
			set
			{
				this.SetAttributeValue("contoso_maximumguests", value);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contoso_name")]
		public string contoso_name
		{
			get
			{
				return this.GetAttributeValue<string>("contoso_name");
			}
			set
			{
				this.SetAttributeValue("contoso_name", value);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contoso_numberofbathrooms")]
		public System.Nullable<int> contoso_NumberofBathrooms
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("contoso_numberofbathrooms");
			}
			set
			{
				this.SetAttributeValue("contoso_numberofbathrooms", value);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contoso_numberofbedrooms")]
		public System.Nullable<int> contoso_NumberofBedrooms
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("contoso_numberofbedrooms");
			}
			set
			{
				this.SetAttributeValue("contoso_numberofbedrooms", value);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contoso_pricepermonth")]
		public Microsoft.Xrm.Sdk.Money contoso_pricepermonth
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("contoso_pricepermonth");
			}
			set
			{
				this.SetAttributeValue("contoso_pricepermonth", value);
			}
		}
		
		/// <summary>
		/// Value of the Price per Month in base currency.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contoso_pricepermonth_base")]
		public Microsoft.Xrm.Sdk.Money contoso_pricepermonth_Base
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("contoso_pricepermonth_base");
			}
		}
		
		/// <summary>
		/// The primary image
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contoso_primaryimage")]
		public Microsoft.Xrm.Sdk.EntityReference contoso_PrimaryImage
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("contoso_primaryimage");
			}
			set
			{
				this.SetAttributeValue("contoso_primaryimage", value);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contoso_summary")]
		public string contoso_Summary
		{
			get
			{
				return this.GetAttributeValue<string>("contoso_summary");
			}
			set
			{
				this.SetAttributeValue("contoso_summary", value);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contoso_totalparkingspaces")]
		public System.Nullable<int> contoso_TotalParkingSpaces
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("contoso_totalparkingspaces");
			}
			set
			{
				this.SetAttributeValue("contoso_totalparkingspaces", value);
			}
		}
		
		/// <summary>
		/// Unique identifier of the user who created the record.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
		public Microsoft.Xrm.Sdk.EntityReference CreatedBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
			}
		}
		
		/// <summary>
		/// Date and time when the record was created.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
		public System.Nullable<System.DateTime> CreatedOn
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
			}
		}
		
		/// <summary>
		/// Unique identifier of the delegate user who created the record.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
		public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
			}
		}
		
		/// <summary>
		/// Exchange rate for the currency associated with the entity with respect to the base currency.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("exchangerate")]
		public System.Nullable<decimal> ExchangeRate
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<decimal>>("exchangerate");
			}
		}
		
		/// <summary>
		/// Sequence number of the import that created this record.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("importsequencenumber")]
		public System.Nullable<int> ImportSequenceNumber
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("importsequencenumber");
			}
			set
			{
				this.SetAttributeValue("importsequencenumber", value);
			}
		}
		
		/// <summary>
		/// Unique identifier of the user who modified the record.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
		public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
			}
		}
		
		/// <summary>
		/// Date and time when the record was modified.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
		public System.Nullable<System.DateTime> ModifiedOn
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
			}
		}
		
		/// <summary>
		/// Unique identifier of the delegate user who modified the record.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
		public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
			}
		}
		
		/// <summary>
		/// Date and time that the record was migrated.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("overriddencreatedon")]
		public System.Nullable<System.DateTime> OverriddenCreatedOn
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("overriddencreatedon");
			}
			set
			{
				this.SetAttributeValue("overriddencreatedon", value);
			}
		}
		
		/// <summary>
		/// Owner Id
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ownerid")]
		public Microsoft.Xrm.Sdk.EntityReference OwnerId
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ownerid");
			}
			set
			{
				this.SetAttributeValue("ownerid", value);
			}
		}
		
		/// <summary>
		/// Unique identifier for the business unit that owns the record
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningbusinessunit")]
		public Microsoft.Xrm.Sdk.EntityReference OwningBusinessUnit
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningbusinessunit");
			}
		}
		
		/// <summary>
		/// Unique identifier for the team that owns the record.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningteam")]
		public Microsoft.Xrm.Sdk.EntityReference OwningTeam
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningteam");
			}
		}
		
		/// <summary>
		/// Unique identifier for the user that owns the record.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owninguser")]
		public Microsoft.Xrm.Sdk.EntityReference OwningUser
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owninguser");
			}
		}
		
		/// <summary>
		/// Status of the Listing
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statecode")]
		public virtual contoso_listing_statecode? statecode
		{
			get
			{
				return ((contoso_listing_statecode?)(EntityOptionSetEnum.GetEnum(this, "statecode")));
			}
			set
			{
				this.SetAttributeValue("statecode", value.HasValue ? new Microsoft.Xrm.Sdk.OptionSetValue((int)value) : null);
			}
		}
		
		/// <summary>
		/// Reason for the status of the Listing
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statuscode")]
		public virtual contoso_listing_statuscode? statuscode
		{
			get
			{
				return ((contoso_listing_statuscode?)(EntityOptionSetEnum.GetEnum(this, "statuscode")));
			}
			set
			{
				this.SetAttributeValue("statuscode", value.HasValue ? new Microsoft.Xrm.Sdk.OptionSetValue((int)value) : null);
			}
		}
		
		/// <summary>
		/// For internal use only.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezoneruleversionnumber")]
		public System.Nullable<int> TimeZoneRuleVersionNumber
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("timezoneruleversionnumber");
			}
			set
			{
				this.SetAttributeValue("timezoneruleversionnumber", value);
			}
		}
		
		/// <summary>
		/// Unique identifier of the currency associated with the entity.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("transactioncurrencyid")]
		public Microsoft.Xrm.Sdk.EntityReference TransactionCurrencyId
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("transactioncurrencyid");
			}
			set
			{
				this.SetAttributeValue("transactioncurrencyid", value);
			}
		}
		
		/// <summary>
		/// Time zone code that was in use when the record was created.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("utcconversiontimezonecode")]
		public System.Nullable<int> UTCConversionTimeZoneCode
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("utcconversiontimezonecode");
			}
			set
			{
				this.SetAttributeValue("utcconversiontimezonecode", value);
			}
		}
		
		/// <summary>
		/// Version Number
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
		public System.Nullable<long> VersionNumber
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
			}
		}
		
		/// <summary>
		/// 1:N contoso_listingfee_listing
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("contoso_listingfee_listing")]
		public System.Collections.Generic.IEnumerable<ContosoRealEstate.BusinessLogic.Models.contoso_ListingFee> contoso_listingfee_listing
		{
			get
			{
				return this.GetRelatedEntities<ContosoRealEstate.BusinessLogic.Models.contoso_ListingFee>("contoso_listingfee_listing", null);
			}
			set
			{
				this.SetRelatedEntities<ContosoRealEstate.BusinessLogic.Models.contoso_ListingFee>("contoso_listingfee_listing", null, value);
			}
		}
		
		/// <summary>
		/// 1:N contoso_reservation_listing
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("contoso_reservation_listing")]
		public System.Collections.Generic.IEnumerable<ContosoRealEstate.BusinessLogic.Models.contoso_Reservation> contoso_reservation_listing
		{
			get
			{
				return this.GetRelatedEntities<ContosoRealEstate.BusinessLogic.Models.contoso_Reservation>("contoso_reservation_listing", null);
			}
			set
			{
				this.SetRelatedEntities<ContosoRealEstate.BusinessLogic.Models.contoso_Reservation>("contoso_reservation_listing", null, value);
			}
		}
	}
}
#pragma warning restore CS1591
