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
    public class ParcelApp : IParcelApp
    {
        private readonly IMapper _mapper;
        private readonly IParcelRepository _parcel;

        public ParcelApp(IMapper mapper, IParcelRepository parcel)
        {
            _mapper = mapper;
            _parcel = parcel;
        }
        public async Task<ParcelDto> Create(ParcelDto Entity)
        {
            var iData = _mapper.Map<Parcel>(Entity);

            await _parcel.Create(iData);

            Entity = _mapper.Map<ParcelDto>(iData);

            return Entity;
        }
        public async Task<ParcelDto> Update(ParcelDto Entity)
        {
            var iData = _mapper.Map<Parcel>(Entity);
            await _parcel.Update(iData);

            Entity = _mapper.Map<ParcelDto>(iData);
            return Entity;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                return await _parcel.Delete(id);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ParcelDto> GetDataByID(int id)
        {
            var iData = await _parcel.GetDataByID(id);
            return _mapper.Map<ParcelDto>(iData);
        }

        public async Task<List<ParcelDto>> List()
        {
            var iDataList = await _parcel.List();
            return _mapper.Map<List<ParcelDto>>(iDataList);
        }

    }
}
