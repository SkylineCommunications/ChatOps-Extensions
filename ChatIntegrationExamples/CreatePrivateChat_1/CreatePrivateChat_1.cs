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
			var emailParam = engine.GetScriptParam("User Email");
			if (string.IsNullOrWhiteSpace(emailParam?.Value))
			{
				engine.ExitFail("'User Email' parameter is required.");
				return;
			}

			try
			{
				chatIntegrationHelper.Teams.TryCreatePrivateChat(emailParam.Value);
			}
			catch (TeamsChatIntegrationException e)
			{
				engine.ExitFail($"Couldn't create the private chat with error {e.Message}.");
				return;
			}

			engine.ExitSuccess($"The private chat with {emailParam.Value} was created successfully.");
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