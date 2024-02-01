using App.Base.GenericModel;

namespace App.User.Model
{
	public class User : GenericModel
	{
        public string Name { get; set; }	
		public string Email { get; set; }
		public string Password { get; set; }
		public string Phone { get; set; }
    }
}
