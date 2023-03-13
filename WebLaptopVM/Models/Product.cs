namespace WebLaptopVM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Carts = new HashSet<Cart>();
            Edits = new HashSet<Edit>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        public int Category { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [DisplayName("Tên sản phẩm")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [DisplayName("Giá bán")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [DisplayName("Giá nhập")]
        public int Cost { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [DisplayName("Mô tả")]
        public string Describe { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [DisplayName("Màu sắc")]
        [StringLength(50)]
        public string Color { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [StringLength(50)]
        public string Weight { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [DisplayName("Chất liệu")]
        [StringLength(50)]
        public string Made_of { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [StringLength(50)]
        public string RAM { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [StringLength(50)]
        public string CPU { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [StringLength(50)]
        public string Pin { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [DisplayName("Kích thước màn hình")]
        [StringLength(50)]
        public string Screen_size { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [DisplayName("Card đồ họa")]
        [StringLength(50)]
        public string Card { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [DisplayName("Ổ cứng")]
        [StringLength(50)]
        public string Hard_drive { get; set; }

        public bool Status { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [DisplayName("Ảnh sản phẩm")]
        [StringLength(50)]
        public string Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        public virtual Category Category1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Edit> Edits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual StatusProduct StatusProduct { get; set; }
    }
}
