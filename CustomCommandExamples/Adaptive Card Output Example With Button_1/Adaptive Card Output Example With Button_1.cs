using System;
using System.Collections.Generic;
using AdaptiveCards;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.DcpChatIntegrationHelper.Common;
using Skyline.DataMiner.DcpChatIntegrationHelper.Internal.Common;
using Skyline.DataMiner.Net.Messages;

/// <summary>
/// DataMiner Script Class.
/// </summary>
public class Script
{
	/// <summary>
	/// The Script entry point.
	/// </summary>
	/// <param name="engine">Link with SLAutomation process.</param>
	public void Run(Engine engine)
	{
		// Looking up the dataminerId
		var dataminerInfoResponse = engine.SendSLNetSingleResponseMessage(new GetInfoMessage(InfoType.DataMinerInfo));
		var dataminerInfo = (GetDataMinerInfoResponseMessage)dataminerInfoResponse;

		// Cloud identity
		// You can find these IDs by opening the DMS overview page on admin.dataminer.services
		// Example: https://admin.dataminer.services/5d8ce07f-5b73-4135-b5a2-2cf4129912c6/dms/311e8ee6-7f7e-4020-b9ae-e43356a18e28/overview
		// var organizationId = Guid.Parse("5d8ce07f-5b73-4135-b5a2-2cf4129912c6");
		// var dmsId = Guid.Parse("311e8ee6-7f7e-4020-b9ae-e43356a18e28");
		var organizationId = Guid.Parse("");
		var dmsId = Guid.Parse("");

		var adaptiveCardBody = new List<AdaptiveElement>()
		{
			new AdaptiveFactSet()
			{
				Facts = new List<AdaptiveFact>
				{
					new AdaptiveFact("Name:", "Uplink"),
					new AdaptiveFact("Bitrate:", "3 mb/s")
				},
			},
			new AdaptiveFactSet()
			{
				Facts = new List<AdaptiveFact>
				{
					new AdaptiveFact("Name:", "Downlink"),
					new AdaptiveFact("Bitrate:", "19 mb/s")
				},
			},
			new AdaptiveActionSet()
			{
				Actions = new List<AdaptiveAction>()
				{
					AdaptiveCardHelper.Buttons.ChangeDms("Click here to change the conversation's active DMS"),
					AdaptiveCardHelper.Buttons.OpenUrl(new Uri("https://dataminer.services"), "dataminer.services"),
					// Example custom command from https://github.com/SkylineCommunications/ChatOps-Extensions/tree/main/CustomCommandExamples#input-parameter
					AdaptiveCardHelper.Buttons.RunCustomCommand(
						"Parameter Input Example",
						dataminerInfo.ID,
						organizationId,
						dmsId,
						new List<CustomCommandInput>()
						{
							new CustomCommandInput("Parameter Input", CustomCommandInputType.Parameter, "The overwritten default value"),
						},
						"Run Example Custom Command",
						skipConfirmation: false),
					AdaptiveCardHelper.Buttons.GetElement(1, dataminerInfo.ID, organizationId, dmsId, "Show element 1"),
					AdaptiveCardHelper.Buttons.GetAlarmsForElement(1, dataminerInfo.ID, "Fill in element name here", organizationId, dmsId, "Show alarms for element 1"),
					AdaptiveCardHelper.Buttons.GetAlarmsForView(1, "Fill in view name here", organizationId, dmsId, "Show alarms for view 1")
				}
			}
		};

		engine.AddScriptOutput("AdaptiveCard", adaptiveCardBody.ToJson());
	}
}