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
			edittext.KeyPress += async (object sender, View.KeyEventArgs e) =>{
				e.Handled = false;
				if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
				{
					



					ParseQuery<ParseObject> query = ParseObject.GetQuery("TestClass")
						.WhereStartsWith("TestName", string.Format("{0}", edittext.Text));
					IEnumerable<ParseObject> results = await query.FindAsync();
					//string name = query.Find<String>("TestName");

					//ExpandableListView view = FindViewById<ExpandableListView>(Resource.Id.list1);
					var count = await query.CountAsync();

					foreach(var result in results)
					{
						if(count > 0)
						{
							//add all items into a list
							for (int i = 0; i < count; i++)
							{
								
							}
						}
						else 
						{
							//Return "No items found"
						}



						//Outputs ONE result as a button
						/*if(result.Get<String>("TestName") == string.Format("{0}", edittext.Text))
						{
							
							Button btn = FindViewById<Button>(Resource.Id.button1);
							btn.Text = string.Format("{0}",count);

						}
						else
						{
							Button btn = FindViewById<Button>(Resource.Id.button1);
							btn.Text = string.Format("{0}",count);
						}*/
	
					}




			
				}
			};
			Spinner spinner = FindViewById<Spinner> (Resource.Id.day_prompt);

			spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
			var adapter = ArrayAdapter.CreateFromResource (
				this, Resource.Array.day_array, Android.Resource.Layout.SimpleSpinnerItem);

			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner.Adapter = adapter;

		}
	}
}



