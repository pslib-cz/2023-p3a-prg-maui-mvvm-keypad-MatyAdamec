using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MauiKeypad.Models;

namespace MauiKeypad.Converters
{
    internal class Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is EntryState state)
            {
                switch (state)
                {
                    case EntryState.Success:
                        return Colors.Green;
                    case EntryState.Denied:
                        return Colors.Red;
                    default:
                        return Colors.Transparent;
                }
            }
            return Colors.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Colors.Transparent;
        }
    }

}
