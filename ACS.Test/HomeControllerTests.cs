using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Options;
using ASC.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace ACS.Test
{
    public class HomeControllerTests
    {
        private readonly Mock<ILogger<HomeController>> optionsMock;
        public HomeControllerTests()
        {
            optionsMock = new Mock<ILogger<HomeController>>();
        }
        [Fact]
        public void HomeController_Index_View_Test()
        {
            
            var controler = new HomeController(optionsMock.Object);
        }
        [Fact]
        public void HomeController_Index_NoModel_Test()
        {
            var controller = new HomeController(optionsMock.Object);
            // Assert Model for Null
            Assert.Null((controller.Index() as ViewResult).ViewData.Model);
        }
        [Fact]
        public void HomeController_Index_Validation_Test()
        {
            var controller = new HomeController(optionsMock.Object);
            // Assert ModelState Error Count to 0
            Assert.Equal(0, (controller.Index() as ViewResult).ViewData.ModelState.ErrorCount);
        }
    }
}
