
using System;
using ServiceStack.DataAnnotations;


namespace ORMdemo.Models.POCO
{
    public class PDT01
    {
        #region Fields
        [AutoIncrement]
        [PrimaryKey] // Marks this as the primary key
         // Auto-increment Id
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string prodName { get; set; }

        [StringLength(500)] 
        public string prodDesc { get; set; }

        [Required] 
        [StringLength(100)]
        public string prodCompany { get; set; }

        [Range(1, int.MaxValue)] 
        public int prodPrice { get; set; }

        [Required]
        public DateTime mDate { get; set; }

        [Required] 
        public DateTime exDate { get; set; }

        #endregion

        #region Constructor
        public PDT01()
        {
            // Initialize default dates
            mDate = DateTime.Now; // Current date as manufacturing date
            exDate = mDate.AddYears(1); // Add 1 year to manufacturing date
        }
        #endregion
    }
}
