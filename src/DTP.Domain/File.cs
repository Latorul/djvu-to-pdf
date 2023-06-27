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

        try
        {
            CreatePdf(executableFile, outputFilePath);
        }
        catch
        {
            System.IO.File.Delete(outputFilePath);
            throw;
        }

        return outputFilePath;
    }

    /// <summary>
    /// Собирает PDF файл из страниц DJVU файла.
    /// </summary>
    /// <param name="inputFilePath">Путь к входному файлу.</param>
    /// <param name="outputFilePath">Путь к выходному файлу.</param>
    [SupportedOSPlatform("windows")]
    private static void CreatePdf(string inputFilePath, string outputFilePath)
    {
        var djvuDocument = new DjvuDocument(inputFilePath);
        var djvuPages = djvuDocument.Pages;
        
        using var pdfDocument = new PdfDocument();

        foreach (DjvuPage? djvuPage in djvuPages)
        {
            var djvuImage = djvuPage.Image;
            
            using var stream = new MemoryStream();
            djvuImage.Save(stream, ImageFormat.Bmp);
            using var xImage = XImage.FromStream(stream);
            
            var page = pdfDocument.AddPage();
            page.Width = djvuImage.Width;
            page.Height = djvuImage.Height;

            XGraphics graphics = XGraphics.FromPdfPage(page);
            graphics.DrawImage(xImage, 0, 0, page.Width, page.Height);
        }

        pdfDocument.Save(outputFilePath);
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