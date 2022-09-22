using AutoMapper;
using NHibernate;
using PycApi.Data;
using PycApi.Dto;


namespace PycApi.Service
{
    public class BrandService : BaseService<BrandDto, Brand>, IBrandService
    {

        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Brand> hibernateRepository;

        public BrandService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<Brand>(session);
        }



    }
}
