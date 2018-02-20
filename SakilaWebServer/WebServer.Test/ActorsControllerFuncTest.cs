using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using WebServer.Controllers;
using WebServer.Models;

namespace WebServer.Test
{

    /**
        Example of Functional test:
        cases for each controller action (method)
     */
    public class ActorsControllerFunctionTest
    {
        [Fact]
        public void GetActorByIdSmokeTest()
        {
            var controller = new ActorsController();
            var result = controller.Get(101) as OkObjectResult;
            var actor = result.Value as Actor;
            Assert.Equal(actor.Actor_ID, 101);
            Assert.Equal(actor.FirstName, "SUSAN");
            Assert.Equal(actor.LastName, "DAVIS");
        }
    }

}