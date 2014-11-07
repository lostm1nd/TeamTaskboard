namespace TeamTaskboard.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        public User()
        {
            this.ReportertedTasks = new HashSet<TeamTask>();
            this.ProcessedTasks = new HashSet<TeamTask>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public int? TeamId { get; set; }

        public virtual Team Team { get; set; }

        [InverseProperty("Reporter")]
        public virtual ICollection<TeamTask> ReportertedTasks { get; set; }

        [InverseProperty("Processor")]
        public virtual ICollection<TeamTask> ProcessedTasks { get; set; }
    }
}
