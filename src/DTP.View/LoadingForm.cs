using System.ComponentModel;

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
        Domain.Converter.BackgroundWorker = ConvertingBackgroundWorker;
        _args = args;
    }

    /// <summary>
    /// Запускает конвертацию.
    /// </summary>
    private async void LoadingForm_Shown(object sender, EventArgs e)
    {
        ConvertingBackgroundWorker.RunWorkerAsync();
    }

    /// <summary>
    /// Предупреждает пользователя об отмене конвертации.
    /// </summary>
    private void LoadingForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.ApplicationExitCall)
        {
            return;
        }

        var closingResult = MessageBox.Show(
            "Are you sure you want to abort the conversion?",
            string.Empty,
            MessageBoxButtons.YesNo);

        if (closingResult == DialogResult.No)
        {
            e.Cancel = true;
        }

        ConvertingBackgroundWorker.CancelAsync();
    }

    /// <summary>
    /// Запускает конвертацию.
    /// </summary>
    private void ConvertingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        try
        {
            Domain.Converter.ConvertDjvuToPdf(_args);
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message, "Error while converting");
        }
    }

    /// <summary>
    /// Обновляет progressBar при завершении конвертации каждой страницы.
    /// </summary>
    private void ConvertingBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        ConvertingProgressBar.Maximum = (int)e.UserState!;
        ConvertingProgressBar.PerformStep();
    }

    /// <summary>
    /// Закрывает приложение при завершении процесса.
    /// </summary>
    private void ConvertingBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        Application.Exit();
    }
}