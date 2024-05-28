using System;
using AdaptiveCards;

namespace TakeOwnershipOfAlarm_1
{
	using System.Collections.Generic;
	using Skyline.DataMiner.Automation;
	using Skyline.DataMiner.DcpChatIntegrationHelper.Common;
	using Skyline.DataMiner.DcpChatIntegrationHelper.Internal.Common;
	using Skyline.DataMiner.DcpChatIntegrationHelper.Teams;

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
			var dataMinerId = engine.GetScriptParam("DataMiner ID");
			if (string.IsNullOrWhiteSpace(dataMinerId?.Value))
			{
				engine.ExitFail("'DataMiner ID' parameter is required.");
				return;
			}

			var elementId = engine.GetScriptParam("Element ID");
			if (string.IsNullOrWhiteSpace(elementId?.Value))
			{
				engine.ExitFail("'Element ID' parameter is required.");
				return;
			}

			var alarmId = engine.GetScriptParam("Alarm ID");
			if (string.IsNullOrWhiteSpace(alarmId?.Value))
			{
				engine.ExitFail("'Alarm ID' parameter is required.");
				return;
			}

			// This input will not be asked from the user but will automatically be filled in by the DataMiner bot with the
			// dataminer.services email address of the user executing this Automation script using their linked DataMiner account
			// Note that this needs to be defined as input on the Automation script with the exact name "dataminer.services User Email",
			// otherwise it will not be provided by the DataMiner bot
			var userEmail = engine.GetScriptParam("dataminer.services User Email");
			if (string.IsNullOrWhiteSpace(userEmail?.Value))
			{
				engine.ExitFail("'dataminer.services User Email' parameter is required.");
				return;
			}

			try
			{
				engine.AcknowledgeAlarm(
					int.Parse(dataMinerId.Value),
					int.Parse(elementId.Value),
					int.Parse(alarmId.Value),
					"Acknowledged using ChatOps");
			}
			catch (Exception e)
			{
				engine.AddScriptOutput("User", engine.UserDisplayName);
				engine.AddScriptOutput("Login", engine.UserLoginName);
				engine.AddScriptOutput("Message", "Couldn't take ownership of the alarm.");
				engine.AddScriptOutput("StackTrace", e.ToString());
			}

			// Cloud identity
			// You can find these IDs by opening the DMS overview page on admin.dataminer.services
			// Example: https://admin.dataminer.services/5d8ce07f-5b73-4135-b5a2-2cf4129912c6/dms/311e8ee6-7f7e-4020-b9ae-e43356a18e28/overview
			// var organizationId = Guid.Parse("5d8ce07f-5b73-4135-b5a2-2cf4129912c6");
			// var dmsId = Guid.Parse("311e8ee6-7f7e-4020-b9ae-e43356a18e28");
			var organizationId = Guid.Parse("");
			var dmsId = Guid.Parse("");

			var adaptiveCardBody = new List<AdaptiveElement>()
				{
					new AdaptiveTextBlock($"{engine.UserDisplayName} took ownership of the alarm."),
					new AdaptiveFactSet()
					{
						Facts = new List<AdaptiveFact>
						{
							new AdaptiveFact("DataMiner login:", engine.UserLoginName),
							new AdaptiveFact("dataminer.services login:", userEmail.Value),
						},
					}
				};
			// Response for taking ownership
			engine.AddScriptOutput("AdaptiveCard", adaptiveCardBody.ToJson());

			// Also send a private chat message to the person taking ownership
			var chatIntegrationHelper = new ChatIntegrationHelperBuilder().Build();
			try
			{
				IChat chat;
				try
				{
					chat = chatIntegrationHelper.Teams.TryGetPrivateChat(userEmail.Value);
				}
				catch (TeamsChatIntegrationException)
				{
					try
					{
						chatIntegrationHelper.Teams.TryCreatePrivateChat(userEmail.Value);
						chat = chatIntegrationHelper.Teams.TryGetPrivateChat(userEmail.Value);
					}
					catch (TeamsChatIntegrationException e)
					{
						engine.ExitFail($"Couldn't fetch nor create the chat with error {e.Message}.");
						return;
					}
				}

				chatIntegrationHelper.Teams.TrySendChatNotification(chat.ChatId, "And good luck resolving that alarm! 😉");
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