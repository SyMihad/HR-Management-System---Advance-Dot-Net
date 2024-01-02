using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static UserDTO CreateSuperAdmin(UserDTO userDTO)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<User, UserDTO>();
                c.CreateMap<UserDTO, User>();
            });

            var mapper = new Mapper(cfg);
            var mappedUser = mapper.Map<User>(userDTO);
            var user = DataAccessFactory.UserData().Create(mappedUser);
            var auth = new Authorization();
            auth.Role = "Super_Admin";
            auth.UserID = user.Id;
            var authCreated = DataAccessFactory.AuthorizationData().Create(auth);
            return mapper.Map<UserDTO>(user);

        }

        public static List<UserWithAuthorizationDTO> GetAllSuperAdmin()
        {
            var data = DataAccessFactory.UserFilter().FilterWithType("Super_Admin");
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<User, UserWithAuthorizationDTO>();
                c.CreateMap<Authorization, AuthorizationDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<UserWithAuthorizationDTO>>(data);
            return mapped;
        }

        public static UserDTO UpdateUser(UserDTO userDTO)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<User, UserDTO>();
                c.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(cfg);
            var mappedData = mapper.Map<User>(userDTO);
            var data = DataAccessFactory.UserData().Update(mappedData);
            return mapper.Map<UserDTO>(data);
        }

        public static bool DeleteUser(int id)
        {
            var res = DataAccessFactory.UserData().Delete(id);
            return res;
        }

        public static UserDTO ShowUserProfile(int id)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<User, UserDTO>();
                c.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(cfg);
            var res = DataAccessFactory.UserData().Read(id);
            return mapper.Map<UserDTO>(res);
        }

        public static OrganizationDTO CreateOrganization(OrganizationDTO organizationDTO)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Organization, OrganizationDTO>();
                c.CreateMap<OrganizationDTO, Organization>();
            });

            var mapper = new Mapper(cfg);
            var mappedOrganization = mapper.Map<Organization>(organizationDTO);
            var org = DataAccessFactory.OrganizationData().Create(mappedOrganization);
            return mapper.Map<OrganizationDTO>(org);

        }

        public static OrganizationDTO UpdateOrganization(OrganizationDTO organizationDTO)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Organization, OrganizationDTO>();
                c.CreateMap<OrganizationDTO, Organization>();
            });

            var mapper = new Mapper(cfg);
            var mappedOrganization = mapper.Map<Organization>(organizationDTO);
            var org = DataAccessFactory.OrganizationData().Update(mappedOrganization);
            return mapper.Map<OrganizationDTO>(org);

        }

        public static bool DeleteOrganization(int id)
        {
            var res = DataAccessFactory.OrganizationData().Delete(id);
            return res;
        }

        public static JobCategoryDTO CreateJobCategory(JobCategoryDTO jobCategoryDTO)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<JobCategories, JobCategoryDTO>();
                c.CreateMap<JobCategoryDTO, JobCategories>();
            });

            var mapper = new Mapper(cfg);
            var mappedJobCategory = mapper.Map<JobCategories>(jobCategoryDTO);
            var jobCat = DataAccessFactory.JobCategoryData().Create(mappedJobCategory);
            return mapper.Map<JobCategoryDTO>(jobCat);

        }

        public static JobCategoryDTO UpdateJobCetegory(JobCategoryDTO jobCategoryDTO)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<JobCategories, JobCategoryDTO>();
                c.CreateMap<JobCategoryDTO, JobCategories>();
            });

            var mapper = new Mapper(cfg);
            var mappedJobCategory = mapper.Map<JobCategories>(jobCategoryDTO);
            var jobCat = DataAccessFactory.JobCategoryData().Update(mappedJobCategory);
            return mapper.Map<JobCategoryDTO>(jobCat);

        }

        public static bool DeleteJobCetegory(int id)
        {
            var res = DataAccessFactory.JobCategoryData().Delete(id);
            return res;
        }

        public static UserDTO CreateManager(UserDTO userDTO)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<User, UserDTO>();
                c.CreateMap<UserDTO, User>();
            });

            var mapper = new Mapper(cfg);
            var mappedUser = mapper.Map<User>(userDTO);
            var user = DataAccessFactory.UserData().Create(mappedUser);

            var userID = user.Id;

            var auth = new Authorization();
            auth.Role = "Manager";
            auth.UserID = userID;
            var authCreated = DataAccessFactory.AuthorizationData().Create(auth);

            var jobCat = DataAccessFactory.JobCategoryFIlter().FilterWithTypeSingle("Manager");
            var userJobTable = new UserJobTable();
             userJobTable.UserID = userID;
             userJobTable.JobCategoryID = jobCat.Id;
             var userTableCreated = DataAccessFactory.UserJobTableData().Create(userJobTable); 

             var org = DataAccessFactory.OrganizationData().Read(userDTO.OrganizationID);
             var userOrganizationTable = new UserOrganizationTable();
             userOrganizationTable.OrganizationID = org.Id;
             userOrganizationTable.UserID = userID;
             var userOrganizationCreated = DataAccessFactory.UserOrganizationTableData().Create(userOrganizationTable); 

            return mapper.Map<UserDTO>(user);

        }

        public static UserDTO CreateEmployee(UserDTO userDTO)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<User, UserDTO>();
                c.CreateMap<UserDTO, User>();
            });

            var mapper = new Mapper(cfg);
            var mappedUser = mapper.Map<User>(userDTO);
            var user = DataAccessFactory.UserData().Create(mappedUser);

            var userID = user.Id;

            var auth = new Authorization();
            auth.Role = "Employee";
            auth.UserID = userID;
            var authCreated = DataAccessFactory.AuthorizationData().Create(auth);

            var jobCat = DataAccessFactory.JobCategoryFIlter().FilterWithTypeSingle(userDTO.JobCategoryType);
            var userJobTable = new UserJobTable();
            userJobTable.UserID = userID;
            userJobTable.JobCategoryID = jobCat.Id;
            var userTableCreated = DataAccessFactory.UserJobTableData().Create(userJobTable);

            var org = DataAccessFactory.OrganizationData().Read(userDTO.OrganizationID);
            var userOrganizationTable = new UserOrganizationTable();
            userOrganizationTable.OrganizationID = org.Id;
            userOrganizationTable.UserID = userID;
            var userOrganizationCreated = DataAccessFactory.UserOrganizationTableData().Create(userOrganizationTable);

            return mapper.Map<UserDTO>(user);
            
        }

        public static List<UserJobCategoryDTO> GetAllUserBasedOnORganization(int id)
        {
            var data = DataAccessFactory.UserOrganizationData().GetAllUserBasedOnOrganization(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<User, UserDTO>();
                c.CreateMap<JobCategories, JobCategoryDTO>();
                c.CreateMap<UserJobTable, UserJobTableDTO>();
                c.CreateMap<User, UserJobCategoryDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<UserJobCategoryDTO>>(data);
            return mapped;
        }

        public static TokenDTO Authenticate(string email, string pass)
        {

            var res = DataAccessFactory.AuthData().Authenticate(email, pass);
            if (res)
            {
                var token = new Token();
                var user = DataAccessFactory.AuthData().GetUser(email);
                token.UserId = user.Id;
                token.CreatedAt = DateTime.Now;
                token.TKey = Guid.NewGuid().ToString();
                var ret = DataAccessFactory.TokenData().Create(token);
                if (ret != null)
                {
                    var cfg = new MapperConfiguration(c => {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    return mapper.Map<TokenDTO>(ret);
                }

            }
            return null;
        }

        public static bool IsTokenValid(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Read(tkey);
            if (extk != null && extk.DeletedAt == null)
            {
                return true;
            }
            return false;
        }
        public static bool Logout(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Read(tkey);
            extk.DeletedAt = DateTime.Now;
            if (DataAccessFactory.TokenData().Update(extk) != null)
            {
                return true;
            }
            return false;


        }


    }
}
