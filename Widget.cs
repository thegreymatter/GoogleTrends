using System.Collections.Generic;

namespace GoogleTrends
{
	public class Widget
	{
		public Request request { get; set; }
		public string token { get; set; }
		public string id { get; set; }
		public string type { get; set; }
		public string title { get; set; }
		public string template { get; set; }
		public string embedTemplate { get; set; }
		public string version { get; set; }
		public bool isLong { get; set; }
		public bool isCurated { get; set; }
		public string geo { get; set; }
		public string resolution { get; set; }
		public string keywordName { get; set; }
	}

	public class Request
	{
		public string time { get; set; }
		public string resolution { get; set; }
		public string locale { get; set; }
		public List<ComparisonItem> comparisonItem { get; set; }
		public RequestOptions requestOptions { get; set; }
		public Geo geo { get; set; }
		public Restriction restriction { get; set; }
		public string keywordType { get; set; }
		public List<string> metric { get; set; }
		public TrendinessSettings trendinessSettings { get; set; }
		public string language { get; set; }
	}

	public class Restriction
	{
		public Geo geo { get; set; }
		public string time { get; set; }
		public string originalTimeRangeForExploreUrl { get; set; }
		public ComplexKeywordsRestriction complexKeywordsRestriction { get; set; }
	}

	public class RequestOptions
	{
		public string property { get; set; }
		public string backend { get; set; }
		public int category { get; set; }
	}

	public class ComparisonItem
	{
		public Geo geo { get; set; }
		public ComplexKeywordsRestriction complexKeywordsRestriction { get; set; }
		public string time { get; set; }
	}

	public class Geo
	{
		public string country { get; set; }
	}

	public class ComplexKeywordsRestriction
	{
		public List<RequestKeyword> keyword { get; set; }
	}

	public class RequestKeyword
	{
		public string type { get; set; }
		public string value { get; set; }
	}


	public class TrendinessSettings
	{
		public string compareTime { get; set; }
	}
}