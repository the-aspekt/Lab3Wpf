using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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

namespace Lab3Wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> styles = new List<string>() { "White.xaml", "Dark.xaml" };

        public MainWindow()
        {

            InitializeComponent();
            
            Uri uri = new Uri(styles[0], UriKind.Relative);
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(Application.LoadComponent(uri) as ResourceDictionary);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (textBox != null)
            {
                string selectedFont = ((sender as ComboBox).SelectedItem as string);
                textBox.FontFamily = new FontFamily(selectedFont);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (textBox != null)
            {
                int selectedFontSize = Convert.ToInt16(((sender as ComboBox).SelectedItem as string));
                textBox.FontSize = selectedFontSize;
            }
        }

        private void Image_IsEnabledChanged(object sender, MouseButtonEventArgs e)
        {
            if (textBox.FontWeight != FontWeights.Bold)
            {
                textBox.FontWeight = FontWeights.Bold;
            }
            else
            {
                textBox.FontWeight = FontWeights.Normal;
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (textBox.FontStyle != FontStyles.Italic)
            {
                textBox.FontStyle = FontStyles.Italic;
            }
            else
            {
                textBox.FontStyle = FontStyles.Normal;
            }
        }

        private void ToggleButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (textBox.TextDecorations.Count == 0)
            {
                textBox.TextDecorations.Add(TextDecorations.Underline);
            }
            else
            {
                textBox.TextDecorations.Clear();
            }
           
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = new SolidColorBrush(Colors.Red);
            }
        }


        private void MenuItem_Click3(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            menu.WindowStyle = WindowStyle.ToolWindow;
            menu.ShowDialog();
        }

        private void MenuItem_Click(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            //dialog.ShowDialog();
            if (dialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(dialog.FileName);
            }
        }

        private void MenuItem_Click_1(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            //saveFileDialog.ShowDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        {

           MessageBoxResult exitQuestion = MessageBox.Show("Вы уверены, что хотите выйти?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (exitQuestion == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }

        }

        private void DarkThemeExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Uri uri = new Uri(styles[0], UriKind.Relative);

            if (ThemeFlag.IsChecked == true)
            {
                uri = new Uri(styles[1], UriKind.Relative);
            }
            
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(Application.LoadComponent(uri) as ResourceDictionary);

        }

    }
}
