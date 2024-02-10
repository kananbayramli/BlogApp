using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface IPostRepository
    {
        //ienumerable butun postlari getirir lakin iqureable filterleyerek, bize lazim olan meselen 5 postu getirir
        IQueryable<Post> Posts{ get; }
        
        void CreatePost(Post post);
        void EditPost(Post post);
        void EditPost(Post post, int[] tagIds);


    }
}