﻿using Entities.DTOs;
using Shared.Utilities.Results.Abstract;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> Get(int categoryId);

        Task<IDataResult<CategoryListDto>> GetAll();

        Task<IDataResult<CategoryListDto>> GetAllByNonDeleted();

        Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive();

        Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDto(int categoryId);

        Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto, string createdByName);

        Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName);

        Task<IDataResult<CategoryDto>> Delete(int categoryId, string modifiedByName);

        Task<IResult> HardDelete(int categoryId);
    }
}