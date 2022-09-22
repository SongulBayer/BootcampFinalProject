using AutoMapper;
using NHibernate;
using PycApi.Data;
using PycApi.Dto;


namespace PycApi.Service
{
    public class CategoryService : BaseService<CategoryDto, Category>, ICategoryService
    {

        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Category> hibernateRepository;

        public CategoryService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<Category>(session);
        }



    }
}
