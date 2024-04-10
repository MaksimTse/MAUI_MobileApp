namespace MAUI_MobileApp;

public partial class Failid_Page : ContentPage
{
    string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    public Failid_Page()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdateFilesList();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string filename = fileNameEntry.Text;
        if (String.IsNullOrEmpty(filename)) { return; }
        if (File.Exists(Path.Combine(folderPath, filename)))
        {
            bool isRewrite = await DisplayAlert("Hoiatus", "Fail on juba olemas. Kas tahad ümberkirjutada?", "jah", "ei");
            if (isRewrite == false) { return; }
        }
        File.WriteAllText(Path.Combine(folderPath, filename), textEditor.Text);
        UpdateFilesList();
    }

    private void UpdateFilesList()
    {
        fileList.ItemsSource = Directory.GetFiles(folderPath).Select(f => Path.GetFileName(f));
        filesList.SelectedItem = null;
    }

    private void fileList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null) { return; }
        string filename = e.SelectedItem.ToString();
        textEditor.Text = File.ReadAllText(Path.Combine(folderPath, filename));
        fileNameEntry.Text = filename;
        fileList.SelectedItem = null;
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        string fileName=(string)((MenuItem)sender).BindingContext;
        File.Delete(Path.Combine(folderPath, fileName));
        UpdateFilesList();
    }

    private void ToList_Clicked(object sender, EventArgs e)
    {
        string fileName=(string)((MenuItem)sender).BindingContext;
        List<string> list = File.ReadLines(Path.Combine(folderPath, fileName)).ToList();
        filesList.ItemsSource = list;

    }

    private void filesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }
}
