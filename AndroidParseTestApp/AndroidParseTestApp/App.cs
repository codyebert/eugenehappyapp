using System;
using Android.App;
using Android.Runtime;
using Parse;

namespace ParseAndroidStarterProject
{
	[Application]
	public class App : Application
	{
		public App (IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{
		}

		public override void OnCreate ()
		{
			base.OnCreate ();

			// Initialize the Parse client with your Application ID and .NET Key found on
			// your Parse dashboard
			ParseClient.Initialize ("kOJRWgMgXY4tdecrmOnGNJ7UvRrF5BQ26anwESpj", "3fDyL2ynxVk1bZF9SzARrLRPY84SFDufAoY95QpV");
		}
	}
}