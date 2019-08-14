using System;
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
            if ((bool)dialog.ShowDialog())
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(dialog.FileName, FileMode.OpenOrCreate)))
                {
                    //pass
                }
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
            int len = WorkField.RowDefinitions.Count - 2;
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
                Margin = new Thickness(0, 20, 0, 20),
                Text = "Write your new case"
            };
            Grid.SetRow(textBox, len);
            Grid.SetColumn(textBox, 1);
            Grid.SetColumnSpan(textBox, 2);
            WorkField.Children.Add(textBox);
            Grid.SetRow(PrevButton, len + 1);
            Grid.SetRow(NextButton, len + 1);
            Grid.SetRow(AddQuestButton, len + 1);
            Grid.SetRow(RemoveQuestButton, len + 1);
        }

        private void RemoveQuestButton_Click(object sender, RoutedEventArgs e)
        {
            int len = WorkField.RowDefinitions.Count;
            if (len <= 3)
            {
                MessageBox.Show("You cannot remove lower than 1 question", "RemoveError", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            foreach (UIElement element in WorkField.Children)
            {
                if (Grid.GetRow(element) == len - 2)
                    Grid.SetRow(element, len - 3); //while in debugging
            }
            WorkField.RowDefinitions.RemoveAt(len - 2);
        }
    }
}
