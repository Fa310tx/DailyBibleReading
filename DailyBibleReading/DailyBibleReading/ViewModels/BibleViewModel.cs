using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyBibleReading.ViewModels
{
	class BibleViewModel
	{
		public async static Task<List<Models.Bible>> GetChaptersAsync(string _version = "b_kjv")
		{
			var bibles = new List<Models.Bible>();

			var bible = new Models.Bible();
			bible.Version = _version;
			bible.Books = new List<Models.Book>();

			// the the daily bible reading information for the whole week surrounding today
			// great examples of working with dates (http://www.dotnetperls.com/datetime)
			DateTime begindate;
			DateTime enddate;
			DateTime today = DateTime.Today;
			DayOfWeek day = today.DayOfWeek;

			// switch is supposed to be more readable (and maybe faster) than if/else(if)
			switch (day)
			{
				case DayOfWeek.Sunday:
					begindate = today.AddDays(-6);
					enddate = today.AddDays(5);
					break;
				case DayOfWeek.Monday:
					begindate = today;
					enddate = today.AddDays(4);
					break;
				case DayOfWeek.Tuesday:
					begindate = today.AddDays(-1);
					enddate = today.AddDays(3);
					break;
				case DayOfWeek.Wednesday:
					begindate = today.AddDays(-2);
					enddate = today.AddDays(2);
					break;
				case DayOfWeek.Thursday:
					begindate = today.AddDays(-3);
					enddate = today.AddDays(1);
					break;
				case DayOfWeek.Friday:
					begindate = today.AddDays(-4);
					enddate = today;
					break;
				case DayOfWeek.Saturday:
					begindate = today.AddDays(-5);
					enddate = today.AddDays(6);
					break;
				default:
					begindate = today;
					enddate = today;
					break;
			}

			var apiresults = await Api.GetApiResultsAsync(begindate.ToString("yyyy-MM-dd"), enddate.ToString("yyyy-MM-dd"), _version);
			foreach (var _chapter in apiresults.chapters)
			{
				var book = new Models.Book();
				book.Name = _chapter.book;
				book.Chapters = new List<Models.Chapter>();

				var chapter = new Models.Chapter();
				chapter.Date = DateTime.Parse(_chapter.date);
				/* if/else version
				if (chapter.Date == today)
				{
					chapter.HasBeenRead = true;
					chapter.IsTodaysChapter = true;
				}
				else
				{
					chapter.HasBeenRead = false;
					chapter.IsTodaysChapter = false;
				}
				*/
				// conditional version (supposed to be more concise and easier to read)
				chapter.HasBeenRead = chapter.Date == today ? true : false;
				chapter.IsTodaysChapter = chapter.Date == today ? true : false;
				chapter.Number = _chapter.chapter;
				chapter.Verses = new List<Models.Verse>();

				foreach (var _verse in _chapter.verses)
				{
					var verse = new Models.Verse();
					verse.Number = _verse.verse;
					verse.Text = _verse.text;

					chapter.Verses.Add(verse);
				}

				book.Chapters.Add(chapter);

				bible.Books.Add(book);
			}

			bibles.Add(bible);

			return bibles;
		}
	}
}