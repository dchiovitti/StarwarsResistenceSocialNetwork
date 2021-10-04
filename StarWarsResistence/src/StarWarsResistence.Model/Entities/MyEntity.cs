using System.ComponentModel.DataAnnotations;
namespace StarWarsResistence.Model.Entities
{
    public class MyEntity
    {
        [Key]
        public int Id { get; set; }
        public string Col { get; set; }
    }
}