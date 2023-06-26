namespace DTP.Domain;

/// <summary>
/// Класс для работы с конвертируемыми файлами.
/// </summary>
public static class File
{
    /// <summary>
    /// Расширение выходного файла.
    /// </summary>
    private const string OutputExtension = ".pdf";


    /// <summary>
    /// Конвертирует файл .djvu в .pdf .
    /// </summary>
    /// <param name="executableFile">Путь к входному файлу.</param>
    /// <returns>Путь к выходному файлу.</returns>
    public static string ConvertToPdf(string executableFile)
    {
        var outputFilePath = GetOutputPath(executableFile);

        using var image = Aspose.Imaging.Image.Load(executableFile);
        var exportOptions = new PdfOptions
        {
            PdfDocumentInfo = new PdfDocumentInfo()
        };

        try
        {
            image.Save(outputFilePath, exportOptions);
        }
        catch
        {
            System.IO.File.Delete(outputFilePath);
            throw;
        }
        return outputFilePath;
    }

    /// <summary>
    /// Открывает файл программой по умолчанию.
    /// </summary>
    /// <param name="filePath">Путь к файлу.</param>
    public static void Open(string filePath)
    {
        Process.Start(
            new ProcessStartInfo
            {
                FileName = filePath,
                UseShellExecute = true
            });
    }

    /// <summary>
    /// Возвращает путь к выходному файлу.
    /// </summary>
    /// <param name="executableFile">Путь к входному файлу.</param>
    /// <returns>Путь к выходному файлу.</returns>
    private static string GetOutputPath(string executableFile)
    {
        var directory = Path.GetDirectoryName(executableFile);
        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(executableFile);

        var outputFilePath = Path.Combine(directory!, fileNameWithoutExtension + OutputExtension);

        return outputFilePath;
    }
}