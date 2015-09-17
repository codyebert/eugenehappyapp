
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parse;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidParseTestApp
{
	[Activity (Label = "ListActivity")]			
	public class ListActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.List);

			//Receiving intents
			string venue = Intent.GetStringExtra ("barname") ?? "Data Not Available";
			string day = Intent.GetStringExtra ("day") ?? "Data Not Available";
			string startTime = Intent.GetStringExtra ("start") ?? "Data Not Available";
			string endTime = Intent.GetStringExtra ("end") ?? "Data Not Available";



			//Query based on user input, name of venue
			/*ParseQuery<ParseObject> query = ParseObject.GetQuery ("TestClass")
				.WhereStartsWith ("TestName", string.Format ("{0}", edittext.Text));
			IEnumerable<ParseObject> results = await query.FindAsync ();

			//Number of objects returned
			var count = await query.CountAsync ();*/

		}
	}
}

