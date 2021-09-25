using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using NSubstitute;
using NUnit.Framework;
using PersonEditor.Model;
using PersonEditor.Web.WorkContext;
using Shouldly;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System;
using PersonEditor.Model.Entities;
using PersonEditor.Controllers;

namespace PersonEditor.Web.Tests.ControllersTests
{
    public class PersonControllerTests
    {
        protected IWebHostBuilder WebHostBuilder { get; private set; }

        protected IWorkContext WorkContext { get; private set; }

        protected string Route { get; set; } = "/api/Person";

        [SetUp]
        public void BeforeEach()
        {
            WorkContext = Substitute.For<IWorkContext>();

            var workContextCreator = Substitute.For<IWorkContextCreatable>();

            workContextCreator.Create(Arg.Any<HttpContext>()).Returns(WorkContext);

            WebHostBuilder = new WebHostBuilder();

            WebHostBuilder
                .ConfigureServices(services =>
                {
                    services.AddTransient(_ => workContextCreator);

                    services
                        .AddMvc(options =>
                        {
                            options.EnableEndpointRouting = false;
                        })
                        .AddApplicationPart(typeof(PersonController).Assembly)
                        .AddControllersAsServices();
                });

            WebHostBuilder.Configure(applicationBuilder => applicationBuilder.UseMvc());
        }

        [TestFixture]
        public class GetPerson : PersonControllerTests
        {
            [Test]
            public async Task Then_StatusCode_OK_Should_Be_Returned()
            {
                // Arrange
                WorkContext.PersonRepository.GetPerson(Arg.Any<Guid>()).Returns(new Person());

                using (var server = new TestServer(WebHostBuilder))
                {
                    // Act
                    var response = await server.CreateClient().GetAsync(Route);

                    // Assert
                    response.StatusCode.ShouldBe(HttpStatusCode.OK);
                }
            }

            [Test]
            public async Task Then_GetPerson_Should_Be_Called()
            {
                // Arrange
                var personId = Guid.NewGuid();

                using (var server = new TestServer(WebHostBuilder))
                {
                    // Act
                    var response = await server.CreateClient().GetAsync($"{Route}?id={personId}");

                    // Assert
                    WorkContext.PersonRepository.Received().GetPerson(personId);
                }
            }
        }
    }
}