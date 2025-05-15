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
using Microsoft.Win32;

namespace Lab2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CommandBinding saveCommand = new CommandBinding(ApplicationCommands.Save, execute_Save, canExecute_Save);
            CommandBinding deleteCommand = new CommandBinding(ApplicationCommands.Delete, execute_Delete, canExecute_Delete);
            CommandBinding openCommand = new CommandBinding(ApplicationCommands.Open, execute_Open, canExecute_Open);
            CommandBindings.Add(saveCommand);
            CommandBindings.Add(deleteCommand);
            CommandBindings.Add(openCommand);
        }
        void canExecute_Save(object sender, CanExecuteRoutedEventArgs e)
        {
            if (inputTextBox.Text.Trim().Length > 0) e.CanExecute = true; else e.CanExecute = false;
        }
        void execute_Save(object sender, ExecutedRoutedEventArgs e)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = System.IO.Path.Combine(documentsPath, "File.txt");
            System.IO.File.WriteAllText(filePath, inputTextBox.Text);
            MessageBox.Show($"The file was saved to:\n{filePath}");
        }

        void canExecute_Open(object sender, CanExecuteRoutedEventArgs e)
        {
            if (inputTextBox.Text.Length == 0) e.CanExecute = true; else e.CanExecute = false;
        }
        void execute_Open(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == false) return;
            string filename = ofd.FileName;
            inputTextBox.Text = System.IO.File.ReadAllText(filename);
        }
        void canExecute_Delete(object sender, CanExecuteRoutedEventArgs e)
        {
            if (inputTextBox.Text.Length > 0) e.CanExecute = true; else e.CanExecute = false;
        }
        void execute_Delete(object sender, ExecutedRoutedEventArgs e)
        {
            inputTextBox.Text = "";
            MessageBox.Show("Successfully deleted!");
        }

    }
}

