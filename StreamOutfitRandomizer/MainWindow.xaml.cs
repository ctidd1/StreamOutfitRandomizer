using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using StreamOutfitRandomizer.Contexts;
using StreamOutfitRandomizer.Models;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StreamOutfitRandomizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CategoryContext _categoryContext = new();
        private CollectionViewSource categoryViewSource;
        private Random random;


        public MainWindow()
        {
            InitializeComponent();
            categoryViewSource = (CollectionViewSource)FindResource(nameof(categoryViewSource));
            random = new Random();
            categoryDataGrid.CellEditEnding += OnCellEditEnding;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                bool isCreated = _categoryContext.Database.EnsureCreated();
                _categoryContext.Categories.Load();
                categoryViewSource.Source = _categoryContext.Categories.Local.ToObservableCollection();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void MakeRandomChoice(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Test");
            var row = categoryDataGrid.SelectedItem;
            if (row is Category category)
            {
                category.RandomChoice = random.Next(category.NumberOfItems);
                _categoryContext.SaveChanges();
            }
        }
        private void OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            _categoryContext.SaveChanges();   
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _categoryContext.Dispose();
            base.OnClosing(e);
        }
    }
}