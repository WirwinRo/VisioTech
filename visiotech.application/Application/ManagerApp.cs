using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using visiotech.application.Dtos;
using visiotech.application.Interfaces;
using visiotech.domain.Entities;
using visiotech.domain.Interfaces;

namespace visiotech.application.Application
{
    public class ManagerApp : IManagerApp
    {
        private readonly IMapper _mapper;
        private readonly IManagerRepository _manager;

        public ManagerApp(IMapper mapper, IManagerRepository manager)
        {
            _mapper = mapper;
            _manager = manager;
        }
        public async Task<ManagerDto> Create(ManagerDto Entity)
        {
            var iData = _mapper.Map<Manager>(Entity);

            await _manager.Create(iData);

            Entity = _mapper.Map<ManagerDto>(iData);

            return Entity;
        }

        public async Task<ManagerDto> Update(ManagerDto Entity)
        {
            var iData = _mapper.Map<Manager>(Entity);
            await _manager.Update(iData);

            Entity = _mapper.Map<ManagerDto>(iData);
            return Entity;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                return await _manager.Delete(id);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ManagerDto> GetDataByID(int id)
        {
            var iData = await _manager.GetDataByID(id);
            return _mapper.Map<ManagerDto>(iData);
        }

        public async Task<List<ManagerDto>> List()
        {
            var iDataList = await _manager.List();
            return _mapper.Map<List<ManagerDto>>(iDataList);
        }

        public async Task<Dictionary<string, int>> GetManagerArea()
        {
            return await _manager.GetManagerArea();
        }
    }
}
