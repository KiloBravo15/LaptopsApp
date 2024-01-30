using Buchnat.LaptopsApp.Core;
using Buchnat.LaptopsApp.Interfaces;
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
using System.Windows.Shapes;
using BL = Buchnat.LaptopsApp.BLC;
using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using Buchnat.LaptopsApp.DAOSQL;
using System.Configuration;
using Buchnat.LaptopsApp.Models;

namespace Buchnat.LaptopsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ViewModels.LaptopListViewModel LaptopLVM { get; } = new ViewModels.LaptopListViewModel();
        private ViewModels.LaptopViewModel selectedLaptop = null;

        public ViewModels.ProducerListViewModel ProducerLVM { get; } = new ViewModels.ProducerListViewModel();
        private ViewModels.ProducerViewModel selectedProducer = null;

        private readonly BL.BLC blc;
        private bool _isBLCAvailable = false;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            blc = new BL.BLC(ConfigurationManager.AppSettings["DAOLibraryName"]);

            LaptopLVM.RefreshList(blc.GetLaptops().Distinct());
            ProducerLVM.RefreshList(blc.GetProducers());

        }

        private void LaptopList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                ChangeSelectedLaptop((ViewModels.LaptopViewModel)e.AddedItems[0]);
            }
        }

        private void EditLaptop(object sender, RoutedEventArgs e)
        {
            if (selectedLaptop != null)
            {
                LaptopDialog laptopEditDialog = new(
                    blc.GetProducers().Select(x => x.Name),
                    blc.GetLaptopById(selectedLaptop.LaptopGUID)
                );

                if (laptopEditDialog.ShowDialog() == true)
                {
                    blc.CreateOrUpdateLaptop(new Models.Laptop()
                    {
                        Id = selectedLaptop.LaptopGUID,
                        Model = laptopEditDialog.LaptopModel,
                        Producer = blc.GetProducer(new Guid(laptopEditDialog.LaptopProducer)),
                        Processor = laptopEditDialog.LaptopProcessor,
                        RAM = laptopEditDialog.LaptopRAM,
                        StorageInGB = laptopEditDialog.LaptopStorageInGB
                    });

                    LaptopLVM.RefreshList(blc.GetLaptops());
                    ChangeSelectedLaptop(null);
                }
            }
            else
            {
                MessageBox.Show("Laptop is not selected!");
            }
        }

        private void RemoveLaptop(object sender, RoutedEventArgs e)
        {
            if (selectedLaptop != null)
            {
                blc.RemoveLaptop(selectedLaptop.LaptopGUID);
                LaptopLVM.RefreshList(blc.GetLaptops());
                selectedLaptop = null;
            }
            else
            {
                MessageBox.Show("Laptop is not selected!");
            }
        }

        private void AddLaptop(object sender, RoutedEventArgs e)
        {
            var allProducersNames = blc.GetProducers().Select(x => x.Name);
            LaptopDialog laptopInputDialog = new(allProducersNames);

            if (laptopInputDialog.ShowDialog() == true)
            {
                Models.Laptop laptop;
                try
                {
                    laptop = new Models.Laptop()
                    {
                        Id = selectedLaptop.LaptopGUID,
                        Model = laptopInputDialog.LaptopModel,
                        Producer = blc.GetProducer(new Guid(laptopInputDialog.LaptopProducer)),
                        Processor = laptopInputDialog.LaptopProcessor,
                        RAM = laptopInputDialog.LaptopRAM,
                        StorageInGB = laptopInputDialog.LaptopStorageInGB
                    };
                }
                catch
                {
                    MessageBox.Show("Error occurred, check your input values!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                blc.CreateOrUpdateLaptop(laptop);
                LaptopLVM.RefreshList(blc.GetLaptops());
            }
        }
        private void AddProducer(object sender, RoutedEventArgs e)
        {
            ProducerDialog producerDialog = new();

            if (producerDialog.ShowDialog() == true)
            {
                Producer producer;
                try
                {
                    producer = new Producer()
                    {
                        Name = producerDialog.ProducerName,
                        Description = producerDialog.ProducerDescription
                    };
                }
                catch
                {
                    MessageBox.Show("Error occurred, check your input values!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                blc.CreateOrUpdateProducer(producer);
                ProducerLVM.RefreshList(blc.GetProducers());
            }
        }

        private void RemoveProducer(object sender, RoutedEventArgs e)
        {
            if (selectedProducer != null)
            {
                blc.RemoveProducer(selectedProducer.ProducerGUID);
                ProducerLVM.RefreshList(blc.GetProducers());
                selectedProducer = null;
            }
            else
            {
                MessageBox.Show("Producer is not selected!");
            }
        }

        private void EditProducer(object sender, RoutedEventArgs e)
        {
            if (selectedProducer != null)
            {
                ProducerDialog producerDialog = new(
                    blc.GetProducer(selectedProducer.ProducerGUID)
                );

                if (producerDialog.ShowDialog() == true)
                {
                    blc.CreateOrUpdateProducer(new Producer()
                    {
                        Id = selectedProducer.ProducerGUID,
                        Name = producerDialog.ProducerName,
                        Description = producerDialog.ProducerDescription
                    });

                    ProducerLVM.RefreshList(blc.GetProducers());
                    ChangeSelectedProducer(null);
                }
            }
            else
            {
                MessageBox.Show("Producer is not selected!");
            }
        }

        private void ChangeSelectedLaptop(ViewModels.LaptopViewModel laptopViewModel)
        {
            selectedLaptop = laptopViewModel;
            DataContext = selectedLaptop;
        }


        #region Producer operations

        private void ChangeSelectedProducer(ViewModels.ProducerViewModel producerViewModel)
        {
            selectedProducer = producerViewModel;
            DataContext = selectedProducer;
        }

        // Define similar CRUD operations for Producers as in the aircraft example

        #endregion


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
