using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Yeditepe.DataAccess.Repositories;
using YtsFramework.NETCore.Aspects.Caching;
using YtsFramework.NETCore.Signatures;
using YtsFramework.NETCore.Utilities.IoC;
using YtsFramework.NETCore.Utilities.Results.DataResult;
using YtsFramework.NETCore.Utilities.Results.Result;

namespace Yeditepe.Business.Repositories
{

    public class ServiceRepository<TEntity, TModel> : IServiceRepository<TModel>
        where TEntity : class, IBaseEntity, new()
        where TModel : class, IBaseModel, new()
    {
        private readonly IMapper _mapper;
        private readonly IDalRepository<TEntity> _dal;

        protected ServiceRepository()
        {
            _mapper = ServiceTool.ServiceProvider.GetService<IMapper>();
            _dal = ServiceTool.ServiceProvider.GetService<IDalRepository<TEntity>>();
        }

        [CacheAspect]
        public async Task<bool> AnyAsync(int id)=> await _dal.GetAsync(id) != null;

        [CacheAspect]
        public virtual async Task<TModel> GetAsync(int id) => _mapper.Map<TModel>(await _dal.GetAsync(id));

        [RemoveCacheAspect]
        public virtual async Task<IDataResponse<TModel>> InsertAsync(TModel model)
        {
            var result = await _dal.InsertAsync(_mapper.Map<TEntity>(model));
            if (!result.Success) return new ErrorDataResponse<TModel>(result.Message);
            return new SuccessDataResponse<TModel>(_mapper.Map<TModel>(result.Data));
        }

        [RemoveCacheAspect]
        public virtual async Task<List<IDataResponse<TModel>>> InsertRangeAsync(IEnumerable<TModel> models)
        {
            var result = new List<IDataResponse<TModel>>();
            foreach (var model in models) result.Add(await InsertAsync(model));
            return result;
        }

        [RemoveCacheAspect]
        public virtual async Task<IResponse> UpdateAsync(TModel model) => await _dal.UpdateAsync(_mapper.Map<TEntity>(model));

        [RemoveCacheAspect]
        public virtual async Task<List<IResponse>> UpdateRangeAsync(IEnumerable<TModel> models)
        {
            var result = new List<IResponse>();
            foreach (var model in models) result.Add(await UpdateAsync(model));
            return result;
        }

        [RemoveCacheAspect]
        public virtual async Task<IDataResponse<int>> DeleteAsync(int id)
        {
            var entity = await _dal.GetAsync(id);
            var result = await _dal.DeleteAsync(entity);
            if (!result.Success) return new ErrorDataResponse<int>(id, result.Message);
            return new SuccessDataResponse<int>(id, result.Message);
        }

        [RemoveCacheAspect]
        public virtual async Task<List<IDataResponse<int>>> DeleteRangeAsync(IEnumerable<int> list)
        {
            var result = new List<IDataResponse<int>>();
            foreach (var id in list) result.Add(await DeleteAsync(id));
            return result;
        }

        [RemoveCacheAspect]
        public virtual async Task RemoveCacheAsync() => await Task.CompletedTask;
    }
}
