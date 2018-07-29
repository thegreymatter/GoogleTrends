using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace GoogleTrends
{
	public class TimeSeriesResponse
	{
		[JsonProperty("default")] public Default Default { get; set; }
	}

	public class Default
	{
		[JsonProperty("timelineData")] public List<TimelineDatum> TimelineData { get; set; }

		[JsonProperty("averages")] public List<long> Averages { get; set; }
	}

	public class TimelineDatum
	{
		[JsonProperty("time")] public long Time { get; set; }

		[JsonProperty("formattedTime")] public string FormattedTime { get; set; }

		[JsonProperty("value")] public List<long> Value { get; set; }

		[JsonProperty("hasData")] public List<bool> HasData { get; set; }

		[JsonProperty("formattedValue")] public List<string> FormattedValue { get; set; }

	}


}