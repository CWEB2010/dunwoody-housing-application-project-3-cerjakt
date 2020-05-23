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
using System.Windows.Shapes;
using Project_Three_GUI.Models;

namespace Project_Three_GUI
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        //Making a list for the floor numbers
        List<int[]> floorNumList = new List<int[]>
        {
            new int[] {1,2,3,4,5,6,7,8},
            new int[] {1,2,3},
            new int[] {4,5,6},
            new int[] {7,8}
        };

        ObservableCollection<Resident> residentWindowList = null;
        Data_Source source = new Data_Source();
        Resident aResident;

        //Used to initialize the second window and populate the floors list with data
        public SecondWindow()
        {
            InitializeComponent();
            //dropdown
            floor_number_combo_box.ItemsSource = floorNumList[0];
            //populating grid
            this.DataContext = source.readData();
            resident_entry_grid.ItemsSource = source.readData();

            residentWindowList = source.readData();
        }
        //Exit button close
        private void exit_btn(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
        //Submit button
        private void add_resident_btn(object sender, RoutedEventArgs e)
        {
            //selection 0 = student worker
            //selection 1 = athlete
            //selection 2 = scholarship recipient
            if (student_type_combo_box.SelectedIndex == 0)
            {
                double earnings = 14 * Convert.ToDouble(monthlyhoursBox.Text.ToString());
                double rent = 1245 - earnings;

                aResident = new Athlete(fullnameBox.Text.ToString(), student_type_combo_box.Text, Convert.ToInt32(studentidBox.Text.ToString()), Convert.ToInt32(room_number_combo_box.Text.ToString()), rent, Convert.ToInt32(floor_number_combo_box.Text.ToString()));
                //Adds a new student to list
                residentWindowList.Add(aResident);
                //Writes the new data to CSV file
                source.writeData(residentWindowList);
                MessageBox.Show("A resident was successfully added.");

                //Repopulating the datagrid with the addition of a new student
                resident_entry_grid.ItemsSource = residentWindowList;

                //Refresh the data grid
                resident_entry_grid.Items.Refresh();
            }
            else if (student_type_combo_box.SelectedIndex == 1)
            {
                
            }
            else if (student_type_combo_box.SelectedIndex == 2)
            {
               
            }

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
