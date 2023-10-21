﻿using AutoMapper;
using BusinessLogic.AbstractLogic.Application;
using BusinessLogic.AbstractLogic.Product;
using BusinessLogic.Contracts;
using Context.Entities;
using DataTransferObjets.Configuration;
using DataTransferObjets.Dto;
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
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHostEnvironment hostEnvironment;
        private readonly string relacionProperties = "Mark,Category";

        public ProductService(IMapper mapper, IUnitOfWork unitOfWork, IHostEnvironment hostEnvironment)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.hostEnvironment = hostEnvironment;
        }
        public async Task<bool> Add(ProductRequest requestDto, IFormFileCollection file, CancellationToken cancellationToken)
        {
            if (file.Count > 0)
            {
                string DirectoryPathImages = Path.Combine(hostEnvironment.ContentRootPath, "wwwroot" + StaticDefination.ImagePath);
                ProductLogic.CreateDirectoryImages(DirectoryPathImages);
                ResponseImagesDto response = ProductLogic.SavePicture(new ImagesDto { Files = file, upLoadPath = DirectoryPathImages });
                if (response.RequestResponse)
                    requestDto.ImageUrl = response.SavePath;
            }
            Product entity = mapper.Map<Product>(requestDto);
            await unitOfWork.ProductRepository.Create(entity, cancellationToken);
            int result = await unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            await unitOfWork.ProductRepository.Delete(id, cancellationToken);
            int result = await unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<IEnumerable<ProductResponse>> GetAll()
        {
            IEnumerable<Product?> data = await unitOfWork.ProductRepository.ReadAll(includeProperties: relacionProperties);
            IEnumerable<ProductResponse> response = mapper.Map<IEnumerable<ProductResponse>>(data);
            return response;
        }

        public async Task<ProductResponse> GetById(int id)
        {
            Product? entity = await unitOfWork.ProductRepository.ReadById(x => x.Id.Equals(id), includeProperties: string.Empty);
            ProductResponse responseDto = mapper.Map<ProductResponse>(entity);
            return responseDto;
        }

        public async Task<bool> Update(int id, ProductRequest requestDto, IFormFileCollection file, CancellationToken cancellationToken)
        {
            if (file.Count > 0)
            {
                string DirectoryPathImages = Path.Combine(hostEnvironment.ContentRootPath, "wwwroot" + StaticDefination.ImagePath);
                ProductLogic.CreateDirectoryImages(DirectoryPathImages);
                ProductLogic.EraseToRewrite(DirectoryPathImages + requestDto.ImageUrl);
                ResponseImagesDto response = ProductLogic.SavePicture(new ImagesDto { Files = file, upLoadPath = DirectoryPathImages });
                if (response.RequestResponse)
                    requestDto.ImageUrl = response.SavePath;
            }
            Product entity = mapper.Map<Product>(requestDto);
            await unitOfWork.ProductRepository.Update(id, entity, cancellationToken);
            int result = await unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> ValidateNameId(int id, string name)
        {
            IEnumerable<Product?> data = await unitOfWork.ProductRepository.ReadAll();
            IEnumerable<ProductResponse> response = mapper.Map<IEnumerable<ProductResponse>>(data);
            return GenericValidation.ValidateDuplicateNameField(response, id, name);
        }

        public SelectListItemViewModel GetAllDropdownList()
        {
            throw new NotImplementedException();
        }

    }
}