using System.Diagnostics;
using Aspose.Imaging.ImageOptions;

namespace DTP.Domain;

public static class Program
{
	[STAThread]
	private static void Main()
	{
		(string inputFilePath, string outputFilePath) = GetFilesPath();
		ConvertFile(inputFilePath, outputFilePath);
		OpenFile(outputFilePath);
	}

	private static (string inputFilePath, string outputFilePath) GetFilesPath()
	{
		const string inputExtension = ".djvu";
		const string outputExtension = ".pdf";

#if DEBUG
		const string processPath = "template.djvu";
#else
		string processPath = Environment.ProcessPath!;
#endif

		var directory = Path.GetDirectoryName(processPath);
		var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(processPath);

		var inputFilePath = Path.Combine(directory!, fileNameWithoutExtension + inputExtension);
		var outputFilePath = Path.Combine(directory!, fileNameWithoutExtension + outputExtension);

		return (inputFilePath, outputFilePath);
	}

	private static void ConvertFile(string inputFilePath, string outputFilePath)
	{
		using var image = Aspose.Imaging.Image.Load(inputFilePath);
		var exportOptions = new PdfOptions
		{
			PdfDocumentInfo = new Aspose.Imaging.FileFormats.Pdf.PdfDocumentInfo()
		};

		image.Save(outputFilePath, exportOptions);
	}

	private static void OpenFile(string outputFilePath)
	{
		Process.Start(
			new ProcessStartInfo
			{
				FileName = outputFilePath,
				UseShellExecute = true
			});
	}
}