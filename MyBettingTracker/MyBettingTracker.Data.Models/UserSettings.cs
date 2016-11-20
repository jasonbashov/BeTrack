namespace MyBettingTracker.Data.Models
{
    using Common.Contracts;
    using Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserSettings : AuditInfo, IDeletableEntity
    {
        public UserSettings()
            : base()
        {

        }

        [Key]
        public int Id { get; set; }
                
        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public decimal  UnitSize { get; set; }
    }
}
