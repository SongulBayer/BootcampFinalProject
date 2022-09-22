using AutoMapper;
using NHibernate;
using PycApi.Base;
using PycApi.Data;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PycApi.Service
{//Base Service added
    public abstract class BaseService<Dto, Entity> : IBaseService<Dto, Entity> where Entity : class
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Entity> hibernateRepository;


        public BaseService(ISession session, IMapper mapper) : base()
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<Entity>(session);
        }


        public virtual BaseResponse<IEnumerable<Dto>> GetAll()
        {
            try
            {
                var tempEntity = hibernateRepository.Entities.ToList();
                var result = mapper.Map<IEnumerable<Entity>, IEnumerable<Dto>>(tempEntity);
                return new BaseResponse<IEnumerable<Dto>>(result);
            }
            catch (Exception ex)
            {
                Log.Error("BaseService.GetAll", ex);
                return new BaseResponse<IEnumerable<Dto>>(ex.Message);
            }
        }

        public virtual BaseResponse<Dto> GetById(int id)
        {
            try
            {
                var tempEntity = hibernateRepository.GetById(id);
                var result = mapper.Map<Entity, Dto>(tempEntity);
                return new BaseResponse<Dto>(result);
            }
            catch (Exception ex)
            {
                Log.Error("BaseService.GetById", ex);
                return new BaseResponse<Dto>(ex.Message);
            }
        }

        public virtual BaseResponse<Dto> Insert(Dto insertResource)
        {
            try
            {
                var tempEntity = mapper.Map<Dto, Entity>(insertResource);              

                hibernateRepository.BeginTransaction();
                hibernateRepository.Save(tempEntity);
                hibernateRepository.Commit();

                hibernateRepository.CloseTransaction();
                return new BaseResponse<Dto>(mapper.Map<Entity, Dto>(tempEntity));
            }
            catch (Exception ex)
            {
                Log.Error("BaseService.Insert", ex);
                hibernateRepository.Rollback();
                hibernateRepository.CloseTransaction();
                return new BaseResponse<Dto>(ex.Message);
            }

        }

        public virtual BaseResponse<Dto> Remove(int id)
        {
            try
            {
                var tempEntity = hibernateRepository.GetById(id);
                if (tempEntity is null)
                {
                    return new BaseResponse<Dto>("Record Not Found");
                }

                hibernateRepository.BeginTransaction();
                hibernateRepository.Delete(id);
                hibernateRepository.Commit();
                hibernateRepository.CloseTransaction();

                return new BaseResponse<Dto>(mapper.Map<Entity, Dto>(tempEntity));
            }
            catch (Exception ex)
            {
                Log.Error("BaseService.Remove", ex);
                hibernateRepository.Rollback();
                hibernateRepository.CloseTransaction();
                return new BaseResponse<Dto>(ex.Message);
            }
        }

        public virtual BaseResponse<Dto> Update(int id, Dto updateResource)
        {
            try
            {
                var tempEntity = hibernateRepository.GetById(id);
                if (tempEntity is null)
                {
                    return new BaseResponse<Dto>("Record Not Found");
                }


                var entity = mapper.Map<Dto,Entity>(updateResource, tempEntity);

                hibernateRepository.BeginTransaction();
                hibernateRepository.Update(entity);
                hibernateRepository.Commit();
                hibernateRepository.CloseTransaction();

                var resource = mapper.Map<Entity, Dto>(entity);
                return new BaseResponse<Dto>(resource);
            }
            catch (Exception ex)
            {
                Log.Error("BaseService.Update", ex);
                hibernateRepository.Rollback();
                hibernateRepository.CloseTransaction();
                return new BaseResponse<Dto>(ex.Message);
            }
        }
        //public virtual BaseResponse<Dto> GetByMail(string mail)
        //{
        //    return 
        //}


    }
}
