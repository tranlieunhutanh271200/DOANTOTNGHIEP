using System;
using System.Collections.Generic;

namespace Service.Core.Models.DTOs.Courses
{
    public class SubjectDTO
    {
        public Guid Id { get; set; }
        public int MyProperty { get; set; }
    }
    public class TimelineDTO
    {
        public int Year { get; set; }
        public List<SemesterDTO> Semesters { get; set; }
    }
    public class SemesterDTO
    {
        public int Id { get; set; }
        public string SemesterName { get; set; }
        public int MyProperty { get; set; }

    }
}