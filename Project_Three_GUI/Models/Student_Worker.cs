using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Three_GUI.Models
{
	class Student_Worker : Resident
	{
		public double pay { get; set; }
		public int hours_worked { get; set; }

		public Student_Worker(string name, int id, int room_number, double rent_fee, int floor, double boarding_fee, double pay, int hours_worked)
		{
			this.name = name;
			this.id = id;
			this.room_number = room_number;
			this.rent_fee = rent_fee;
			this.floor = floor;
			this.boarding_fee = boarding_fee;
			this.pay = pay;
			this.hours_worked = hours_worked;
		}

		//Define a toString method 
		public override string ToString()
		{
			return String.Format($"Welcome, {name}, ID: {id}, Room Number: {room_number}, Rent Free: {rent_fee}, Floor Number: {floor}, Boarding Fee: {boarding_fee}, Boarding Fee: {boarding_fee}, Boarding Fee: {pay}, Boarding Fee: {hours_worked}");
		}

	}
}
