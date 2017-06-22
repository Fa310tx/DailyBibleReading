// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace DailyBibleReading.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
			return CrossSettings.Current;
			}
		}

		#region Setting Constants
		private const string SettingsKey = "settings_key";
		private static readonly string SettingsDefault = string.Empty;

		private const string FontSizeKey = "FontSize";
		private static readonly int FontSizeDefault = 16;

		private const string VersionKey = "Version";
		private static readonly string VersionDefault = "b_kjv";

		private const string HasBeenReadKey = "HasBeenRead";
		private static readonly bool HasBeenReadDefault = false;
		#endregion

		public static string GeneralSettings
		{
			get
			{
				return AppSettings.GetValueOrDefault<string>(SettingsKey, SettingsDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue<string>(SettingsKey, value);
			}
		}

		public static int FontSize
		{
			get
			{
				return AppSettings.GetValueOrDefault<int>(FontSizeKey, FontSizeDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue<int>(FontSizeKey, value);
			}
		}

		public static string Version
		{
			get
			{
				return AppSettings.GetValueOrDefault<string>(VersionKey, VersionDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue<string>(VersionKey, value);
			}
		}

		public static bool HasBeenRead
		{
			get
			{
				return AppSettings.GetValueOrDefault<bool>(HasBeenReadKey, HasBeenReadDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue<bool>(HasBeenReadKey, value);
			}
		}
	}
}