using ServiceStack.DataAnnotations;

namespace FinalDemo.Models.POCO
{
    public class PDT01
    {
        /// <summary>
        /// product id
        /// </summary>
        [AutoIncrement]
        [PrimaryKey]
        public int T01F01 { get; set; }


        /// <summary>
        /// product name
        /// </summary>
        public string T01F02 { get; set; }


        /// <summary>
        /// product desc.
        /// </summary>
        public string T01F03 { get; set; }


        /// <summary>
        /// product category
        /// </summary>
        public string T01F04 { get; set; }


        /// <summary>
        /// product quantity
        /// </summary>
        public int T01F05 { get; set; }


        /// <summary>
        /// price 
        /// </summary>
        public int T01F06 { get; set; }


        /// <summary>
        /// create at
        /// </summary>
        [IgnoreOnUpdate]
        public DateTime T01F07 { get; set; } = DateTime.Now;


        /// <summary>
        /// update at
        /// </summary>
        [IgnoreOnInsert]
        public DateTime T01F08 { get; set; } = DateTime.Now;
    }
}
