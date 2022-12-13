﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_SR6
{
     enum Precipitation
    {
        sun,
        cloud,
        rain,
        snow
    }
    internal class WeatherControl : DependencyObject
    {
        private string windDirection;
        private int windSpeed;
        private Precipitation precipitation;


        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }

        public WeatherControl(string windDirection, int windSpeed, Precipitation precipitation)
        {
            this.windDirection = windDirection;
            this.windSpeed = windSpeed;
            this.precipitation = precipitation;
        }
        public static readonly DependencyProperty TempProperty;
        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);

        }
        static WeatherControl() 
        {
            TempProperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemp)),
                new ValidateValueCallback(ValidateTemp));

        }
        private static bool ValidateTemp (object value)
        {
            int v = (int)value;
            if (v>=-50 && v<= 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static object CoerceTemp (DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v>=-50 && v<= 50)
            {
                return v;
            }
            else
            {
                return null;
            }
        }
    }
}
