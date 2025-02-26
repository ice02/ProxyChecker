using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Security.Principal;

namespace ProxyChecker.Components.Pages
{
    public partial class UserInfos : ComponentBase
    {
        [Inject]
        AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

        WindowsIdentity? identity = null;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            logger.LogDebug($"Culture : {CultureInfo.CurrentCulture.NativeName}");

            var userinfo = Localizer.GetString("UserInfo");

            if (identity == null && AuthenticationStateProvider != null)
            {
                var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
                identity = authState.User.Identity as WindowsIdentity;
                StateHasChanged();
            }
        }
    }
}
