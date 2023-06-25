namespace DTP.Domain;

public static class Program
{
    private static void Main(string[] args)
    {
        try
        {
#if DEBUG
            const string executableFile = "template.djvu";
#else
            var executableFile = args[0];
#endif
            if (Path.GetExtension(executableFile) != ".djvu")
                throw new ArgumentException("File format must be .djvu");

            var outputFilePath = File.ConvertToPdf(executableFile);
            File.Open(outputFilePath);
        }
        catch (IndexOutOfRangeException indexException)
        {
            Console.WriteLine(indexException.Message);
            throw;
        }
        catch (ArgumentException argumentException)
        {
            Console.WriteLine(argumentException.Message);
            throw;
        }
        catch (InvalidOperationException operationException)
        {
            Console.WriteLine(operationException.Message);
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}