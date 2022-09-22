using PycApi.Base;
using System.Collections.Generic;

namespace PycApi.Service
{
    public interface IBaseService<Dto, Entity>
    {
        BaseResponse<Dto> GetById(int id);
        BaseResponse<IEnumerable<Dto>> GetAll();
        BaseResponse<Dto> Insert(Dto insertResource);
        BaseResponse<Dto> Update(int id, Dto updateResource);
        BaseResponse<Dto> Remove(int id);
    }
}
