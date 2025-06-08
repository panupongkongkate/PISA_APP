using Microsoft.JSInterop;

namespace PISA_APP.Services;

public class ModalService
{
    private readonly IJSRuntime _jsRuntime;

    public ModalService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task ShowAsync(string modalId)
    {
        try
        {
            var elementExists = await _jsRuntime.InvokeAsync<bool>("checkElementExists", $"#{modalId}");
            if (!elementExists)
            {
                Console.WriteLine($"Modal element {modalId} not found in DOM");
                return;
            }

            var modal = await _jsRuntime.InvokeAsync<IJSObjectReference>("bootstrap.Modal.getOrCreateInstance", $"#{modalId}");
            await modal.InvokeVoidAsync("show");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error showing modal {modalId}: {ex.Message}");
        }
    }

    public async Task HideAsync(string modalId)
    {
        try
        {
            var elementExists = await _jsRuntime.InvokeAsync<bool>("checkElementExists", $"#{modalId}");
            if (!elementExists)
            {
                Console.WriteLine($"Modal element {modalId} not found in DOM");
                return;
            }

            var modal = await _jsRuntime.InvokeAsync<IJSObjectReference>("bootstrap.Modal.getOrCreateInstance", $"#{modalId}");
            await modal.InvokeVoidAsync("hide");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error hiding modal {modalId}: {ex.Message}");
        }
    }

    public async Task ToggleAsync(string modalId)
    {
        try
        {
            var modal = await _jsRuntime.InvokeAsync<IJSObjectReference>("bootstrap.Modal.getOrCreateInstance", $"#{modalId}");
            await modal.InvokeVoidAsync("toggle");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error toggling modal {modalId}: {ex.Message}");
        }
    }

    public async Task<bool> IsShownAsync(string modalId)
    {
        try
        {
            var modal = await _jsRuntime.InvokeAsync<IJSObjectReference>("bootstrap.Modal.getOrCreateInstance", $"#{modalId}");
            return await modal.InvokeAsync<bool>("_isShown");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error checking modal state {modalId}: {ex.Message}");
            return false;
        }
    }
}