using DTP.Domain;

namespace DTP.View;

/// <summary>
/// Форма, отображающая процесс конвертации.
/// </summary>
public partial class LoadingForm : Form
{
    /// <summary>
    /// Список с путём к файлу.
    /// </summary>
    private readonly string[] _args;

    
    /// <summary>
    /// Конструктор класса <see cref="LoadingForm"/>.
    /// </summary>
    /// <param name="args">Список с путём к файлу</param>
    public LoadingForm(string[] args)
    {
        InitializeComponent();
        _args = args;
    }

    /// <summary>
    /// Запускает конвертацию.
    /// </summary>
    private async void LoadingForm_Shown(object sender, EventArgs e)
    {
        LoadingBar.Start();
        try
        {
            await Converter.ConvertDjvuToPdf(_args);
        }
        catch (Exception exception)
        {
            LoadingBar.Stop();
            MessageBox.Show(exception.Message, "Error while converting");
        }
        finally
        {
            Application.Exit();
        }
    }
}