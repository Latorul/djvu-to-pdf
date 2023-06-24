namespace DTP.Domain;

public static class File
{
    private const string InputExtension = ".djvu";
    private const string OutputExtension = ".pdf";


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

    public static void Open(string outputFilePath)
    {
        Process.Start(
            new ProcessStartInfo
            {
                FileName = outputFilePath,
                UseShellExecute = true
            });
    }

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