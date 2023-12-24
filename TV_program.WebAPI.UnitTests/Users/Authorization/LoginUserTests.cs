using System.Net;
using TV_program.BL.Auth.Entities;
using TV_program.DataAccess;
using TV_program.DataAccess.Entities;
using FluentAssertions;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;

namespace TV_program.WebAPI.UnitTests.Users.Authorization
{
    public class LoginUserTests : TV_programWebAPITestsBaseClass
    {
        [Test]
        public async Task SuccessFullResult()
        {
            var user = new UserEntity()
            {
                UserName = "test@test",
                PhoneNumber = "Test",
                Email = "test@test",
                Code = "Test",
                PasswordHash = "Test",
                Registration = new DateTime(2023, 01, 13),
                LastEntry = new DateTime(2023, 10, 12)
            };
            var password = "Password12@";

            using var scope = GetService<IServiceScopeFactory>().CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserEntity>>();
            var result = await userManager.CreateAsync(user, password);

            //execute
            var query = $"?email={user.UserName}&password={password}";
            var requestUri =
                TV_programApiEndpoints.AuthorizeUserEndpoint + query; // /auth/login?login=test@test&password=password
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var client = TestHttpClient;
            var response = await client.SendAsync(request);

            var responseContentJson = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<TokensResponse>(responseContentJson);

            content.Should().NotBeNull();
            content.AccessToken.Should().NotBeNull();
            content.RefreshToken.Should().NotBeNull();


            var requestToGetAllProducts =
                new HttpRequestMessage(HttpMethod.Get, TV_programApiEndpoints.AuthorizeUserEndpoint);

            var clientWithToken = TestHttpClient;
            client.SetBearerToken(content.AccessToken);
            var getAllUsersResponse = await client.SendAsync(requestToGetAllProducts);

            getAllUsersResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public async Task BadRequestUserNotFoundResultTest()
        {
            // prepare: (imagine_login, imagine_password) => execute (try to login) => assert (BadRequest user not found)
            //prepare
            var login = "not_existing@mail.ru";
            using var scope = GetService<IServiceScopeFactory>().CreateScope();
            var userRepository = scope.ServiceProvider.GetRequiredService<IRepository<UserEntity>>();
            var user = userRepository.GetAll().FirstOrDefault(x => x.UserName.ToLower() == login.ToLower());
            if (user != null)
            {
                userRepository.Delete(user);
            }

            var password = "password";
            //100% confidence
            //execute
            var query = $"?email={login}&password={password}";
            var requestUri =
                TV_programApiEndpoints.AuthorizeUserEndpoint + query; // /auth/login?login=test@test&password=password
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var response = await TestHttpClient.SendAsync(request);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Test]
        public async Task PasswordIsIncorrectResultTest()
        {
            var user = new UserEntity()
            {
                Email = "test@test",
                UserName = "test@test",
            };
            var password = "password";

            using var scope = GetService<IServiceScopeFactory>().CreateScope();
            var userManager = scope.ServiceProvider.GetService<UserManager<UserEntity>>();
            await userManager.CreateAsync(user, password);

            var incorrect_password = "kvhdbkvhbk";

            //execute
            var query = $"?email={user.UserName}&password={incorrect_password}";
            var requestUri =
                TV_programApiEndpoints.AuthorizeUserEndpoint + query; // /auth/login?login=test@test&password=kvhdbkvhbk
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var client = TestHttpClient;
            var response = await client.SendAsync(request);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest); // with some message
        }

        [Test]
        [TestCase("", "")]
        [TestCase("qwe", "")]
        [TestCase("test@test", "")]
        [TestCase("", "password")]
        public async Task LoginOrPasswordAreInvalidResultTest(string login, string password)
        {
            //execute
            var query = $"?login={login}&password={password}";
            var requestUri =
                TV_programApiEndpoints.AuthorizeUserEndpoint + query; // /auth/login?login=test@test&password=kvhdbkvhbk
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var client = TestHttpClient;
            var response = await client.SendAsync(request);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest); // with some message
        }
    }
}
