using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using pocket_calculator.ViewModels;

namespace pocket_calculator.Views;

public partial class CalculatorView : UserControl
{
    public CalculatorView()
    {
        InitializeComponent();
        DataContext = new CalculatorViewModel();
    }
}