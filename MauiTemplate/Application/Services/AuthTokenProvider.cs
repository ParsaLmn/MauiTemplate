using Application.Interfaces;
using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthTokenProvider : IAuthTokenProvider
    {
        private readonly AccessTokenRepository _tokenRepository;
        public AuthTokenProvider(AccessTokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public async Task<string?> GetAcccessTokenAsync()
        {
            var token = await _tokenRepository.GetAccessToken();
            return token;
        }
    }
}
