# Chat Integration

This guideline is about how to integrate DataMiner into business communication platforms with automation scripts.

## Table of Contents

- [Prerequisites](#prerequisites)
  - [General](#general)
  - [Microsoft Teams](#microsoft-teams)
  - [Slack](#slack) 
- [Getting Started](#getting-started)
  - [Microsoft Teams](#getting-started) 
  - [Slack](#getting-started) 
- [Examples](#examples)
  - [Microsoft Teams](#examples) 
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

### General

- The DataMiner System must be cloud-connected, i.e. [connecting it to the DataMiner Cloud Platform](https://docs.dataminer.services/user-guide/Cloud_Platform/AboutCloudPlatform/Connecting_your_DataMiner_System_to_the_cloud.html).

- The CloudGateway Module must be updated to at least version 2.9.0, i.e. [upgrading the installed DxM versions on your DataMiner System](https://docs.dataminer.services/user-guide/Cloud_Platform/CloudAdminApp/Managing_cloud-connected_nodes.html).


### Microsoft Teams

- The DataMiner App must be allowed in your Team on [Microsoft Teams](https://docs.microsoft.com/en-us/microsoftteams/manage-apps).

- Admin Consent must be granted in the [DCP Admin app](https://docs.dataminer.services/user-guide/Cloud_Platform/CloudAdminApp/Granting_admin_consent.html).


## Getting Started

### Microsoft Teams

- [Deploy the DMAPP]() to your DataMiner System. Installing this package, will add the automation scripts for Microsoft Teams in the Automation module.

- [Access the DataMiner System](https://docs.dataminer.services/user-guide/Getting_started/Accessing_DataMiner/Accessing_DataMiner.html) and open the Automation module (via apps > Automation).<details><summary>...</summary>
![Gif-Automation](https://user-images.githubusercontent.com/109528797/186685478-9eac1cbf-f2d9-4c9a-8a6a-a2f499dbdcd9.gif)

</details>

- Open the '*memory files*' tab and create memory files named '*Teams*', '*Channels*' and '*Chats*'. The purpose of these files is to persist the created Teams, Channels and Chats.<details><summary>...</summary>
![Gif-MemFiles](https://user-images.githubusercontent.com/109528797/186685736-dacafe23-53be-4165-8982-eb2113549d78.gif)

</details>

- Also create a memory file named YesOrNo with the following entries: *{postion:0, value:1, description:yes ; postion:1, value:0, description:no}*<details><summary>...</summary>
![Gif-MemFilesYesorNo](https://user-images.githubusercontent.com/109528797/186685771-9d9c4155-1f58-4700-98aa-90ebd19c329e.gif)

</details>

- Other automation scripts can be created here.


### Slack
- 
- 



## Examples

### Microsoft Teams

 - The code for these automation scripts can be found under [this folder](ChatIntegrationExamples) in the repository.

#### Create Team

- Open the Automation module (via apps > Automation) and click on the '*automation scripts*' tab. To create a new Team, click the '*Create Team*' automation script and fill in the desired fields, **the fields are case sensitive.**

- When pressing the '*execute now*' button, a Team (with a general Channel) is created in Microsoft Teams with the Dataminer bot.<details><summary>...</summary>
![Gif-CreateTeam](https://user-images.githubusercontent.com/109528797/186685886-ae5f1834-1c5c-438d-92e7-03740330e51d.gif)

</details>

#### Create Channel

- As a Channel exists in a Team, a Team must first be created *(see previous example)*.

- To create a new Channel, click the '*Create Channel*' automation script and choose the desired Team for this Channel.

- When pressing the '*execute now*' button, a Channel is created in Microsoft Teams with the Dataminer bot.<details><summary>...</summary>
![Gif-CreateChannel](https://user-images.githubusercontent.com/109528797/186855003-c4002e8e-c9cf-42fd-91bd-b389d4bab908.gif)


</details>

#### Add Team Members

- To add a new member or members to a Team, click the '*Add Team Members*' automation script and select the desired Team.

- When pressing the '*execute now*' button, the members are added to a Team in Microsoft Teams.<details><summary>...</summary>
![Gif-AddTeamMember](https://user-images.githubusercontent.com/109528797/186880110-4fb9a616-b647-4919-9556-4a057a65be2b.gif)


</details>

#### Add Team Owner

- To add a new owner to a Team, click the '*Add Team Owners*' automation script and select the desired Team.

- When pressing the '*execute now*' button, a owner is added to a Team in Microsoft Teams.<details><summary>...</summary>
![Gif-AddTeamOwner](https://user-images.githubusercontent.com/109528797/187139084-f2991b40-cbe2-46fe-aec9-c804b9852e62.gif)


</details>

#### Send Channel Notification

- To send a notification in a Channel, click the '*Send Channel Notification*' automation script and choose the desired Channel for this notification.

- When pressing the '*execute now*' button, a Channel is created in Microsoft Teams with the Dataminer bot.<details><summary>...</summary>
![Gif-SendNotification](https://user-images.githubusercontent.com/109528797/187139103-4728e148-204d-447f-9674-8d74f4e373d1.gif)


</details>

## Help

Any advise for common problems or issues.

## Contact

[@Jordy Ampe](https://github.com/JordyGit)  
[@RobbertVH](https://github.com/RobbertVH)

Project Link: [Chat-integration](https://github.com/SkylineCommunications/chat-integration)

## Version History

- 1.0
  - Initial Release

## License

This project is licensed under the [MIT License](https://github.com/SkylineCommunications/chat-integration/blob/main/LICENSE) - see the file for details
