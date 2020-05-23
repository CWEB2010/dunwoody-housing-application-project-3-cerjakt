using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Three_GUI.Models
{
	abstract class Resident
	{
		public string type { get; set; }
		public string name { get; set; }
		public int id { get; set; }
		public int room_number { get; set; }
		public double rent_fee { get; set; }
		public int floor { get; set; }
	}
}
