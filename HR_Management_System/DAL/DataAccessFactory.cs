using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<User, int, User> UserData()
        {
            return new UserRepo();
        }

        public static IFilter<User, String> UserFilter()
        {
            return new UserRepo();
        }

        public static IRepo<Authorization, int, Authorization> AuthorizationData()
        {
            return new AuthorizationRepo();
        }

        public static IRepo<Organization, int, Organization> OrganizationData()
        {
            return new OrganizationRepo();
        }

        public static IRepo<JobCategories, int, JobCategories> JobCategoryData()
        {
            return new JobCategoryRepo();
        }

        public static IFilter<JobCategories, string> JobCategoryFIlter()
        {
            return new JobCategoryRepo();
        }

        public static IRepo<UserJobTable, int, UserJobTable> UserJobTableData()
        {
            return new UserJobTableRepo();
        }

        public static IRepo<UserOrganizationTable, int, UserOrganizationTable> UserOrganizationTableData()
        {
            return new UserOrganizationTableRepo();
        }

        public static IUserOrganization<User, int> UserOrganizationData()
        {
            return new UserRepo();
        }

        public static IRepo<JobApplications, int, JobApplications> JobApplicationData()
        {
            return new JobApplicationRepo();
        }

        public static IRepo<JobRequirments, int, JobRequirments> JobRequirmentsData()
        {
            return new JobRequirmentsRepo();
        }

        public static IFilter<JobRequirments, int> JobRequirmentsFilter()
        {
            return new JobRequirmentsRepo();
        }

        public static IFilter<JobApplications, string> JobApplicationFilter()
        {
            return new JobApplicationRepo();
        }

        public static IRepo<Notice, int, Notice> NoticeData()
        {
            return new NoticeRepo();
        }

        public static INoticeFilter<Notice, int> NoticeFilter()
        {
            return new NoticeRepo();
        }

        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }

        public static IAuth<bool> AuthData()
        {
            return new UserRepo();
        }

    }
}
