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
		private void spinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;

			string toast = string.Format ("You've chosen {0}", spinner.GetItemAtPosition (e.Position));
			Toast.MakeText (this, toast, ToastLength.Long).Show ();
		}
//		int count = 1;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			EditText edittext = FindViewById<EditText>(Resource.Id.edittext);
			edittext.KeyPress += async (object sender, View.KeyEventArgs e) => 
			{
				e.Handled = false;

				if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter) 
				{
					//Query based on user input, name of venue
					ParseQuery<ParseObject> query = ParseObject.GetQuery ("TestClass")
						.WhereStartsWith ("TestName", string.Format ("{0}", edittext.Text));
					IEnumerable<ParseObject> results = await query.FindAsync ();

					//Number of objects returned
					var count = await query.CountAsync ();
					//Create array

					string[] arr = null;
					int i = 0;

					//Iterates list of results
					foreach (var result in results) 
					{
						string objId = result.Get<String>("TestName");
						arr[i] = objId;
						i++;

					}

			
						var intent = new Intent (this, typeof(ListActivity));
						intent.PutExtra("this", arr);

				}
			};
			/*Button btn = FindViewById<Button> (Resource.Id.button1);
			btn.Click += async(sender, e) => {
			}*/
					
			//SPINNER LOGIC
			Spinner spinner = FindViewById<Spinner> (Resource.Id.day_prompt);

			spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
			var adapter = ArrayAdapter.CreateFromResource (
				this, Resource.Array.day_array, Android.Resource.Layout.SimpleSpinnerItem);

			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner.Adapter = adapter;

			Spinner spinner1 = FindViewById<Spinner> (Resource.Id.start_time);

			spinner1.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
			var adapter1 = ArrayAdapter.CreateFromResource (
				this, Resource.Array.startTimeArray, Android.Resource.Layout.SimpleSpinnerItem);

			adapter1.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner1.Adapter = adapter1;

			Spinner spinner2 = FindViewById<Spinner> (Resource.Id.end_time);

			spinner2.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
			var adapter2 = ArrayAdapter.CreateFromResource (
				this, Resource.Array.endTimeArray, Android.Resource.Layout.SimpleSpinnerItem);

			adapter2.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner2.Adapter = adapter2;
		}
	}

}



