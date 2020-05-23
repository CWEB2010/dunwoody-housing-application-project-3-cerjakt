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
using Project_Three_GUI.Models;

namespace Project_Three_GUI
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {

        List<int[]> floorNumList = new List<int[]>
        {
            new int[] {1,2,3,4,5,6,7,8},
            new int[] {1,2,3},
            new int[] {4,5,6},
            new int[] {7,8}
        };

        //Used to initialize the second window and populate the floors list with data
        public SecondWindow()
        {
            InitializeComponent();
            floor_number_combo_box.ItemsSource = floorNumList[0];
        }
        //Exit button close
        private void exit_btn(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
        //Submit button
        private void add_resident_btn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //Logic for making the floors changed based on the student type
        private void student_type_changed(object sender, SelectionChangedEventArgs e)
        {
            if (student_type_combo_box.SelectedIndex == 0)
            {
                floor_number_combo_box.ItemsSource = floorNumList[1];
            }
            else if (student_type_combo_box.SelectedIndex == 1)
            {
                floor_number_combo_box.ItemsSource = floorNumList[2];
            }
            else if (student_type_combo_box.SelectedIndex == 2)
            {
                floor_number_combo_box.ItemsSource = floorNumList[3];
            }
        }
    }
}
