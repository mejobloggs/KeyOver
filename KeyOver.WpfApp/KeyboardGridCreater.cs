using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using KeyOver.Models;
using System.Reflection;

namespace KeyOver.WpfApp;

public class KeyboardGridCreater
{
    public Grid GetGrid(KeyboardLayoutModel keyboardModel)
    {
        var windowGrid = new Grid();
        windowGrid.HorizontalAlignment = HorizontalAlignment.Center;
        windowGrid.VerticalAlignment = VerticalAlignment.Bottom;
        windowGrid.Margin = new Thickness(0, 0, 0, 60);
        windowGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        int col = 0;
        foreach (var keyGroup in keyboardModel.KeyGroups)
        {
            windowGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            var grid = GetKeyGroupGrid(keyGroup);

            if(col > 0)
            {
                grid.Margin = new Thickness(50,0,0,0);
            }

            Grid.SetColumn(grid, col++);
            Grid.SetRow(grid, 0);

            windowGrid.Children.Add(grid);
        }




        return windowGrid;
    }

    private Grid GetKeyGroupGrid(KeyboardLayoutModel.KeyGroup keyGroup)
    {
        var grid = new Grid();
        grid.HorizontalAlignment = HorizontalAlignment.Center;
        grid.VerticalAlignment = VerticalAlignment.Bottom;
        grid.ShowGridLines = false;

        for (int i = 0; i < keyGroup.KeyRows.First().Count(); i++)
        {
            var colDef = new ColumnDefinition();
            colDef.Width = GridLength.Auto;
            grid.ColumnDefinitions.Add(colDef);
        }

        for (int i = 0; i < keyGroup.KeyRows.Count(); i++)
        {
            var rowDef = new RowDefinition();
            rowDef.Height = GridLength.Auto;
            grid.RowDefinitions.Add(rowDef);
        }

        int row, col;

        for (row = 0; row < keyGroup.KeyRows.Count(); row++)
        {
            for (col = 0; col < keyGroup.KeyRows[row].Count(); col++)
            {
                var keyText = keyGroup.KeyRows[row][col];

                Border border = new Border();
                border.BorderBrush = Brushes.Black;
                border.BorderThickness = new Thickness(1);
                border.CornerRadius = new CornerRadius(5);
                border.Background = Brushes.LightBlue;
                border.Margin = new Thickness(2);
                border.Width = 50;
                border.Height = 50;

                if (!string.IsNullOrEmpty(keyText) && keyText == keyGroup.IndexFingerLetter)
                {
                    border.Background = Brushes.LightSalmon;
                }


                TextBlock txt = new TextBlock();
                txt.Text = keyText;
                txt.FontSize = 20;
                txt.FontWeight = FontWeights.Bold;
                txt.TextAlignment = TextAlignment.Center;
                txt.HorizontalAlignment = HorizontalAlignment.Stretch;
                txt.VerticalAlignment = VerticalAlignment.Center;
                

                border.Child = txt;

                Grid.SetColumn(border, col);
                Grid.SetRow(border, row);

                grid.Children.Add(border);
            }
        }

        return grid;
    }
}
