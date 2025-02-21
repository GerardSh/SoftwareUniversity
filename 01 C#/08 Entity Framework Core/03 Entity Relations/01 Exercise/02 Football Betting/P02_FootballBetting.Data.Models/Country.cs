namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Country;

    public class Country
    {
        public int CountryId { get; set; }

        [Required]
        [MaxLength(CountryNameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
