using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visiotech.domain.Interfaces
{
    public interface ICommonRepository<E> where E : class
    {
        Task<E> Create(E Entity);
        Task<E> Update(E Entity);
        Task<bool> Delete(int id);
        Task<E> GetDataByID(int id);
        Task<List<E>> List();
    }
}
