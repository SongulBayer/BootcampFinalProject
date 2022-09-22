using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PycApi.Dto;
using PycApi.Service;
using PycApi.Data;
using PycApi.Base;
using Microsoft.AspNetCore.Authorization;

namespace PycApi.Controller
{
    //Added methods by inheriting from base service
    //Only authorized users can access
    [Authorize]
    [ApiController]
    [Route("api/nhb/[controller]")]
    public class OfferController : BaseController<OfferDto, Offer>
    {
        private readonly IOfferService offerService;
        private readonly IMapper mapper;


        public OfferController(IOfferService offerService, IMapper mapper) : base(offerService, mapper)
        {
            this.mapper = mapper;
            this.offerService = offerService;
        }

    }
}
