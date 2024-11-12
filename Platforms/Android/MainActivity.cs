using Android.App;
using Android.Content.PM;
using Android.OS;
using Firebase;

namespace IMProWater
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Inicjalizacja Firebase
            FirebaseApp.InitializeApp(this); // lub FirebaseApp.InitializeApp(Android.App.Application.Context);
        }
    }
}
