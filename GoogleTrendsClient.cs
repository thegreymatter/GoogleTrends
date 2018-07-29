using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace GoogleTrends
{
	public class GoogleTrendsClient
	{
		private int _tz;
		private string _locale;

		public GoogleTrendsClient(string locale = "en-US", int tz = 360, string geo = "")
		{
			_tz = tz;
			_locale = locale;


		}

		public static string StreamToString(Stream stream)
		{
			using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
			{
				return reader.ReadToEnd();
			}
		}

		public List<TimelineDatum> GetInterestsOverTime(List<string> keywordList, int cat = 0, string timeframe = "today 5-y", string geo = "", string gprop = "")
		{
			var kwlist = keywordList.Select(x => new Keyword() { keyword = x, time = timeframe, geo = geo });
			var req = JsonConvert.SerializeObject(new { comparisonItem = new List<Keyword>(kwlist), category = 0, property = "" });
			var token = SetTokens(req, "TIMESERIES");
			
			var request = WebRequest.CreateHttp($"https://trends.google.com/trends/api/widgetdata/multiline?hl={_locale}&tz={_tz}&req={JsonConvert.SerializeObject(token.Item2)}&token={token.Item1}");

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			if (response.StatusCode!=HttpStatusCode.OK)
			{
				throw new Exception(response.StatusDescription);
			}

			var widgetResponse = JsonConvert.DeserializeObject<TimeSeriesResponse>(StreamToString(response.GetResponseStream()).Remove(0, 5));
			return widgetResponse.Default.TimelineData;

		}

		private (string, Request) SetTokens(string req, string widgetTokenType)
		{
			var request = WebRequest.CreateHttp($"https://trends.google.com/trends/api/explore?hl={_locale}&tz={_tz}&req={req}");

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			if (response.StatusCode!=HttpStatusCode.OK)
			{
				throw new Exception(response.StatusDescription);
			}
			var res = StreamToString(response.GetResponseStream()).Remove(0, 4);
			var widgetResponse = JsonConvert.DeserializeObject<WidgetResponse>(res);
			return (widgetResponse.widgets.First(x => x.id == widgetTokenType).token, widgetResponse.widgets.First(x => x.id == widgetTokenType).request);
		}
	}

	internal class Keyword
	{
		public string keyword { get; set; }
		public string time { get; set; }
		public string geo { get; set; }
	}
}
