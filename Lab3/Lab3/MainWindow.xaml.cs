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

namespace Lab3
{
    public partial class MainWindow : Window
    {
        private static readonly string[] answers =
        {
            "Так", "Ні", "Скоріше так", "Скоріше ні"
        };

        public MainWindow()
        {
            InitializeComponent();

            CommandBinding findCommand = new CommandBinding(ApplicationCommands.Find, Execute_Find, CanExecute_Find);
            CommandBindings.Add(findCommand);
        }

        private void CanExecute_Find(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrWhiteSpace(questionBox.Text);
        }

        private void Execute_Find(object sender, ExecutedRoutedEventArgs e)
        {
            Random rand = new Random();
            string result = answers[rand.Next(answers.Length)];
            answerText.Text = result;
        }
    }
}
