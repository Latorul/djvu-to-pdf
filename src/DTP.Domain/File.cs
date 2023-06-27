using System.Drawing;
using System.Runtime.Versioning;
using PdfSharp.Drawing;
using PdfSharp.Pdf;


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
    [SupportedOSPlatform("windows")]
    public static string ConvertToPdf(string executableFile)
    {
        var outputFilePath = GetOutputPath(executableFile);

        try
        {
            var djvuDocument = new DjvuDocument(executableFile);

            using var document = new PdfDocument();

            foreach (DjvuPage? bitmapPage in djvuDocument.Pages)
            {
                using var stream = new MemoryStream();
                bitmapPage.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                PdfPage page = document.AddPage();
                using (XImage img = XImage.FromStream(stream))
                {
                    page.Width = bitmapPage.Image.Width;
                    page.Height = bitmapPage.Image.Height;

                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    gfx.DrawImage(img, 0, 0, page.Width, page.Height);
                }
            }

            document.Save(outputFilePath);
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