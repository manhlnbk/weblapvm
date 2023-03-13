namespace WebLaptopVM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("Admin")]
    public partial class Admin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Admin()
        {
            Edits = new HashSet<Edit>();
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

        [Column("Phone number")]
        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [DisplayName("Số điện thoại")]
        [StringLength(50)]
        public string Phone_number { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        public bool Sex { get; set; }

        public int Level { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [DisplayName("Ảnh quản trị viên")]
        [StringLength(50)]
        public string Image { get; set; }

        public virtual Level Level1 { get; set; }

        public virtual Sex Sex1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Edit> Edits { get; set; }
    }
}
