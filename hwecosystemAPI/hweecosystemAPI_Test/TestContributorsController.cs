using AutoMapper;
using hwecosystemAPI.Controllers;
using hwecosystemAPI.Models;
using hwecosystemAPI.Repositories;
using hwecosystemAPI.Services;
using System;
using NUnit.Framework;

namespace hweecosystemAPI_Test
{
    public class TestContributorsController
    {
        ContributorsController controller;
        IContributorService _service;
        public TestContributorsController()
        {
            _service = new ContributorRepository();
            _controller = new ShoppingCartController(_service);
        }

        [Fact]
        public void Test1()
        {

        }

    }
}
