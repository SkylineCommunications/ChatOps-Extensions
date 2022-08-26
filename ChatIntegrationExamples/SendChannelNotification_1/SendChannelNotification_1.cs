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

04/08/2022	1.0.0.1		Jordy Ampe, Skyline	Initial version
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
	public void Run(Engine engine)
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

			var factory = new ChatIntegrationHelperFactory();
			chatIntegrationHelper = factory.Create(
				log => engine.Log(log, LogType.Debug, 1),
				log => engine.Log(log, LogType.Information, 1),
				log => engine.Log(log, LogType.Error, 1));

			var response = chatIntegrationHelper.Teams.TrySendChannelNotification(teamIdParam.Value, channelIdParam.Value, notificationParam.Value);
			if (response.Error)
			{
				engine.ExitFail($"Couldn't send the notification to the channel with id {channelIdParam.Value} with error {response.ErrorMessage}.");
				return;
			}

			engine.ExitSuccess($"The notification was sent to the channel with id {channelIdParam.Value}!");
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