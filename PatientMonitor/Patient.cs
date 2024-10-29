using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientMonitor
{
    internal class Patient
    {
        ECG ecg;
        private string patientName;
        private DateTime dateOfStudy;
        private int age;
        public double ECGAmplitude { get => ecg.Amplitude; set => ecg.Amplitude = value; }
        public double ECGFrequency { get => ecg.Frequency; set => ecg.Frequency = value; }

        public int ECGHarmonics { get => ecg.Harmonics; set => ecg.Harmonics = value; }

        public string PatientName { get => patientName; set => patientName = value; }

        public DateTime DateOfStudy { get => dateOfStudy; set => dateOfStudy = value; }
        public int Age { get => age; set => age = value; }
        public Patient(double ampltude, double frequency, int harmonics, string patientName, DateTime dateOfStudy, int age)
        {
            this.patientName = patientName;
            this.dateOfStudy = dateOfStudy;
            this.age = age;
            ecg = new ECG(ampltude, frequency, harmonics);
        }
        public double NextSample(double timeIndex)
        {
            return ecg.NextSample(timeIndex);
        }
    }
}