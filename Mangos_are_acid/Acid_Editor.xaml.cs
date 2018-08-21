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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mangos_are_acid
{
    /// <summary>
    /// Interaction logic for Acid_Editor.xaml
    /// </summary>
    public partial class Acid_Editor : Window
    {
        public Acid_Editor()
        {
            InitializeComponent();
            Color color = (Color)ColorConverter.ConvertFromString("#273b78");
            var loadButton = (Button)this.FindName("load");
            loadButton.Background = new SolidColorBrush(color);
        }
    }
}
