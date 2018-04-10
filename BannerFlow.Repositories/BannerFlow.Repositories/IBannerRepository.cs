using BannerFlow.Entities;
using System.Collections.Generic;

namespace BannerFlow.Repositories
{
    public interface IBannerRepository
    {
        /// <summary>
        /// Creates a new banner
        /// </summary>
        /// <param name="banner">Banner to save</param>
        /// <returns>True if successful</returns>
        bool Save(Banner banner);
        /// <summary>
        /// Updates an existing banner
        /// </summary>
        /// <param name="banner">Banner to update</param>
        /// <returns>True if succesful</returns>
        bool Update(Banner banner);
        /// <summary>
        /// Deletes an existing banner; If not exists throws Null exception
        /// </summary>
        /// <param name="id">Id of the banner to delete</param>
        /// <returns>True if successful</returns>
        bool Delete(int id);
        /// <summary>
        /// Returns the Banner for the given Id
        /// </summary>
        /// <param name="id">Id of the banner to return</param>
        /// <returns>Banner object if available otherwise null</returns>
        Banner GetById(int id);
        /// <summary>
        /// Gets all banner
        /// </summary>
        /// <returns></returns>
        List<Banner> GetAll();
        /// <summary>
        /// Returns Banner Html for the given banner id
        /// </summary>
        /// <param name="id">Banner Id</param>
        /// <returns>Returns Html string if available</returns>
        string GetBannerHtmlById(int id);
    }
}
