using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Firebase;
using Firebase.Database;

namespace RidesApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]

    public class MainActivity : AppCompatActivity
    {
        Button testConnection;

        FirebaseDatabase database;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            testConnection = (Button)FindViewById(Resource.Id.myButton);

            testConnection.Click += TestConnection_Click;

        }

        private void TestConnection_Click(object sender, System.EventArgs e)
        {
            initializeDatabase();
        }

        void initializeDatabase()
        {
            var app = FirebaseApp.InitializeApp(this);

            if (app == null)
            {
                var options = new FirebaseOptions.Builder()
                    .SetApplicationId("rideappproject")
                    .SetApiKey("AIzaSyCflazAnYZKhp5g_leYvPSs1SRf0BJLsZc")
                    .SetDatabaseUrl("https://rideappproject.firebaseio.com/")
                    .SetStorageBucket("rideappproject.appspot.com")
                    .Build();

                app = FirebaseApp.InitializeApp(this, options);

                database = FirebaseDatabase.GetInstance(app);
            }
            else
            {
                database = FirebaseDatabase.GetInstance(app);
            }

            DatabaseReference dbref = database.GetReference("GetSupport");

            dbref.SetValue("Ticket1");

            Toast.MakeText(this, "Comleted", ToastLength.Short).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}