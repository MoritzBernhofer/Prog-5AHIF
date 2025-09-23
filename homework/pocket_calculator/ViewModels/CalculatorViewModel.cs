using System;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace pocket_calculator.ViewModels;

public partial class CalculatorViewModel : ViewModelBase
{
    [ObservableProperty] private string _equation = "";

    [RelayCommand]
    private void NonActionButtonClicked(object buttonContext)
    {
        var buttonContent = buttonContext?.ToString() ?? "No content";
        Equation += buttonContent;
    }

    [RelayCommand]
    private void Calculate()
    {
        var equation = "22-33";
        var solved = false;

        while (solved == false)
        {
            var (operator1, operator2, action, newEquation) = GetOps(equation);

            solved = true;
        }
    }

    private (string, string, string, string) GetOps(string equation)
    {
        var equationArray = equation.Select(str => str.ToString()).ToArray();

        if (equationArray.Length < 3 || IsAction(equationArray[0]))
        {
            throw new NotImplementedException("");
        }

        var operator1 = "";
        var index = 0;
        while (!IsAction(equationArray[index]))
        {
            operator1 += equationArray[index++];
        }

        var action = equationArray[index++];
        var operator2 = "";
        while (!IsAction(equationArray[index]) && index < equationArray.Length)
        {
            operator2 += equationArray[index++];
        }

        return (operator1, operator2, action,
            string.Concat(equationArray.Skip(index)));
    }

    private static bool IsAction(string c) =>
        c switch
        {
            "+" => true,
            "-" => true,
            "/" => true,
            "*" => true,
            _ => false
        };
}