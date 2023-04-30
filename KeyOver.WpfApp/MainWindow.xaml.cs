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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KeyOver.WpfApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        var gridCreater = new KeyboardGridCreater();
        var layout = new JsonProvider(new FileLoader("default-layout.json")).GetKeyboardLayoutConfig();

        Content = gridCreater.GetGrid(layout);

        InitializeComponent();

    }
    protected override void OnSourceInitialized(EventArgs e)
    {
        base.OnSourceInitialized(e);
        var hwnd = new WindowInteropHelper(this).Handle;
        WindowServices.SetWindowExTransparent(hwnd);
    }
}
