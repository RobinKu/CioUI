using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CioUI.Wpf
{
    internal static class TextBlockExtensions
    {
        internal static Size GetTextSize(this TextBlock textBlock)
        {
            Typeface typeface = new Typeface(textBlock.FontFamily, textBlock.FontStyle, textBlock.FontWeight, textBlock.FontStretch);

            FormattedText formattedText = new FormattedText(textBlock.Text, CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, typeface, textBlock.FontSize, Brushes.Black);

            return new Size(formattedText.Width, formattedText.Height);
        }
    }
}
