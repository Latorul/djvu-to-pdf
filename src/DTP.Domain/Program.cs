namespace DTP.Domain;

public static class Program
{
    private static void Main(string[] args)
    {
        var executableFile = args[0];
        if (Path.GetExtension(executableFile) != ".djvu")
            return;

        var outputFilePath = File.ConvertToPdf(executableFile);
        File.Open(outputFilePath);
    }
}