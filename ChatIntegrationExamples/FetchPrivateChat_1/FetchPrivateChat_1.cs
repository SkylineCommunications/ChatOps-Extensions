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

			var chatsMemoryFile = engine.GetMemory("ChatsExample");
			if (chatsMemoryFile == null)
			{
				engine.ExitFail("'ChatsExample' memory file is required.");
				return;
			}

			IChat chat;
			try
			{
				chat = chatIntegrationHelper.Teams.TryGetPrivateChat(emailParam.Value);
			}
			catch (TeamsChatIntegrationException e)
			{
				engine.ExitFail($"Couldn't fetch the chat with error {e.Message}.");
				return;
			}

			chatsMemoryFile.Set($"{chat.DisplayName} ({chat.Type} - {chat.ChatId})", chat.ChatId);

			engine.ExitSuccess("The fetched private chat was saved in the 'ChatsExample' memory file!");
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