using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyOver.Tests;
[TestClass]
public class LoadLayoutConfigTests
{
    [TestMethod]
    public void CanLoadAndDeserializeJson()
    {
        var dataLoader = new Services.KeyboardLayoutConfig.FileLoader("Test1.json");
        var provider = new Services.KeyboardLayoutConfig.JsonProvider(dataLoader);
        var layout = provider.Get();

        Assert.IsNotNull(layout);
    }
}
