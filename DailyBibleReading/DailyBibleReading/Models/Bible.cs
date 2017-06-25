using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DailyBibleReading.Models
{
	class Bible : INotifyPropertyChanged
	{
		/* if using enum
		public Versions Version { get; set; }
		*/
		public string Version { get; set; }
		public List<Book> Books { get; set; }

		event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
		{
			add
			{
			}

			remove
			{
			}
		}

		public Dictionary<string, string> VersionDictionary = new Dictionary<string, string>()
		{
			{ "b_asv1901", "American Standard Version 1901" },
			{ "b_bbe", "Bible In Basic English" },
			{ "b_darby", "Darby English Bible" },
			{ "b_kjv", "King James Version" },
			{ "b_nasb", "New American Standard Bible" },
			{ "b_niv", "New International Version" },
			{ "b_nkjv", "New King James Version" },
			{ "b_nlt", "New Living Translation" },
			{ "b_rsv", "Revised Standard Version" },
			{ "b_web", "World English Bible" },
			{ "b_ylt", "Young's Literal Translation" }
		};

		public string[] VersionArray = new string[]
		{
			"American Standard Version 1901",
			"Bible In Basic English",
			"Darby English Bible",
			"King James Version",
			"New American Standard Bible",
			"New International Version",
			"New King James Version",
			"New Living Translation",
			"Revised Standard Version",
			"World English Bible",
			"Young's Literal Translation"
		};

		public string[] BookArray = new string[66]
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
	}
	class Book : INotifyPropertyChanged
	{
		public string Name { get; set; }
		public List<Chapter> Chapters { get; set; }

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
	class Chapter : INotifyPropertyChanged
	{
		public DateTime Date { get; set; }
		public bool HasBeenRead { get; set; }
		public bool IsTodaysChapter { get; set; }
		public int Number { get; set; }
		public List<Verse> Verses { get; set; }

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
		public int Number { get; set; }
		public string Text { get; set; }

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

	// enum can't have spaces
	enum Books
	{
		// normally starts with 0 but you can change the beginning number
		// we change because the database starts with 1
		Genesis = 1,
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
