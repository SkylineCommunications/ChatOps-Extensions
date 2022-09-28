# Custom Commands

This readme details how to create custom DataMiner bot commands using Automation scripts.

## Table of Contents

- [Prerequisites](#prerequisites)
  - [Development](#Development)
    - [DataMiner Integration Studio Visual Studio Extension](#dataminer-integration-studio-visual-studio-extension)
  - [Usage](#Usage)
    - [General](#general)
    - [Microsoft Teams](#microsoft-teams)
- [Examples](#examples)
  - [General](#general-1)
  - [Microsoft Teams](#microsoft-teams-1) 
    * [Getting Started](#getting-started)
    * [Creating a Team](#creating-a-team)
- [Help](#help)
- [Contact](#contact)
- [Version History](#version-history)
- [License](#license)

## Prerequisites

### Development

#### DataMiner Integration Studio Visual Studio Extension

The DataMiner Integration Studio Visual Studio extension (also referred to as DIS) is required for development of Automation scripts using the [Skyline.DataMiner.DcpChatIntegrationHelper NuGet package](#skylinedataminerdcpchatintegrationhelper-nuget-package). You can also use DIS to deploy Automation scripts directly from your development environment to your DataMiner Systems.

See [Installing DataMiner Integration Studio](https://aka.dataminer.services/DisInstallation).

> ℹ️
> We recommend that you always use the latest version of the DataMiner Integration Studio Visual Studio extension.

### Usage

#### General

- The DataMiner System must be cloud-connected. See [Connecting your DataMiner System to the cloud](https://docs.dataminer.services/user-guide/Cloud_Platform/AboutCloudPlatform/Connecting_your_DataMiner_System_to_the_cloud.html).

- The CoreGateway module must be updated to at least version 2.11.0 (which is available since [Cloud Pack 2.8.0](https://community.dataminer.services/downloads/)). See [Upgrading nodes to the latest DxM versions](https://docs.dataminer.services/user-guide/Cloud_Platform/CloudAdminApp/Managing_cloud-connected_nodes.html).

- The FieldControl module must be updated to at least version 2.8.1 (which is available since [Cloud Pack 2.8.0](https://community.dataminer.services/downloads/)). See [Upgrading nodes to the latest DxM versions](https://docs.dataminer.services/user-guide/Cloud_Platform/CloudAdminApp/Managing_cloud-connected_nodes.html).

#### Microsoft Teams

- The [DataMiner bot](https://teams.microsoft.com/l/app/9a09d087-5d07-4481-b34f-cd053eab7925) must be allowed in your [Microsoft Teams](https://docs.microsoft.com/en-us/microsoftteams/manage-apps).

- [Admin consent must be granted](https://docs.dataminer.services/user-guide/Cloud_Platform/CloudAdminApp/Granting_admin_consent.html) in the [DCP Admin app](https://admin.dataminer.services).

## Examples

### General

- The code for these Automation scripts can be found in [the CustomCommandExamples folder](CustomCommandExamples).

### Microsoft Teams

#### Getting Started

1. [Download this DMAPP]() and [deploy it to your DataMiner System](https://docs.dataminer.services/develop/TOOLS/TOOApplicationPackages/Installing_an_app_package.html). Installing this package will add the custom command Automation scripts for Microsoft Teams in the Automation module.

   > :warning:
   > Note that reinstalling this DMAPP will overwrite any Automation scripts and memory files with identical names.

2. [Open DataMiner Cube](https://docs.dataminer.services/user-guide/Getting_started/Accessing_DataMiner/Accessing_DataMiner_Cube.html) and open the Automation module (via apps > Automation). The added Automation scripts will be shown there. <details><summary>`show demo`</summary>![Gif-Automation](https://user-images.githubusercontent.com/109528797/186685478-9eac1cbf-f2d9-4c9a-8a6a-a2f499dbdcd9.gif)</details>

#### Creating a Team

1. In the Automation module in DataMiner Cube, click the '*Create Team Example*' Automation script and click the '*Execute*' button.

2. Fill in the necessary information. Note that the **fields are case sensitive**.

   - *Team Owner Email*: The email address of the owner of the team you are creating.
   - *Team Name*: The name of the team you are creating.
   - *Teams*: Select the memory file the script should use to save the ID of the team you are creating.

3. Click the '*execute now*' button.  A team (with a General channel) will be created in Microsoft Teams. The [DataMiner bot](https://teams.microsoft.com/l/app/9a09d087-5d07-4481-b34f-cd053eab7925) will also be installed. <details><summary>`show demo`</summary>![Gif-CreateTeam](https://user-images.githubusercontent.com/109528797/186685886-ae5f1834-1c5c-438d-92e7-03740330e51d.gif)</details>

## Help

[Skyline Communications: Support](https://skyline.be/contact/tech-support)

## Contact

[Skyline Communications: Contact](https://skyline.be/contact)

## Version History

[Releases](https://github.com/SkylineCommunications/ChatOpts-Extensions/releases)

## License

This project is licensed under the [MIT License](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/LICENSE) – see the file for details.
