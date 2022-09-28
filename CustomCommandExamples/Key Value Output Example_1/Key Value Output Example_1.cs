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
		engine.AddScriptOutput("Uplink", "Bitrate 3 mb/s");
		engine.AddScriptOutput("Downlink", "Bitrate 19 mb/s");
	}
}