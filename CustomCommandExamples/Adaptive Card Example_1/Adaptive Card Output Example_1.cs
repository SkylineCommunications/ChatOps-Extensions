using System.Collections.Generic;
using AdaptiveCards;
using Newtonsoft.Json;
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
		var adaptiveCardBody = new List<AdaptiveElement>()
		{
			new AdaptiveTextBlock("This is an adaptive card example containing a TextBlock, 2 FactSets with 2 Facts each, and an Image.")
			{
				Wrap = true
			},
			new AdaptiveFactSet()
			{
				Facts = new List<AdaptiveFact>
				{
					new AdaptiveFact("Name:", "Uplink"),
					new AdaptiveFact("Bitrate:", "3 mb/s")
				},
			},
			new AdaptiveFactSet()
			{
				Facts = new List<AdaptiveFact>
				{
					new AdaptiveFact("Name:", "Downlink"),
					new AdaptiveFact("Bitrate:", "19 mb/s")
				},
			},
			new AdaptiveImage("https://skyline.be/sites/default/files/inline-images/DataMinerbySLC_Q.png"),
		};

		engine.AddScriptOutput("AdaptiveCard", JsonConvert.SerializeObject(adaptiveCardBody));
	}
}