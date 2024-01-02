using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class NoticeService
    {
        public static NoticeDTO CreateNotice(NoticeDTO noticeDTO)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Notice, NoticeDTO>();
                c.CreateMap<NoticeDTO, Notice>();
            });
            noticeDTO.Status = "Unseen";
            var mapper = new Mapper(cfg);
            var mappedNotice = mapper.Map<Notice>(noticeDTO);
            var notice = DataAccessFactory.NoticeData().Create(mappedNotice);
            return mapper.Map<NoticeDTO>(notice);
        }

        public static NoticeDTO ViewNotice(int id)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Notice, NoticeDTO>();
                c.CreateMap<NoticeDTO, Notice>();
            });
            
            var mapper = new Mapper(cfg);
            var notice = DataAccessFactory.NoticeData().Read(id);
            notice.Status = "Seen";
            var updatedNotice = DataAccessFactory.NoticeData().Update(notice);

            return mapper.Map<NoticeDTO>(updatedNotice);
        }

        public static List<NoticeDTO> ViewAllNotice(int id)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Notice, NoticeDTO>();
                c.CreateMap<NoticeDTO, Notice>();
            });

            var mapper = new Mapper(cfg);
            var notice = DataAccessFactory.NoticeFilter().ViewAll(id);

            return mapper.Map<List<NoticeDTO>>(notice);
        }

        public static List<NoticeDTO> TrackAllNotice(int id)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Notice, NoticeDTO>();
                c.CreateMap<NoticeDTO, Notice>();
            });

            var mapper = new Mapper(cfg);
            var notice = DataAccessFactory.NoticeFilter().TrackAll(id);

            return mapper.Map<List<NoticeDTO>>(notice);
        }
    }
}
