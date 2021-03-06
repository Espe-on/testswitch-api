﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TestSwitchApi.Models.DataModels
{
    public class CandidateTestModel
    {
        [Key]
        public int CandidateId { get; set; }
        [Key]
        public int TestId { get; set; }
        public string TestResult { get; set; }
        public string TestAnswer { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public CandidateDataModel Candidate { get; set; }
    }
}