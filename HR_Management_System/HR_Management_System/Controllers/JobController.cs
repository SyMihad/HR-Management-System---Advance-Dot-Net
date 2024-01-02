using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;

namespace HR_Management_System.Controllers
{
    public class JobController : ApiController
    {
        [HttpPost]
        [Route("api/job/createJobRequirmentsPost")]
        public HttpResponseMessage CreateJobRequirmentsPost(JobRequirmentsDTO jobRequirmentsDTO)
        {
            try
            {
                var res = JobService.CreateJobRequirmentsPost(jobRequirmentsDTO);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "post not created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/job/viewJobRequirmentsPost/{id}")]
        public HttpResponseMessage ViewJobRequirmentsPost(int id)
        {
            try
            {
                var res = JobService.ViewJobRequirmentsPost(id);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "post not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/job/deleteJobRequirmentsPost/{id}")]
        public HttpResponseMessage DeletePost(int id)
        {
            var res = JobService.DeleteJobRequirmentsPost(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }

        [HttpPut]
        [Route("api/job/updateJobRequirmentsPost")]
        public HttpResponseMessage UpdateJobRequirmentsPost(JobRequirmentsDTO jobRequirmentsDTO)
        {
            try
            {
                var res = JobService.UpdateJobRequirmentsPost(jobRequirmentsDTO);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "post not updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/job/viewAllJobRequirmentsPost")]
        public HttpResponseMessage ViewAllJobRequirmentsPost()
        {
            try
            {
                var res = JobService.AllJobRequirmentsPost();
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "post not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/job/viewAllJobRequirmentsPostbyOrg/{id}")]
        public HttpResponseMessage ViewAllJobRequirmentsPostByOrg(int id)
        {
            try
            {
                var res = JobService.AllJobRequirmentsPostByOrg(id);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "post not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/job/createJobApplication")]
        public HttpResponseMessage CreateJobApplication(JobApplicationDTO jobApplicationDTO)
        {
            try
            {
                var res = JobService.CreateJobApplication(jobApplicationDTO);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "post not created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/job/viewJobApplication/{id}")]
        public HttpResponseMessage ViewJobApplication(int id)
        {
            try
            {
                var res = JobService.ViewJobApplication(id);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "post not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/job/makeShortLishted/{id}")]
        public HttpResponseMessage MakeShortLishted(int id)
        {
            try
            {
                var res = JobService.MakeShortLishted(id);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "post not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/job/makeSelected/{id}")]
        public HttpResponseMessage MakeSelected(int id)
        {
            try
            {
                var res = JobService.MakeSelected(id);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "post not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/job/allShortLishted")]
        public HttpResponseMessage AllShortLishted()
        {
            try
            {
                var res = JobService.AllShortLishted();
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "post not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/job/allSelected")]
        public HttpResponseMessage AllSelected()
        {
            try
            {
                var res = JobService.AllSelected();
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "post not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

    }
}