using AutoMapper;
using NHibernate;
using PycApi.Base;
using PycApi.Data;
using PycApi.Dto;
using Serilog;
using System;

namespace PycApi.Service
{
    public class ProductService : BaseService<ProductDto, Product>, IProductService
    {

        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Product> hibernateRepositoryProduct;

        public ProductService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepositoryProduct = new HibernateRepository<Product>(session);
        }


       

    }
}
