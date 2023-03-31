using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KeyOver.Services.KeyboardLayoutConfig;
internal class FileLoader : IKeyboardConfigLoader
{
    private readonly string _filePath;
    public FileLoader(string fileName)
    {
        var folderPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Assets\Config\KeyboardLayouts");
        _filePath = Path.Combine(folderPath, fileName);
    }
    public string GetDataAsString()
    {
        var data = File.ReadAllText(_filePath);
        return data;
    }
}