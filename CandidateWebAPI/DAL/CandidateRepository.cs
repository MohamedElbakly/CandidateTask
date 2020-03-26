using CandidateBL.DataAccess;
using CandidateWebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CandidateBL;
using CandidateBL.DataAccess;

namespace CandidateWebAPI.DAL
{
    public class CandidateRepository : ICandidateRepository, IDisposable
    {
        private NetwaysEntities context;

        public CandidateRepository(NetwaysEntities context)
        {
            this.context = context;
        }

        public Candidate GetCandidateByID(long CandidateID)
        {
            return context.Candidates.Find(CandidateID);
        }

        public List<GetCandidatesBySkill_Result> GetCandidateBySkill(string Skill)
        {
            List<GetCandidatesBySkill_Result> list = context.GetCandidatesBySkill(Skill).ToList();
            return list;
        }
        public IEnumerable<Candidate> GetCandidateByTitle(string Title)
        {
            return context.Candidates.Where(t => t.Title == Title).ToList();
        }

        public IEnumerable<Candidate> GetCandidates()
        {
            return context.Candidates.ToList();
        }

        public bool InsertCandidate(Candidate candidate)
        {
            bool Saved = false;
            try
            {
                context.Candidates.Add(candidate);
                Saved = true;
            }
            catch (Exception e)
            {

            }

            return Saved;
        }

        public void Save()
        {
            context.SaveChanges();

        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}