using AutoMapper;
using MailKit;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using PycApi.Base;
using PycApi.Dto;
using PycApi.Service;
using PycApi.StartUpExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using IMailService = PycApi.Service.IMailService;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Data;
using PycApi.Data;
using AutoMapper;
using NHibernate;
using PycApi.Base;
using PycApi.Data;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PycApi
{
    [ApiController]
    [Route("api/nhb/[controller]")]
    public class UserController : ControllerBase
    {
        //Services Added
        private readonly IAccountService accountService;
        private readonly IMapper mapper;
        private readonly IMailService _mailservice;
        protected readonly IHibernateRepository<Account> hibernateRepository;
        protected readonly ISession session;


        public UserController(IAccountService accountService, IMapper mapper,IMailService mailService)
        {
            this.accountService = accountService;
            this.mapper = mapper;
            this._mailservice = mailService;
            hibernateRepository = new HibernateRepository<Account>(session);
        }

        [NonAction]
        [HttpGet]
        public BaseResponse<IEnumerable<AccountDto>> GetAll()
        {
            var response = accountService.GetAll();
            return response;
        }

        [NonAction]
        [HttpGet("{id}")]
        public BaseResponse<AccountDto> GetById(int id)
        {
            var response = accountService.GetById(id);
            return response;
        }

        [HttpDelete("{id}")]
        public BaseResponse<AccountDto> Delete(int id)
        {
            var response = accountService.Remove(id);
            return response;
        }

        //Sending e-mail to registered users
        [HttpPost]
        public BaseResponse<AccountDto> Create([FromBody] AccountDto dto )
        {
            var response2 = accountService.GetAll();
            var result = response2.Response.FirstOrDefault(x => x.Email == dto.Email);
            if (result is null)
            {
                var mail = new MailDto();
                mail.To = dto.Email;
                mail.Subject = "We are glad you joined us.";
                mail.Body = "Welcome";
                _mailservice.SendEmail(mail);
                //Password hashed
                dto.Password = PasswordHashing.HashPassword(dto.Password);
                var response = accountService.Insert(dto);

                return response;
            }
            return new BaseResponse<AccountDto>("User Alread Exist");
           
        }

        [NonAction]
        [HttpPut("{id}")]
        public BaseResponse<AccountDto> Update(int id, [FromBody] AccountDto dto)
        {
            var response = accountService.Update(id, dto);
            return response;
        }
    }
    //Password Hashing
    public class PasswordHashing
    {
        public static string HashPassword(string password)
        {
            var prf = KeyDerivationPrf.HMACSHA256;
            var rng = RandomNumberGenerator.Create();
            const int iterCount = 10000;
            const int saltSize = 128 / 8;
            const int numBytesRequested = 256 / 8;

            // Produce a version 3 (see comment above) text hash.
            var salt = new byte[saltSize];
            rng.GetBytes(salt);
            var subkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, numBytesRequested);

            var outputBytes = new byte[13 + salt.Length + subkey.Length];
            outputBytes[0] = 0x01; // format marker
            WriteNetworkByteOrder(outputBytes, 1, (uint)prf);
            WriteNetworkByteOrder(outputBytes, 5, iterCount);
            WriteNetworkByteOrder(outputBytes, 9, saltSize);
            Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);
            Buffer.BlockCopy(subkey, 0, outputBytes, 13 + saltSize, subkey.Length);
            return Convert.ToBase64String(outputBytes);
        }

        public static bool VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            var decodedHashedPassword = Convert.FromBase64String(hashedPassword);

            // Wrong version
            if (decodedHashedPassword[0] != 0x01)
                return false;

            // Read header information
            var prf = (KeyDerivationPrf)ReadNetworkByteOrder(decodedHashedPassword, 1);
            var iterCount = (int)ReadNetworkByteOrder(decodedHashedPassword, 5);
            var saltLength = (int)ReadNetworkByteOrder(decodedHashedPassword, 9);

            // Read the salt: must be >= 128 bits
            if (saltLength < 128 / 8)
            {
                return false;
            }
            var salt = new byte[saltLength];
            Buffer.BlockCopy(decodedHashedPassword, 13, salt, 0, salt.Length);

            // Read the subkey (the rest of the payload): must be >= 128 bits
            var subkeyLength = decodedHashedPassword.Length - 13 - salt.Length;
            if (subkeyLength < 128 / 8)
            {
                return false;
            }
            var expectedSubkey = new byte[subkeyLength];
            Buffer.BlockCopy(decodedHashedPassword, 13 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);

            // Hash the incoming password and verify it
            var actualSubkey = KeyDerivation.Pbkdf2(providedPassword, salt, prf, iterCount, subkeyLength);
            return actualSubkey.SequenceEqual(expectedSubkey);
        }

        private static void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
        {
            buffer[offset + 0] = (byte)(value >> 24);
            buffer[offset + 1] = (byte)(value >> 16);
            buffer[offset + 2] = (byte)(value >> 8);
            buffer[offset + 3] = (byte)(value >> 0);
        }

        private static uint ReadNetworkByteOrder(byte[] buffer, int offset)
        {
            return ((uint)(buffer[offset + 0]) << 24)
                | ((uint)(buffer[offset + 1]) << 16)
                | ((uint)(buffer[offset + 2]) << 8)
                | ((uint)(buffer[offset + 3]));
        }
    }
}
