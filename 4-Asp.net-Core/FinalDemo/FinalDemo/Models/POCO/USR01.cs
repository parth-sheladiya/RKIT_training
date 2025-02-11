using FinalDemo.Models.ENUM;
using FinalDemo.Services;
using ServiceStack.DataAnnotations;

namespace FinalDemo.Models.POCO
{
    public class USR01 
    {
        /// <summary>
        /// user id
        /// </summary>
        [PrimaryKey]
        [AutoIncrement]
        public int R01F01 { get; set; }
        [Unique]
        /// <summary>
        /// user name
        /// </summary>
        public string R01F02 { get; set; }
        [Unique]
        /// <summary>
        /// user email
        /// </summary>
        public string R01F03 { get; set; }

        /// <summary>
        /// user password
        /// </summary>
        public string R01F04 { get; set; }

        /// <summary>
        /// user phone number
        /// </summary>
        public string R01F05 { get; set; }

        /// <summary>
        /// user address
        /// </summary>
        public string R01F06 { get; set; }

        /// <summary>
        /// user role
        /// </summary>
        [IgnoreOnUpdate]
        public EnumRole R01F07 { get; set; }

        /// <summary>
        /// created at
        /// </summary>
        [IgnoreOnUpdate]
        public DateTime R01F08 { get; set; }  = DateTime.Now;

        /// <summary>
        /// updated at
        /// </summary>
        [IgnoreOnInsert]
        public DateTime R01F09 { get; set; }  = DateTime.Now;
    }
}
