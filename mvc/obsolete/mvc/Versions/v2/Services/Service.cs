using AutoMapper;
using mvc.Configurations.Exceptions;
using mvc.DataAccess.Entities;
using mvc.DataAccess.Repository.Interfaces;
using mvc.Versions.v2.DTOs;

namespace mvc.Versions.v2.Services;

public abstract class Service<TEntity, TDto, TForCreationDto, TForUpdateDto, TRepository> : IService<TEntity, TDto, TForCreationDto, TForUpdateDto>
    where TEntity : class, IEntity
    where TDto : class, IDto
    where TForCreationDto : class, IDto
    where TForUpdateDto : class, IDto
    where TRepository : IRepository<TEntity>
{
    protected readonly IUnitOfWork UnitOfWork;
    protected readonly IMapper Mapper;

    protected TRepository Repository { get; init; } = default!;

    protected Service(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        this.Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<TDto>> GetAllAsync()
    {
        var (entities, _) = await Repository.GetAsync();

        var dtos = Mapper.Map<IEnumerable<TDto>>(entities);

        return dtos;
    }

    public async Task<TDto> GetByIdAsync(int id)
    {
        var entity = await Repository.GetByIdAsync(id) ?? throw new NotFoundApiException();

        var dto = Mapper.Map<TDto>(entity);

        return dto;
    }

    public async Task<TDto> CreateAsync(TForCreationDto dto)
    {
        var entity = Mapper.Map<TEntity>(dto);

        await Repository.AddAsync(entity);
        await UnitOfWork.SaveAsync();

        var createdDto = Mapper.Map<TDto>(entity);

        return createdDto;
    }

    public async Task UpdateAsync(int id, TForUpdateDto dto)
    {
        var entityToUpdate = await Repository.GetByIdAsync(id) ?? throw new NotFoundApiException();

        Mapper.Map(dto, entityToUpdate);

        Repository.Modify(entityToUpdate);
        await UnitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entityToDelete = await Repository.GetByIdAsync(id) ?? throw new NotFoundApiException();

        Repository.Remove(entityToDelete);
        await UnitOfWork.SaveAsync();
    }
}