using BLL.DTOs;
using BLL.Services;
using HR_Management_System.Auth;
using HR_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace HR_Management_System.Controllers
{
    public class AuthController : ApiController
    {

        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(LoginModel login)
        {
            try
            {
                var res = AuthService.Authenticate(login.Email, login.Password);
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

        [Logged]
        [HttpGet]
        [Route("api/logout")]
        public HttpResponseMessage Logout()
        {
            var token = Request.Headers.Authorization.ToString();
            try
            {
                var res = AuthService.Logout(token);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }

        }


        [HttpPost]
        [Route("api/auth/createSuperAdmin")]
        public HttpResponseMessage CreateSuperAdmin(UserDTO user)
        {
            try
            {
                var res = AuthService.CreateSuperAdmin(user);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/auth/allSuperAdmins")]
        public HttpResponseMessage GetAllSuperAdmin()
        {
            try
            {
                var res = AuthService.GetAllSuperAdmin();
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Super Admins not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/auth/updateSuperAdmin")]
        public HttpResponseMessage UpdateSuperAdmin(UserDTO user)
        {
            try
            {
                var res = AuthService.UpdateUser(user);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/auth/deleteUser/{id}")]
        public HttpResponseMessage DeletePost(int id)
        {
            var res = AuthService.DeleteUser(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }

        [HttpGet]
        [Route("api/auth/showProfile/{id}")]
        public HttpResponseMessage ShowProfile(int id)
        {
            try
            {
                var res = AuthService.ShowUserProfile(id);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Profile not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }

        }

        [HttpPost]
        [Route("api/auth/createOrganization")]
        public HttpResponseMessage CreateOrganization(OrganizationDTO organizationDTO)
        {
            try
            {
                var res = AuthService.CreateOrganization(organizationDTO);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Organization not created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/auth/updateOrganization")]
        public HttpResponseMessage UpdateOrganization(OrganizationDTO organizationDTO)
        {
            try
            {
                var res = AuthService.UpdateOrganization(organizationDTO);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Organization not updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/auth/deleteOrganization/{id}")]
        public HttpResponseMessage DeleteOrganization(int id)
        {
            var res = AuthService.DeleteOrganization(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }

        [HttpPost]
        [Route("api/auth/createJobCategory")]
        public HttpResponseMessage CreateJobCetegory(JobCategoryDTO jobCategoryDTO)
        {
            try
            {
                var res = AuthService.CreateJobCategory(jobCategoryDTO);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Job Category not created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/auth/updateJobCetegory")]
        public HttpResponseMessage UpdateJobCetegory(JobCategoryDTO jobCategoryDTO)
        {
            try
            {
                var res = AuthService.UpdateJobCetegory(jobCategoryDTO);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Job Category not updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/auth/deleteJobCetegory/{id}")]
        public HttpResponseMessage DeleteJobCetegory(int id)
        {
            var res = AuthService.DeleteJobCetegory(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }

        [HttpPost]
        [Route("api/auth/createManager")]
        public HttpResponseMessage CreateManager(UserDTO user)
        {
            try
            {
                var res = AuthService.CreateManager(user);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/auth/createEmployee")]
        public HttpResponseMessage CreateEmployee(UserDTO user)
        {
            try
            {
                var res = AuthService.CreateEmployee(user);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/auth/allEmployees/{id}")]
        public HttpResponseMessage GetAllUserBasedOnORganization(int id)
        {
            try
            {
                var res = AuthService.GetAllUserBasedOnORganization(id);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Profile not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }

        }
    }
}