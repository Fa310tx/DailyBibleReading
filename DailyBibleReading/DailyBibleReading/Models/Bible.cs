using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyBibleReading.Models
{
	// enum can't have spaces
	enum Versions
	{
		American_Standard_Version_1901,
		Bible_In_Basic_English,
		Darby_English_Bible,
		King_James_Version,
		New_American_Standard_Bible,
		New_International_Version,
		New_King_James_Version,
		New_Living_Translation,
		Revised_Standard_Version,
		World_English_Bible,
		Youngs_Literal_Translation
	}

	class Verse
	{
		public int Number { get; set; }
		public string Text { get; set; }
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
	class Book
	{
		public string Name { get; set; }
		public List<Chapter> Chapters { get; set; }
	}
	class Bible
	{
		/* if using enum
		public Versions Version { get; set; }
		*/
		public string Version { get; set; }
		public List<Book> Books { get; set; }
	}
}
