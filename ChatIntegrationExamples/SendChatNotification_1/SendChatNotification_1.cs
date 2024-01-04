using System;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.DcpChatIntegrationHelper.Common;
using Skyline.DataMiner.DcpChatIntegrationHelper.Teams;

public class Script
{
	public void Run(Engine engine)
	{
		var chatIntegrationHelper = new ChatIntegrationHelperBuilder().Build();
		try
		{
			var chatIdParam = engine.GetScriptParam("Chat ID");
			if (string.IsNullOrWhiteSpace(chatIdParam?.Value))
			{
				engine.ExitFail("'Chat ID' parameter is required.");
				return;
			}

			var notificationParam = engine.GetScriptParam("Notification");
			if (string.IsNullOrWhiteSpace(notificationParam?.Value))
			{
				engine.ExitFail("'Notification' parameter is required.");
				return;
			}

			try
			{
				chatIntegrationHelper.Teams.TrySendChatNotification(chatIdParam.Value, notificationParam.Value);
			}
			catch (TeamsChatIntegrationException e)
			{
				engine.ExitFail($"Couldn't send the notification to the chat with ID {chatIdParam.Value} with error {e.Message}.");
				return;
			}

			engine.ExitSuccess($"The notification was sent to the chat with ID {chatIdParam.Value}!");
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