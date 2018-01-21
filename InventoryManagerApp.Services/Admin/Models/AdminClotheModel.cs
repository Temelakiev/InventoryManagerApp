using System.ComponentModel.DataAnnotations;
using static InventoryManagerApp.Data.DataConstants;

namespace InventoryManagerApp.Services.Admin.Models
{
    public class AdminClotheModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(TypeMinLength)]
        [MaxLength(TypeMaxLength)]
        public string Type { get; set; }

        public int Quantity { get; set; }

        [Required]
        [MinLength(SizeMinLength)]
        [MaxLength(SizeMaxLength)]
        public string Size { get; set; }

        public decimal SinglePrice { get; set; }

        [Required]
        [MinLength(PictureUrlMinLength)]
        [MaxLength(PictureUrlMaxLength)]
        public string PictureUrl { get; set; }

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }
    }
}
