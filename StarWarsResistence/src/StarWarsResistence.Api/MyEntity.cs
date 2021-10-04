using System.ComponentModel.DataAnnotations;
namespace StarWarsResistence.Api
{
    public class MyEntity
    {
        [Key]
        public int Id { get; set; }
        public string Col { get; set; }
    }
}