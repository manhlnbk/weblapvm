namespace WebLaptopVM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("Cart")]
    public partial class Cart
    {
        public int Id { get; set; }

        public int Product { get; set; }

        public int User { get; set; }

        [DisplayName("Số lượng")]
        public int Quantity { get; set; }

        [DisplayName("Giá bán")]
        public int? Price { get; set; }

        [DisplayName("Ảnh sản phẩm")]
        [StringLength(50)]
        public string Image { get; set; }

        public virtual Product Product1 { get; set; }

        public virtual User User1 { get; set; }
    }
}
