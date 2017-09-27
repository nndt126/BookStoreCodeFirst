namespace Model.Class
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Author")]
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Pls insert Author Name")]
        [StringLength(50)]
        public string AuthorName { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/M/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }

        [Required(ErrorMessage = "Pls choose Author Image")]
        [StringLength(250)]
        public string AuthorImage { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
