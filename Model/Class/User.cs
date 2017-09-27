namespace Model.Class
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Pls insert User Name")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Pls insert Password")]
        [StringLength(50)]
        public string Password { get; set; }

        public int? IDRole { get; set; }

        public virtual PhanQuyen PhanQuyen { get; set; }
    }
}
