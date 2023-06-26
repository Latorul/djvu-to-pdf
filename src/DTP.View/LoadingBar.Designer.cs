namespace DTP.View
{
	partial class LoadingBar
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			SecondStep = new Panel();
			ThirdStep = new Panel();
			FourthStep = new Panel();
			FifthStep = new Panel();
			SixthStep = new Panel();
			SeventhStep = new Panel();
			EighthStep = new Panel();
			NinthStep = new Panel();
			TenthStep = new Panel();
			FirstStep = new Panel();
			LoadingBarTimer = new System.Windows.Forms.Timer(components);
			SuspendLayout();
			// 
			// SecondStep
			// 
			SecondStep.BackColor = Color.FromArgb(15, 127, 127, 127);
			SecondStep.Location = new Point(25, 3);
			SecondStep.Name = "SecondStep";
			SecondStep.Size = new Size(16, 32);
			SecondStep.TabIndex = 0;
			// 
			// ThirdStep
			// 
			ThirdStep.BackColor = Color.FromArgb(15, 127, 127, 127);
			ThirdStep.Location = new Point(47, 3);
			ThirdStep.Name = "ThirdStep";
			ThirdStep.Size = new Size(16, 32);
			ThirdStep.TabIndex = 1;
			// 
			// FourthStep
			// 
			FourthStep.BackColor = Color.FromArgb(15, 127, 127, 127);
			FourthStep.Location = new Point(69, 3);
			FourthStep.Name = "FourthStep";
			FourthStep.Size = new Size(16, 32);
			FourthStep.TabIndex = 3;
			// 
			// FifthStep
			// 
			FifthStep.BackColor = Color.FromArgb(15, 127, 127, 127);
			FifthStep.Location = new Point(91, 3);
			FifthStep.Name = "FifthStep";
			FifthStep.Size = new Size(16, 32);
			FifthStep.TabIndex = 2;
			// 
			// SixthStep
			// 
			SixthStep.BackColor = Color.FromArgb(15, 127, 127, 127);
			SixthStep.Location = new Point(113, 3);
			SixthStep.Name = "SixthStep";
			SixthStep.Size = new Size(16, 32);
			SixthStep.TabIndex = 7;
			// 
			// SeventhStep
			// 
			SeventhStep.BackColor = Color.FromArgb(15, 127, 127, 127);
			SeventhStep.Location = new Point(135, 3);
			SeventhStep.Name = "SeventhStep";
			SeventhStep.Size = new Size(16, 32);
			SeventhStep.TabIndex = 5;
			// 
			// EighthStep
			// 
			EighthStep.BackColor = Color.FromArgb(15, 127, 127, 127);
			EighthStep.Location = new Point(157, 3);
			EighthStep.Name = "EighthStep";
			EighthStep.Size = new Size(16, 32);
			EighthStep.TabIndex = 6;
			// 
			// NinthStep
			// 
			NinthStep.BackColor = Color.FromArgb(15, 127, 127, 127);
			NinthStep.Location = new Point(179, 3);
			NinthStep.Name = "NinthStep";
			NinthStep.Size = new Size(16, 32);
			NinthStep.TabIndex = 4;
			// 
			// TenthStep
			// 
			TenthStep.BackColor = Color.FromArgb(15, 127, 127, 127);
			TenthStep.Location = new Point(201, 3);
			TenthStep.Name = "TenthStep";
			TenthStep.Size = new Size(16, 32);
			TenthStep.TabIndex = 7;
			// 
			// FirstStep
			// 
			FirstStep.BackColor = Color.FromArgb(15, 127, 127, 127);
			FirstStep.Location = new Point(3, 3);
			FirstStep.Name = "FirstStep";
			FirstStep.Size = new Size(16, 32);
			FirstStep.TabIndex = 4;
			// 
			// ProgressBarTimer
			// 
			LoadingBarTimer.Tick += ProgressBarTimer_Tick;
			// 
			// LoadingBar
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			Controls.Add(TenthStep);
			Controls.Add(SixthStep);
			Controls.Add(FourthStep);
			Controls.Add(SeventhStep);
			Controls.Add(FirstStep);
			Controls.Add(ThirdStep);
			Controls.Add(EighthStep);
			Controls.Add(FifthStep);
			Controls.Add(NinthStep);
			Controls.Add(SecondStep);
			Name = "LoadingBar";
			Size = new Size(220, 38);
			ResumeLayout(false);
		}

		#endregion

		private Panel FirstStep;
		private Panel SecondStep;
		private Panel ThirdStep;
		private Panel FourthStep;
		private Panel FifthStep;
		private Panel SixthStep;
		private Panel SeventhStep;
		private Panel EighthStep;
		private Panel NinthStep;
		private Panel TenthStep;
		private System.Windows.Forms.Timer LoadingBarTimer;
	}
}
