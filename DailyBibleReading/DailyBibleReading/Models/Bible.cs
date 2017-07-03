using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DailyBibleReading.Models
{
	class Bible : INotifyPropertyChanged
	{
		string Version { get; set; }
		List<Book> Books { get; set; }

		event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
		{
			add
			{
			}

			remove
			{
			}
		}

		static Dictionary<string, string> VersionDictionary = new Dictionary<string, string>()
		{
			{ "asv1901", "American Standard Version" },
			{ "bbe", "Bible In Basic English" },
			{ "cjb", "Complete Jewish Bible" },
			{ "cev", "Contemporary English Version" },
			{ "darby", "Darby Bible" },
			{ "erv", "Easy-To-Read Version" },
			{ "gnv", "Geneva Bible" },
			{ "gw", "God's Word" },
			{ "gnt", "Good News Translation" },
			{ "hnv", "Hebrew Names Version Of The World English Bible" },
			{ "hcsb", "Holman Christian Standard Bible" },
			{ "kjv", "King James Version" },
			{ "mkjv", "Modern King James Version" },
			{ "nasb", "New American Standard Bible" },
			{ "ncv", "New Century Version" },
			{ "net", "New English Translation" },
			{ "nirv", "New International Reader's Version" },
			{ "nkjv", "New King James Version" },
			{ "nlt", "New Living Translation" },
			{ "nrsv", "New Revised Standard Version" },
			{ "rsv", "Revised Standard Version" },
			{ "amp", "The Amplified Bible" },
			{ "esv", "The English Standard Version" },
			{ "tlb", "The Living Bible" },
			{ "msg", "The Message" },
			{ "niv", "The New International Version" },
			{ "tev", "Today's English Version" },
			{ "tniv", "Today's New International Version" },
			{ "wbt", "Webster's Bible Translation" },
			{ "web", "World English Bible" },
			{ "ylt", "Young's Literal Translation" },
		};
		List<KeyValuePair<string, string>> VersionList = VersionDictionary.ToList();
	}
	class Book : INotifyPropertyChanged
	{
		string Name { get; set; }
		List<Chapter> Chapters { get; set; }

		event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
		{
			add
			{
			}

			remove
			{
			}
		}

		List<string> BookEnumList()
		{
			IEnumerable<BookEnum> BooksIEnumerable = Enum.GetValues(typeof(BookEnum)).Cast<BookEnum>();
			List<string> BooksWithSpaces = new List<string>(BooksIEnumerable.Select(v => v.ToString().Replace("_", " ")));
			return BooksWithSpaces;
		}

		static string[] BookArray = new string[66]
		{
			"Genesis",
			"Exodus",
			"Leviticus",
			"Numbers",
			"Deuteronomy",
			"Joshua",
			"Judges",
			"Ruth",
			"1 Samuel",
			"2 Samuel",
			"1 Kings",
			"2 Kings",
			"1 Chronicles",
			"2 Chronicles",
			"Ezra",
			"Nehemiah",
			"Esther",
			"Job",
			"Psalm",
			"Proverbs",
			"Ecclesiastes",
			"Song Of Solomon",
			"Isaiah",
			"Jeremiah",
			"Lamentations",
			"Ezekiel",
			"Daniel",
			"Hosea",
			"Joel",
			"Amos",
			"Obadiah",
			"Jonah",
			"Micah",
			"Nahum",
			"Habakkuk",
			"Zephaniah",
			"Haggai",
			"Zechariah",
			"Malachi",
			"Matthew",
			"Mark",
			"Luke",
			"John",
			"Acts",
			"Romans",
			"1 Corinthians",
			"2 Corinthians",
			"Galatians",
			"Ephesians",
			"Philippians",
			"Colossians",
			"1 Thessalonians",
			"2 Thessalonians",
			"1 Timothy",
			"2 Timothy",
			"Titus",
			"Philemon",
			"Hebrews",
			"James",
			"1 Peter",
			"2 Peter",
			"1 John",
			"2 John",
			"3 John",
			"Jude",
			"Revelation"
		};
		List<string> BookList = BookArray.ToList();
	}
	class Chapter : INotifyPropertyChanged
	{
		DateTime Date { get; set; }
		bool HasBeenRead { get; set; }
		bool IsTodaysChapter { get; set; }
		int Number { get; set; }
		List<Verse> Verses { get; set; }

		event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
		{
			add
			{
			}

			remove
			{
			}
		}
	}
	class Verse : INotifyPropertyChanged
	{
		int Number { get; set; }
		string Text { get; set; }

		event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
		{
			add
			{
			}

			remove
			{
			}
		}
	}

	// enums can't have spaces
	enum BookEnum
	{
		Genesis,
		Exodus,
		Leviticus,
		Numbers,
		Deuteronomy,
		Joshua,
		Judges,
		Ruth,
		First_Samuel,
		Second_Samuel,
		First_Kings,
		Second_Kings,
		First_Chronicles,
		Second_Chronicles,
		Ezra,
		Nehemiah,
		Esther,
		Job,
		Psalm,
		Proverbs,
		Ecclesiastes,
		Song_Of_Solomon,
		Isaiah,
		Jeremiah,
		Lamentations,
		Ezekiel,
		Daniel,
		Hosea,
		Joel,
		Amos,
		Obadiah,
		Jonah,
		Micah,
		Nahum,
		Habakkuk,
		Zephaniah,
		Haggai,
		Zechariah,
		Malachi,
		Matthew,
		Mark,
		Luke,
		John,
		Acts,
		Romans,
		First_Corinthians,
		Second_Corinthians,
		Galatians,
		Ephesians,
		Philippians,
		Colossians,
		First_Thessalonians,
		Second_Thessalonians,
		First_Timothy,
		Second_Timothy,
		Titus,
		Philemon,
		Hebrews,
		James,
		First_Peter,
		Second_Peter,
		First_John,
		Second_John,
		Third_John,
		Jude,
		Revelation
	}
}