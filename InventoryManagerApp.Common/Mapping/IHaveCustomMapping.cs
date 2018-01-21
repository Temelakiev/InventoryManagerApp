using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagerApp.Common.Mapping
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile mapper);
    }
}
