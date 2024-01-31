using App.Base.GenericModel.Interface;

namespace App.Base.GenericModel
{
    public class GenericModel : IGenericModel
    {
        public long  Id { get; set; }
        public DateTime RecDate { get; set; } = DateTime.UtcNow;
    }
}
