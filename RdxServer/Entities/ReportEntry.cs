using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdxServer.Entities
{
    public class ReportEntry
    {
        public string Label { get; set; }

        public int Events { get; set; }
    }
}
