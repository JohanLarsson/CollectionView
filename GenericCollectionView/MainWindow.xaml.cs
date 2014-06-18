using System.Windows;

namespace GenericCollectionView
{
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Vm _vm;
        public MainWindow()
        {
            InitializeComponent();
            _vm = new Vm();
            DataContext = _vm;
        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            _vm.Persons = _vm.Persons.Concat(new[] { new Person("Next") }).ToArray();
        }
    }
}
