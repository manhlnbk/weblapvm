namespace WebLaptopVM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Edits = new HashSet<Edit>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [DisplayName("Tên hãng")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [DisplayName("Xuất xứ")]
        public string Origin { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống!")]
        [DisplayName("Mô tả")]
        public string Describe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Edit> Edits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
