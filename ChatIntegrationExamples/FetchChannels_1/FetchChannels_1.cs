using System;
using System.Collections.Generic;
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

			var channelMemoryFile = engine.GetMemory("Channels");
			if (channelMemoryFile == null)
			{
				engine.ExitFail("'Channels' memory file is required.");
				return;
			}

			IEnumerable<IChannel> channels;
			try
			{
				channels = chatIntegrationHelper.Teams.TryGetChannels(teamIdParam.Value);
			}
			catch (TeamsChatIntegrationException e)
			{
				engine.ExitFail($"Couldn't fetch the channels with error {e.Message}.");
				return;
			}

			foreach (var channel in channels)
			{
				channelMemoryFile.Set($"{channel.DisplayName} ({channel.ChannelId})", channel.ChannelId);
			}

			engine.ExitSuccess("The fetched channels were saved in the 'Channels' memory file!");
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