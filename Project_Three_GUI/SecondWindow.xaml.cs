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

        //Declaring variables to be used for querying and other logic
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

            //Query Logic
            residentWindowList = source.readData();

            //Count the amount of student workers in the resident window list
            var student_worker_query = residentWindowList.Where(x => x.type.ToString().Contains("Student Worker"));
            studentworkerBox.Text = student_worker_query.Count().ToString();

            //Count the amount of athletes in the resident window list
            var student_athlete_query = residentWindowList.Where(x => x.type.ToString().Contains("Athlete"));
            athleteBox.Text = student_athlete_query.Count().ToString();

            //Count the amount of scholarship recipients in the resident window list
            var student_scholarship_recipient_query = residentWindowList.Where(x => x.type.ToString().Contains("Scholarship Recipient"));
            scholarshiprecipientBox.Text = student_scholarship_recipient_query.Count().ToString();

            //Count the amount of residents in floors 1-3
            //The or operator is used to account for multiple floors 
            var floor1to3_query = residentWindowList.Where(x => x.floor.Equals(1) | x.floor.Equals(2) | x.floor.Equals(3));
            floor1to3Box.Text = floor1to3_query.Count().ToString();

            //Count the amount of residents in floors 4-6
            var floor4to6_query = residentWindowList.Where(x => x.floor.Equals(4) | x.floor.Equals(5) | x.floor.Equals(6));
            floor4to6Box.Text = floor4to6_query.Count().ToString();

            //Count the amount of residents in floors 7-8
            var floor7to8_query = residentWindowList.Where(x => x.floor.Equals(7) | x.floor.Equals(8));
            floor7to8Box.Text = floor7to8_query.Count().ToString();

        }

        //Exit button close
        private void exit_btn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Refresh button functionality
        //It reuses code that initiates when the second window opens
        private void refresh_btn(object sender, RoutedEventArgs e)
		{

            //Refresh the data grid
            resident_entry_grid.Items.Refresh();

            //Query Logic
            residentWindowList = source.readData();

            //Count the amount of student workers in the resident window list
            var student_worker_query = residentWindowList.Where(x => x.type.ToString().Contains("Student Worker"));
            studentworkerBox.Text = student_worker_query.Count().ToString();

            //Count the amount of athletes in the resident window list
            var student_athlete_query = residentWindowList.Where(x => x.type.ToString().Contains("Athlete"));
            athleteBox.Text = student_athlete_query.Count().ToString();

            //Count the amount of scholarship recipients in the resident window list
            var student_scholarship_recipient_query = residentWindowList.Where(x => x.type.ToString().Contains("Scholarship Recipient"));
            scholarshiprecipientBox.Text = student_scholarship_recipient_query.Count().ToString();

            //Count the amount of residents in floors 1-3
            //The or operator is used to account for multiple floors 
            var floor1to3_query = residentWindowList.Where(x => x.floor.Equals(1) | x.floor.Equals(2) | x.floor.Equals(3));
            floor1to3Box.Text = floor1to3_query.Count().ToString();

            //Count the amount of residents in floors 4-6
            var floor4to6_query = residentWindowList.Where(x => x.floor.Equals(4) | x.floor.Equals(5) | x.floor.Equals(6));
            floor4to6Box.Text = floor4to6_query.Count().ToString();

            //Count the amount of residents in floors 7-8
            var floor7to8_query = residentWindowList.Where(x => x.floor.Equals(7) | x.floor.Equals(8));
            floor7to8Box.Text = floor7to8_query.Count().ToString();

            //Repopulating the datagrid with the addition of a new student
            resident_entry_grid.ItemsSource = residentWindowList;
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
                //Show a message box to the user when they add a resident
                MessageBox.Show("A Resident was successfully added.");
            }
            else if (student_type_combo_box.SelectedIndex == 1)
            {
                double rent = 1200;

                aResident = new Athlete(fullnameBox.Text.ToString(), student_type_combo_box.Text, Convert.ToInt32(studentidBox.Text.ToString()), Convert.ToInt32(room_number_combo_box.Text.ToString()), rent, Convert.ToInt32(floor_number_combo_box.Text.ToString()));
                //Adds a new student to list
                residentWindowList.Add(aResident);
                //Writes the new data to CSV file
                source.writeData(residentWindowList);
                MessageBox.Show("A Resident was successfully added.");
            }
            else if (student_type_combo_box.SelectedIndex == 2)
            {
                double rent = 100;

                aResident = new Athlete(fullnameBox.Text.ToString(), student_type_combo_box.Text, Convert.ToInt32(studentidBox.Text.ToString()), Convert.ToInt32(room_number_combo_box.Text.ToString()), rent, Convert.ToInt32(floor_number_combo_box.Text.ToString()));
                //Adds a new student to list
                residentWindowList.Add(aResident);
                //Writes the new data to CSV file
                source.writeData(residentWindowList);
                MessageBox.Show("A Resident was successfully added.");
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //Logic for making the floors changed based on the student type
        //If student worker is selected, populate the combo box with floors 1 through 3
        //If athlete is selected, populate the combo box with floors 4 through 6
        //If scholarship recipient is selected, populate the combo box with floors 7 through 8
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

        //Logic for filtering the table by student ID
        private void search_bar_textchanged(object sender, TextChangedEventArgs e)
        {
            //try and catch was needed to be used to prevent an error in the if statement
            //if the if the id of a resident contains the same value as the search bar text, filter the grid to that number
            try
            {
                if (search_bar.Text != null)
                {
                    resident_entry_grid.ItemsSource = residentWindowList.Where(x => x.id.ToString().Contains(search_bar.Text));
                }
                else
                {
                    resident_entry_grid.ItemsSource = residentWindowList;
                }
            }
            catch
            {
               
            }
        }
    }
}
