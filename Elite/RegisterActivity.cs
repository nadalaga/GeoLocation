using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
namespace Elite
{
    [Activity(Label = "Register")]
    public class RegisterActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_registertoolbar);
            Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
            btnBack.Click += btnBackClickEvent;
            var editToolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
         //   Toolbar will now take on default actionbar characteristics
            SetSupportActionBar(editToolbar);
            SupportActionBar.Title = "Register";

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

        }

        public void btnBackClickEvent(object sender, EventArgs e) {
            Intent objLoginIntent = new Intent(this, typeof(LoginActivity));
            StartActivity(objLoginIntent);
        }
       public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
                Finish();

            return base.OnOptionsItemSelected(item);
        }
    }

  
}