# Chat Integration

This guideline is about how to integrate DataMiner into business communication platforms with automation scripts.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Examples](#examples)
- [Help](#help)
- [Contact](#contact)
- [Version History](#version-history)
- [License](#license)

## Prerequisites

### General

- The DataMiner System must be connected to the DataMiner Cloud Platform ([DCP](https://docs.dataminer.services/user-guide/Cloud_Platform/AboutCloudPlatform/Connecting_your_DataMiner_System_to_the_cloud.html)).

- The CloudGateway Module ([DxM](https://docs.dataminer.services/user-guide/Cloud_Platform/CloudAdminApp/Managing_cloud-connected_nodes.html)) on your cloud-connected DataMiner System must be atleast version 2.9.0.


### Microsoft Teams

- The DataMiner App must be allowed in your Team on [Microsoft Teams](https://docs.microsoft.com/en-us/microsoftteams/manage-apps).

- [Admin Consent](https://docs.dataminer.services/user-guide/Cloud_Platform/CloudAdminApp/Granting_admin_consent.html) must be granted in the DCP admin app.


## Examples

### Microsoft Teams

#### Installation

- [Deploy the DMAPP]() to your DataMiner System. Installing this package, will add the automation scripts for Microsoft Teams in the Automation module.

- [Access the DataMiner System](https://docs.dataminer.services/user-guide/Getting_started/Accessing_DataMiner/Accessing_DataMiner.html) and open the Automation module (via apps > Automation). <details><summary>...</summary>
![Gif-Automation](https://user-images.githubusercontent.com/109528797/186685478-9eac1cbf-f2d9-4c9a-8a6a-a2f499dbdcd9.gif)

</details>

- Open the "memory files" tab and create memory files named '*Teams*', '*Channels*' and '*Chats*'. The purpose of these files is to persist the created Teams, Channels and Chats.<details><summary>...</summary>
![Gif-MemFiles](https://user-images.githubusercontent.com/109528797/186685736-dacafe23-53be-4165-8982-eb2113549d78.gif)

</details>

- Also create a memory file named YesOrNo with the following entries: *{postion:0, value:1, description:yes ; postion:1, value:0, description:no}*<details><summary>...</summary>
![Gif-MemFilesYesorNo](https://user-images.githubusercontent.com/109528797/186685771-9d9c4155-1f58-4700-98aa-90ebd19c329e.gif)

</details>


#### Usage

- Open the Automation module (via apps > Automation) and click on the "automation scripts" tab and double click the "Create Team" automation script. Fill in the fields for creating a new Team, **the fields are case sensitive.**
- When pressing the "execute now" button, a Team is created in Microsoft Teams with the Dataminer bot.<details><summary>...</summary>
![Gif-CreateTeam](https://user-images.githubusercontent.com/109528797/186685886-ae5f1834-1c5c-438d-92e7-03740330e51d.gif)

</details>

## Help

Any advise for common problems or issues.

## Contact

[@Jordy Ampe](https://github.com/JordyGit)  
[@RobbertVH](https://github.com/RobbertVH)

Project Link: [Chat-integration](https://github.com/SkylineCommunications/chat-integration)

## Version History

- 0.2
  - Refactoring
  - Generalizations
- 1.0
  - Initial Release

## License

This project is licensed under the [MIT License](https://github.com/SkylineCommunications/chat-integration/blob/main/LICENSE) - see the file for details
