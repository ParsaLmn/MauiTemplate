using Bit.BlazorUI;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Common.Shared;
public partial class NavMenu
{
    private bool isMenuOpen;

    private List<BitNavItem> _navItems = default!;

    [CascadingParameter] public Task<AuthenticationState> AuthenticationStateTask { get; set; } = default!;

    [Parameter]
    public bool IsMenuOpen
    {
        get => isMenuOpen;
        set
        {
            if (value == isMenuOpen) return;

            isMenuOpen = value;

            _ = IsMenuOpenChanged.InvokeAsync(value);
        }
    }

    [Parameter] public EventCallback<bool> IsMenuOpenChanged { get; set; }
    protected override async Task OnInitializedAsync()
    {
        _navItems = new()
        {
            new BitNavItem
            {
                Text = "����",
                IconName = BitIconName.Home,
                Url = "/",
            }
            ,
           new BitNavItem
            {
                Text = "�������",
                IconName = BitIconName.Count,
                Url = "/counter",
            }
           ,
           new BitNavItem
            {
                Text = "tools",
                IconName = BitIconName.Count,
                Url = "/tools",
            }
        };
        await base.OnInitializedAsync();
    }
    private async Task HandleOnItemClick(BitNavItem item)
    {
        if (string.IsNullOrWhiteSpace(item.Url)) return;

        await CloseNavMenu();
    }

    private async Task CloseNavMenu()
    {
        IsMenuOpen = false;

        await JsRuntime.SetBodyOverflow(false);
    }
}
