using System;
using CoreGraphics;
using Foundation;
using UIKit;
using WebKit;

namespace WKWebViewTest.iOS
{
    public partial class ViewController : UIViewController
    {
        WKWebView m_webView;
        WKNavigationDelegate m_navDelegate;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (m_webView == null)
            {
                m_webView = new WKWebView(View.Frame,
                                          new WKWebViewConfiguration()
                                          {
                                              MediaPlaybackAllowsAirPlay = false,
                                          });

                m_webView.AutoresizingMask = UIViewAutoresizing.All;
                m_webView.TranslatesAutoresizingMaskIntoConstraints = true;
                View.AddSubview(m_webView);
            }

            if (m_webView.NavigationDelegate == null)
            {
                m_navDelegate = new WKWebViewDelegate();
                m_webView.NavigationDelegate = m_navDelegate;
                m_webView.LoadRequest(new NSUrlRequest(new NSUrl("https://www.google.com"), NSUrlRequestCachePolicy.UseProtocolCachePolicy, 20));
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }

    public class WKWebViewDelegate : WKNavigationDelegate
    { 
        public override void DidReceiveAuthenticationChallenge(WKWebView webView, NSUrlAuthenticationChallenge challenge, Action<NSUrlSessionAuthChallengeDisposition, NSUrlCredential> completionHandler)
        {
            base.DidReceiveAuthenticationChallenge(webView, challenge, completionHandler);
        }
    }
}
