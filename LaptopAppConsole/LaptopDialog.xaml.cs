using Buchnat.LaptopsApp.Core;
using Buchnat.LaptopsApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Buchnat.LaptopsApp
{
    /// <summary>
    /// Interaction logic for LaptopDialog.xaml
    /// </summary>
    public partial class LaptopDialog : Window
    {
        public LaptopDialog(IEnumerable<string> producers)
        {
            InitializeComponent();
            producers.ToList().ForEach(p => laptopProducer.Items.Add(p));
            if (laptopProducer.Items.Count > 0)
            {
                laptopProducer.SelectedIndex = 0;
            }
            laptopProcessor.ItemsSource = Enum.GetNames(typeof(ProcessorType));
            if (laptopProcessor.Items.Count > 0)
            {
                laptopProcessor.SelectedIndex = 0;
            }
        }

        public LaptopDialog(IEnumerable<string> producers, ILaptop laptop)
        {
            InitializeComponent();
            producers.ToList().ForEach(p => laptopProducer.Items.Add(p));

            for (int i = 0; i < producers.Count(); i++)
            {
                if (producers.ElementAt(i).Equals(laptop.Producer.Name))
                {
                    laptopProducer.SelectedIndex = i;
                    break;
                }
            }
            laptopProcessor.ItemsSource = Enum.GetNames(typeof(ProcessorType));
            if (laptopProcessor.Items.Count > 0)
            {
                laptopProcessor.SelectedIndex = 0;
            }
            laptopModel.Text = laptop.Model;
            laptopProcessor.SelectedIndex = (int)laptop.Processor;
            laptopRAM.Text = laptop.RAM.ToString();
            laptopStorageInGB.Text = laptop.StorageInGB.ToString();
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            laptopModel.SelectAll();
            laptopModel.Focus();
        }

        public string LaptopModel
        {
            get { return laptopModel.Text; }
        }

        public ProcessorType LaptopProcessor
        {
            get
            {
                return (ProcessorType)laptopProcessor.SelectedIndex;
            }
        }

        public int LaptopRAM
        {
            get
            {
                return int.Parse(laptopRAM.Text);
            }
        }

        public int LaptopStorageInGB
        {
            get
            {
                return int.Parse(laptopStorageInGB.Text);
            }
        }

        public string LaptopProducer
        {
            get
            {
                return laptopProducer.Text;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
