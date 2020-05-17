using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Three_GUI.Models
{
    class Athlete : Resident
    {
		public double boarding_fee { get; set; }

		public Athlete(string name, int id, int room_number, double rent_fee, int floor, double boarding_fee)
		{
			this.name = name;
			this.id = id;
			this.room_number = room_number;
			this.rent_fee = rent_fee;
			this.floor = floor;
			this.boarding_fee = boarding_fee;
		}

		//Define a toString method 
		public override string ToString()
		{
			return String.Format($"Welcome, {name}, ID: {id}, Room Number: {room_number}, Rent Free: {rent_fee}, Floor Number: {floor}");
		}

	}
}
