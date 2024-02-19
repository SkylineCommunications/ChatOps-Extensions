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
		// This input will not be asked from the user but will automatically be filled in by the DataMiner bot with the
		// dataminer.services email address of the user executing this automation script using their linked DataMiner account
		// Note that this needs to be defined as input on the automation script with the exact name "dataminer.services User Email",
		// otherwise it will not be provided by the DataMiner bot
		var userEmail = engine.GetScriptParam("dataminer.services User Email");
		if (string.IsNullOrWhiteSpace(userEmail?.Value))
		{
			engine.ExitFail("'dataminer.services User Email' parameter is required.");
			return;
		}

		// The DataMiner user executing an automation script is always available
		// Custom commands executed with the DataMiner bot will always be executed using the linked DataMiner account on dataminer.services
		var dataminerAccountLoginName = engine.UserLoginName;
		var dataminerAccountDisplayName = engine.UserDisplayName;

		// Return as an output
		engine.AddScriptOutput("dataminer.services User Email", userEmail.Value);
		engine.AddScriptOutput("DataMiner account login name", dataminerAccountLoginName);
		engine.AddScriptOutput("DataMiner account display name", dataminerAccountDisplayName);
	}
}