﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using System;
using System.Text.RegularExpressions;

namespace OlibKey.Views.Windows
{
	public class SettingsWindow : Window
	{
		private TabItem _tiStorage;
		private TextBox _tbIteration;
		private TextBox _tbNumberOfEncryptionProcedures;
		private TextBox _tbAutosave;
		private TextBox _tbBlock;
		private TextBox _tbMessage;
		private ComboBox _cbTheme;
		private ComboBox _cbLanguage;
		private Button _bClose;

		public SettingsWindow()
		{
			InitializeComponent();
			DataContext = App.Settings;

			_cbLanguage.SelectedIndex = App.Settings.Language switch
			{
				"ru-RU" => 1,
				"uk-UA" => 2,
				"de-DE" => 3,
				"fr-FR" => 4,
				"hy-AM" => 5,
				_ => 0
			};

			_cbTheme.SelectedIndex = App.Settings.Theme switch
			{
				"Gloomy" => 1,
				"Mysterious" => 2,
				"Turquoise" => 3,
				_ => 0
			};

			_cbTheme.SelectionChanged += ThemeChange;
			_cbLanguage.SelectionChanged += LanguageChange;
			_bClose.Click += (s, e) => Close();
			Closing += (s, e) =>
			{
				Regex reg = new Regex(@"^\d+$");
				if (_tbAutosave.Text == "0"
				|| !reg.IsMatch(_tbBlock.Text)
				|| _tbBlock.Text == "0"
				|| !reg.IsMatch(_tbMessage.Text)
				|| _tbMessage.Text == "0")
				{
					_ = MessageBox.Show(this, null, (string)Application.Current.FindResource("CDBError1"), (string)Application.Current.FindResource("Error"),
					MessageBox.MessageBoxButtons.Ok, MessageBox.MessageBoxIcon.Error);
					e.Cancel = true;
					return;
				}

				if (App.MainWindowViewModel.IsUnlockDatabase)
				{
					if (!reg.IsMatch(_tbIteration.Text)
						|| _tbIteration.Text == "0"
						|| !reg.IsMatch(_tbNumberOfEncryptionProcedures.Text)
						|| _tbNumberOfEncryptionProcedures.Text == "0"
						|| !reg.IsMatch(_tbAutosave.Text))
					{
						_ = MessageBox.Show(this, null, (string)Application.Current.FindResource("CDBError1"), (string)Application.Current.FindResource("Error"),
						MessageBox.MessageBoxButtons.Ok, MessageBox.MessageBoxIcon.Error);
						e.Cancel = true;
						return;
					}

					if (App.MainWindowViewModel.SelectedTabItem != null)
					{
						App.MainWindowViewModel.SelectedTabItem.ViewModel.Iterations = int.Parse(_tbIteration.Text);
						App.MainWindowViewModel.SelectedTabItem.ViewModel.NumberOfEncryptionProcedures = int.Parse(_tbNumberOfEncryptionProcedures.Text);
					}
				}

				App.Settings.AutosaveDuration = int.Parse(_tbAutosave.Text);
				App.Settings.BlockDuration = int.Parse(_tbBlock.Text);
				App.Settings.MessageDuration = int.Parse(_tbMessage.Text);

				App.Autosave.Stop();

				App.Autosave.Interval = new TimeSpan(0, App.Settings.AutosaveDuration, 0);
				App.Autoblock.Interval = new TimeSpan(0, App.Settings.BlockDuration, 0);

				App.Autosave.Start();
			};

			_tiStorage.IsEnabled = App.MainWindowViewModel.SelectedTabItem != null && App.MainWindowViewModel.SelectedTabItem.ViewModel.IsUnlockDatabase;

			if (App.MainWindowViewModel.SelectedTabItem != null)
			{
				_tbIteration.Text = App.MainWindowViewModel.SelectedTabItem.ViewModel.Iterations.ToString();
				_tbNumberOfEncryptionProcedures.Text = App.MainWindowViewModel.SelectedTabItem.ViewModel.NumberOfEncryptionProcedures.ToString();
			}

			_tbAutosave.Text = App.Settings.AutosaveDuration.ToString();
			_tbBlock.Text = App.Settings.BlockDuration.ToString();
			_tbMessage.Text = App.Settings.MessageDuration.ToString();
		}


		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
			_cbTheme = this.FindControl<ComboBox>("cbTheme");
			_cbLanguage = this.FindControl<ComboBox>("cbLanguage");
			_bClose = this.FindControl<Button>("bClose");
			_tbIteration = this.FindControl<TextBox>("tbIteration");
			_tbNumberOfEncryptionProcedures = this.FindControl<TextBox>("tbNumberOfEncryptionProcedures");
			_tiStorage = this.FindControl<TabItem>("tiStorage");
			_tbAutosave = this.FindControl<TextBox>("tbAutosave");
			_tbBlock = this.FindControl<TextBox>("tbBlock");
			_tbMessage = this.FindControl<TextBox>("tbMessage");		
		}

		private void LanguageChange(object sender, SelectionChangedEventArgs e)
		{
			App.Settings.Language = _cbLanguage.SelectedIndex switch
			{
				1 => "ru-RU",
				2 => "uk-UA",
				3 => "de-DE",
				4 => "fr-FR",
				5 => "hy-AM",
				_ => "en-US"
			};
			Application.Current.Styles[4] = new StyleInclude(new Uri("resm:Styles?assembly=OlibKey"))
			{
				Source = new Uri($"avares://OlibKey/Assets/Local/lang.{App.Settings.Language}.axaml")
			};
		}

		private void ThemeChange(object sender, SelectionChangedEventArgs e)
		{
			App.Settings.Theme = _cbTheme.SelectedIndex switch
			{
				1 => "Gloomy",
				2 => "Mysterious",
				3 => "Turquoise",
				_ => "Dazzling"
			};

			Application.Current.Styles[2] = new StyleInclude(new Uri("resm:Styles?assembly=OlibKey"))
			{
				Source = new Uri($"avares://OlibKey/Assets/Themes/{App.Settings.Theme}.axaml")
			};
		}
	}
}
