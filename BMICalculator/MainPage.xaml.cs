namespace BMICalculator;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCalculateClicked(object? sender, EventArgs e)
    {
        if (!double.TryParse(HeightEntry.Text, out double height) || height <= 0)
        {
            await DisplayAlertAsync("Invalid Input", "Please enter a valid height in cm.", "OK");
            return;
        }

        if (!double.TryParse(WeightEntry.Text, out double weight) || weight <= 0)
        {
            await DisplayAlertAsync("Invalid Input", "Please enter a valid weight in kg.", "OK");
            return;
        }

        double heightInMeters = height / 100.0;
        double bmi = weight / (heightInMeters * heightInMeters);
        double bmiRounded = Math.Round(bmi, 2);

        string category;
        Color categoryColor;
        string description;

        if (bmi < 18.5)
        {
            category = "Underweight";
            categoryColor = Color.FromArgb("#FF6600");
            description = "Below healthy range.\nConsider increasing caloric intake.";
        }
        else if (bmi < 25.0)
        {
            category = "Normal Weight";
            categoryColor = Color.FromArgb("#006600");
            description = "Within healthy range.\nMaintain current habits.";
        }
        else if (bmi < 30.0)
        {
            category = "Overweight";
            categoryColor = Color.FromArgb("#CC6600");
            description = "Above healthy range.\nRegular exercise is recommended.";
        }
        else
        {
            category = "Obese";
            categoryColor = Color.FromArgb("#CC0000");
            description = "Significantly above healthy range.\nPlease consult a physician.";
        }

        BmiValueLabel.Text = bmiRounded.ToString("F2");
        BmiCategoryLabel.Text = category;
        BmiCategoryLabel.TextColor = categoryColor;
        BmiDescriptionLabel.Text = description;
        ResultFrame.IsVisible = true;
    }
}