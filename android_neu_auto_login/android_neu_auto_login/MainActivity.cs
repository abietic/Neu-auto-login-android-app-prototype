using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Android.Webkit;

namespace android_neu_auto_login
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private WebView mWebView;
        private class CustWebViewClient : WebViewClient
        {
            public override void OnPageFinished(WebView w, string url)
            {
                base.OnPageFinished(w, url); // 在网页页面加载结束后，在网页中插入我们要使用的js代码
                var userName = ""; // 用于登录的学号
                var passWord = ""; // 学号对应的统一身份认证密码（明文，注意个人信息安全）
                w.LoadUrl("javascript:(function() { " +
                "document.getElementById('un').value='"+ userName +"';document.getElementById('pd').value='"+ passWord +"';login();})()"); // js代码
            }
            
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
            mWebView = FindViewById<WebView>(Resource.Id.webview);
            mWebView.LoadUrl("https://pass.neu.edu.cn/tpass/login?service=https%3A%2F%2Fipgw.neu.edu.cn%2Fsrun_cas.php%3Fac_id%3D15"); // 通过统一身份认证登录校园网的url
            //启用JavaScript
            mWebView.Settings.JavaScriptEnabled = true;
            mWebView.Settings.UseWideViewPort = true;

            mWebView.Settings.JavaScriptCanOpenWindowsAutomatically = true;

            mWebView.SetWebViewClient(new CustWebViewClient());
            
        

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}
