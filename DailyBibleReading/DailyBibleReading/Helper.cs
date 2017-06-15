using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace DailyBibleReading
{
	public class Helper
    {
        // connect to a json api and return the results
        public static async Task<string> GetJsonAsync(string _url)
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
                // create a popup with the results
                //MessageDialog dialog = new MessageDialog(result);
                //await dialog.ShowAsync();
            }
            catch (Exception ex)
            {
                // Details in ex.Message and ex.HResult.
                // do something with the results
                // Output to debugger
                Debug.WriteLine(ex);
                // create a popup with the results
                //MessageDialog dialog = new MessageDialog(result);
                //await dialog.ShowAsync();
            }

            // Once your app is done using the HttpClient object call dispose to free up system resources (the underlying socket and memory used for the object)
            httpclient.Dispose();

            // return the string to Task<>
            return result;
        }
    }
}
