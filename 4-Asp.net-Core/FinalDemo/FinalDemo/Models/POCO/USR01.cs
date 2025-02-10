using FinalDemo.Models.ENUM;
using FinalDemo.Services;

namespace FinalDemo.Models.POCO
{
    public class USR01 
    {
        /// <summary>
        /// user id
        /// </summary>
        public int R01F01 { get; set; }

        /// <summary>
        /// user name
        /// </summary>
        public string R01F02 { get; set; }

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
        public EnumRole R01F07 { get; set; }

        /// <summary>
        /// created at
        /// </summary>
       public DateTime R01F08 { get; set; } 

        /// <summary>
        /// updated at
        /// </summary>
        public DateTime R01F09 { get; set; }
    }
}
