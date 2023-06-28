using DTP.Domain;
using System;
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
        Domain.File.bw = ConvertingBackgroundWorker;
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
            ConvertingBackgroundWorker.RunWorkerAsync();
            //await Converter.ConvertDjvuToPdf(_args);
        }
        catch (Exception exception)
        {
            LoadingBar.Stop();
            MessageBox.Show(exception.Message, "Error while converting");
        }
        finally
        {
            //Application.Exit();
        }
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
    }

    private void ConvertingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        Converter.ConvertDjvuToPdf(_args);
    }

    private void ConvertingBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        ConvertingProgressBar.Maximum = (int)e.UserState!;
        ConvertingProgressBar.PerformStep();
    }

    private void ConvertingBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        Application.Exit();
    }
}