﻿using System;
using System.Collections.Generic;
using System.Linq;
using TestSwitchApi.Models.ApiModels;
using TestSwitchApi.Models.DataModels;
using TestSwitchApi.Models.Request;

namespace TestSwitchApi.Repositories
{
    public class CandidatesRepo : ICandidatesRepo
    {
        private readonly TestSwitchDbContext _context;

        public CandidatesRepo(TestSwitchDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CandidateDataModel> GetAllCandidates(PageRequest pageRequest)
        {
            return _context.Candidates
                .OrderBy(c => c.FirstName)
                .Skip((pageRequest.Page - 1) * pageRequest.PageSize)
                .Take(pageRequest.PageSize);
        }

        public CandidateDataModel GetCandidateById(int id)
        {
            return _context.Candidates
                .Single(c => c.Id == id);
        }

        public CandidateDataModel GetCandidateByGuid(string guid)
        {
            return _context.Candidates
                .SingleOrDefault(c => c.Guid==guid);
        }

        public int Count(PageRequest pageRequest)
        {
            return _context.Candidates
                .Count();
        }

        public CandidateDataModel Register(CandidateRequest candidateRequest)
        {
            var response = _context.Candidates.Add(new CandidateDataModel()
            {
                FirstName = candidateRequest.FirstName,
                LastName = candidateRequest.LastName,
                Email = candidateRequest.Email,
                Guid = Guid.NewGuid().ToString(),
                CandidateTests = new List<CandidateTestModel>
                {
                    new CandidateTestModel
                    {
                        TestId = 1,
                    },
                    new CandidateTestModel
                    {
                        TestId = 2,
                    },
                    new CandidateTestModel
                    {
                        TestId = 3,
                    },
                },
            });
            _context.SaveChanges();
            return response.Entity;
        }
    }
}