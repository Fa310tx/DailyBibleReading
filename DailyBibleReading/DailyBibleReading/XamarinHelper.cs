using PCLStorage;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DailyBibleReading
{
	public class Helper
    {
        // connect to a json api and return the results
        public static async Task<string> GetHttpStringAsync(string _url)
        {
            // declare an empty variable to be filled later
            string result = null;
            HttpClient httpclient = new HttpClient();
            Uri url = new Uri(_url);

            // Always catch network exceptions for async methods
            try
            {
                result = await httpclient.GetStringAsync(url);

                // do something with the results
                // Output to debugger
                //Debug.WriteLine(result);
            }
            catch (Exception ex)
            {
                // Details in ex.Message and ex.HResult.
                // do something with the results
                // Output to debugger
                Debug.WriteLine(ex);
            }

            // Once your app is done using the HttpClient object call dispose to free up system resources (the underlying socket and memory used for the object)
            httpclient.Dispose();

            // return the string to Task<>
            return result;
        }

		// opens default web browser
		public static void OpenExternalPage(string _url)
		{
			Uri url = new Uri(_url);
			Device.OpenUri(url);
		}

		// opens default e-mail client
		// When creating an email link, as with any HTML link, you should use &amp; to represent the ampersand (&).
		// It's also good practice to use %20 in place of all spaces and %0D%0A in place of all carriage returns (i.e. when you want a space, such as when you'd normally use the "Enter" key).
		// When I say that it's "good practice" to do this, I mean, some browsers/email clients behave differently and may or may not show spaces and carriage returns the way you'd like.Therefore, using the method outlined here will ensure that your users see what you intend them to see.
		// example:  mailto:jj@anti-exe.com?Subject=Daily%20Bible%20Reading%20&amp;body=Your%20app%20is%20a%20load%20of%20hooey
		public static void SendEmail(string _address)
		{
			Uri url = new Uri("mailto:" + _address);
			Device.OpenUri(url);
		}
		// create additional overloaded methods to allow optional parameters
		public static void SendEmail(string _address, string _subject)
		{
			Uri url = new Uri("mailto:" + _address + "?subject=" + _subject);
			Device.OpenUri(url);
		}
		public static void SendEmail(string _address, string _subject, string _body)
		{
			Uri url = new Uri("mailto:" + _address + "?Subject=" + _subject + "&amp;body=" + _body);
			Device.OpenUri(url);
		}

		// opens store and shows items by publisher
		public static void MoreFromDeveloper(string _developer)
		{
		}

		// read a text file from the app's local folder
		public static async Task<string> ReadTextFileAsync(string _filename)
		{
			// declare an empty variable to be filled later
			string result = null;
			// see if the file exists
			try
			{
				// get hold of the file system
				IFolder rootFolder = FileSystem.Current.LocalStorage;

				// create a folder, if one does not exist already
				//IFolder folder = await rootFolder.CreateFolderAsync("DailyBibleReading", CreationCollisionOption.OpenIfExists);

				// create a file, overwriting any existing file
				IFile file = await rootFolder.CreateFileAsync(_filename, CreationCollisionOption.ReplaceExisting);

				// populate the file with some text
				result = await file.ReadAllTextAsync();
			}
			// if the file doesn't exist
			catch (Exception ex)
			{
				// do something with the results
				// Output to debugger
				Debug.WriteLine(ex);
			}
			// return the contents of the file
			return result;
		}
		// write a text file to the app's local folder
		public static async Task<string> WriteTextFileAsync(string _filename, string _content)
		{
			// declare an empty variable to be filled later
			string result = null;
			try
			{
				// get hold of the file system
				IFolder rootFolder = FileSystem.Current.LocalStorage;

				// create a folder, if one does not exist already
				//IFolder folder = await rootFolder.CreateFolderAsync("DailyBibleReading", CreationCollisionOption.OpenIfExists);

				// create a file, overwriting any existing file
				IFile file = await rootFolder.CreateFileAsync(_filename, CreationCollisionOption.ReplaceExisting);

				// populate the file with some text
				await file.WriteAllTextAsync(_content);

				result = _content;
			}
			// if there was a problem
			catch (Exception ex)
			{
				// do something with the results
				// Output to debugger
				Debug.WriteLine(ex);
			}
			// return the contents of the file
			return result;
		}
	}
}