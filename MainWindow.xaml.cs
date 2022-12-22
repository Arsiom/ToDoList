using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WPF.models;
using WPF.Services;


namespace WPF
{
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\todoDataList.json";
        private BindingList <ToDoModel> _todoDataList;
        private IO _fileIOService;
            
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOService = new IO(PATH);

            _todoDataList = _fileIOService.LoadData();

            dgList.ItemsSource = _todoDataList;
            _todoDataList.ListChanged += _todoDataList_ListChanged;
        }

        private void _todoDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if(e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged || e.ListChangedType == ListChangedType.ItemAdded)
            {
                _fileIOService.SaveData(sender);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            //string s;
            //s = textbox.Text;

            //_todoDataList = new BindingList<ToDoModel>()
            //{
            // new ToDoModel() { Text = s}
            //};

            //dgList.ItemsSource = _todoDataList;
            //_todoDataList.ListChanged += _todoDataList_ListChanged;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
