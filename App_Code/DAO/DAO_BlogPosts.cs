using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_BlogPosts
/// </summary>
public class DAO_BlogPosts
{
    private DataAccess dataAccess;

	public DAO_BlogPosts()
	{
        dataAccess = new DataAccess();
	}

    public DataTable GetBlogPostByID(tblBlogPost blogPost)
    {
        String query = String.Format(@"SELECT postOwnerID, postDate, postInfo, postStatus
                        FROM     tblBlogPosts
                        WHERE  (postID = '{0}')", blogPost.postOwnerID);
        return dataAccess.ExecuteQuery(query);
    }
    public DataTable GetBlogPostByUserID(string postOwnerID)
    {
        String query = String.Format(@"SELECT postID, postDate, postInfo, postStatus
                        FROM     tblBlogPosts
                        WHERE  (postOwnerID = '{0}') and (postStatus = {1})
                        ORDER BY postDate DESC", postOwnerID, 1);
        return dataAccess.ExecuteQuery(query);
    }

    public bool InsertBlogPost(tblBlogPosts blogPosts)
    {
        String query = String.Format(@"INSERT INTO tblBlogPosts
                  (postOwnerID, postDate, postInfo, postStatus)
                VALUES ('{0}', '{1}', '{2}', '{3}')", blogPosts.PostOwnerID,
                                     blogPosts.PostDate, blogPosts.PostInfo, blogPosts.PostStatus);
        if (dataAccess.ExecuteNonQuery(query))
            return true;
        return false;
    }

    public bool UpdateBlogPostStatus(tblBlogPosts blogPosts)
    {
        String query = String.Format(@"UPDATE tblBlogPosts
                                        SET          postStatus =0
                                        WHERE  (postID = '{0}')",
                                      blogPosts.PostID);
        if (dataAccess.ExecuteNonQuery(query))
            return true;
        return false;
    }

    public bool UpdateBlogPostInfo(tblBlogPosts blogPosts)
    {
        String query = string.Format(@"UPDATE tblBlogPosts
                                            SET          postInfo ='{0}'
                                            WHERE  (postID = '{1}')",
                                     blogPosts.PostInfo, blogPosts.PostID);
        if (dataAccess.ExecuteNonQuery(query))
            return true;
        return false;
    }
}