using System.Diagnostics;
using System.Reflection;
using Aspose.Imaging.ImageOptions;

namespace DTP.Domain;

public static class Program
{
	[STAThread]
	private static void Main(string[] args)
	{
		var executableFile = args[0];
		if (Path.GetExtension(executableFile) != ".djvu")
			return;

		(string inputFilePath, string outputFilePath) = GetFilesPath(executableFile);
		ConvertFile(inputFilePath, outputFilePath);
		OpenFile(outputFilePath);
	}

	private static (string inputFilePath, string outputFilePath) GetFilesPath(string executableFile)
	{
#if DEBUG
		executableFile = "template.djvu";
#endif

		const string inputExtension = ".djvu";
		const string outputExtension = ".pdf";

		var directory = Path.GetDirectoryName(executableFile);
		var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(executableFile);

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