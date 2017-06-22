﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DailyBibleReading
{
	// classes for the daily bible reading api json result
	// classes generated by json2csharp (http://json2csharp.com)
	// generated class names were a little odd so I made them more appropriate
	public class Verse
	{
		public int verse { get; set; }
		public string text { get; set; }
	}
	public class Chapter
	{
		public string date { get; set; }
		public string book { get; set; }
		public int chapter { get; set; }
		public List<Verse> verses { get; set; }
		public string version { get; set; }
	}
	public class RootObject
	{
		public List<Chapter> chapters { get; set; }
	}

	public class Api
	{
		public async static Task<RootObject> GetApiResultsAsync(string _begindate, string _enddate, string _version = "b_kjv")
		{
			string result = null;

			// make the api call
			result = await Helper.GetHttpStringAsync("http://www.anti-exe.com/api/dailybiblereading?begindate=" + _begindate + "&enddate=" + _enddate + "&version=" + _version);

			string textfile = "ApiResults.txt";
			// if there is no content
			if (result == null || result == "" || result.Contains("SQLSTATE") == true)
			{
				// read content from a pre-existing file
				//result = await Helper.ReadTextFileAsync(textfile);
				// do something with the results
				// Output to debugger
				Debug.WriteLine("Can't connect to the API." + "\r\n" + "Loading from local cache.");
			}
			else
			{
				// write to a cache file
				//await Helper.WriteTextFileAsync(textfile, result);
			}

			RootObject rootobject = null;

			// if we still don't have any content
			if (result == null || result == "")
			{
				// do something with the results
				// Output to debugger
				Debug.WriteLine("Can't load from local cache." + "\r\n" + "Check your internet connection.");
			}
			else
			{
				rootobject = JsonConvert.DeserializeObject<RootObject>(result);
			}
			return rootobject;
		}
	}
}