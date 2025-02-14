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
    public class VineyardApp : IVineyardApp
    {
        private readonly IMapper _mapper;
        private readonly IVineyardRepository _vineyard;

        public VineyardApp(IMapper mapper, IVineyardRepository vineyard)
        {
            _mapper = mapper;
            _vineyard = vineyard;
        }
        public async Task<VineyardDto> Create(VineyardDto Entity)
        {
            var iData = _mapper.Map<Vineyard>(Entity);

            await _vineyard.Create(iData);

            Entity = _mapper.Map<VineyardDto>(iData);

            return Entity;
        }
        public async Task<VineyardDto> Update(VineyardDto Entity)
        {
            var iData = _mapper.Map<Vineyard>(Entity);
            await _vineyard.Update(iData);

            Entity = _mapper.Map<VineyardDto>(iData);
            return Entity;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                return await _vineyard.Delete(id);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<VineyardDto> GetDataByID(int id)
        {
            var iData = await _vineyard.GetDataByID(id);
            return _mapper.Map<VineyardDto>(iData);
        }

        public async Task<List<VineyardDto>> List()
        {
            var iDataList = await _vineyard.List();
            return _mapper.Map<List<VineyardDto>>(iDataList);
        }

        public async Task<Dictionary<string, List<string>>> GetVineyardManager()
        {
            return await _vineyard.GetVineyardManager();
        }
    }
}
