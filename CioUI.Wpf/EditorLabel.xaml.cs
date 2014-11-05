using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CioUI.Wpf
{
    /// <summary>
    /// Interaction logic for EditorLabel.xaml
    /// </summary>
    [ContentProperty("Editor")]
    public partial class EditorLabel : UserControl
    {
        public EditorLabel()
        {
            InitializeComponent();
        }

        //public static readonly DependencyProperty LabelWidthProperty = DependencyProperty.Register("LabelWidth", typeof(float), typeof(EditorLabel));
        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(EditorLabel));
        public static readonly DependencyProperty EditorProperty = DependencyProperty.Register("Editor", typeof(object), typeof(EditorLabel));

        public double LabelWidth
        {
            get
            {
                return lbl.DesiredSize.Width;
            }
            set
            {
                lbl.Width = value;
            }
        }

        public string Label
        {
            get
            {
                return (string)GetValue(LabelProperty);
            }
            set
            {
                SetValue(LabelProperty, value);
            }
        }

        public object Editor
        {
            get
            {
                return GetValue(EditorProperty);
            }
            set
            {
                SetValue(EditorProperty, value);
            }
        }

        public double TextWidth
        {
            get
            {
                return lbl.GetTextSize().Width;
            }
        }

        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            Size returnSize = base.ArrangeOverride(arrangeBounds);

            Panel pnl = Parent as Panel;

            if (pnl != null)
            {
                LabelWidth = pnl.Children
                    .OfType<EditorLabel>()
                    .Where(e => VisualTreeHelper.GetOffset(e).X == VisualTreeHelper.GetOffset(this).X)
                    .Max(e => e.TextWidth);
            }

            return returnSize;
        }

        protected override void OnVisualParentChanged(DependencyObject oldParent)
        {
            base.OnVisualParentChanged(oldParent);

            FrameworkElement oldElement = oldParent as FrameworkElement;
            if (oldElement != null)
            {
                oldElement.SizeChanged -= SizeChangedHandler;
            }

            FrameworkElement newElement = Parent as FrameworkElement;
            if (newElement != null)
            {
                newElement.SizeChanged += SizeChangedHandler;
            }
        }

        private void SizeChangedHandler(object sender, SizeChangedEventArgs e)
        {
            InvalidateArrange();
        }
    }
}
