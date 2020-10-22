using RdxServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RdxServer.Repositories.Interfaces
{
    public interface IDeviceEventRepository : IRepository<DeviceEvent>, IDisposable
    {
        Task<int> SaveEvent(DeviceEvent evt);

        Task<IEnumerable<DeviceEvent>> FindBy(Expression<Func<DeviceEvent, bool>> predicate);
    }
}
