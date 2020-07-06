﻿using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;
using ReactiveUI;

namespace OlibKey.Core
{
	public class TextBoxPlus : TextBox, IStyleable
	{
		private bool _defaultContextEnabled = true;
		public bool DefaultContextEnabled { get => _defaultContextEnabled; set { this._defaultContextEnabled = false; } }
		Type IStyleable.StyleKey => typeof(TextBox);
		public MenuItem[] AppendContextMenuItems { get; set; }
		private List<object> contextMenuItemList;
		public static readonly StyledProperty<ContextMenu> TextBoxContextMenuProperty =
			AvaloniaProperty.Register<Control, ContextMenu>(nameof(TextBoxContextMenu));

		public ContextMenu TextBoxContextMenu { get => GetValue(TextBoxContextMenuProperty); set => SetValue(TextBoxContextMenuProperty, value); }

		public TextBoxPlus() : base()
		{
			contextMenuItemList = new List<object>();
			this.ContextMenu = new ContextMenu();
			this.ContextMenu.ContextMenuOpening += ContextMenu_ContextMenuOpening;
		}

		private void ContextMenu_ContextMenuOpening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (contextMenuItemList.Count == 0)
			{
				if (this.DefaultContextEnabled)
				{

					contextMenuItemList.AddRange(new[] {
					new MenuItem() { Header = "Cut", Command = ReactiveCommand.Create(CutCommand), IsEnabled=!this.IsReadOnly },
					new MenuItem() { Header = "Copy", Command = ReactiveCommand.Create(CopyCommand) },
					new MenuItem() { Header = "Paste", Command = ReactiveCommand.Create(PasteCommand),IsEnabled=!this.IsReadOnly},
					new MenuItem() { Header = "Select All", Command = ReactiveCommand.Create(SelectAllCommand) },
					new MenuItem() { Header = "Clear Selection", Command = ReactiveCommand.Create(ClearSelCommand) },
					});


				}
				if (this.TextBoxContextMenu != null)
				{
					var contextItems = this.TextBoxContextMenu.Items;
					this.TextBoxContextMenu.Items = null;
					if (contextItems != null)
						foreach (var x in contextItems)
						{
							contextMenuItemList.Add(x);
						}
				}



				this.ContextMenu.Items = contextMenuItemList;
			}

		}

		private void ClearSelCommand()
		{
			SelectionStart = 0;
			SelectionEnd = 0;
		}

		private void SelectAllCommand()
		{
			SelectionStart = 0;
			SelectionEnd = Text.Length;
		}

		private async void CutCommand()
		{
			await Application.Current.Clipboard.SetTextAsync(SelectedText);
			SelectedText = string.Empty;
		}

		public async void CopyCommand()
		{
			await Application.Current.Clipboard.SetTextAsync(SelectedText);
		}

		public async void PasteCommand()
		{
			var text = await Application.Current.Clipboard.GetTextAsync();
			Text = Text.Insert(SelectionStart, text);
			SelectionStart += SelectionStart + text.Length;
		}
	}
}
