﻿// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace AgOpenGPS.Helpers
{
    internal class FallbackBrushConverter : IValueConverter
    {
        public object Convert(
            object? value,
            Type targetType,
            object? parameter,
            CultureInfo culture
        )
        {
            if (value is SolidColorBrush brush)
            {
                return brush;
            }

            if (value is Color)
            {
                return new SolidColorBrush((Color)value);
            }

            // We draw red to visibly see an invalid bind in the UI.
            return new SolidColorBrush(
                new Color
                {
                    A = 255,
                    R = 255,
                    G = 0,
                    B = 0
                }
            );
        }

        public object ConvertBack(
            object? value,
            Type targetType,
            object? parameter,
            CultureInfo culture
        )
        {
            throw new NotImplementedException();
        }
    }
}
