namespace Artur.ModelBD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sto")]
    public partial class sto
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Auto { get; set; }

        [Required]
        [StringLength(50)]
        public string ClientName { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(20)]
        public string CenaRemonta { get; set; }
    }
}
