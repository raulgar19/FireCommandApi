using FireCommandApi.Models;

namespace FireCommandApi.Models.ViewModels
{
    public class RiskZoneViewModel
    {
        public List<RiskZone> RiskZones { get; set; }
        public List<Priority> Priorioties { get; set; }
        public List<RiskType> RiskTypes { get; set; }
    }
}