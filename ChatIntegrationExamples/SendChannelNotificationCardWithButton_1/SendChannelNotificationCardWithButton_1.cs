using System;
using System.Collections.Generic;
using AdaptiveCards;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.DcpChatIntegrationHelper.Common;
using Skyline.DataMiner.DcpChatIntegrationHelper.Internal.Common;
using Skyline.DataMiner.DcpChatIntegrationHelper.Teams;
using Skyline.DataMiner.Net.Messages;

namespace SendChannelNotificationCardWithButton_1
{
	/// <summary>
	/// Represents a DataMiner Automation script.
	/// </summary>
	public class Script
	{
		/// <summary>
		/// The script entry point.
		/// </summary>
		/// <param name="engine">Link with SLAutomation process.</param>
		public void Run(IEngine engine)
		{
			var chatIntegrationHelper = new ChatIntegrationHelperBuilder().Build();
			try
			{
				var teamIdParam = engine.GetScriptParam("Team ID");
				if (string.IsNullOrWhiteSpace(teamIdParam?.Value))
				{
					engine.ExitFail("'Team ID' parameter is required.");
					return;
				}

				var channelIdParam = engine.GetScriptParam("Channel ID");
				if (string.IsNullOrWhiteSpace(channelIdParam?.Value))
				{
					engine.ExitFail("'Channel ID' parameter is required.");
					return;
				}

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
					// Some additional examples
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
									new CustomCommandInput("Parameter Input", CustomCommandInputType.Parameter, "The overwriten default value"),
								},
								"Run Example Custom Command"),
							AdaptiveCardHelper.Buttons.GetElement(1, dataminerInfo.ID, organizationId, dmsId, "Show element 1"),
							AdaptiveCardHelper.Buttons.GetAlarmsForElement(1, dataminerInfo.ID, "Fill in element name here", organizationId, dmsId, "Show alarms for element 1"),
							AdaptiveCardHelper.Buttons.GetAlarmsForView(1, "Fill in view name here", organizationId, dmsId, "Show view 1")
						}
					}
				};

				try
				{
					chatIntegrationHelper.Teams.TrySendChannelNotification(teamIdParam.Value, channelIdParam.Value, adaptiveCardBody);
				}
				catch (TeamsChatIntegrationException e)
				{
					engine.ExitFail($"Couldn't send the notification card to the channel with ID {channelIdParam.Value} with error {e.Message}.");
					return;
				}

				engine.ExitSuccess($"The notification card was sent to the channel with ID {channelIdParam.Value}!");
			}
			catch (ScriptAbortException)
			{
				// Also ExitSuccess is a ScriptAbortException
				throw;
			}
			catch (Exception e)
			{
				engine.ExitFail($"An exception occurred with the following message: {e.Message}");
			}
			finally
			{
				chatIntegrationHelper?.Dispose();
			}
		}
	}
}