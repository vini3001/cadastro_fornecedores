using System.ComponentModel.DataAnnotations;

namespace cad_cliente.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FantasyName { get; set; }

        public string SocialReason { get; set; }

        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Street { get; set; }

        public string NumberStreet { get; set; }

        [Required]
        public string Cep { get; set; }

        public string CountryName { get; set; }

        public string CityName { get; set; }

        public string StateName { get; set; }

        public string SquareName { get; set; }

        [Required]
        public string FullName { get; set; }
    }
}
