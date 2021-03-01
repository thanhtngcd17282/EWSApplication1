using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EWSApplication.DataLayers.Common;
using EWSApplication.Entities.DBContext;
namespace EWSApplication.DataLayers
{
    public class PostDAL
    {
        EWSDbContext db = new EWSDbContext();
        /// <summary>
        /// lấy danh sách tất cả bài post để hiển thị trên Home
        /// </summary>
        /// <returns></returns>
        public List<Post> GetAllPost()
        {
            List<Post> lst = new List<Post>();
            lst = db.Posts.ToList();
            return lst;
        }
        /// <summary>
        /// Chi tiết bài post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public Post GetDetailsPost(int postId)
        {
            Post pst = new Post();
            pst = db.Posts.Where(x => x.postid == postId).SingleOrDefault();
            UpdateViewPost(postId);
            return pst;
        }
        /// <summary>
        /// lấy top 5 bài post phổ biến
        /// </summary>
        /// <returns></returns>
        public List<Post> GetTopPopularPost()
        {
            List<Post> lst = new List<Post>();
            lst = db.Posts.OrderByDescending(x => x.like).Take(5).ToList();
            return lst;
        }
        /// <summary>
        /// lấy top 5 bài post nhiều view nhất
        /// </summary>
        /// <returns></returns>
        public List<Post> GetTopViewPost()
        {
            List<Post> lst = new List<Post>();
            lst = db.Posts.OrderByDescending(x => x.view).Take(5).ToList();
            return lst;
        }
        /// <summary>
        /// lấy top bài post lastest
        /// </summary>
        /// <returns></returns>
        public List<Post> GetTopLastPost()
        {
            DateTime date = DateTime.Now;
            // creating object of TimeSpan 
            TimeSpan ts = new TimeSpan(10, 0, 0, 0);

            // getting ShortTime from  
            // subtracting DateTime and TimeSpan 
            // using Subtract() method; 
            DateTime dateFrom = date.Subtract(ts);
            List<Post> lst = new List<Post>();
            lst = db.Posts.Where(t => t.datetimepost > dateFrom && t.datetimepost < DateTime.Now).ToList();
            return lst;
        }

        /// <summary>
        /// Load tất cả comment của bài post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public List<Comment> GetListCommentOfPost(int postId)
        {
            List<Comment> cmt = new List<Comment>();
            cmt = db.Comments.Where(x => x.postid == postId).ToList();
            return cmt;
        }
        /// <summary>
        /// tăng view cho bài post
        /// </summary>
        /// <param name="postId"></param>
        public void UpdateViewPost(int postId)
        {
            var pst = db.Posts.Where(x => x.postid == postId).SingleOrDefault();
            pst.view = pst.view+1;
            db.SaveChanges();
        }
        /// <summary>
        /// Tạo mới bài post
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool CreateNewPost(StructurePost data, string filePath)
        {
            try
            {
                Post pst = new Post()
                {
                    //postid = 0,
                    title = data.title,
                    anonymous = data.anonymous=="on",
                    tag = data.tag,
                    userid = Convert.ToInt32(data.userid),
                    content = data.content,
                    view = 0,
                    like = 0,
                    dislike = 0,
                    datetimepost = DateTime.Now,
                    filePath = filePath
                };             
                db.Posts.Add(pst);
                db.SaveChanges();
                //Email(data.content, "", "");
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool CreateNewComment(StructureComment cmtData)
        {
            try
            {
                Comment cmt = new Comment()
                {
                    anonymous = cmtData.anonymous,
                    Date = DateTime.Now,
                    Content= cmtData.Content,
                    postid = cmtData.postid,
                    userid = cmtData.userid
                };
                db.Comments.Add(cmt);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// gửi email về admin khi có bài post mới vào hệ thống 
        /// </summary>
        /// <param name="htmlString"></param>
        public static void Email(string content , string email , string pass)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("FromMailAddress");
                message.To.Add(new MailAddress("votrannhatbinh1999@gmail.com"));
                message.Subject = "Test";
                message.IsBodyHtml = false; //to make message body as html (true)
                message.Body = content;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("FromMailAddress", "password");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
        }
    }
}
