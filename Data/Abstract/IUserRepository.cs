using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface IUserRepository
    {
        //ienumerable butun Commentlari getirir lakin iqureable filterleyerek, bize lazim olan meselen 5 Commentu getirir
        IQueryable<User> Users{ get; }
        
        void CreateUser(User user);

    }
}