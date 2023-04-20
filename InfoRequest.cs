using System.ComponentModel.DataAnnotations;

namespace Final_Project_3045.models
{ 
public class InfoRequest
{
		[Key]
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public string Birthday { get; set; }
		public string ProgramYear { get; set; }
		public string CollegeProgram { get; set; }
	}
}
