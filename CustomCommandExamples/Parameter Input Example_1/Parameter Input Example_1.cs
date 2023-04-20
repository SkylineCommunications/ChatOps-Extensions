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
		var parameterInput = engine.GetScriptParam("Parameter Input");
		if (string.IsNullOrWhiteSpace(parameterInput?.Value))
		{
			engine.ExitFail("'Parameter Input' parameter is required.");
			return;
		}

		// Return the input as an output
		engine.AddScriptOutput("Parameter Input", parameterInput.Value);
	}
}