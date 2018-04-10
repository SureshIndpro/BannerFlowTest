using BannerFlow.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BannerFlow.Repositories
{
    public class BannerRepository : IBannerRepository
    {
        private static List<Banner> banners = new List<Banner>();
        private static Object thisLock = new Object();

        public bool Save(Banner banner)
        {
            banner.Id = banners.Count > 0 ? banners.Max(x => x.Id) + 1 : 1;
            lock (thisLock)
            {
                banners.Add(banner);
            }
            return true;
        }
        public bool Update(Banner banner)
        {
            Banner existingBanner = banners.SingleOrDefault(x => x.Id == banner.Id);
            if (existingBanner == null)
                throw new ArgumentNullException("The banner not available");

            lock (thisLock)
            {
                existingBanner.Html = banner.Html;
                existingBanner.Modified = banner.Modified;
                existingBanner.Created = banner.Created;
            }
            return true;
        }
        public bool Delete(int id)
        {
            Banner existingBanner = banners.SingleOrDefault(x => x.Id == id);
            if (existingBanner == null)
                throw new ArgumentNullException("The banner not available");
            else
            {
                lock (thisLock)
                {
                    banners.Remove(existingBanner);
                }
                return true;
            }
        }
        
        public Banner GetById(int id)
        {
            //TODO: Need to clone this to avoid possible manipulation of data directly in the object.
            return banners.SingleOrDefault(x => x.Id == id);
        }

        public List<Banner> GetAll()
        {
            //TODO: Need to clone this to avoid possible manipulation of data directly in the list.
            return banners;
        }

        public string GetBannerHtmlById(int id)
        {
            var banner = banners.SingleOrDefault(x => x.Id == id);
            if (banner == null)
                return string.Empty;
            else
                return banner.Html;
        }
    }
}
