using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace RLTimer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        #region Private Fields
        private int _initialMinutes = 0;
        private int _initialSeconds = 0;
        private int _initialHours = 0;

        private int _currentHours;
        private int _currentMinutes;
        private int _currentSeconds;

        public string CurrentHoursText { get; set; }

        public int CurrentHours
        {
            get
            {
                return _currentHours;
            }

            set
            {
                _currentHours = value;
                CurrentHoursText = value.ToString();
            }
        }

        public int CurrentMinutes
        {
            get
            {
                return _currentMinutes;
            }

            set
            {
                _currentMinutes = value;
            }
        }

        public int CurrentSeconds
        {
            get
            {
                return _currentSeconds;
            }

            set
            {
                _currentSeconds = value;
            }
        }

        #endregion

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            InitializeVariables();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }


        private void InitializeVariables()
        {
            hoursTextBox.Text = _initialHours.ToString();
            minutesTextBox.Text = _initialMinutes.ToString();
            secondsTextBox.Text = _initialSeconds.ToString();
            hoursTextBox.DataContext = this;


        }



        private void hoursTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(hoursTextBox.Text))
            {
                hoursTextBox.Text = "0";
                return;
            }
            decimal hoursInput = decimal.Parse(hoursTextBox.Text);
            hoursInput = Math.Round(hoursInput, MidpointRounding.AwayFromZero);

            int rounded = Convert.ToInt32(hoursInput);
            hoursTextBox.Text = rounded.ToString();
            return;

        }

        private void minutesTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(minutesTextBox.Text))
            {
                minutesTextBox.Text = "0";
                return;
            }
            decimal minutesInput = decimal.Parse(minutesTextBox.Text);
            minutesInput = Math.Round(minutesInput, MidpointRounding.AwayFromZero);

            int roundedMinutes = Convert.ToInt32(minutesInput);


            //See if >60 minutes
            if (roundedMinutes > 59)
            {
                TimeSpan ts = TimeSpan.FromMinutes(roundedMinutes);
                int minutes = ts.Minutes;
                int hours = ts.Hours;

                IncrementStartingHours(hours);

                roundedMinutes = minutes;
            }





            minutesTextBox.Text = roundedMinutes.ToString();
            return;
        }

        private void secondsTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(secondsTextBox.Text))
            {
                secondsTextBox.Text = "0";
                return;
            }
            decimal secondsInput = decimal.Parse(secondsTextBox.Text);
            secondsInput = Math.Round(secondsInput, MidpointRounding.AwayFromZero);

            int roundedSeconds = Convert.ToInt32(secondsInput);

            //See if >60 seconds
            if (roundedSeconds > 59)
            {
                TimeSpan ts = TimeSpan.FromSeconds(roundedSeconds);
                int minutes = ts.Minutes;
                int hours = ts.Hours;

                IncrementStartingMinutes(minutes);
                IncrementStartingHours(hours);
                roundedSeconds = 0;
                roundedSeconds = ts.Seconds;
            }

            secondsTextBox.Text = roundedSeconds.ToString();
            return;
        }

        private void secondsTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(secondsTextBox.Text))
            {
                return;
            }

            if (secondsTextBox.Text == "0")
            {
                secondsTextBox.Text = "";


            }
        }

        private void IncrementStartingMinutes(int minutesToAdd)
        {
            if (String.IsNullOrEmpty(minutesTextBox.Text))
            {
                return;
            }
            decimal minutesInput = decimal.Parse(minutesTextBox.Text);
            minutesInput = Math.Round(minutesInput, MidpointRounding.AwayFromZero);

            int rounded = Convert.ToInt32(minutesInput);
            rounded += minutesToAdd;
            minutesTextBox.Text = rounded.ToString();
            return;
        }

        private void IncrementStartingHours(int hoursToAdd)
        {
            if (String.IsNullOrEmpty(hoursTextBox.Text))
            {
                return;
            }
            decimal hoursInput = decimal.Parse(hoursTextBox.Text);
            hoursInput = Math.Round(hoursInput, MidpointRounding.AwayFromZero);

            int rounded = Convert.ToInt32(hoursInput);
            rounded += hoursToAdd;
            hoursTextBox.Text = rounded.ToString();
            return;
        }

        private void minutesTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(minutesTextBox.Text))
            {
                return;
            }

            if (minutesTextBox.Text == "0")
            {
                minutesTextBox.Text = "";


            }
        }

        private void hoursTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(hoursTextBox.Text))
            {
                return;
            }

            if (hoursTextBox.Text == "0")
            {
                hoursTextBox.Text = "";


            }
        }

        private void startTimerButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentHours = 5;
        }
    }//end class
}
