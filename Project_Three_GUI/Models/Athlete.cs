using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Three_GUI.Models
{
    class Athlete : Resident
    {
		public Athlete(string name, string type, int id, int room_number, double rent_fee, int floor)
		{
			this.name = name;
			this.type = type;
			this.id = id;
			this.room_number = room_number;
			this.rent_fee = rent_fee;
			this.floor = floor;
		}

		//Define a toString method 
		public override string ToString()
		{
			return String.Format($"Welcome, {name}, Type: {type}, ID: {id}, Room Number: {room_number}, Rent Free: {rent_fee}, Floor Number: {floor}");
		}

	}
}
