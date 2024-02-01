using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface ICommentRepository
    {
        //ienumerable butun Commentlari getirir lakin iqureable filterleyerek, bize lazim olan meselen 5 Commentu getirir
        IQueryable<Comment> Comments{ get; }
        
        void CreateComment(Comment comment);

    }
}