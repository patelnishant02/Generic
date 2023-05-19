﻿using System;
using System.Collections.Generic;

namespace Generic.Entities.Models
{
    public partial class Skill
    {
        public Skill()
        {
            MissionSkills = new HashSet<MissionSkill>();
            UserSkills = new HashSet<UserSkill>();
        }

        public int SkillId { get; set; }
        public string? SkillName { get; set; }
        public byte Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<MissionSkill> MissionSkills { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}
