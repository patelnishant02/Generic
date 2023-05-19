using System;
using System.Collections.Generic;

namespace Generic.Entities.Models
{
    public partial class NotificationSetting
    {
        public int NotificationId { get; set; }
        public long UserId { get; set; }
        public bool RecommendedMissions { get; set; }
        public bool MyStories { get; set; }
        public bool NewMission { get; set; }
        public bool RecommendStory { get; set; }
        public bool MissionApplication { get; set; }
        public bool ReceiveNotificationByEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
