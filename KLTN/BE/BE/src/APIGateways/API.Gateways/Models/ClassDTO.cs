using Course.gRPC.Protos;
using System;
using System.Collections.Generic;

namespace API.Gateways.Models
{
    public class ClassDTO : BaseDTO
    {
        public int Id { get; set; }
        public int SemesterId { get; set; }
        public Guid TeacherId { get; set; }
        public Guid SubjectId { get; set; }
        public string Code { get; set; }
        public List<StudentModel> Students { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
