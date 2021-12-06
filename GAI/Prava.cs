namespace GAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prava")]
    public partial class Prava
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_prava { get; set; }

        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? licence_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? expire_date { get; set; }

        [StringLength(50)]
        public string categories { get; set; }

        [StringLength(50)]
        public string licence_series { get; set; }

        [Column("licence number")]
        [StringLength(10)]
        public string licence_number { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public virtual Drivers Drivers { get; set; }
    }
}
