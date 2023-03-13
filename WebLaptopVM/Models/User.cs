namespace WebLaptopVM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Carts = new HashSet<Cart>();
            Edits = new HashSet<Edit>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [DisplayName("Họ và tên")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [DisplayName("Tài khoản")]
        [StringLength(50)]
        public string Account { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [DisplayName("Mật khẩu")]
        [StringLength(50)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [DisplayName("Số điện thoại")]
        [StringLength(50)]
        public string Phone_number { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        public bool Sex { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [DisplayName("Ảnh người dùng")]
        [StringLength(50)]
        public string Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Edit> Edits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual Sex Sex1 { get; set; }
    }
}
