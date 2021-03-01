using EWSApplication.Entities.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWSApplication.DataLayers
{
    public class ManagerDAL
    {
        EWSDbContext db = new EWSDbContext();
        #region Tags
        /// <summary>
        /// Tao Tag moi
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public bool CreateNewTag(string tagName)
        {
            try
            {
                var tag = new Tag()
                {
                    tagname = tagName
                };
                db.Tags.Add(tag);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Xoa tag
        /// </summary>
        /// <param name="tagID"></param>
        /// <returns></returns>
        public bool DeleteTag(string tagID)
        {
            try
            {
                var tag = db.Tags.Where(x => x.tagid == tagID).SingleOrDefault();
                db.Tags.Remove(tag);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion
    }
}
