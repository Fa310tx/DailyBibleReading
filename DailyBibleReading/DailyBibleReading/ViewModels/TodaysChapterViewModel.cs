using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DailyBibleReading.ViewModels
{
	public class VerseItem : Verse
	{
		public string VerseReference { get; set; }
	}

	public class TodaysChapterViewModel
	{
		public async static Task<List<VerseItem>> GetVersesAsync(string _date, string _version = "b_kjv")
		{
			var verses = new List<VerseItem>();

			var apiresults = await Api.GetApiResultsAsync(_date, _date, _version);
			var chapters = apiresults.chapters;
			foreach (var chapter in chapters)
			{
				foreach (var verse in chapter.verses)
				{
					var verseitem = new VerseItem();

					verseitem.text = verse.text;
					verseitem.VerseReference = chapter.book + " " + chapter.chapter + ":" + verse.verse;

					verses.Add(verseitem);
				}
			}

			// no chapter on the weekend
			// great examples of working with dates (http://www.dotnetperls.com/datetime)
			var day = DateTime.Today.DayOfWeek;
			if (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
			{
				var verseitem = new VerseItem();

				verseitem.text = "Come join us in reading the Bible this year. We read one chapter of the Bible each weekday (Monday through Friday).";
				verseitem.VerseReference = "No chapter today";

				verses.Add(verseitem);
			}

			return verses;
		}
	}
}