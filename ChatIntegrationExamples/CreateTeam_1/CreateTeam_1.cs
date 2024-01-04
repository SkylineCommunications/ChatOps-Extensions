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
			var ownerEmailParam = engine.GetScriptParam("Team Owner Email");
			if (string.IsNullOrWhiteSpace(ownerEmailParam?.Value))
			{
				engine.ExitFail("'Team Owner Email' parameter is required.");
				return;
			}

			var teamNameParam = engine.GetScriptParam("Team Name");
			if (string.IsNullOrWhiteSpace(teamNameParam?.Value))
			{
				engine.ExitFail("'Team Name' parameter is required.");
				return;
			}

			var teamsMemoryFile = engine.GetMemory("Teams");
			if (teamsMemoryFile == null)
			{
				engine.ExitFail("'Teams' memory file is required.");
				return;
			}

			ITeam team;
			try
			{
				team = chatIntegrationHelper.Teams.TryCreateTeam(teamNameParam.Value, ownerEmailParam.Value);
			}
			catch (TeamsChatIntegrationException e)
			{
				engine.ExitFail($"Couldn't create the team with error {e.Message}.");
				return;
			}

			teamsMemoryFile.Set($"{team.DisplayName} ({team.TeamId})", team.TeamId);

			engine.ExitSuccess($"The team with ID {team.TeamId} should be created soon!");
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