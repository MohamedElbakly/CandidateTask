﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CandidateBL.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class NetwaysEntities : DbContext
    {
        public NetwaysEntities()
            : base("name=NetwaysEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Candidate_Skills> Candidate_Skills { get; set; }
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
    
        public virtual ObjectResult<GetCandidatesBySkill_Result> GetCandidatesBySkill(string skill)
        {
            var skillParameter = skill != null ?
                new ObjectParameter("Skill", skill) :
                new ObjectParameter("Skill", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCandidatesBySkill_Result>("GetCandidatesBySkill", skillParameter);
        }
    }
}