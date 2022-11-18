using System;
using System.IO;
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

namespace WpfCommandApp
{
    public class MainWindowCommand
    {
        public static RoutedCommand WindowExit { set; get; }
        static MainWindowCommand()
        {
            WindowExit = new RoutedCommand("AppExit", typeof(MainWindow));
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //btn.Command = ApplicationCommands.Help;

            //CommandBinding binding = new CommandBinding();
            //binding.Command = ApplicationCommands.Help;
            //binding.Executed += CommandHelpBinding_Executed;

            //btn.CommandBindings.Add(binding);
        }

        void CommandHelpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Welcome to Help Book");
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            using (StreamWriter writer = new("log.txt", true))
            {
                writer.WriteLine("App exit: date: " + DateTime.Now.ToShortDateString()
                    + " time: " + DateTime.Now.ToLongTimeString());
                writer.Flush();
            }

            this.Close();
        }
    }
}
