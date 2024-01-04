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
			var teamIdParam = engine.GetScriptParam("Team ID");
			if (string.IsNullOrWhiteSpace(teamIdParam?.Value))
			{
				engine.ExitFail("'Team ID' parameter is required.");
				return;
			}

			var teamMembersToAddParam = engine.GetScriptParam("Team Members to Add (; separated)");
			if (string.IsNullOrWhiteSpace(teamMembersToAddParam?.Value))
			{
				engine.ExitFail("'Team Members to Add (; separated)' parameter is required.");
				return;
			}

			// Create an array with the emails, remove empty values, remove leading & trailing spaces, remove duplicates, remove invalid emails (no @, no ., or less than 5 chars (x@x.x))
			var teamMembersToAdd = teamMembersToAddParam.Value
				.Split(';')
				.Select(v => v.Trim())
				.Where(v => !string.IsNullOrWhiteSpace(v) && v.Length >= 5 && v.Contains("@") && v.Contains("."))
				.ToList()
				.Distinct()
				.ToArray();

			if (teamMembersToAdd.Length == 0)
			{
				engine.ExitFail("No members given to add to the team.");
				return;
			}

			try
			{
				chatIntegrationHelper.Teams.TryAddTeamMembers(teamIdParam.Value, teamMembersToAdd);
			}
			catch (TeamsChatIntegrationException e)
			{
				engine.ExitFail(
					$"Couldn't add the members [{string.Join(", ", teamMembersToAdd)}] to the team with ID {teamIdParam.Value} with error {e.Message}.");
				return;
			}

			engine.ExitSuccess(
				$"The members [{string.Join(", ", teamMembersToAdd)}] are added to the team with ID {teamIdParam.Value}!");
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