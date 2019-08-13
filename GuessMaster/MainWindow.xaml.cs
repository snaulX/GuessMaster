﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using Microsoft.Win32;
using System.IO;

namespace GuessMaster
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string fileName;

        public MainWindow()
        {
            InitializeComponent();
            fileName = "untitled";
            Title = $"Guess Master by snaulX v{Assembly.GetEntryAssembly().GetName().Version} - {fileName}";
            SaveFile.Click += SaveFile_Click;
        }

        public void SaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                AddExtension = true,
                CheckFileExists = false,
                CheckPathExists = true,
                Filter = "Guess files|*.guess",
                DefaultExt = $"{fileName}.guess"
            };
            dialog.ShowDialog();
            dialog.FileOk += SaveDialog_FileOk;
        }

        private void SaveDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            using (BinaryWriter writer = new BinaryWriter(System.IO.File.OpenWrite(fileName)))
            {

            }
        }

        private void AddQuestButton_Click(object sender, RoutedEventArgs e)
        {
            if (WorkField.RowDefinitions.Count >= 7)
            {
                MessageBox.Show("You cannot create more than 5 questions", "CreateError", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            WorkField.RowDefinitions.Add(new RowDefinition());
            int len = WorkField.RowDefinitions.Count - 1;
            CheckBox checkBox = new CheckBox
            {
                Name = "Right" + len,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            Grid.SetRow(checkBox, len);
            WorkField.Children.Add(checkBox);
            TextBox textBox = new TextBox
            {
                Name = "Answer" + len,
                FontSize = 16,
                Margin = new Thickness(0, 20, 0, 20)
            };
            Grid.SetRow(textBox, len);
            Grid.SetColumnSpan(textBox, 2);
            WorkField.Children.Add(textBox);
        }
    }
}
