using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Parse;

namespace ParseAndroidStarterProject
{
	[Activity (Label = "ParseAndroidStarterProject", MainLauncher = true)]
	public class Activity1 : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			var btn = this.FindViewById<Button>(Resource.Id.button1);
			btn.Click += async (sender, e) => {
				var obj = new ParseObject("Note");
				obj ["text"] = "Hello, world!  This is a Xamarin app using Parse!";
				obj ["tags"] = new List<string> {"welcome", "xamarin", "parse"};
				await obj.SaveAsync ();
			};
		}
	}
}


