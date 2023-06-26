using System.ComponentModel;

namespace DTP.View;

partial class LoadingForm
{
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private IContainer components = null;

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{
			components.Dispose();
		}

		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		label1 = new Label();
		label2 = new Label();
		LoadingBar = new LoadingBar();
		SuspendLayout();
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
		label1.Location = new Point(55, 9);
		label1.Name = "label1";
		label1.Size = new Size(134, 15);
		label1.TabIndex = 0;
		label1.Text = "Converting DJVU to PDF\r\n";
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Location = new Point(90, 24);
		label2.Name = "label2";
		label2.Size = new Size(65, 15);
		label2.TabIndex = 1;
		label2.Text = "Please wait";
		// 
		// LoadingBar
		// 
		LoadingBar.BackColor = Color.White;
		LoadingBar.Location = new Point(12, 42);
		LoadingBar.Name = "LoadingBar";
		LoadingBar.Size = new Size(220, 38);
		LoadingBar.TabIndex = 2;
		LoadingBar.TimerInterval = 100;
		// 
		// LoadingForm
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.White;
		ClientSize = new Size(244, 92);
		Controls.Add(LoadingBar);
		Controls.Add(label2);
		Controls.Add(label1);
		FormBorderStyle = FormBorderStyle.FixedDialog;
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "LoadingForm";
		StartPosition = FormStartPosition.CenterScreen;
		Text = "DJVU to DPF";
		Shown += LoadingForm_Shown;
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private Label label1;
	private Label label2;
	private LoadingBar LoadingBar;
}