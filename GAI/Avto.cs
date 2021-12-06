namespace GAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Avto")]
    public partial class Avto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Avto { get; set; }

        public int ID { get; set; }

        [StringLength(50)]
        public string VIN { get; set; }

        [StringLength(50)]
        public string Manu { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        public int? God { get; set; }

        public int? Wei { get; set; }

        public int? Color { get; set; }

        public int? Engine_Type { get; set; }

        [StringLength(50)]
        public string Type_od { get; set; }

        public virtual Drivers Drivers { get; set; }
    }
}
