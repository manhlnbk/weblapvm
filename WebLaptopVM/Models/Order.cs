namespace WebLaptopVM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Edits = new HashSet<Edit>();
        }

        public int Id { get; set; }

        public int User { get; set; }

        public int Product { get; set; }

        [DisplayName("Trạng thái đơn hàng")]
        public int Stutus { get; set; }

        [DisplayName("Số lượng")]
        public int Quantity { get; set; }

        [DisplayName("Thời gian đặt hàng")]
        public DateTime Time_order { get; set; }

        [DisplayName("Lợi nhuận")]
        public int? Profit { get; set; }

        [StringLength(50)]
        [DisplayName("Số điện thoại")]
        public string Phone_number { get; set; }

        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Edit> Edits { get; set; }

        public virtual Product Product1 { get; set; }

        public virtual StatusOrder StatusOrder { get; set; }

        public virtual User User1 { get; set; }
    }
}
