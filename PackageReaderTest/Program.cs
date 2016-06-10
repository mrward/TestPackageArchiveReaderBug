using System;
using System.IO;

namespace PackageReaderTest
{
	class Program
	{
		string fileName;

		public static void Main (string[] args)
		{
			try {
				var program = new Program ();
				program.Run (new [] { "Xamarin.Android.Support.v4.23.1.1.nupkg" });
			} catch (Exception ex) {
				Console.WriteLine (ex.ToString ());
			}
		}

		void Run (string[] args)
		{
			if (args.Length == 0) {
				ShowUsage ();
				return;
			}

			fileName = Path.GetFullPath (args[0]);

			string targetPath = Path.GetDirectoryName (typeof (Program).Assembly.Location);
			targetPath = Path.Combine (targetPath, "extract");
			if (!Directory.Exists (targetPath)) {
				Directory.CreateDirectory (targetPath);
			}

			var extractor = new NuGetPackageExtractor ();
			extractor.Extract (fileName, targetPath);
		}

		void ShowUsage ()
		{
			Console.WriteLine ("PackageReaderTest NuGetPackageFileName.nupkg");
		}
	}
}
