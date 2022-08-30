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

			var channelIsFavoriteParam = engine.GetScriptParam("Channel Is Favorite");
			if (string.IsNullOrWhiteSpace(channelIsFavoriteParam?.Value))
			{
				engine.ExitFail("'Channel Is Favorite' parameter is required.");
				return;
			}

			// If "1", "true" or "yes" is the value it's true, otherwise false
			var channelIsFavorite = channelIsFavoriteParam.Value == "1" ||
			                        string.Equals(channelIsFavoriteParam.Value, "true", StringComparison.InvariantCultureIgnoreCase) ||
			                        string.Equals(channelIsFavoriteParam.Value, "yes", StringComparison.InvariantCultureIgnoreCase);

			var channelMemoryFile = engine.GetMemory("Channels");
			if (channelMemoryFile == null)
			{
				engine.ExitFail("'Channels' memory file is required.");
				return;
			}

			IChannel channel;

			try
			{
				channel = chatIntegrationHelper.Teams.TryCreateChannel(teamIdParam.Value, channelNameParam.Value, channelDescriptionParam.Value, channelIsFavorite);
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