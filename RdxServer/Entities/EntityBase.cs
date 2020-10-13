using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdxServer.Entities
{
    public class EntityBase
    {
            [Column("EventId")]
            public int Id { get; set; }

    }
}
