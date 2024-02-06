# Chat Integration

This readme details how to integrate DataMiner into business communication platforms with Automation scripts.

## Table of Contents

- [Prerequisites](#prerequisites)
  - [Development](#Development)
    - [Skyline.DataMiner.DcpChatIntegrationHelper NuGet Package](#skylinedataminerdcpchatintegrationhelper-nuget-package)
    - [DataMiner Integration Studio Visual Studio Extension](#dataminer-integration-studio-visual-studio-extension)
  - [Usage](#Usage)
    - [General](#general)
    - [Microsoft Teams](#microsoft-teams)
- [Examples](#examples)
  - [General](#general-1)
  - [Microsoft Teams](#microsoft-teams-1) 
    * [Getting Started](#getting-started)
    * [Creating a Team](#creating-a-team)
    * [Fetching all Teams](#fetching-all-teams)
    * [Creating a Channel](#creating-a-channel)
    * [Fetching all Channels of a Team](#fetching-all-channels-of-a-team)
    * [Adding Team Members](#adding-team-members)
    * [Adding Team Owners](#adding-team-owners)
    * [Sending a Channel Notification](#sending-a-channel-notification)
    * [Sending a Channel Notification using an Adaptive Card](#sending-a-channel-notification-using-an-adaptive-card)
    * [Sending a Channel Notification using an Adaptive Card with buttons](#sending-a-channel-notification-using-an-adaptive-card-with-buttons)
    * [Creating a Private Chat](#creating-a-private-chat)
    * [Fetching a Private Chat](#fetching-a-private-chat)
    * [Sending a Chat Notification](#sending-a-chat-notification)
    * [Sending a Chat Notification using an Adaptive Card](#sending-a-chat-notification-using-an-adaptive-card)
    * [Sending a Chat Notification using an Adaptive Card with buttons](#sending-a-chat-notification-using-an-adaptive-card-with-buttons)
- [Help](#help)
- [Contact](#contact)
- [Version History](#version-history)
- [License](#license)

## Prerequisites

### Development

#### Skyline.DataMiner.DcpChatIntegrationHelper NuGet Package

The [Skyline.DataMiner.DcpChatIntegrationHelper NuGet package can be found on nuget.org](https://www.nuget.org/packages/Skyline.DataMiner.DcpChatIntegrationHelper). This NuGet package allows easy integration with business communication platforms from a DataMiner Automation script.

> ℹ️
> We recommend that you always use the latest version of the Skyline.DataMiner.DcpChatIntegrationHelper NuGet package.

#### DataMiner Integration Studio Visual Studio Extension

The DataMiner Integration Studio Visual Studio extension (also referred to as DIS) is required for development of Automation scripts using the [Skyline.DataMiner.DcpChatIntegrationHelper NuGet package](#skylinedataminerdcpchatintegrationhelper-nuget-package). You can also use DIS to deploy Automation scripts directly from your development environment to your DataMiner Systems.

See [Installing DataMiner Integration Studio](https://aka.dataminer.services/DisInstallation).

> ℹ️
> We recommend that you always use the latest version of the DataMiner Integration Studio Visual Studio extension.

### Usage

#### General

- The DataMiner System must be cloud-connected. See [Connecting your DataMiner System to the cloud](https://aka.dataminer.services/connect-to-the-cloud).

- The CloudGateway module must be updated to at least version 2.9.0. See [Upgrading nodes to the latest DxM versions](https://aka.dataminer.services/managing-cloud-connected-nodes).

#### Microsoft Teams

- The [DataMiner bot](https://teams.microsoft.com/l/app/9a09d087-5d07-4481-b34f-cd053eab7925) must be allowed in your [Microsoft Teams](https://docs.microsoft.com/en-us/microsoftteams/manage-apps).

- [Admin consent must be granted](https://aka.dataminer.services/chat-integration-admin-consent) in the [Admin app](https://admin.dataminer.services).

## Examples

### General

- The code for these Automation scripts can be found in [the ChatIntegrationExamples folder]().

### Microsoft Teams

#### Getting Started

1. [Deploy the latest version of the ChatIntegration Examples package via the Catalog](https://catalog.dataminer.services/catalog/3129) or [download the package as a ZIP](https://github.com/SkylineCommunications/ChatOps-Extensions/files/14181236/DcpChatIntegrationEx.1.1.1.zip), unzip it, and [deploy it to your DataMiner System locally](https://aka.dataminer.services/installing-application-packages). Installing this package will add the example Automation scripts for Microsoft Teams in the Automation module along with some memory files that will be used by the Automation scripts to save the IDs of the created and fetched resources.

   > :warning:
   > Installing this DMAPP will overwrite any Automation scripts and memory files with identical names.

2. [Open DataMiner Cube](https://aka.dataminer.services/accessing-cube) and open the Automation module (via apps > Automation). The added Automation scripts will be shown there. <details><summary>`show demo`</summary>![Gif-Automation](https://user-images.githubusercontent.com/109528797/186685478-9eac1cbf-f2d9-4c9a-8a6a-a2f499dbdcd9.gif)</details>

#### Creating a Team

1. In the Automation module in DataMiner Cube, click the '*Create Team Example*' Automation script and click the '*Execute*' button.

2. Fill in the necessary information. Note that the **fields are case sensitive**.

   - *Team Owner Email*: The email address of the owner of the team you are creating.
   - *Team Name*: The name of the team you are creating.
   - *Teams*: Select the memory file the script should use to save the ID of the team you are creating.

3. Click the '*execute now*' button. A team (with a General channel) will be created in Microsoft Teams and a reference will be saved in the *Teams* memory file. The [DataMiner bot](https://teams.microsoft.com/l/app/9a09d087-5d07-4481-b34f-cd053eab7925) will also be installed. <details><summary>`show demo`</summary>![Gif-CreateTeam](https://user-images.githubusercontent.com/109528797/186685886-ae5f1834-1c5c-438d-92e7-03740330e51d.gif)</details>

#### Fetching all Teams

1. In the Automation module in DataMiner Cube, click the '*Fetch Teams Example*' Automation script and click the '*Execute*' button.

2. Fill in the necessary information.

   - *Teams*: Select the memory file the script should use to save the IDs of the teams you are fetching.

3. Click the '*execute now*' button. All the teams will be fetched from Microsoft Teams and their reference will be saved in the *Teams* memory file. <details><summary>`show demo`</summary>![Gif-FetchAllTeams](https://user-images.githubusercontent.com/33500507/227512024-c5e044ed-c2b2-4af2-8397-112c11d6d60e.gif)</details>

#### Creating a Channel

1. First make sure [a team is created as detailed above](#creating-a-team), as a channel can only exist within a team.

2. In the Automation module in DataMiner Cube, click the '*Create Channel Example*' Automation script and click the '*Execute*' button.

3. Fill in the necessary information. Note that the **fields are case sensitive**.

   - *Team ID*: The ID of the team that should contain the channel.
   - *Channel Name*: The name of the channel you are creating.
   - *Channel Description*: The description of the channel you are creating.
   - *Channels*: Select the memory file the script should use to save the ID of the channel you are creating.

4. Click the '*execute now*' button. A channel will be created in Microsoft Teams and a reference will be saved in the *Channels* memory file. <details><summary>`show demo`</summary>![Gif-CreateChannel](https://user-images.githubusercontent.com/109528797/186855003-c4002e8e-c9cf-42fd-91bd-b389d4bab908.gif)</details>

#### Fetching all Channels of a Team

1. In the Automation module in DataMiner Cube, click the '*Fetch Channels Example*' Automation script and click the '*Execute*' button.

2. Fill in the necessary information.

   - *Team ID*: The ID of the team that you want to fetch the channels from.
   - *Channels*: Select the memory file the script should use to save the IDs of the channels you are fetching.

3. Click the '*execute now*' button. All the channels of the given team will be fetched from Microsoft Teams and their reference will be saved in the *Channels* memory file. <details><summary>`show demo`</summary>![Gif-FetchAllChannelsOfATeam](https://user-images.githubusercontent.com/33500507/227512092-af755ec7-0641-4a90-b58e-f2c02a8a5d8d.gif)</details>

#### Adding Team Members

To add a new member or members to a team:

1. First make sure [a team is created as detailed above](#creating-a-team), as members can only exist within a team.

2. In the Automation module in DataMiner Cube, click the '*Add Team Members Example*' Automation script and click the '*Execute*' button.

3. Fill in the necessary information. Note that the **fields are case sensitive**.

   - *Team ID*: The ID of the team where you want to add one or more new members.
   - *Team Members to Add*: The email addresses of the members, separated by semicolons (";").

4. Click the '*execute now*' button. The members will be added to the team in Microsoft Teams. <details><summary>`show demo`</summary>![Gif-AddTeamMember](https://user-images.githubusercontent.com/109528797/186880110-4fb9a616-b647-4919-9556-4a057a65be2b.gif)</details>

#### Adding Team Owners

To add a new owner or owners to a team:

1. First make sure [a team is created as detailed above](#creating-a-team), as owners can only exist within a team.

2. In the Automation module in DataMiner Cube, click the '*Add Team Owners Example*' Automation script and click the '*Execute*' button.

3. Fill in the necessary information. Note that the **fields are case sensitive**.

   - *Team ID*: The ID of the team where you want to add one or more new owners.
   - *Team Owners to Add*: The email addresses of the new owners, separated by semicolons (";").

4. Click the '*execute now*' button. An owner will be added to the team in Microsoft Teams. <details><summary>`show demo`</summary>![Gif-AddTeamOwner](https://user-images.githubusercontent.com/109528797/187139084-f2991b40-cbe2-46fe-aec9-c804b9852e62.gif)</details>

#### Sending a Channel Notification

To send a notification in a channel:

1. First make sure [a channel is created as detailed above](#creating-a-channel).

2. In the Automation module in DataMiner Cube, click the '*Send Channel Notification Example*' Automation script and click the '*Execute*' button.

3. Fill in the necessary information. Note that the **fields are case sensitive**.

   - *Team ID*: The ID of the team where you want to send a notification.
   - *Channel ID*: The ID of the channel where you want to send a notification. Note that this must be a channel of the specified team.
   - *Notification*: The text of the notification.

4. Click the '*execute now*' button. A notification will be sent in the channel in Microsoft Teams. <details><summary>`show demo`</summary>![Gif-SendChannelNotification](https://user-images.githubusercontent.com/109528797/187139103-4728e148-204d-447f-9674-8d74f4e373d1.gif)</details>

#### Sending a Channel Notification using an Adaptive Card

To send a notification using an Adaptive Card in a channel:

1. First make sure [a channel is created as detailed above](#creating-a-channel).

2. In the Automation module in DataMiner Cube, click the '*Send Channel Notification Card Example*' Automation script and click the '*Execute*' button.

3. Fill in the necessary information. Note that the **fields are case sensitive**.

   - *Team ID*: The ID of the team where you want to send a notification.
   - *Channel ID*: The ID of the channel where you want to send a notification. Note that this must be a channel of the specified team.
   - *Notification*: The text of the notification.

4. Click the '*execute now*' button. An Adaptive Card notification will be sent in the channel in Microsoft Teams. <details><summary>`show demo`</summary>![Gif-SendChannelNotificationCard](https://github.com/SkylineCommunications/ChatOps-Extensions/assets/33500507/cd749909-770e-4152-bbb8-ed7855723058)</details>

#### Sending a Channel Notification using an Adaptive Card with buttons

To send a notification using an Adaptive Card with buttons in a channel:

1. First make sure that you fill in the organization ID and DMS ID in the Automation script named '*Send Channel Notification Card With Buttons Example*'. You can find these IDs in the URL by opening the DMS overview in the [Admin app](https://admin.dataminer.services). An example is provided in the Automation script.

2. Make sure [a channel is created as detailed above](#creating-a-channel).

3. In the Automation module in DataMiner Cube, click the '*Send Channel Notification Card With Buttons Example*' Automation script and click the '*Execute*' button.

4. Fill in the necessary information. Note that the **fields are case sensitive**.

   - *Team ID*: The ID of the team where you want to send a notification.
   - *Channel ID*: The ID of the channel where you want to send a notification. Note that this must be a channel of the specified team.

5. Click the '*execute now*' button. An Adaptive Card notification with buttons will be sent in the channel in Microsoft Teams. <details><summary>`show example`</summary>![SendChannelNotificationCardWithButtons](https://github.com/SkylineCommunications/ChatOps-Extensions/assets/33500507/5f0289ba-b27c-446d-8fd2-ca8caab5ff9e)</details>

#### Creating a Private Chat

1. In the Automation module in DataMiner Cube, click the '*Create Private Chat Example*' Automation script and click the '*Execute*' button.

2. Fill in the necessary information.

   - *User Email*: The email address of the user of the private chat you are creating.

3. Click the '*execute now*' button. A private chat between the given user and the DataMiner Teams Bot will be created in Microsoft Teams. <details><summary>`show demo`</summary>![Gif-CreatePrivateChat](https://user-images.githubusercontent.com/33500507/222172682-f285e5e2-2fb7-4559-8915-c884fe09c3ef.gif)</details>

#### Fetching a Private Chat

1. First make sure [a private chat is created as detailed above](#creating-a-private-chat).

2. In the Automation module in DataMiner Cube, click the '*Fetch Private Chat Example*' Automation script and click the '*Execute*' button.

3. Fill in the necessary information.

   - *Chats*: Select the memory file the script should use to save the ID of the private chat you are fetching.
   - *User Email*: The email address of the user of the private chat you are fetching.

4. Click the '*execute now*' button. The private chat between the given user and the DataMiner Teams Bot will be fetched from Microsoft Teams and a reference will be saved in the *Chats* memory file. <details><summary>`show demo`</summary>![Gif-FetchPrivateChat](https://user-images.githubusercontent.com/33500507/222172678-87e1a487-68e9-4bb5-a419-800c48cb0ef5.gif)</details>

#### Sending a Chat Notification

To send a notification in a chat:

1. First make sure [a private chat is fetched as detailed above](#fetching-a-private-chat).

2. In the Automation module in DataMiner Cube, click the '*Send Chat Notification Example*' Automation script and click the '*Execute*' button.

3. Fill in the necessary information. Note that the **fields are case sensitive**.

   - *Chat ID*: The ID of the chat where you want to send a notification.
   - *Notification*: The text of the notification.

4. Click the '*execute now*' button. A notification will be sent in the chat in Microsoft Teams. <details><summary>`show demo`</summary>![Gif-SendChatNotification](https://user-images.githubusercontent.com/33500507/222172619-89273119-c88a-42ad-b035-916a2ef9b802.gif)</details>

#### Sending a Chat Notification using an Adaptive Card

To send a notification using an Adaptive Card in a chat:

1. First make sure [a private chat is fetched as detailed above](#fetching-a-private-chat).

2. In the Automation module in DataMiner Cube, click the '*Send Chat Notification Card Example*' Automation script and click the '*Execute*' button.

3. Fill in the necessary information. Note that the **fields are case sensitive**.

   - *Chat ID*: The ID of the chat where you want to send a notification.
   - *Notification*: The text of the notification.

4. Click the '*execute now*' button. An Adaptive Card notification will be sent in the chat in Microsoft Teams. <details><summary>`show demo`</summary>![Gif-SendChatNotificationCard](https://github.com/SkylineCommunications/ChatOps-Extensions/assets/33500507/4f9f6535-ce16-46de-8353-0737a2a1b701)</details>

#### Sending a Chat Notification using an Adaptive Card with buttons

To send a notification using an Adaptive Card with buttons in a chat:

1. First make sure that you fill in the organization ID and dms ID in the Automation script named '*Send Chat Notification Card With Buttons Example*'. You can find these IDs in the URL by opening the DMS overview in the [Admin app](https://admin.dataminer.services). An example is provided in the Automation script.

2. Then make sure [a private chat is fetched as detailed above](#fetching-a-private-chat).

3. In the Automation module in DataMiner Cube, click the '*Send Chat Notification Card With Buttons Example*' Automation script and click the '*Execute*' button.

4. Fill in the necessary information. Note that the **fields are case sensitive**.

   - *Chat ID*: The ID of the chat where you want to send a notification.

5. Click the '*execute now*' button. An Adaptive Card notification with buttons will be sent in the chat in Microsoft Teams. <details><summary>`show example`</summary>![SendChatNotificationCardWithButtons](https://github.com/SkylineCommunications/ChatOps-Extensions/assets/33500507/abd1ba78-2beb-4558-b48d-ea6c5c7ee58a)</details>

## Help

[Skyline Communications: Support](https://aka.dataminer.services/tech-support)

## Contact

[Skyline Communications: Contact](https://aka.dataminer.services/contact)

## Version History

[Releases](https://github.com/SkylineCommunications/chat-integration/releases)

## License

This project is licensed under the [MIT License](https://github.com/SkylineCommunications/chat-integration/blob/main/LICENSE) – see the file for details.
