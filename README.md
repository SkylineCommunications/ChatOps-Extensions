# Chat Integration

This guideline is about how to integrate DataMiner into business communication platforms with automation scripts.

## Table of Contents

- [Prerequisites](#prerequisites)
  - [Development](#Development)
    - [Skyline.DataMiner.DcpChatIntegrationHelper NuGet Package](#skyline.dataminer.dcpchatintegrationhelper-nuget-package)
    - [DataMiner Integration Studio Visual Studio Extension](#dataminer-integration-studio-visual-studio-extension)
  - [Usage](#Usage)
    - [General](#general)
    - [Microsoft Teams](#microsoft-teams)
- [Examples](#examples)
  - [General](#general-1)
  - [Microsoft Teams](#microsoft-teams-1) 
    * [Getting Started](#getting-started)
    * [Create Team](#create-team)
    * [Create Channel](#create-channel)
    * [Add Members](#add-team-members)
    * [Add Owner](#add-team-owner)
    * [Send Channel Notification](#send-channel-notification)
- [Help](#help)
- [Contact](#contact)
- [Version History](#version-history)
- [License](#license)

## Prerequisites

### Development

#### Skyline.DataMiner.DcpChatIntegrationHelper NuGet Package

The Skyline.DataMiner.DcpChatIntegrationHelper NuGet Package can be found on [nuget.org](https://nuget.org). This nuget package allows to easily integrate with business communication platforms from a DataMiner Automation script.

> ℹ️
> We recommend that you always use the latest version of the Skyline.DataMiner.DcpChatIntegrationHelper NuGet Package.

#### DataMiner Integration Studio Visual Studio Extension

The DataMiner Integration Studio Visual Studio extension (also refered to as DIS) is required for development of Automation scripts using the [Skyline.DataMiner.DcpChatIntegrationHelper NuGet Package](#skyline.dataminer.dcpchatintegrationhelper-nuget-package). DIS can also be used to deploy your code directly to your DataMiner Systems.

See [Installing DataMiner Integration Studio](https://aka.dataminer.services/DisInstallation).

> ℹ️
> We recommend that you always use the latest version of the DataMiner Integration Studio Visual Studio extension.

### Usage

#### General

- The DataMiner System must be cloud-connected, i.e. [connecting it to the DataMiner Cloud Platform](https://docs.dataminer.services/user-guide/Cloud_Platform/AboutCloudPlatform/Connecting_your_DataMiner_System_to_the_cloud.html).

- The CloudGateway Module must be updated to at least version 2.9.0, i.e. [upgrading the installed DxM versions on your DataMiner System](https://docs.dataminer.services/user-guide/Cloud_Platform/CloudAdminApp/Managing_cloud-connected_nodes.html).

#### Microsoft Teams

- The DataMiner App must be allowed in your Team on [Microsoft Teams](https://docs.microsoft.com/en-us/microsoftteams/manage-apps).

- Admin Consent must be granted in the [DCP Admin app](https://docs.dataminer.services/user-guide/Cloud_Platform/CloudAdminApp/Granting_admin_consent.html).

## Examples

### General

- The code for these automation scripts can be found under [this folder](ChatIntegrationExamples).

### Microsoft Teams

#### Getting Started

- [Deploy the DMAPP]() to your DataMiner System. Installing this package, will add the automation scripts for Microsoft Teams in the Automation module and some memory files which will be used by the automation scripts to save the IDs of the created resources.

- [Access the DataMiner System](https://docs.dataminer.services/user-guide/Getting_started/Accessing_DataMiner/Accessing_DataMiner.html) and open the Automation module (via apps > Automation). The added automation scripts are shown here. <details><summary>`show demo`</summary>![Gif-Automation](https://user-images.githubusercontent.com/109528797/186685478-9eac1cbf-f2d9-4c9a-8a6a-a2f499dbdcd9.gif)</details>

#### Create Team

- Open the Automation module (via apps > Automation) and click on the '*automation scripts*' tab. To create a new Team, click the '*Create Team*' automation script and fill in the desired fields, **the fields are case sensitive.**

- When pressing the '*execute now*' button, a Team (with a general Channel) is created in Microsoft Teams with the Dataminer bot. <details><summary>`show demo`</summary>![Gif-CreateTeam](https://user-images.githubusercontent.com/109528797/186685886-ae5f1834-1c5c-438d-92e7-03740330e51d.gif)</details>

#### Create Channel

- As a Channel exists in a Team, a Team must first be created *(see previous example)*.

- To create a new Channel, click the '*Create Channel*' automation script and choose the desired Team for this Channel.

- When pressing the '*execute now*' button, a Channel is created in Microsoft Teams with the Dataminer bot. <details><summary>`show demo`</summary>![Gif-CreateChannel](https://user-images.githubusercontent.com/109528797/186855003-c4002e8e-c9cf-42fd-91bd-b389d4bab908.gif)</details>

#### Add Team Members

- To add a new member or members to a Team, click the '*Add Team Members*' automation script and select the desired Team.

- When pressing the '*execute now*' button, the members are added to a Team in Microsoft Teams. <details><summary>`show demo`</summary>![Gif-AddTeamMember](https://user-images.githubusercontent.com/109528797/186880110-4fb9a616-b647-4919-9556-4a057a65be2b.gif)</details>

#### Add Team Owner

- To add a new owner to a Team, click the '*Add Team Owners*' automation script and select the desired Team.

- When pressing the '*execute now*' button, a owner is added to a Team in Microsoft Teams. <details><summary>`show demo`</summary>![Gif-AddTeamOwner](https://user-images.githubusercontent.com/109528797/187139084-f2991b40-cbe2-46fe-aec9-c804b9852e62.gif)</details>

#### Send Channel Notification

- To send a notification in a Channel, click the '*Send Channel Notification*' automation script and choose the desired Channel for this notification.

- When pressing the '*execute now*' button, a notification is sent in Microsoft Teams.<details><summary>`show demo`</summary>![Gif-SendNotification](https://user-images.githubusercontent.com/109528797/187139103-4728e148-204d-447f-9674-8d74f4e373d1.gif)</details>

## Help

[Skyline Communications: Support](https://skyline.be/contact/tech-support) 

## Contact

[Skyline Communications: Contact](https://skyline.be/contact) 

## Version History

[Releases](https://github.com/SkylineCommunications/chat-integration/releases)

## License

This project is licensed under the [MIT License](https://github.com/SkylineCommunications/chat-integration/blob/main/LICENSE) - see the file for details
