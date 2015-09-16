
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





			//Button to send to general info page
			/*Button generalinfobutton = FindViewById<Button> (Resource.Id.button1);
			generalinfobutton.Click += async (sender, e) =>
			{
				var query = ParseObject.GetQuery("TestClass")
					.WhereEqualTo("TestName", string.Format("{0}", edittext.Text));
				IEnumerable<ParseObject> results = await query.FindAsync();
				foreach(var result in results)
				{    
					string barname = string.Format("{0}",result.Get<String>("TestName"));

					string streetaddress = result.Get<string>("StreetAddress");
					string citystatezip = result.Get<string>("CityStateZip");
					string phone = result.Get<string>("Phone");
					string barinfo = streetaddress + "\n" + citystatezip + "\n" + phone ; 
					var intent = new Intent(this, typeof(GeneralInfoActivity));
					intent.PutExtra("barname", barname);
					intent.PutExtra("barinfo", barinfo);
					StartActivity(intent);
				}
			};*/

		}
	}
}

