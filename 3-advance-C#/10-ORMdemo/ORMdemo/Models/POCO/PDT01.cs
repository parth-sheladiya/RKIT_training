
using System;
using ServiceStack.DataAnnotations;


namespace ORMdemo.Models.POCO
{
    /// <summary>
    /// poco class
    /// </summary>
    public class PDT01
    {
        #region Fields

        /// <summary>
        /// id
        /// </summary>
        [AutoIncrement]
        [PrimaryKey] // Marks this as the primary key
         // Auto-increment Id
        public int Id { get; set; }

        /// <summary>
        /// product name
        /// </summary>
        [Required]
        [StringLength(100)]
        public string prodName { get; set; }


        /// <summary>
        /// description
        /// </summary>
        [StringLength(500)] 
        public string prodDesc { get; set; }

        /// <summary>
        /// company
        /// </summary>
        [Required] 
        [StringLength(100)]
        public string prodCompany { get; set; }

        /// <summary>
        /// price
        /// </summary>
        [Range(1, int.MaxValue)] 
        public int prodPrice { get; set; }

        /// <summary>
        /// manufacture date
        /// </summary>
        [Required]
        public DateTime mDate { get; set; } = DateTime.Now;

        /// <summary>
        /// expiry date
        /// </summary>
        [Required] 
        public DateTime exDate { get; set; } = DateTime.Now.AddYears(1);

        #endregion

        
    }
}
