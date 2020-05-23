using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Project_Three_GUI.Models
{
	class Data_Source
	{
		//The Data_Source class is heavily influenced from Chris Fulton's code
		//Declaring Variables
		const string PATH = @"C:\\Users\\Jake\\Documents\\College\\SENG Semester 2\\Advanced Programming\\Projects\\Project 3\\Project_Three_GUI\\Resources\\Residents.csv";

		FileStream input;
		StreamReader read;
		string[] data;
		List<Resident> residentList; //Global


		/**Mehod that reads the data into my program **/
		public ObservableCollection<Resident> readData()
		{
			string[] data;
			ObservableCollection<Resident> residentList = null; //Local
			try
			{
				FileStream input = new FileStream(PATH, FileMode.Open, FileAccess.Read);
				StreamReader read = new StreamReader(input);
				residentList = new ObservableCollection<Resident>();

				//This looping structure reads in all of the records
				while (!read.EndOfStream)
				{
					//read in records and instantiate objects
					data = read.ReadLine().Split(',');
					residentList.Add(new Athlete(data[0], data[1], Convert.ToInt32(data[2]), Convert.ToInt32(data[3]), Convert.ToDouble(data[4]), Convert.ToInt32(data[5]), Convert.ToDouble(data[6])));
					Console.WriteLine(residentList[residentList.Count - 1]);
				}

				read.Dispose();
				input.Dispose();

			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			return residentList;

		}//End of readData() method

		public void writeData(List<Resident> residentList)
		{
			FileStream output = new FileStream(PATH, FileMode.Create, FileAccess.Write);
			StreamWriter write = new StreamWriter(output);
			write.WriteLine("name,id,room_number,rent_fee,floor,");

			foreach (Resident x in residentList)
			{
				//Write out each record
				write.WriteLine($"{x.name},{x.id},{x.room_number},{x.rent_fee},{x.floor},{x.boarding_fee}");
			}

			write.Dispose();
			output.Dispose();

		}
	}
}