using App.Base.GenericModel;

namespace api_fetch.Models
{
    public class Roles :GenericModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }

    }
}
