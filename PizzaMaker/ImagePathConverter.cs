﻿using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace PizzaMaker
{
    public class ImagePathConverter : IValueConverter
    {
        private string imageDirectory = Directory.GetCurrentDirectory();

        public string ImagePath(int levelNumber)
        {
            if (levelNumber == 1)
                return "Images/level1.png";
            else if (levelNumber == 2)
                return "Images/level2.png";
            else if (levelNumber == 3)
                return "Images/level3.png";
            else
                return "Images/blank.png";
        }

        public string ImageDirectory
        {
            get { return imageDirectory; }
            set { imageDirectory = value; }
        }

        public object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            string imagePath = System.IO.Path.Combine(ImageDirectory, (string)value);
            return new BitmapImage(new Uri(imagePath));
        }

        public object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        { return null; }
    }
}
