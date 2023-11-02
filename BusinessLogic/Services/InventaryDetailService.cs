using AutoMapper;
using BusinessLogic.Contracts;
using Context.Entities;
using DataTransferObjets.Dto.In;
using DataTransferObjets.Dto.Out;
using DataTransferObjets.Dto.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Repository.GenericRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class InventaryDetailService : IInventaryDetailService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly string DropdownListInventary = "Inventary";
        private readonly string DropdownListProduct = "Product";

        public InventaryDetailService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Add(InventaryDetailRequest requestDto, CancellationToken cancellationToken)
        {
            InventaryDetail entity = mapper.Map<InventaryDetail>(requestDto);
            await unitOfWork.InventayDetailRepository.Create(entity, cancellationToken);
            int result = await unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            await unitOfWork.InventayDetailRepository.Delete(id, cancellationToken);
            int result = await unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<IEnumerable<InventaryDetailResponse>> GetAll()
        {
            IEnumerable<InventaryDetail?> data = await unitOfWork.InventayDetailRepository.ReadAll();
            IEnumerable<InventaryDetailResponse> response = mapper.Map<IEnumerable<InventaryDetailResponse>>(data);
            return response;
        }

        public SelectListItemViewModelInventaryDetail GetAllDropdownList()
        {
            return new SelectListItemViewModelInventaryDetail
            {
                InventaryDropDownList = unitOfWork.ProductRepository.GetAllDropdownList(DropdownListInventary),
                ProductDropDownList = unitOfWork.ProductRepository.GetAllDropdownList(DropdownListProduct)
            };
        }

        public async Task<InventaryDetailResponse> GetById(int id)
        {
            InventaryDetail? entity = await unitOfWork.InventayDetailRepository.ReadById(x => x.Id.Equals(id), includeProperties: string.Empty);
            InventaryDetailResponse responseDto = mapper.Map<InventaryDetailResponse>(entity);
            return responseDto;
        }

        public async Task<bool> Update(int id, InventaryDetailRequest requestDto, CancellationToken cancellationToken)
        {
            InventaryDetail entity = mapper.Map<InventaryDetail>(requestDto);
            await unitOfWork.InventayDetailRepository.Update(id, entity, cancellationToken);
            int result = await unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
