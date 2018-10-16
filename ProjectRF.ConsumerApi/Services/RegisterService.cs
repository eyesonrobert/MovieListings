using ProjectRF.ConsumerApi.Interfaces;
using ProjectRF.ConsumerApi.Models;
using ProjectRF.ConsumerApi.Tools;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjectRF.ConsumerApi.Services
{
    public class RegisterService : BaseService, IRegister
    {
        public int Insert(RegisterDomain model)

        {
            int returnValue = 0;

            DataProvider.ExecuteNonQuery("dbo.Register_Create",
               inputParamMapper: (SqlParameterCollection inputs) =>
               {
                   inputs.Add(SqlDbParameter.Instance.BuildParameter("@FirstName", model.FirstName, SqlDbType.NVarChar));
                   inputs.Add(SqlDbParameter.Instance.BuildParameter("@LastName", model.LastName, SqlDbType.NVarChar));
                   inputs.Add(SqlDbParameter.Instance.BuildParameter("@Email", model.Email, SqlDbType.NVarChar));
                   inputs.Add(SqlDbParameter.Instance.BuildParameter("@Password", model.Password, SqlDbType.NVarChar));

                   SqlParameter idOut = new SqlParameter("@Id", 0);
                   idOut.Direction = ParameterDirection.Output;

                   inputs.Add(idOut);
               },
               returnParameters: (SqlParameterCollection inputs) =>
               {
                   int.TryParse(inputs["@Id"].Value.ToString(), out returnValue);
               }
               );
            return returnValue;
        }
    }
}
