namespace DTP.View;

/// <summary>
/// Строка загрузки.
/// </summary>
public partial class LoadingBar : UserControl
{
	/// <summary>
	/// Список всех элементов.
	/// </summary>
	private readonly Queue<Panel> _panels = new();

	/// <summary>
	/// Цвет неактивного элемента.
	/// </summary>
	private readonly Color DefaultColor = ColorTranslator.FromHtml("#0F7f7f7f");

	/// <summary>
	/// Цвет активного элемента.
	/// </summary>
	private readonly Color ActiveColor = ColorTranslator.FromHtml("#FF00FF00");

	/// <summary>
	/// Интервал между сменой активного элемента в миллисекундах.
	/// </summary>
	public int TimerInterval { get; set; } = 100;

	/// <summary>
	/// Конструктор класса <see cref="LoadingBar"/>.
	/// </summary>
	public LoadingBar()
	{
		InitializeComponent();
		EnqueueSteps();
		LoadingBarTimer.Interval = TimerInterval;
	}

	/// <summary>
	/// Запуск полосы загрузки.
	/// </summary>
	public void Start() => LoadingBarTimer.Start();

	/// <summary>
	/// Остановка полосы загрузки.
	/// </summary>
	public void Stop() => LoadingBarTimer.Stop();

	/// <summary>
	/// Сменяет активный элемент.
	/// </summary>
	private void ProgressBarTimer_Tick(object sender, EventArgs e)
	{
		_panels.Peek().BackColor = DefaultColor;
		_panels.Enqueue(_panels.Dequeue());
		_panels.Peek().BackColor = ActiveColor;
	}

	/// <summary>
	/// 
	/// </summary>
	private void EnqueueSteps()
	{
		_panels.Enqueue(FirstStep);
		_panels.Enqueue(SecondStep);
		_panels.Enqueue(ThirdStep);
		_panels.Enqueue(FourthStep);
		_panels.Enqueue(FifthStep);
		_panels.Enqueue(SixthStep);
		_panels.Enqueue(SeventhStep);
		_panels.Enqueue(EighthStep);
		_panels.Enqueue(NinthStep);
		_panels.Enqueue(TenthStep);
	}
}