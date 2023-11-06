using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication1.Model;
using AvaloniaApplication1.Pages;
using AvaloniaApplication3.Model;

namespace AvaloniaApplication1;

public partial class MainWindow : Window
{
    private bool isClient = false;
    private Employee employeeAuth;
    public MainWindow()
    {
        InitializeComponent();
        employeeAuth = null;
    }



    private void BtnAuth_OnClick(object? sender, RoutedEventArgs e)
    {
        if (TBoxLogin.Text.Length <= 1 || TBoxPassword.Text.Length <= 1)
        {
            //TODO: Сообщение
            return;
        }

        List<Employee> employees = DataBaseManager.GetEmployees();
        
        for(int i = 0; i <= employees.Count; i++)
        {
            if (employees[i].Login.Equals(TBoxLogin.Text) &&
                employees[i].Password.Equals(TBoxPassword))
            {
                employeeAuth = employees[i];
                break;
            }
        }

        if (employeeAuth == null)
        {
            //TODO: Сообщение
            return;
        }
        else
        {
            WindowMeny wMeny = new WindowMeny(employeeAuth);
            wMeny.Show();
            this.Hide();
        }
    }

    private void BtnClose_OnClick(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void BtnSwitch_OnClick(object? sender, RoutedEventArgs e)
    {
        isClient = !isClient;
        if (isClient)
        {
            PanelClient.IsVisible = true;
            PanelEmployee.IsVisible = false;
        }
        else
        {
            PanelClient.IsVisible = false;
            PanelEmployee.IsVisible = true;
        }
    }
}