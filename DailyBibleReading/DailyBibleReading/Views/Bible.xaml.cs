﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyBibleReading.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Bible : ContentPage
	{
		public Bible()
		{
			InitializeComponent();
		}

		private void Chapter_ItemTapped(object sender, ItemTappedEventArgs e)
		{

		}

		private void Verses_ItemTapped(object sender, ItemTappedEventArgs e)
		{

		}
	}
}