using System.ComponentModel.DataAnnotations;
using App.Base.Constants;
using App.Base.GenericModel.Interface;

namespace App.Base.GenericModel
{
    public class GenericModel : IGenericModel,ISoftDelete
    {
        public long  Id { get; set; }
        public DateTime RecDate { get; set; } = DateTime.UtcNow;

        [MaxLength(1)]
        public char RecStatus { get; set; } = Status.Active;
    }
}
public interface IUserModel
{
    public long UserId { get; set; }
}
