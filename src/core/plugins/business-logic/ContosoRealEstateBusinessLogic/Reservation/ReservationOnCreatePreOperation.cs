// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using ContosoRealEstate.BusinessLogic.Models;
using Microsoft.Xrm.Sdk;
using System;

namespace ContosoRealEstate.BusinessLogic.Plugins;

/// <summary>
/// Plugin development guide: https://docs.microsoft.com/powerapps/developer/common-data-service/plug-ins
/// Best practices and guidance: https://docs.microsoft.com/powerapps/developer/common-data-service/best-practices/business-logic/
/// </summary>
[CrmPluginRegistration(MessageNameEnum.Create, contoso_Reservation.EntityLogicalName, StageEnum.PreOperation, ExecutionModeEnum.Synchronous,
    "contoso_from,contoso_to,contoso_listing,contoso_nights", 
    "ReservationOnCreatePreOperation", 1000, IsolationModeEnum.Sandbox)]
public class ReservationOnCreatePreOperation : ReservationLogic, IPlugin
{
    public ReservationOnCreatePreOperation(string unsecureConfiguration, string secureConfiguration)
        : base(typeof(ReservationOnCreatePreOperation), unsecureConfiguration, secureConfiguration)
    {
    }

    // Entry point for custom business logic execution
    public override void ExecuteDataversePlugin(ILocalPluginContext localPluginContext)
    {
        if (localPluginContext == null)
        {
            throw new ArgumentNullException(nameof(localPluginContext));
        }

        if (UsePowerFxPlugins(localPluginContext)) return;

        ValidatePluginExecutionContext(localPluginContext, MessageNameEnum.Create, StageEnum.PreOperation, contoso_Reservation.EntityLogicalName);
        IsSelectedListingAvailable(localPluginContext);
        ValidateFields(localPluginContext);
        IsSelectedListingAvailable(localPluginContext);
        SetNameField(localPluginContext);
        SetReservationDateOnCreate(localPluginContext);
        
    }
}
