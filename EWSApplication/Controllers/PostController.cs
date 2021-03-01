using EWSApplication.BussinessLayers;
using EWSApplication.DataLayers.Common;
using EWSApplication.Entities.DBContext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EWSApplication.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int postId)
        {
            //xử lí dữ liệu post
            // dữ liệu post gồm:......           
            Post postData = new Post();
            postData= PostBLL.Post_GetDetailsPost(postId);
            ViewBag.ListComt = PostBLL.Post_GetListCommentOfPost(postId);
            return View(postData);
        }

        [HttpPost]
        public ActionResult NewComment(StructureComment cmtData)
        {
            //gồm nội dung comment và id người gửi + id bài post...
            if (cmtData.anonymous != null)
            {
                cmtData.anonymous = true;
            }
            else
            {
                cmtData.anonymous = false;
            }
            PostBLL.Post_CreateNewComment(cmtData);
            return RedirectToAction("Detail","Post");
        }

        [HttpPost]
        public ActionResult Create(StructurePost data , ObjFile doc)
        {
            var filePath = "";
            if(Session["uid"] != null)
            {
                data.userid = Session["uid"].ToString();
            }
            foreach (var file in doc.files)
            {

                if (file != null)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    filePath = Path.Combine(Server.MapPath("~/Files"), fileName);
                    file.SaveAs(filePath);
                }
                else
                {
                    filePath = "";
                }
            }

            PostBLL.Post_CreateNewPost(data, filePath);
            return RedirectToAction("Index","Home");
        }
    }
}