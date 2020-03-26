using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CandidateBL;
using CandidateBL.DataAccess;

namespace CandidateWebAPI.Repositories
{
    public interface ICandidateRepository : IDisposable
    {
        IEnumerable<Candidate> GetCandidates();
        Candidate GetCandidateByID(long CandidateID);
        IEnumerable<Candidate> GetCandidateByTitle(string Title);
        List<GetCandidatesBySkill_Result> GetCandidateBySkill(string Skill);
        bool InsertCandidate(Candidate candidate);
        void Save();
    }
}
