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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {

        bool g;
        EncryptionManager encryptionManager;
        public MainWindow()
        {
            InitializeComponent();

            encryptionManager = new EncryptionManager();

            EncryptionManager.IsEncry = true;
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)CipherComboBox.SelectedItem;
            string method = selectedItem?.Content.ToString();
            string result = encryptionManager.ChoosingEncryption(method, KeyTextBox.Text, InputTextBox.Text);
            OutputTextBox.Text = result;

        }

        private void EncryptRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            g = true;
            if (EncryptButton != null && g)
            {
                EncryptButton.Content = "Шифровать";
                EncryptionManager.IsEncry = g;
            }

        }

        private void DecryptRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            g = false;
            EncryptButton.Content = "Дешифровать";
            EncryptionManager.IsEncry = g;

        }

        private void CipherComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
