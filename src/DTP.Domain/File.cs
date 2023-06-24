namespace DTP.Domain;

/// <summary>
/// Класс для работы с конвертируемыми файлами.
/// </summary>
public static class File
{
    /// <summary>
    /// Расширение входного файла.
    /// </summary>
    private const string InputExtension = ".djvu";

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
        (string inputFilePath, string outputFilePath) = GetPaths(executableFile);

        using var image = Aspose.Imaging.Image.Load(inputFilePath);
        var exportOptions = new PdfOptions
        {
            PdfDocumentInfo = new PdfDocumentInfo()
        };

        image.Save(outputFilePath, exportOptions);
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
    /// Возвращает пути к входному и выходному файлам.
    /// <remarks>При запуске программы в режиме DEBUG
    /// путь к входному файлу меняется на стандартный.</remarks>
    /// </summary>
    /// <param name="executableFile">Путь к входному файлу.</param>
    /// <returns> Пути к входному и выходному файлам.</returns>
    private static (string inputFilePath, string outputFilePath) GetPaths(string executableFile)
    {
#if DEBUG
        executableFile = "template.djvu";
#endif

        var directory = Path.GetDirectoryName(executableFile);
        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(executableFile);

        var inputFilePath = Path.Combine(directory!, fileNameWithoutExtension + InputExtension);
        var outputFilePath = Path.Combine(directory!, fileNameWithoutExtension + OutputExtension);

        return (inputFilePath, outputFilePath);
    }
}