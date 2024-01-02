using AutoMapper;
using AutoMapper.Configuration.Conventions;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class JobService
    {
        public static JobRequirmentsDTO CreateJobRequirmentsPost(JobRequirmentsDTO jobRequirmentsDTO)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<JobRequirments, JobRequirmentsDTO>();
                c.CreateMap<JobRequirmentsDTO, JobRequirments>();
            });

            var mapper = new Mapper(cfg);
            var mappedPost = mapper.Map<JobRequirments>(jobRequirmentsDTO);
            var post = DataAccessFactory.JobRequirmentsData().Create(mappedPost);
            return mapper.Map<JobRequirmentsDTO>(post);
        }

        public static JobRequirmentsDTO ViewJobRequirmentsPost(int id)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<JobRequirments, JobRequirmentsDTO>();
               c.CreateMap<JobRequirmentsDTO, JobRequirments>();
            });

            var post = DataAccessFactory.JobRequirmentsData().Read(id);
            var mapper = new Mapper(cfg);
            var mappedPost = mapper.Map<JobRequirmentsDTO>(post);
            return mappedPost;
        }

        public static bool DeleteJobRequirmentsPost(int id)
        {
            var res = DataAccessFactory.JobRequirmentsData().Delete(id);
            return res;
        }

        public static JobRequirmentsDTO UpdateJobRequirmentsPost(JobRequirmentsDTO jobRequirmentsDTO)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<JobRequirments, JobRequirmentsDTO>();
                c.CreateMap<JobRequirmentsDTO, JobRequirments>();
            });

            var mapper = new Mapper(cfg);
            var mappedPost = mapper.Map<JobRequirments>(jobRequirmentsDTO);
            var post = DataAccessFactory.JobRequirmentsData().Update(mappedPost);
            return mapper.Map<JobRequirmentsDTO>(post);
        }

        public static List<JobRequirmentsDTO> AllJobRequirmentsPost()
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<JobRequirments, JobRequirmentsDTO>();
                c.CreateMap<JobRequirmentsDTO, JobRequirments>();
            });

            var mapper = new Mapper(cfg);
            var post = DataAccessFactory.JobRequirmentsData().Read();
            return mapper.Map<List<JobRequirmentsDTO>>(post);
        }

        public static List<JobRequirmentsDTO> AllJobRequirmentsPostByOrg(int id)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<JobRequirments, JobRequirmentsDTO>();
                c.CreateMap<JobRequirmentsDTO, JobRequirments>();
            });

            var mapper = new Mapper(cfg);
            var post = DataAccessFactory.JobRequirmentsFilter().FilterWithType(id);
            return mapper.Map<List<JobRequirmentsDTO>>(post);
        }

        public static JobApplicationDTO CreateJobApplication(JobApplicationDTO jobApplicationDTO)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<JobApplications, JobApplicationDTO>();
                c.CreateMap<JobApplicationDTO, JobApplications>();
            });
            jobApplicationDTO.Status = "Submitted";
            var mapper = new Mapper(cfg);
            var mappedPost = mapper.Map<JobApplications>(jobApplicationDTO);
            var post = DataAccessFactory.JobApplicationData().Create(mappedPost);
            return mapper.Map<JobApplicationDTO>(post);
        }

        public static JobApplicationDTO ViewJobApplication(int id)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<JobApplications, JobApplicationDTO>();
                c.CreateMap<JobApplicationDTO, JobApplications>();
            });

            var mapper = new Mapper(cfg);

            var post = DataAccessFactory.JobApplicationData().Read(id);
            return mapper.Map<JobApplicationDTO>(post);
        }

        public static JobApplicationDTO MakeShortLishted(int id)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<JobApplications, JobApplicationDTO>();
                c.CreateMap<JobApplicationDTO, JobApplications>();
            });
            var mapper = new Mapper(cfg);

            var post = DataAccessFactory.JobApplicationData().Read(id);
            post.Status = "ShortLishted";
            var updated = DataAccessFactory.JobApplicationData().Update(post);
            return mapper.Map<JobApplicationDTO>(updated);
        }

        public static JobApplicationDTO MakeSelected(int id)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<JobApplications, JobApplicationDTO>();
                c.CreateMap<JobApplicationDTO, JobApplications>();
            });
            var mapper = new Mapper(cfg);

            var post = DataAccessFactory.JobApplicationData().Read(id);
            post.Status = "Selected";
            var updated = DataAccessFactory.JobApplicationData().Update(post);
            return mapper.Map<JobApplicationDTO>(updated);
        }

        public static List<JobApplicationDTO> AllShortLishted()
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<JobApplications, JobApplicationDTO>();
                c.CreateMap<JobApplicationDTO, JobApplications>();
            });
            var mapper = new Mapper(cfg);
            var data = DataAccessFactory.JobApplicationFilter().FilterWithType("ShortLishted");
            return mapper.Map<List<JobApplicationDTO>>(data);
        }

        public static List<JobApplicationDTO> AllSelected()
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<JobApplications, JobApplicationDTO>();
                c.CreateMap<JobApplicationDTO, JobApplications>();
            });
            var mapper = new Mapper(cfg);
            var data = DataAccessFactory.JobApplicationFilter().FilterWithType("Selected");
            return mapper.Map<List<JobApplicationDTO>>(data);
        }


    }
}
