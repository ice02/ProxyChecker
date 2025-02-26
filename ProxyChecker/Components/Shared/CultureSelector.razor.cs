using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using ProxyChecker.Components.Layout;
using System.Globalization;

namespace ProxyChecker.Components.Shared
{
    public partial class CultureSelector : ComponentBase
    {
        [Inject]
        IStringLocalizer<MainLayout> Localizer { get; set; }

        [Inject]
        NavigationManager Navigation { get; set; }

        protected override void OnInitialized()
        {
            Culture = CultureInfo.CurrentCulture;
        }

        private CultureInfo Culture
        {
            get
            {
                return CultureInfo.CurrentCulture;
            }
            set
            {
                if (CultureInfo.CurrentCulture != value)
                {
                    var uri = new Uri(Navigation.Uri).GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
                    var cultureEscaped = Uri.EscapeDataString(value.Name);
                    var uriEscaped = Uri.EscapeDataString(uri);

                    Navigation.NavigateTo($"Culture/Set?culture={cultureEscaped}&redirectUri={uriEscaped}", forceLoad: true);
                }
            }
        }
    }
}
