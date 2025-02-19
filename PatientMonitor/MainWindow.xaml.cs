﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;


using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Controls.DataVisualization.Charting.Compatible;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PatientMonitor
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<KeyValuePair<int, double>> dataPoints;
        private DispatcherTimer timer;
        private int index = 0;
        Patient patient;

        public MainWindow()
        {
            InitializeComponent();
            dataPoints = new ObservableCollection<KeyValuePair<int, double>>();
            lineSeriesECG.ItemsSource = dataPoints;
            patient = new Patient(100, (double)1.0, 1, "John Doe", DateTime.Now, 1);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.025); // Set timer to tick every second
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Generate a new data point
            dataPoints.Add(new KeyValuePair<int, double>(index++, patient.NextSample(index)));

            // Optional: Remove old points to keep the chart clean
            if (dataPoints.Count > 200) // Maximum number of points
            {
                dataPoints.RemoveAt(0); // Remove the oldest point
            }
        }

        private void Slider_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Slider slider = sender as Slider;
            if (slider.IsEnabled) slider.ValueChanged += sliderECG_ValueChanged;
            else slider.ValueChanged -= sliderECG_ValueChanged;
        }

        private void sliderECG_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            patient.ECGAmplitude = sliderECG.Value;
        }

        private void buttonParameter_Click(object sender, RoutedEventArgs e)
        {
            sliderECG.IsEnabled = true;
        }

        private void buttonCreatePatient_Click(object sender, RoutedEventArgs e)
        {
            buttonParameter.IsEnabled = true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }



        private void ButtonUpdatePatient_Click(object sender, RoutedEventArgs e)
        {

        }

       
        private void TextBoxFrequency_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        

        private void TextBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBoxPatientName_TextChanged(object sender, TextChangedEventArgs e)
        {
           // textBoxPatientName.Text = "";
        }

        private void textBoxPatientName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = int.TryParse(e.Text, out _);
        }

        private void textBoxPatientAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            e.Handled = !int.TryParse(e.Text, out int result);
        }

        private void datePickerMonitor_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // Überprüfen, ob ein gültiges Datum ausgewählt wurde
            if (!datePickerMonitor.SelectedDate.HasValue)
            {
                // Zeigt eine Warnung, wenn kein Datum ausgewählt ist oder ein ungültiges Datum eingegeben wurde
                MessageBox.Show("Please select a valid date!", "Invalid Date", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                // Optional: Bestätigung, dass das Datum korrekt ist
                DateTime selectedDate = datePickerMonitor.SelectedDate.Value;
                // Hier kann weitere Logik hinzugefügt werden, z.B. das gewählte Datum verwenden
            }
        }

        private void datePickerMonitor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void sliderECG_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        

        private void textBoxPatientName_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxPatientName.Text = "";
        }

        private void ComboBoxHarmonics_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}