﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Configuration;
using System.Collections.ObjectModel;
using System.Web.UI.WebControls;

namespace KMBlog
{
    public partial class admin : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

			if (AppController.IsUserAdmin(User) == false)
				lblUserLevel.Text = "Demonstration Mode - you won't be able to save any changes";
			else
				lblUserLevel.Style.Add("Display", "None");

            GetPostList();
        }

        void GetPostList()
        {
            Collection<Post> posts = Post.GetAllPosts();
            postsRepeater.DataSource = posts;
            postsRepeater.DataBind();

        }

        public void DeletePost(object sender, CommandEventArgs e)
        {

            int postID;
            if (Int32.TryParse(e.CommandArgument.ToString(), out postID) == false)
                return;

            Response.Redirect("post-delete.aspx?p=" + postID.ToString());

        }

        public string GetCommentLinkText(int postID, int commentCount)
        {

            if (commentCount == 0)
               return "No comments";


            // href is edit-comments?p=
            // (TODO: This is the same code as the admin page's GetCommentLinkText
            // - need to refactor when can think of somewhere to put the code - 
            // in the comment class maybe?)
            string href = "\"edit-comments.aspx?p=" + postID.ToString() + "\"";
            string text;

            text = commentCount.ToString() + " comment";
            if (commentCount != 1)
                text += "s";

            String comment = "<a href=" + href + ">" + text + "</a>";

            return comment;

        }




    }
}
