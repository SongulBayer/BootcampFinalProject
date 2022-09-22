using AutoMapper;
using FluentNHibernate.Data;
using NHibernate;
using PycApi.Base;
using PycApi.Data;
using PycApi.Dto;
using Serilog;
using System;
using System.Security.Cryptography;
using System.Text;

namespace PycApi.Service
{
    public class AccountService : BaseService<AccountDto, Account>, IAccountService
    {

        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Account> hibernateRepository;

        public AccountService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<Account>(session);
        }
        //Only one registration is done with one e-mail address.
        public virtual BaseResponse<AccountDto> GetByMail(string mail)
        {
            try
            {
                var tempEntity = hibernateRepository.GetByMail(mail);
                var result = mapper.Map<Account, AccountDto>(tempEntity);
                return new BaseResponse<AccountDto>(result);
            }
            catch (Exception ex)
            {
                Log.Error("BaseService.GetById", ex);
                return new BaseResponse<AccountDto>(ex.Message);
            }
        }
    }
}
