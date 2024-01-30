namespace api_fetch.Models
{
	public class User : GenericModel.GenericModel
	{
        public string Name { get; set; }	
		public string Email { get; set; }
		public string Password { get; set; }
		public string Phone { get; set; }
    }
}
