using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Microsoft.Maui.Controls;
using notePad.languages;
using notePad.main;

namespace notePad
{
    public partial class MainPage : ContentPage
    {
        private readonly Judge0CodeRunnerService _codeRunnerService;
        private readonly LanguageDetector _detector = new LanguageDetector();

        public ObservableCollection<ProgrammingLanguage> Languages { get; private set; }
        public ProgrammingLanguage SelectedLanguage { get; set; }

        public MainPage()
        {
            InitializeComponent();

            string apiKey = "0e059ad434msha71ddd38715128bp1610b1jsna18f67782e54";
            _codeRunnerService = new Judge0CodeRunnerService(apiKey);

            var detector = new LanguageDetector();
            Languages = new ObservableCollection<ProgrammingLanguage>(detector.GetAllLanguages());
            SelectedLanguage = Languages[0];
            BindingContext = this;
        }

        private void CodeEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            var code = e.NewTextValue;
            var language = _detector.DetectLanguage(code);
            LanguageLabel.Text = $"Language: {language}";
        }

        private void OnLanguageChanged(object sender, EventArgs e)
        {
            if (((Picker)sender).SelectedItem is LanguageOption selected)
            {
                var matchingLanguage = Languages.FirstOrDefault(lang => lang.Name == selected.Name);
                if (matchingLanguage != null)
                {
                    SelectedLanguage = matchingLanguage;
                    Debug.WriteLine($"Selected language: {SelectedLanguage.Name}");
                    LanguageLabel.Text = $"Language: {matchingLanguage.Name}";
                }
            }
        }

        private async void OnRunCodeClicked(object sender, EventArgs e)
        {
            try
            {
                string code = CodeEditor.Text;
                string output = await _codeRunnerService.RunCSharpCodeAsync(code);
                OutputLabel.Text = output;
            }
            catch (Exception ex)
            {
                OutputLabel.Text = $"Error: {ex.Message}";
            }
        }

    }
}
