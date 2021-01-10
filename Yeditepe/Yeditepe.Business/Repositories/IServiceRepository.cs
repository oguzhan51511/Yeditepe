using System.Collections.Generic;
using System.Threading.Tasks;
using YtsFramework.NETCore.Signatures;
using YtsFramework.NETCore.Utilities.Results.DataResult;
using YtsFramework.NETCore.Utilities.Results.Result;

namespace Yeditepe.Business.Repositories
{
    public interface IServiceRepository<TModel> where TModel : class, IBaseModel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> AnyAsync(int id);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TModel> GetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IDataResponse<TModel>> InsertAsync(TModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        Task<List<IDataResponse<TModel>>> InsertRangeAsync(IEnumerable<TModel> models);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResponse> UpdateAsync(TModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        Task<List<IResponse>> UpdateRangeAsync(IEnumerable<TModel> models);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IDataResponse<int>> DeleteAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        Task<List<IDataResponse<int>>> DeleteRangeAsync(IEnumerable<int> list);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task RemoveCacheAsync();
    }
}