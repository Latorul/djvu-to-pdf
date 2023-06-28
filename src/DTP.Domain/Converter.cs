using System.ComponentModel;

namespace DTP.Domain;

/// <summary>
/// Класс по конвертации файлов из одного формата в другой.
/// </summary>
public static class Converter
{
    /// <summary>
    /// Оповещатель о завершении конвертации страниц.
    /// </summary>
    public static BackgroundWorker BackgroundWorker { get; set; }

    /// <summary>
    /// Конвертирует файл из .djvu в .pdf.
    /// </summary>
    /// <param name="args">Путь к конвертируемому файлу.</param>
    /// <exception cref="ArgumentException">Конвертируемый файл в неправильном формате.</exception>
    public static void ConvertDjvuToPdf(string[] args)
    {
#if DEBUG
        const string executableFile = "template2.djvu";
#else
        var executableFile = args[0];
#endif
        if (Path.GetExtension(executableFile) != ".djvu")
            throw new ArgumentException("File format must be .djvu");

        File.BackgroundWorker = BackgroundWorker;
        var outputFilePath = File.ConvertToPdf(executableFile);
        File.Open(outputFilePath);
    }
}