using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyBibleReading.ViewModels
{
	public class ChapterItem : Chapter
	{
		public bool HasBeenRead { get; set; }
		public bool IsTodaysChapter { get; set; }
		public string ChapterReference { get; set; }
	}

	class ReadingScheduleViewModel
	{
		public async static Task<List<ChapterItem>> GetChaptersAsync()
		{
			var chapters = new List<ChapterItem>();

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

			var apiresults = await Api.GetApiResultsAsync(begindate.ToString("yyyy-MM-dd"), enddate.ToString("yyyy-MM-dd"));
			foreach (var chapter in apiresults.chapters)
			{
				var chapteritem = new ChapterItem();

				chapteritem.date = chapter.date;
				chapteritem.book = chapter.book;
				chapteritem.chapter = chapter.chapter;
				chapteritem.HasBeenRead = false;
				chapteritem.IsTodaysChapter = false;
				if (chapteritem.date == today.ToString("yyyy-MM-dd"))
				{
					chapteritem.IsTodaysChapter = true;
					chapteritem.HasBeenRead = true;
				}
				chapteritem.ChapterReference = chapter.book + " " + chapter.chapter;

				chapters.Add(chapteritem);
			}

			return chapters;
		}
	}
}