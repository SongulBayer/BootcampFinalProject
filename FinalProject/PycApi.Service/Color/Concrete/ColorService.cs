using AutoMapper;
using NHibernate;
using PycApi.Base;
using PycApi.Data;
using PycApi.Dto;
using System;



namespace PycApi.Service
{
    public class ColorService : BaseService<ColorDto, Color>, IColorService
    {

        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Color> hibernateRepository;

        public ColorService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<Color>(session);
        }



    }
}
