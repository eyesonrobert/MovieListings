using ProjectRF.ConsumerApi.Interfaces;
using ProjectRF.ConsumerApi.Models;
using ProjectRF.ConsumerApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace ProjectRF.ConsumerApi.Controllers.api
{
    [RoutePrefix("api/user/notes")]
    public class NotesController : ApiController
    {
        INotes _notes = new NotesService();
        [Route(), HttpGet]
        public IHttpActionResult SelectAll()
        {
            try
            {
                ItemsResponse<NotesDomain> response = new ItemsResponse<NotesDomain>();
                response.Items = _notes.SelectAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                {
                   
                };

                return BadRequest(ex.Message);
            }
        }

        [Route("{id:int}"), HttpGet]
        public IHttpActionResult SelectById(int id)
        {
            try
            {
                ItemResponse<NotesDomain> response = new ItemResponse<NotesDomain>
                {
                    Item = _notes.SelectById(id)
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                {

                };

                return BadRequest(ex.Message);
            }
        }

        [Route(), HttpPost]
        public IHttpActionResult Insert(NotesAddRequest model)
        {
            try
            {

                ItemResponse<int> response = new ItemResponse<int>
                {
                    Item = _notes.Insert(model)
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                {

                };

                return BadRequest(ex.Message);
            }
        }

        [Route("{id:int}"), HttpPut]
        public IHttpActionResult Update(NotesUpdateRequest model)
        {
            try
            {
                _notes.Update(model);
                return Ok(new SuccessResponse());
            }
            catch (Exception ex)
            {
                {

                };

                return BadRequest(ex.Message);
            }
        }

        [Route("{id:int}"), HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _notes.Delete(id);
                return Ok(new SuccessResponse());
            }
            catch (Exception ex)
            {
                {

                };

                return BadRequest(ex.Message);
            }
        }

    }
}