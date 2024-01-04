using AdaptiveCards;
using Skyline.DataMiner.DcpChatIntegrationHelper.Common;
using Skyline.DataMiner.DcpChatIntegrationHelper.Teams;

namespace SendChannelNotificationCard_1
{
	using System;
	using System.Collections.Generic;
	using Skyline.DataMiner.Automation;
	
	/// <summary>
	/// Represents a DataMiner Automation script.
	/// </summary>
	public class Script
	{
		/// <summary>
		/// The script entry point.
		/// </summary>
		/// <param name="engine">Link with SLAutomation process.</param>
		public void Run(IEngine engine)
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

				var channelIdParam = engine.GetScriptParam("Channel Id");
				if (string.IsNullOrWhiteSpace(channelIdParam?.Value))
				{
					engine.ExitFail("'Channel Id' parameter is required.");
					return;
				}

				var notificationParam = engine.GetScriptParam("Notification");
				if (string.IsNullOrWhiteSpace(notificationParam?.Value))
				{
					engine.ExitFail("'Notification' parameter is required.");
					return;
				}

				var adaptiveCardBody = new List<AdaptiveElement>()
				{
					// The text notification from the input field
					new AdaptiveTextBlock(notificationParam.Value)
					{
						Wrap = true
					},
					// Some additional examples
					new AdaptiveFactSet()
					{
						Facts = new List<AdaptiveFact>
						{
							new AdaptiveFact("Name:", "Uplink"),
							new AdaptiveFact("Bitrate:", "3 mb/s")
						},
					},
					new AdaptiveFactSet()
					{
						Facts = new List<AdaptiveFact>
						{
							new AdaptiveFact("Name:", "Downlink"),
							new AdaptiveFact("Bitrate:", "19 mb/s")
						},
					},
					new AdaptiveImage("https://skyline.be/sites/default/files/inline-images/DataMinerbySLC_Q.png"),
				};

				try
				{
					chatIntegrationHelper.Teams.TrySendChannelNotification(teamIdParam.Value, channelIdParam.Value, adaptiveCardBody);
				}
				catch (TeamsChatIntegrationException e)
				{
					engine.ExitFail($"Couldn't send the notification card to the channel with id {channelIdParam.Value} with error {e.Message}.");
					return;
				}

				engine.ExitSuccess($"The notification card was sent to the channel with id {channelIdParam.Value}!");
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
}