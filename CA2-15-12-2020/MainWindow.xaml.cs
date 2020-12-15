using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CA2_15_12_2020
{
    /*========================================================================
    # Tristan Reilly
    # S00199625
    # 09/12/2020
    # CA2 OOP
    =======================================================================*/

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Employee> employees = new ObservableCollection<Employee>(); // create collection for employees
        public MainWindow()
        {
            InitializeComponent();

        }
    }
}
