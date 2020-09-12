﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using OlibKey.Core;
using OlibKey.ViewModels.Pages;
using OlibKey.Views.Windows;
using ReactiveUI;
using System;
using System.Reactive.Disposables;

namespace OlibKey.Views.Pages
{
	public class EditLoginPage : ReactiveUserControl<EditLoginPageViewModel>
	{
		private TextBox _txtPassword;
		private TextBox _txtSecurityCode;
		private ProgressBar _pbHard;

		public EditLoginPage() => InitializeComponent();

		private void InitializeComponent()
		{
			this.WhenActivated((CompositeDisposable disposable) => { });

			AvaloniaXamlLoader.Load(this);

			_txtPassword = this.FindControl<TextBox>("txtPassword");
			_txtSecurityCode = this.FindControl<TextBox>("txtSecurityCode");
			_pbHard = this.FindControl<ProgressBar>("pbHard");

			_txtPassword.GetObservable(TextBox.TextProperty).Subscribe(value => PasswordUtils.DeterminingPasswordComplexity(_pbHard, _txtPassword));
		}

		private void CheckedPassword(object sender, RoutedEventArgs e) => _txtPassword.PasswordChar = ((CheckBox)sender).IsChecked ?? false ? '\0' : '•';

		private void CheckedSecurityCode(object sender, RoutedEventArgs e) => _txtSecurityCode.PasswordChar = ((CheckBox)sender).IsChecked ?? false ? '\0' : '•';

		private async void GeneratePassword(object sender, RoutedEventArgs e)
		{
			App.MainWindowViewModel.PasswordGenerator = new PasswordGeneratorWindow { _saveButton = { IsVisible = true } };
			if (await App.MainWindowViewModel.PasswordGenerator.ShowDialog<bool>(App.MainWindow)) _txtPassword.Text = App.MainWindowViewModel.PasswordGenerator._tbPassword.Text;
		}
	}
}