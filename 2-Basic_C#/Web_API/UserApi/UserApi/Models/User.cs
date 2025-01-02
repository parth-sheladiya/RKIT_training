using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserApi.Models
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class User
    {
        #region Properties

        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the city where the user resides.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the pincode (postal code) of the user's location.
        /// </summary>
        public string Pincode { get; set; }

        #endregion
    }
}
