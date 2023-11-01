using AutoMapper;
using BusinessLogic.Contracts;
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

        public InventaryDetailService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public Task<bool> Add(ProductRequest requestDto, IFormFileCollection file, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductResponse>> GetAll()
        {
            throw new NotImplementedException();
        }

        public SelectListItemViewModel GetAllDropdownList()
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, ProductRequest requestDto, IFormFileCollection file, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
