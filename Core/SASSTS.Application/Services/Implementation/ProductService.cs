using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SASSTS.Application.Behaviors;
using SASSTS.Application.Exceptions;
using SASSTS.Application.Models.Dtos.ProductDtos;
using SASSTS.Application.Models.RequestModels.ProductsRM;
using SASSTS.Application.Services.Abstraction;
using SASSTS.Application.Validators.ProductValidators;
using SASSTS.Application.Wrapper;
using SASSTS.Domain.Entities;
using SASSTS.Domain.UWork;

namespace SASSTS.Application.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public ProductService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        public async Task<Result<List<ProductDto>>> GetAllProducts()
        {
            var result = new Result<List<ProductDto>>();

            var productEntites = await _unitWork.GetRepository<Product>().GetAllAsync();
            var productDtos = await productEntites.ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToListAsync();
            result.Data = productDtos;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(GetProductByIdValidator))]
        public async Task<Result<ProductDto>> GetProductById(GetProductByIdVM getProductByIdVM)
        {
            var result = new Result<ProductDto>();

            var productExists = await _unitWork.GetRepository<Product>().AnyAsync(x => x.Id == getProductByIdVM.Id);
            if (!productExists)
            {
                throw new NotFoundException($"{getProductByIdVM.Id} numaralı ürün bulunamadı.");
            }

            var productEntity = await _unitWork.GetRepository<Product>().GetById(getProductByIdVM.Id);

            var productDto = _mapper.Map<Product, ProductDto>(productEntity);

            result.Data = productDto;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(CreateProductValidator))]
        public async Task<Result<int>> CreateProduct(CreateProductVM createProductVM)
        {
            var result = new Result<int>();

            var productExistsSameName = await _unitWork.GetRepository<Product>().AnyAsync(x => x.ProductName == createProductVM.ProductName);
            if (productExistsSameName)
            {
                throw new AlreadyExistsException($"{createProductVM.ProductName} isminde bir ürün zaten mevcut.");
            }

            var categoryExistsSame = await _unitWork.GetRepository<Category>().AnyAsync(x => x.CategoryName == createProductVM.CategoryName && x.Id == createProductVM.CategoryId);
            if (!categoryExistsSame)
            {
                throw new NotFoundException($"Girilen kategori bilgileri eşleşmiyor veya kayıtlı değil.");
            }

            var productEntity = _mapper.Map<CreateProductVM, Product>(createProductVM);

            _unitWork.GetRepository<Product>().Add(productEntity);
            await _unitWork.CommitAsync();

            result.Data = productEntity.Id;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(DeleteProductValidator))]
        public async Task<Result<int>> DeleteProduct(DeleteProductVM deleteProductVM)
        {
            var result = new Result<int>();

            var productExists = await _unitWork.GetRepository<Product>().AnyAsync(x => x.Id == deleteProductVM.Id);
            if (!productExists)
            {
                throw new NotFoundException($"{deleteProductVM.Id} numaralı ürün bulunamadı.");
            }

            _unitWork.GetRepository<Product>().Delete(deleteProductVM.Id);
            await _unitWork.CommitAsync();

            result.Data = deleteProductVM.Id;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(UpdateProductValidator))]
        public async Task<Result<int>> UpdateProduct(UpdateProductVM updateProductVM)
        {
            var result = new Result<int>();

            var existsProduct = await _unitWork.GetRepository<Product>().GetById(updateProductVM.Id);
            if (existsProduct is null)
            {
                throw new NotFoundException($"{updateProductVM} numaralı ürün bulunamadı.");
            }

            var categoryExistsSame = await _unitWork.GetRepository<Category>().AnyAsync(x => x.CategoryName == updateProductVM.CategoryName && x.Id == updateProductVM.CategoryId);
            if (!categoryExistsSame)
            {
                throw new NotFoundException($"Girilen kategori bilgileri eşleşmiyor veya kayıtlı değil.");
            }


            var updatedProduct = _mapper.Map(updateProductVM, existsProduct);

            _unitWork.GetRepository<Product>().Update(updatedProduct);
            await _unitWork.CommitAsync();

            result.Data = updatedProduct.Id;
            _unitWork.Dispose();
            return result;
        }
    }
}
