using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DailyBibleReading.ViewModels
{
	class MainPageViewModel
	{
		public async static Task PopulateCollectionsAsync(ObservableCollection<ChapterItem> _chaptercollection, ObservableCollection<VerseItem> _versecollection, string _version = "b_kjv")
		{
			// the the daily bible reading information for the whole week surrounding today
			// great examples of working with dates (http://www.dotnetperls.com/datetime)
			DateTime today = DateTime.Today;
			// use just today by default
			DateTime begindate = today;
			DateTime enddate = today;
			DayOfWeek day = today.DayOfWeek;
			// redefine variables
			if (day == DayOfWeek.Sunday)
			{
				begindate = today.AddDays(-6);
				enddate = today.AddDays(5);
			}
			if (day == DayOfWeek.Monday)
			{
				begindate = today;
				enddate = today.AddDays(4);
			}
			if (day == DayOfWeek.Tuesday)
			{
				begindate = today.AddDays(-1);
				enddate = today.AddDays(3);
			}
			if (day == DayOfWeek.Wednesday)
			{
				begindate = today.AddDays(-2);
				enddate = today.AddDays(2);
			}
			if (day == DayOfWeek.Thursday)
			{
				begindate = today.AddDays(-3);
				enddate = today.AddDays(1);
			}
			if (day == DayOfWeek.Friday)
			{
				begindate = today.AddDays(-4);
				enddate = today;
			}
			if (day == DayOfWeek.Saturday)
			{
				begindate = today.AddDays(-5);
				enddate = today.AddDays(6);
			}

			var apiresults = await Api.GetApiResultsAsync(begindate.ToString("yyyy-MM-dd"), enddate.ToString("yyyy-MM-dd"), _version);
			var chapters = apiresults.chapters;
			foreach (var chapter in chapters)
			{
				var chapteritem = new ChapterItem();

				chapteritem.book = chapter.book;
				chapteritem.chapter = chapter.chapter;
				chapteritem.ChapterReference = chapteritem.book + " " + chapteritem.chapter;
				// great examples of working with dates (http://www.dotnetperls.com/datetime)
				// chapter.date is 2001-12-25 and chapteritem.date is Sunday, December 25, 2001
				chapteritem.date = DateTime.Parse(chapter.date).ToString("D");
				// check to see if the chapter is today's chapter
				if (chapteritem.date == today.ToString("D"))
				{
					chapteritem.HasBeenRead = true;
					chapteritem.IsTodaysChapter = true;
				}
				else
				{
					chapteritem.HasBeenRead = false;
					chapteritem.IsTodaysChapter = false;
				}
				chapteritem.verses = chapter.verses;
				chapteritem.version = chapter.version;
				_chaptercollection.Add(chapteritem);

				if (chapteritem.IsTodaysChapter == true)
				{
					foreach (var verse in chapteritem.verses)
					{
						var verseitem = new VerseItem();

						verseitem.text = verse.text;
						verseitem.verse = verse.verse;
						verseitem.VerseReference = chapteritem.ChapterReference + ":" + verseitem.verse;

						_versecollection.Add(verseitem);
					}
				}
			}

			// no chapter on the weekend
			// great examples of working with dates (http://www.dotnetperls.com/datetime)
			if (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
			{
				var verseitem = new VerseItem();

				verseitem.text = "Come join us in reading the Bible this year. We read one chapter of the Bible each weekday (Monday through Friday).";
				verseitem.VerseReference = "No chapter today";

				_versecollection.Add(verseitem);
			}
		}
	}

	public class VerseItem : Verse
	{
		public string VerseReference { get; set; }
	}
	public class ChapterItem : Chapter
	{
		public bool HasBeenRead { get; set; }
		public bool IsTodaysChapter { get; set; }
		public string ChapterReference { get; set; }
	}
}