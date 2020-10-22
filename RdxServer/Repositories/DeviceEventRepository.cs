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

namespace RdxServer.Repositories
{
    public class DeviceEventRepository : RepositoryBase<DeviceEvent>, IDeviceEventRepository
    {
        public DeviceEventRepository(RdxDBContext context) : base(context)
        {

        }

        public void Dispose()
        {
            this.Dispose();
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

    }
}
