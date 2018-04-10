using BannerFlow.Entities;
using BannerFlow.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BannerFlow.Controllers
{
    public class BannerApiController : ApiController
    {
        private readonly IBannerService bannerService;

        public BannerApiController(IBannerService bannerService)
        {
            this.bannerService = bannerService;
        }

        [HttpPost]
        public IHttpActionResult Save(BannerDTO bannerDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (bannerDTO == null)
                        throw new ArgumentNullException("Banner is empty");

                    if (string.IsNullOrEmpty(bannerDTO.Html))
                        throw new ArgumentNullException("Html is empty");

                    return Ok(bannerService.Save(bannerDTO));
                }
                else
                    return BadRequest("Model is not valid");
            }
            catch (Exception ex)
            {
                //Log the error
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult Update(BannerDTO bannerDTO)
        {
            try
            {
                if (bannerDTO == null)
                    throw new ArgumentNullException("Banner is empty");

                if (string.IsNullOrEmpty(bannerDTO.Html))
                    throw new ArgumentNullException("Html is empty");

                return Ok(bannerService.Update(bannerDTO));
            }
            catch (Exception ex)
            {
                //Log the error
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                    throw new ArgumentNullException("Banner Id is empty");

                return Ok(bannerService.Delete(id));
            }
            catch (Exception ex)
            {
                //Log the error
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult GetById(int id)
        {
            try
            {
                if (id == 0)
                    throw new ArgumentNullException("Banner Id is empty");

                return Ok(bannerService.GetById(id));
            }
            catch (Exception ex)
            {
                //Log the error
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(bannerService.GetAll());
            }
            catch (Exception ex)
            {
                //Log the error
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult GetBannerHtmlById(int id)
        {
            try
            {
                if (id == 0)
                    throw new ArgumentNullException("Banner Id is empty");

                return Ok(bannerService.GetBannerHtmlById(id));
            }
            catch (Exception ex)
            {
                //Log the error
                return InternalServerError(ex);
            }
        }
    }
}
