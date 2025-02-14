using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using visiotech.api.Dtos;
using visiotech.application.Interfaces;
using visiotech.domain.Entities;
using visiotech.domain.Interfaces;

namespace visiotech.application.Application
{
    public class GrapeApp : IGrapeApp
    {
        private readonly IMapper _mapper;
        private readonly IGrapeRepository _grape;

        public GrapeApp(IMapper mapper,IGrapeRepository grape)
        {
            _mapper = mapper;
            _grape = grape;
        }
        public async Task<GrapeDto> Create(GrapeDto Entity)
        {
            
            var iData = _mapper.Map<Grape>(Entity);
            
            await _grape.Create(iData);

            Entity = _mapper.Map<GrapeDto>(iData);

            return Entity;
        }

        public async Task<GrapeDto> Update(GrapeDto Entity)
        {
            var iData = _mapper.Map<Grape>(Entity);
            await _grape.Update(iData);

            Entity = _mapper.Map<GrapeDto>(iData);
            return Entity;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                return await _grape.Delete(id);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<GrapeDto> GetDataByID(int id)
        {
            var iData = await _grape.GetDataByID(id);
            return _mapper.Map<GrapeDto>(iData);
        }

        public async Task<List<GrapeDto>> List()
        {
            var iDataList = await _grape.List();
            return _mapper.Map<List<GrapeDto>>(iDataList);
        }


    }
}
