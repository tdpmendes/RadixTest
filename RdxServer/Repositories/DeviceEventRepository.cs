using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using RdxServer.Context;
using RdxServer.Entities;
using RdxServer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace RdxServer.Repositories
{
    public class DeviceEventRepository : RepositoryBase<DeviceEvent>, IDeviceEventRepository
    {
        public DeviceEventRepository(RdxDBContext context) : base(context)
        {

        }


        public async Task<IEnumerable<DeviceEvent>> FindBy(Expression<Func<DeviceEvent, bool>> predicate)
        {
            return await Find(predicate);
        }

        public async Task<int> SaveEvent(DeviceEvent evt)
        {
            await Add(evt);
            return await SaveChanges();
        }

        public async Task<IEnumerable<ReportEntry>> EventsBySensor()
        {
            return await Db.DeviceEvent.Where(d => d.ValueType.Equals("INT"))
                                       .GroupBy(d => new { d.Country, d.Region, d.DeviceName })
                                       .Select(d => new ReportEntry() {
                                           Label = string.Concat(d.Key.Country, ".", d.Key.Region, ".", d.Key.DeviceName),
                                           Events = d.Sum(k => int.Parse(k.Value))
                                        }).ToListAsync();
        }
        public async Task<IEnumerable<ReportEntry>> EventsByRegion()
        {

            return await Db.DeviceEvent.Where(d => d.ValueType.Equals("INT"))
                                       .GroupBy(d => new { d.Country, d.Region })
                                       .Select(d => new ReportEntry()
                                       {
                                           Label = string.Concat(d.Key.Country, ".", d.Key.Region),
                                           Events = d.Sum(k => int.Parse(k.Value))
                                       }).ToListAsync();
        }

    }
}
