using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Front.Core.ViewModels;

namespace Front.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true, Title = "About Us")]
    public partial class AboutUsPage : MvxContentPage<AboutUsViewModel>
    {
        public AboutUsPage()
        {
            InitializeComponent();
        }
    }
}