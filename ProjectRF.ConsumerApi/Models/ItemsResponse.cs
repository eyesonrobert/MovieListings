using ProjectRF.ConsumerApi.Controllers.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectRF.ConsumerApi.Models
{
    public class ItemsResponse<T> : SuccessResponse
    {
        public List<T> Items { get; set; }
    }
}