using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace TextBox_Focus
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = false;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = false;
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxUsername.Text.Trim()) || string.IsNullOrEmpty(TextBoxPassword.Text.Trim()))
            {
                MessageBox.Show("Please provide a username and password to continue.", "Info", MessageBoxButton.OK);
            }
            else
            {
                //Close the popup
                ClosePopup();
            }
        }

        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            ClosePopup();
        }

        private void ButtonPopup_Click(object sender, RoutedEventArgs e)
        {
            ApplicationTitle.Text = " ";
            popupCredentails.IsOpen = true;
            LayoutRoot.IsHitTestVisible = false;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = true;
            TextBoxUsername.Focus();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (popupCredentails.IsOpen)
            {
                e.Cancel = true;                    // Cancel subsequent BackKey navigation
                ClosePopup();
            }
            base.OnBackKeyPress(e); // Call base
        }

        private void ClosePopup()
        {
            // If the currently displayed dialog is a pop-up, dialog etc., and
            // a Back Key Press occurs, then "close" the pop-up or dialog, and prevent GoBack.
            popupCredentails.IsOpen = false;                   // Hide the popup
            LayoutRoot.IsHitTestVisible = true; // Restore mouse hit on main page
            ApplicationTitle.Text = "TextBox Focus";

            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = false;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = false;
        }
    }
}