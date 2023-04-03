using KeyOver.Models;

namespace KeyOver.Services.KeyboardLayoutConfig;

public interface IKeyboardConfigProvider
{
    public KeyboardLayoutModel GetKeyboardLayoutConfig();
}