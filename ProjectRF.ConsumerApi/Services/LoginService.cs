using ProjectRF.ConsumerApi.Interfaces;
using ProjectRF.ConsumerApi.Models;
using ProjectRF.ConsumerApi.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjectRF.ConsumerApi.Services
{
    public class LoginService : BaseService, ILogin
    {
        public bool Login(LoginRequest loginRequest)
        {
            bool isSuccess = false;

            LoginModel model = new LoginModel();
            DataProvider.ExecuteCmd(
                "Register_SelectByEmail",
                inputParamMapper: (SqlParameterCollection parms) =>
                {
                    parms.AddWithValue("@Email", loginRequest.Email);
                },
                singleRecordMapper: (IDataReader reader, short set) =>
                {
                    LoginModel mapped = Mapper(reader);
                    model = mapped;
                });
            if (model.Email == null)
            {
                return isSuccess;
            }

            if (loginRequest.Password == model.Password)
            {
                isSuccess = true;
            }

            return isSuccess;
        }
        private LoginModel Mapper(IDataReader reader)
        {
            LoginModel mapped = new LoginModel();
            int index = 0;
            mapped.Email = reader.GetString(index++);
            mapped.Password = reader.GetString(index++);

            return mapped;

        }
    }
}
