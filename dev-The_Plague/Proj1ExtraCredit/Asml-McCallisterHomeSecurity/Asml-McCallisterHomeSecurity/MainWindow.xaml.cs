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
using OperationsManager;
using Microsoft.Win32;
using System.Reflection;

namespace Asml_McCallisterHomeSecurity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OperationsManager.OperationsManager  _rules_them_all;
        public MainWindow()
        {

            InitializeComponent();
            _rules_them_all = OperationsManager.OperationsManager.GetInstance();
            _rules_them_all.ChangedTargets += on_targets_changed;
            //this.DataContext = this._rules_them_all;
            string version_string = Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();
            string program_title = "ASML-McCallister Home Security ";
            this.Title = program_title + version_string;
            lblNumMissiles.Content = _rules_them_all.NumberMissiles.ToString();
        }


        /*
         * Turret controls in this region 
         */
        #region Turret_Controls 

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _rules_them_all.TurretMoveUp();
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _rules_them_all.TurretMoveDown();
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _rules_them_all.TurretMoveLeft();
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _rules_them_all.TurretMoveRight();
                winHomeScreen.Focus();
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnFire_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _rules_them_all.TurretFire();
                lblNumMissiles.Content = _rules_them_all.NumberMissiles.ToString();
                winHomeScreen.Focus();
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _rules_them_all.TurretReset();
                winHomeScreen.Focus();
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }
        #endregion


        /*
         * Target info controls in this region
         */
        #region target_info controls
        /// <summary>
        /// retrieves a filename via OpenFileDialog and then attempts to process it for targets.
        /// if an error occurs, reports it to the user va a messagebox.
        /// </summary>
        /// <param name="sender">Object representing the control</param>
        /// <param name="e">RoutedEventArgs</param>
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "";
            dialog.Filter = "Target Files(.ini, .xml)|*.ini;*.xml| All Files(*.*)|*.*";

            Nullable<bool> result = dialog.ShowDialog();
            string file_name = null;

            if (result == true)
            {
                file_name = dialog.FileName;
                try
                {
                    _rules_them_all.LoadFile(file_name);
                    lblTargetFileName.Content = file_name;
                }
                catch (Exception ex)
                {
                    DisplayError(ex.Message);
                    lblTargetFileName.Content = "No Targets Detected.";
                }
            }
            Keyboard.Focus(winHomeScreen);
            winHomeScreen.Focus();
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _rules_them_all.ReloadTurret();
                lblNumMissiles.Content = _rules_them_all.NumberMissiles;
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
            Keyboard.Focus(winHomeScreen);     
        }

        private void on_targets_changed()
        {
            lstTargets.Items.Clear();
            foreach(ListViewItem item in _rules_them_all.TargetInfo)
            {
                lstTargets.Items.Add(item);
            }
        }

        #endregion

        private void DisplayError(string Message)
        {
            System.Windows.MessageBox.Show(Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);            
        }
    }
}