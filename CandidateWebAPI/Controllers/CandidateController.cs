using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CandidateBL;
using CandidateBL.DataAccess;
using CandidateWebAPI.DAL;
using CandidateWebAPI.Repositories;

namespace CandidateWebAPI.Controllers
{
    public class CandidateController : ApiController
    {

        private ICandidateRepository candidateRepository;

        public CandidateController()
        {
            this.candidateRepository = new CandidateRepository(new NetwaysEntities());
        }

        public CandidateController(ICandidateRepository candidateRepository)
        {
            this.candidateRepository = candidateRepository;
        }

        public HttpResponseMessage GetAllCandidates()
        {
            var CandidatesList = candidateRepository.GetCandidates().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, CandidatesList);
        }

        public HttpResponseMessage AddCandidates(Candidate candidate)
        {
            if (candidateRepository.InsertCandidate(candidate))
            {
                candidateRepository.Save();
                return Request.CreateResponse(HttpStatusCode.OK, "Candidate Saved Successfully");
            }
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Save Candidate Fail");
        }

        public HttpResponseMessage GetCandidateByID(long CandidateID)
        {
            Candidate candidate = candidateRepository.GetCandidateByID(CandidateID);
            return Request.CreateResponse(HttpStatusCode.OK, candidate);
        }

        public HttpResponseMessage GetCandidateByTitle(string Title)
        {
            var candidatelist = candidateRepository.GetCandidateByTitle(Title);
            return Request.CreateResponse(HttpStatusCode.OK, candidatelist);
        }

        public HttpResponseMessage GetCandidateBySkill(string skill)
        {
            var candidatelist = candidateRepository.GetCandidateBySkill(skill);
            return Request.CreateResponse(HttpStatusCode.OK, candidatelist);
        }
    }
}
