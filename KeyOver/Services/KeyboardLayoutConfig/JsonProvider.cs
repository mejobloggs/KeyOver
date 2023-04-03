using KeyOver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KeyOver.Services.KeyboardLayoutConfig;
public class JsonProvider : IKeyboardConfigProvider
{
    private readonly IKeyboardConfigLoader configLoader;

    public JsonProvider(IKeyboardConfigLoader configLoader)
    {
        this.configLoader = configLoader;
    }
    public KeyboardLayoutModel GetKeyboardLayoutConfig()
    {
        var data = configLoader.GetDataAsString();

        var model = JsonSerializer.Deserialize<KeyboardLayoutModel>(data);
        return model;
    }
}
