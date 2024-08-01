using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using static System.Net.WebRequestMethods;

namespace SuperShop.Data.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The field {0} can contain {1} characters length.")]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [Display(Name = "Image")]
        public Guid ImageId { get; set; }

        [Display(Name = "Last Purchase")]
        public DateTime? LastPurchase { get; set; }

        [Display(Name = "Last Sale")]
        public DateTime? LastSale { get; set; }

        [Display(Name = "IsAvailable")]
        public bool IsAvailable { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; }
        public User User { get; set; }

        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://supershop30648.azurewebsites.net/images/noimage.png"
            : $"https://supershop30648.blob.core.windows.net/products/{ImageId}";
    }
}
