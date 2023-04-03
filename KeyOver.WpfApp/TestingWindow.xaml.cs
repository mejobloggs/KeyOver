using KeyOver.Services.KeyboardLayoutConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KeyOver.WpfApp;

/// <summary>
/// Interaction logic for TestingWindow.xaml
/// </summary>
public partial class TestingWindow : Window
{
    public TestingWindow()
    {
        var gridCreater = new KeyboardGridCreater();
        var testLayout = new JsonProvider(new FileLoader("test.json")).GetKeyboardLayoutConfig();

        Content = gridCreater.GetGrid(testLayout);

        InitializeComponent();
    }
}
