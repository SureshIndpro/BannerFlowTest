using AutoMapper;
using BannerFlow.Entities;
using BannerFlow.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BannerFlow.Services
{
    public class BannerService : IBannerService
    {
        private readonly IBannerRepository bannerRepository;

        public BannerService(IBannerRepository bannerRepository)
        {
            this.bannerRepository = bannerRepository;
        }

        public bool Save(BannerDTO bannerDTO)
        {
            try
            {
                Banner banner = Mapper.Map<BannerDTO, Banner>(bannerDTO);
                banner.Created = DateTime.Now;
                banner.Modified = null;
                banner.Html = System.Web.HttpUtility.HtmlEncode(banner.Html);
                return bannerRepository.Save(banner);
            }
            catch
            {
                //Log the error
                throw;
            }
        }
        public bool Update(BannerDTO bannerDTO)
        {
            try
            {
                Banner banner = Mapper.Map<BannerDTO, Banner>(bannerDTO);
                banner.Modified = DateTime.Now;
                banner.Html = System.Web.HttpUtility.HtmlEncode(banner.Html);
                return bannerRepository.Update(banner);
            }
            catch
            {
                //Log the error.
                throw;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                return bannerRepository.Delete(id);
            }
            catch
            {
                //Log the error.
                throw;
            }
        }

        public BannerDTO GetById(int id)
        {
            try
            {
                Banner banner = bannerRepository.GetById(id);
                if (banner != null)
                {
                    banner.Html = System.Web.HttpUtility.HtmlDecode(banner.Html);
                    return Mapper.Map<Banner, BannerDTO>(banner);
                }
            }
            catch
            {
                //Log the error
                throw;
            }
            return null;
        }

        public List<BannerDTO> GetAll()
        {
            try
            {
                var banners = bannerRepository.GetAll().Select(c => Mapper.Map(c, new BannerDTO())).ToList();
                banners.ForEach(x => x.Html = System.Web.HttpUtility.HtmlDecode(x.Html));
                return banners;
            }
            catch
            {
                //Log the error
                throw;
            }
        }

        public string GetBannerHtmlById(int id)
        {
            try
            {
                var bannerHtml = bannerRepository.GetBannerHtmlById(id);
                return System.Web.HttpUtility.HtmlDecode(bannerHtml);
            }
            catch
            {
                //Log the error
                throw;
            }
        }
    }
}
