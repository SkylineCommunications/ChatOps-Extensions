# Custom Commands

This readme details how to create custom DataMiner bot commands using Automation scripts.

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
    * [Output an Adaptive Card](#output-an-adaptive-card)
    * [Output an Adaptive Card with buttons](#output-an-adaptive-card-with-buttons)
    * [Output Key-Values](#output-key-values)
    * [Output JSON](#output-json)
    * [Input Parameter](#input-parameter)
    * [Executor Input](#executor-input)
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

The DataMiner Integration Studio Visual Studio extension (also referred to as DIS) can be used for development of Automation scripts. You can also use DIS to deploy Automation scripts directly from your development environment to your DataMiner Systems.

See [Installing DataMiner Integration Studio](https://aka.dataminer.services/DisInstallation).

> ℹ️
> We recommend that you always use the latest version of the DataMiner Integration Studio Visual Studio extension.

### Usage

#### General

- The DataMiner System must be cloud-connected. See [Connecting your DataMiner System to the cloud](https://docs.dataminer.services/user-guide/Cloud_Platform/AboutCloudPlatform/Connecting_your_DataMiner_System_to_the_cloud.html).

- The CoreGateway module must be updated to at least version 2.11.0 (which is available since [Cloud Pack 2.8.0](https://community.dataminer.services/dataminer-cloud-pack/)). See [Upgrading nodes to the latest DxM versions](https://aka.dataminer.services/managing-cloud-connected-nodes).

- The FieldControl module must be updated to at least version 2.8.1 (which is available since [Cloud Pack 2.8.0](https://community.dataminer.services/dataminer-cloud-pack/)). See [Upgrading nodes to the latest DxM versions](https://aka.dataminer.services/managing-cloud-connected-nodes).

#### Microsoft Teams

- The [DataMiner bot](https://teams.microsoft.com/l/app/9a09d087-5d07-4481-b34f-cd053eab7925) must be allowed in your [Microsoft Teams](https://docs.microsoft.com/en-us/microsoftteams/manage-apps).

- The [DataMiner bot](https://teams.microsoft.com/l/app/9a09d087-5d07-4481-b34f-cd053eab7925) must be installed in your team or chat. See [Installing the DataMiner Teams bot](https://docs.dataminer.services/user-guide/Cloud_Platform/TeamsBot/DataMiner_Teams_bot.html#dataminer-teams-bot-installation).

- [Start a conversation with the DataMiner bot](https://docs.dataminer.services/user-guide/Cloud_Platform/TeamsBot/DataMiner_Teams_bot.html#starting-a-conversation-with-the-teams-bot) by logging in and setting your active DataMiner System. When you execute your first (custom) command to the active DMS, the DataMiner bot will ask you to link your DCP account to your DataMiner account if this has not been done yet.

- Only Automation scripts that are present in a (sub)folder with the name '*bot*' will be recognized as custom commands by the DataMiner bot. The examples below are automatically placed in such a folder.

## Examples

### General

- The code for these Automation scripts can be found in [the CustomCommandExamples folder](). Note that these examples are kept very simple, without user input, and they only demonstrate how to form different types of output to be displayed by the DataMiner bot. For more information about what Automation scripts can do, see [Automation](https://docs.dataminer.services/user-guide/Advanced_Modules/Automation/automation.html).

### Microsoft Teams

#### Getting Started

1. [Deploy the latest version of the Custom Commands Examples package via the Catalog](https://catalog.dataminer.services/details/package/5863) or [download the package as a ZIP](https://github.com/SkylineCommunications/ChatOps-Extensions/files/14334384/Custom.Command.Examples.1.3.0.zip), unzip it, and [deploy it to your DataMiner System locally](https://aka.dataminer.services/installing-application-packages). Installing this package will add the custom command Automation scripts for Microsoft Teams in the Automation module.

   > :warning:
   > Installing this DMAPP will overwrite any Automation scripts with identical names.

#### Output an Adaptive Card

1. In Teams, execute the command '*run Adaptive Card Output Example*' and click the '*Run*' button in the response.

2. The custom command will be executed and the Adaptive Card example should be displayed as the response. <details><summary>`show demo`</summary>![Gif-OutputAnAdaptiveCard](https://user-images.githubusercontent.com/33500507/192817296-cd05a0cb-2267-4639-8d21-32b54bb347cd.gif)</details>

#### Output an Adaptive Card with buttons

1. First make sure that you fill in the organization ID and DMS ID in the Automation script named '*Adaptive Card Output Example with buttons*'. You can find these IDs in the URL by opening the DMS overview in the [Admin app](https://admin.dataminer.services). An example is provided in the Automation script.
   
2. In Teams, execute the command '*run Adaptive Card Output Example with buttons*' and click the '*Run*' button in the response.

3. The custom command will be executed and the Adaptive Card example with buttons should be displayed as the response. <details><summary>`show demo`</summary>![Gif-OutputAnAdaptiveCardWithButtons](https://github.com/SkylineCommunications/ChatOps-Extensions/assets/33500507/4a422789-f961-47c2-8164-c76ed117269a)</details>

#### Output Key-Values

1. In Teams, execute the command '*run Key Value Output Example*' and click the '*Run*' button in the response.

2. The custom command will be executed and the Key Value examples should be displayed as the response. <details><summary>`show demo`</summary>![Gif-OutputKeyValues](https://user-images.githubusercontent.com/33500507/192817311-75f6e7c0-0c91-45e1-9f58-30783fb67ddf.gif)</details>

#### Output JSON

1. In Teams, execute the command '*run JSON Output Example*' and click the '*Run*' button in the response.

2. The custom command will be executed and the JSON example should be displayed as the response. <details><summary>`show demo`</summary>![Gif-OutputJson](https://user-images.githubusercontent.com/33500507/192817316-fc4de34d-a34e-42cd-a5fa-e8e99b363c2d.gif)</details>

#### Input Parameter

1. In Teams, execute the command '*run Parameter Input Example*'.

2. When you are asked to provide the input configured in the Automation script, fill in any value and click the '*Run*' button.

   The custom command will be executed, and the provided input value should be displayed as the response. <details><summary>`show demo`</summary>![Gif-InputParameter](https://user-images.githubusercontent.com/33500507/233356486-bc64d385-997e-4b1b-8466-e26c801a7e4d.gif)</details>

#### Executor Input

1. In Teams, execute the command '*run Executor Input Example*'.

2. You won't be asked to provide the 'dataminer.services User Email' input configured in the Automation script, the DataMiner bot will provide this automatically when you click the '*Run*' button.

   The custom command will be executed, and the executor's information should be displayed as the response. <details><summary>`show demo`</summary>![Gif-ExecutorInput](https://github.com/SkylineCommunications/ChatOps-Extensions/assets/33500507/15646c6d-76ab-4008-86b8-ca0d199ea87f)</details>

## Help

[Skyline Communications: Support](https://aka.dataminer.services/tech-support)

## Contact

[Skyline Communications: Contact](https://aka.dataminer.services/contact)

## Version History

[Releases](https://github.com/SkylineCommunications/ChatOpts-Extensions/releases)

## License

This project is licensed under the [MIT License](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/LICENSE) – see the file for details.
