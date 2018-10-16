using ProjectRF.ConsumerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRF.ConsumerApi.Interfaces
{
    public interface IRegister
    {
        int Insert(RegisterDomain model);
    }
}
