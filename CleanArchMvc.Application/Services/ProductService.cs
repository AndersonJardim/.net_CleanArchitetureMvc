using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
//using CleanArchMvc.Domain.Entities;
//using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        //private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        //public ProductService(IMapper mapper, IProductRepository productRepository)
        public ProductService(IMapper mapper, IMediator mediator)
        {
           // _productRepository = productRepository ??
           //      throw new ArgumentNullException(nameof(productRepository));

            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            //var productsEntity = await _productRepository.GetAllAsync();
            //return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);

            var productsQuery = new GetProductsQuery();
            if (productsQuery == null)
            {
                throw new Exception($"Entity could not be loaded.");
            }
            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            //var productEntity = await _productRepository.GetByIdAsync(id);
            //return _mapper.Map<ProductDTO>(productEntity);

            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if(productByIdQuery == null)
                throw new Exception($"Entity coul not be found.");

            var result = await _mediator.Send(productByIdQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            //var productEntity = await _productRepository.GetProductCategoryAsync(id);
            //return _mapper.Map<ProductDTO>(productEntity);

            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if (productByIdQuery == null)
                throw new Exception($"Entity coul not be found.");

            var result = await _mediator.Send(productByIdQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        public async Task Add(ProductDTO productDto)
        {
            //var productEntity = _mapper.Map<Product>(productDto);
            //await _productRepository.CreateAsync(productEntity);

            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDTO productDto)
        {
            //var productEntity = _mapper.Map<Product>(productDto);
            //await _productRepository.UpdateAsync(productEntity);

            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            //var productEntity = _productRepository.GetByIdAsync(id).Result;
            //await _productRepository.RemoveAsync(productEntity);

            var productRemoveCommand = _mapper.Map<ProductRemoveCommand>(id.Value);
            if (productRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(productRemoveCommand);
        }
    }
}
