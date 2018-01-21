using AutoMapper;
using InventoryManagerApp.Web.Infrastructure.Mapping;
using System;

namespace InventoryManagerApp.Test
{
    public class TestStartup
    {
        private static bool testsInitialize = false;

        public static void Initialize()
        {
            if (!testsInitialize)
            {
                Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
                testsInitialize = true;
            }
        }
    }
}
