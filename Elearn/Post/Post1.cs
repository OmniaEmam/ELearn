using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Elearn.Models;
namespace Elearn.Post
{
    public class Postone
    {
        ElearnEntities1 db = new ElearnEntities1(); 
        post posts = new post();
        List<comment> comments = new List<comment>();
        public Postone(int idpost)
        {
            posts = db.posts.Find(idpost);
            comments = db.comments.Where(m => m.idpost == idpost).ToList();
        }
        public post GetPost()
        {
            return posts;
        }
        public List<comment> GetComments()
        {
            return comments;
        }
    }
    public class posts
    {
        ElearnEntities1 db = new ElearnEntities1();
        List<Postone> postones = new List<Postone>();
        Postone Postone;
        List<post> postss = new List<post>();
        public posts(int idexam)
        {            
            postss = db.posts.Where(m => m.idexame == idexam).ToList();
            foreach(var item in postss){
                Postone = new Postone(item.id);
                postones.Add(Postone);
            }
        }
        public List<Postone> GetPostones()
        {
            return postones;
        }
    }
}