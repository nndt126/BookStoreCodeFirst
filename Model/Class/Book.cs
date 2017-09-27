namespace Model.Class
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Pls insert Book Name")]
        [StringLength(150)]
        public string Name { get; set; }
        
        public int? Prices { get; set; }
      
        [StringLength(50)]
        public string Description { get; set; }

        //[Required(ErrorMessage = "Pls choose Book Image")]
        [StringLength(250)]
        public string Image { get; set; }

        public bool? IsDeleted { get; set; }

        public int? AuthorID { get; set; }

        public virtual Author Author { get; set; }
    }
}
