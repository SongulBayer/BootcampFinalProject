using AutoMapper;
using NHibernate;
using PycApi.Data;
using PycApi.Dto;


namespace PycApi.Service
{
    public class OfferService : BaseService<OfferDto, Offer>, IOfferService
    {

        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Offer> hibernateRepository;

        public OfferService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<Offer>(session);
        }



    }
}
