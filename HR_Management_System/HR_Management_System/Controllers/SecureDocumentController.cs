using BLL.Services;
using HR_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;
using BLL.DTOs;

namespace HR_Management_System.Controllers
{
    public class SecureDocumentController : ApiController
    {
        [HttpPost]
        [Route("api/secure/encrypt")]
        public HttpResponseMessage Encrypt(EncryptionTableDTO message)
        {
            try
            {
                var res = SecureDocumentService.SecureMessage(message);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/secure/getMessage")]
        public HttpResponseMessage GetMessage(DecryptionDTO decryptionDTO)
        {
            try
            {
                var res = SecureDocumentService.GetMessage(decryptionDTO);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Something went wrong" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}