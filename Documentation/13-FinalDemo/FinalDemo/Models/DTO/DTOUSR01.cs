using FinalDemo.Models.ENUM;
using FinalDemo.Models.POCO;
using System.Web;

namespace FinalDemo.Models.DTO
{
    /// <summary>
    /// it is user dto class 
    /// </summary>
    public class DTOUSR01
    {
        /// <summary>
        /// userid
        /// </summary>
        public int R01F01 { get; set; }


        /// <summary>
        /// username
        /// </summary>
        public string R01F02 { get; set; }


        /// <summary>
        /// useremail
        /// </summary>
        public string R01F03 { get; set; }

        /// <summary>
        /// userpassword
        /// </summary>
        public string R01F04 { get; set; }


        /// <summary>
        /// user role
        /// </summary>
        public long R01F05 { get; set; }


        /// <summary>
        /// user address
        /// </summary>
        public string R01F06 { get; set; }

       
        /// <summary>
        /// user role
        /// </summary>
        public EnmRoleType R01F07 { get; set; } 
    }
}