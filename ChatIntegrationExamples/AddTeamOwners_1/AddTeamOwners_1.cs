using System;
using System.Linq;
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

			var teamOwnersToAddParam = engine.GetScriptParam("Team Owners to Add (; separated)");
			if (string.IsNullOrWhiteSpace(teamOwnersToAddParam?.Value))
			{
				engine.ExitFail("'Team Owners to Add (; separated)' parameter is required.");
				return;
			}

			// Create an array with the emails, remove empty values, remove leading & trailing spaces, remove duplicates, remove invalid emails (no @, no ., or less than 5 chars (x@x.x))
			var teamOwnersToAdd = teamOwnersToAddParam.Value
				.Split(';')
				.Select(v => v.Trim())
				.Where(v => !string.IsNullOrWhiteSpace(v) && v.Length >= 5 && v.Contains("@") && v.Contains("."))
				.ToList()
				.Distinct()
				.ToArray();

			if (teamOwnersToAdd.Length == 0)
			{
				engine.ExitFail("No owners given to add to the team.");
				return;
			}

			try
			{
				chatIntegrationHelper.Teams.TryAddTeamOwners(teamIdParam.Value, teamOwnersToAdd);
			}
			catch (TeamsChatIntegrationException e)
			{
				engine.ExitFail(
					$"Couldn't add the owners [{string.Join(", ", teamOwnersToAdd)}] to the team with id {teamIdParam.Value} with error {e.Message}.");
				return;
			}

			engine.ExitSuccess($"The owners [{string.Join(", ", teamOwnersToAdd)}] are added to the team with id {teamIdParam.Value}!");
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