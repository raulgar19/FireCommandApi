using FireCommandApi.Models;

namespace FireCommandApi.Models.ViewModels
{
    public class PersonnelViewModel
    {
        public List<Personnel> Personnel { get; set; }
        public List<Rank> Ranks { get; set; }
        public List<Specialization> Specializations { get; set; }
        public List<Station> Stations { get; set; }
        public List<PersonnelStatus> PersonnelStatuses { get; set; }
    }
}