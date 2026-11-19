using System.ComponentModel.DataAnnotations;

namespace clave.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
