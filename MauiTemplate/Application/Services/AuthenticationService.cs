using Application.Interfaces;
using Application.Repositories;
using Shared.Dtos;
using Shared.Models;
//using Shared.Model;
using System.Net.Http;
using System.Net.Http.Json;

namespace Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient = default!;
        private readonly AccessTokenRepository _tokenRepository;
        private AppAuthenticationStateProvider _authenticationStateProvider = default!;

        public AuthenticationService(
            AppAuthenticationStateProvider authenticationStateProvider, HttpClient httpClient, AccessTokenRepository tokenRepository)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _httpClient = httpClient;
            _tokenRepository = tokenRepository;
        }

        public async Task SignIn(SignInRequestDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Account/Login", dto);
            var result = await response.Content.ReadAsStringAsync();
            await _tokenRepository.SetAccessToken(new AccessToken() { Token = result });
            await _authenticationStateProvider.RaiseAuthenticationStateHasChanged();
        }

        public async Task SignOut()
        {
            await _tokenRepository.RemoveAccessToken();
            await _authenticationStateProvider.RaiseAuthenticationStateHasChanged();
        }
    }
}
