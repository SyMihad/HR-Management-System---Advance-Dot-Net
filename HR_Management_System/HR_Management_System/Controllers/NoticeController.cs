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
    public class NoticeController : ApiController
    {
        [HttpPost]
        [Route("api/notice/createNotice")]
        public HttpResponseMessage CreateNotice(NoticeDTO noticeDTO)
        {
            try
            {
                var res = NoticeService.CreateNotice(noticeDTO);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Notice not created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/notice/viewNotice/{id}")]
        public HttpResponseMessage ViewNotice(int id)
        {
            try
            {
                var res = NoticeService.ViewNotice(id);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Notice not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/notice/viewAllNotice/{id}")]
        public HttpResponseMessage ViewAllNotice(int id)
        {
            try
            {
                var res = NoticeService.ViewAllNotice(id);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Notice not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/notice/trackAllNotice/{id}")]
        public HttpResponseMessage TrackAllNotice(int id)
        {
            try
            {
                var res = NoticeService.TrackAllNotice(id);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Notice not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}