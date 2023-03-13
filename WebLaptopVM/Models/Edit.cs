namespace WebLaptopVM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("Edit")]
    public partial class Edit
    {
        public int Id { get; set; }

        public int? Admin { get; set; }

        public int? Product { get; set; }

        public int? Category { get; set; }

        public int? User { get; set; }

        public int? Order { get; set; }

        [DisplayName("Thời gian chỉnh sửa")]
        public DateTime Time_edit { get; set; }

        public virtual Admin Admin1 { get; set; }

        public virtual Category Category1 { get; set; }

        public virtual Order Order1 { get; set; }

        public virtual Product Product1 { get; set; }

        public virtual User User1 { get; set; }
    }
}
