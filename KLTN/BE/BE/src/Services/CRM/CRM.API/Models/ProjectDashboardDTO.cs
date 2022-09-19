using System.Collections.Generic;

namespace CRM.API.Models
{
    public class ProjectDashboardDTO
    {
        public List<ProjectDetailDTO> ProjectDetailDTOs { get; set; }
        public int TotalProject => ProjectDetailDTOs.Count;
    }
}