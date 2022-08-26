/*
****************************************************************************
*  Copyright (c) 2022,  Skyline Communications NV  All Rights Reserved.    *
****************************************************************************

By using this script, you expressly agree with the usage terms and
conditions set out below.
This script and all related materials are protected by copyrights and
other intellectual property rights that exclusively belong
to Skyline Communications.

A user license granted for this script is strictly for personal use only.
This script may not be used in any way by anyone without the prior
written consent of Skyline Communications. Any sublicensing of this
script is forbidden.

Any modifications to this script by the user are only allowed for
personal use and within the intended purpose of the script,
and will remain the sole responsibility of the user.
Skyline Communications will not be responsible for any damages or
malfunctions whatsoever of the script resulting from a modification
or adaptation by the user.

The content of this script is confidential information.
The user hereby agrees to keep this confidential information strictly
secret and confidential and not to disclose or reveal it, in whole
or in part, directly or indirectly to any person, entity, organization
or administration without the prior written consent of
Skyline Communications.

Any inquiries can be addressed to:

	Skyline Communications NV
	Ambachtenstraat 33
	B-8870 Izegem
	Belgium
	Tel.	: +32 51 31 35 69
	Fax.	: +32 51 31 01 29
	E-mail	: info@skyline.be
	Web		: www.skyline.be
	Contact	: Ben Vandenberghe

****************************************************************************
Revision History:

DATE		VERSION		AUTHOR			COMMENTS

03/08/2022	1.0.0.1		Jordy Ampe, Skyline	Initial version
****************************************************************************
*/

using System;
using System.Threading;
using System.Threading.Tasks;
using DcpChatIntegrationHelper;
using Skyline.DataMiner.Automation;

/// <summary>
/// DataMiner Script Class.
/// </summary>
public class Script
{
	/// <summary>
	/// The Script entry point.
	/// </summary>
	/// <param name="engine">Link with SLAutomation process.</param>
	public async Task RunAsync(Engine engine, CancellationToken cancellationToken)
	{
		ChatIntegrationHelper chatIntegrationHelper = null;
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

			var factory = new ChatIntegrationHelperFactory();
			chatIntegrationHelper = await factory.CreateAsync(
				log => engine.Log(log, LogType.Debug, 1),
				log => engine.Log(log, LogType.Information, 1),
				log => engine.Log(log, LogType.Error, 1));

			var response = await chatIntegrationHelper.Teams.TryCreateChannelAsync(teamIdParam.Value, channelNameParam.Value, channelDescriptionParam.Value, channelIsFavorite, cancellationToken);
			if (response.Error)
			{
				engine.ExitFail(
					$"Couldn't create the channel in the team with id {teamIdParam.Value} with error {response.ErrorMessage}.");
				return;
			}

			channelMemoryFile.Set($"{channelNameParam.Value} ({response.Channel.ChannelId})", response.Channel.ChannelId);

			engine.ExitSuccess($"The channel with id {response.Channel.ChannelId} was created in the team with id {response.Channel.TeamId}!");
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