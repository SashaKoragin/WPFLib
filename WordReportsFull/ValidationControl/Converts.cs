﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace WordReportsFull.ValidationControl
{
    class Converts : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var img = (Icon)value;
            if (img != null)
            {
                var bitmap = img.ToBitmap();
                bitmap.MakeTransparent();
                var hBitmap = bitmap.GetHbitmap();
                ImageSource wpfBitmap = Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                return wpfBitmap;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
