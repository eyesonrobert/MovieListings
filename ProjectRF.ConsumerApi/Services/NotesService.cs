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
    public class NotesService : BaseService, INotes
    {

        public int Insert(NotesAddRequest model)

        {
            int returnValue = 0;

            DataProvider.ExecuteNonQuery("dbo.Notes_Create",
               inputParamMapper: (SqlParameterCollection inputs) =>
               {
                   inputs.Add(SqlDbParameter.Instance.BuildParameter("@Notes", model.Notes, SqlDbType.NVarChar));

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
        List<NotesDomain> INotes.SelectAll()
        {
            List<NotesDomain> list = new List<NotesDomain>();
            DataProvider.ExecuteCmd("dbo.Notes_SelectAll",
                inputParamMapper: null,
                singleRecordMapper: (IDataReader reader, short resultSet) =>
                {
                    list.Add(DataMapper<NotesDomain>.Instance.MapToObject(reader));
                });
            return list;
        }

        public NotesDomain SelectById(int id)
        {
            NotesDomain notesDomain = new NotesDomain();
            DataProvider.ExecuteCmd("dbo.Notes_SelectById",
           inputParamMapper: (SqlParameterCollection inputs) =>
           {
               inputs.AddWithValue("@Id", id);
           },
           singleRecordMapper: (IDataReader reader, short resultSet) =>
           {
               notesDomain = DataMapper<NotesDomain>.Instance.MapToObject(reader);
           });
          return notesDomain;
        }
        private LoginModel Mapper(IDataReader reader)
        {
            LoginModel mapped = new LoginModel();
            int index = 0;
            mapped.Email = reader.GetString(index++);
            mapped.Password = reader.GetString(index++);

            return mapped;

        }


        public void Delete(int id)
        {
            DataProvider.ExecuteNonQuery("dbo.Notes_Delete",
            inputParamMapper: (SqlParameterCollection inputs) =>
            {
                inputs.AddWithValue("@Id", id);
            });
        }

        public void Update(NotesUpdateRequest model)
        {
            DataProvider.ExecuteNonQuery("dbo.Notes_Update",
                inputParamMapper: (SqlParameterCollection inputs) =>
                {
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@Id", model.Id, SqlDbType.Int));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@Notes", model.Notes, SqlDbType.NVarChar));
                });
        }
    }
}