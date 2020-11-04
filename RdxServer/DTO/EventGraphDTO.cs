using RdxServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdxServer.DTO
{
    public class EventGraphDTO
    {
        public IList<ReportEntry> eventsBySensor { get; set; }
        public IList<ReportEntry> eventsByRegion { get; set; }
    }
}
