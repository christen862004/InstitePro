using Microsoft.AspNetCore.Identity;

namespace InstitePro.Models
{
    public class ApplicationUser:IdentityUser
    {
        /*Optial */
        public string  Address { get; set; }
    }
}
