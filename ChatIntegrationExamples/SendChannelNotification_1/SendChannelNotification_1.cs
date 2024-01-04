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

			var notificationParam = engine.GetScriptParam("Notification");
			if (string.IsNullOrWhiteSpace(notificationParam?.Value))
			{
				engine.ExitFail("'Notification' parameter is required.");
				return;
			}

			try
			{
				chatIntegrationHelper.Teams.TrySendChannelNotification(teamIdParam.Value, channelIdParam.Value, notificationParam.Value);
			}
			catch (TeamsChatIntegrationException e)
			{
				engine.ExitFail($"Couldn't send the notification to the channel with ID {channelIdParam.Value} with error {e.Message}.");
				return;
			}

			engine.ExitSuccess($"The notification was sent to the channel with ID {channelIdParam.Value}!");
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