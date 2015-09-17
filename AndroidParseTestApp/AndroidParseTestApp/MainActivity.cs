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
	

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			//Declare edit text
			EditText edittext = FindViewById<EditText> (Resource.Id.edittext);
	
					
			//SPINNER LOGIC
			Spinner spinner1 = FindViewById<Spinner> (Resource.Id.day_prompt);

			spinner1.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
			var adapter1 = ArrayAdapter.CreateFromResource (
				this, Resource.Array.day_array, Android.Resource.Layout.SimpleSpinnerItem);

			adapter1.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner1.Adapter = adapter1;

			Spinner spinner2 = FindViewById<Spinner> (Resource.Id.start_time);

			spinner2.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
			var adapter2 = ArrayAdapter.CreateFromResource (
				this, Resource.Array.startTimeArray, Android.Resource.Layout.SimpleSpinnerItem);

			adapter2.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner2.Adapter = adapter2;

			Spinner spinner3 = FindViewById<Spinner> (Resource.Id.end_time);

			spinner3.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
			var adapter3 = ArrayAdapter.CreateFromResource (
				this, Resource.Array.endTimeArray, Android.Resource.Layout.SimpleSpinnerItem);

			adapter3.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner3.Adapter = adapter3;




			//Send intents to ListActivity
			Button btn = FindViewById<Button> (Resource.Id.button1);
			btn.Click += async(sender, e) => 
			{
				//Intent with barname
				var intent = new Intent (this, typeof(ListActivity));
				intent.PutExtra("barname", edittext.Text);

				//Intent from spinner1
				string day = spinner1.SelectedItem.ToString();
				//var dayChosen = new Intent (this, typeof(ListActivity));
				intent.PutExtra("day", day );

				//Intent from spinner2
				string ST = spinner2.SelectedItem.ToString();
				//var startTime = new Intent (this, typeof(ListActivity));
				intent.PutExtra("start", ST);

				//Intent from spinner3
				string ET = spinner3.SelectedItem.ToString();
				//var endTime = new Intent (this, typeof(ListActivity));
				intent.PutExtra("end", ET);

				StartActivity(intent);
		

			};

		}
	
	}

}



