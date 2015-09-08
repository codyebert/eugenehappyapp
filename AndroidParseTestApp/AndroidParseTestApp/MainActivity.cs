 using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Parse;
using System.Collections.Generic;

namespace AndroidParseTestApp
{
	[Activity (Label = "AndroidParseTestApp", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
//		int count = 1;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

		

//			Get our button from the layout resource,
// 			and attach an event to it

//			var btn = this.FindViewById<Button> (Resource.Id.Button);
//			btn.Click += async (sender, e) => {
//				ParseQuery<ParseObject> query = ParseObject.GetQuery ("TestClass");
//				ParseObject object1 = await query.GetAsync ("HQSr8bt1Zp");
//				string TestName = object1.Get<string> ("TestName");
//				btn.Text = string.Format ("{0}", TestName);
//			};
//		
			EditText edittext = FindViewById<EditText>(Resource.Id.edittext);

			edittext.KeyPress += async (object sender, View.KeyEventArgs e) =>{
				e.Handled = false;
				if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
				{
					ParseQuery<ParseObject> query = ParseObject.GetQuery ("TestClass");
					ParseObject object1 = await query.GetAsync (string.Format("{0}", edittext.Text));
					string TestName = object1.Get<string> ("TestName");
//					btn.Text = string.Format ("{0}", TestName);
					Toast.MakeText(this, string.Format ("{0}", TestName), ToastLength.Long).Show();
					e.Handled = true;
				}
			};

//			var btn = this.FindViewById<Button>(Resource.Id.Button);
//			btn.Click += async (sender, e) => {
//				var query = ParseObject.GetQuery("TestClass")
//					.WhereNotEqualTo("TestName", "The Vintage");
//				
//					
//				btn.Text = string.Format ("{0}", query);
//			};



//			how to print
//			System.Diagnostics.Debug.WriteLine ();


//			create a new user

//			var user = new ParseUser ()
//			{
//				Username = "my name",
//				Password = "my pass",
//				Email = "email@example.com"
//			};
//
//			// other fields can be set just like with ParseObject
//			user ["phone"] = "415-392-0202";
//
//			await user.SignUpAsync ();

		}
	}
}


