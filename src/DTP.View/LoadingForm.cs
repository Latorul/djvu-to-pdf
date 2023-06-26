using DTP.Domain;

namespace DTP.View;

public partial class LoadingForm : Form
{
	private readonly string[] _args;


	public LoadingForm(string[] args)
	{
		InitializeComponent();
		_args = args;
	}

	private async void LoadingForm_Shown(object sender, EventArgs e)
	{
		LoadingBar.Start();
		try
		{
			await Converter.ConvertDjvuToPdf(_args);
		}
		catch (Exception exception)
		{
			MessageBox.Show(exception.Message, "Error while converting");
		}
		finally
		{
			LoadingBar.Stop();
			Application.Exit();
		}
	}
}