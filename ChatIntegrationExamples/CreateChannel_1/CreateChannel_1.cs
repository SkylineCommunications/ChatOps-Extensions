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
			var teamIdParam = engine.GetScriptParam("Team Id");
			if (string.IsNullOrWhiteSpace(teamIdParam?.Value))
			{
				engine.ExitFail("'Team Id' parameter is required.");
				return;
			}

			var channelNameParam = engine.GetScriptParam("Channel Name");
			if (string.IsNullOrWhiteSpace(channelNameParam?.Value))
			{
				engine.ExitFail("'Channel Name' parameter is required.");
				return;
			}

			var channelDescriptionParam = engine.GetScriptParam("Channel Description");
			if (string.IsNullOrWhiteSpace(channelDescriptionParam?.Value))
			{
				engine.ExitFail("'Channel Description' parameter is required.");
				return;
			}

			var channelMemoryFile = engine.GetMemory("Channels");
			if (channelMemoryFile == null)
			{
				engine.ExitFail("'Channels' memory file is required.");
				return;
			}

			IChannel channel;

			try
			{
				channel = chatIntegrationHelper.Teams.TryCreateChannel(teamIdParam.Value, channelNameParam.Value, channelDescriptionParam.Value);
			}
			catch (TeamsChatIntegrationException e)
			{
				engine.ExitFail(
					$"Couldn't create the channel in the team with id {teamIdParam.Value} with error {e.Message}.");
				return;
			}

			channelMemoryFile.Set($"{channelNameParam.Value} ({channel.ChannelId})", channel.ChannelId);

			engine.ExitSuccess($"The channel with id {channel.ChannelId} was created in the team with id {channel.TeamId}!");
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