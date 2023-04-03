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
			var teamsMemoryFile = engine.GetMemory("Teams");
			if (teamsMemoryFile == null)
			{
				engine.ExitFail("'Teams' memory file is required.");
				return;
			}

			IEnumerable<ITeam> teams;
			try
			{
				teams = chatIntegrationHelper.Teams.TryGetTeams();
			}
			catch (TeamsChatIntegrationException e)
			{
				engine.ExitFail($"Couldn't fetch the teams with error {e.Message}.");
				return;
			}

			teamsMemoryFile.Clear();
			foreach (var team in teams)
			{
				teamsMemoryFile.Set($"{team.DisplayName} ({team.TeamId})", team.TeamId);
			}

			engine.ExitSuccess("The fetched teams were saved in the 'Teams' memory file!");
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