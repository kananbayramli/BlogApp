using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface ITagRepository
    {
        //ienumerable butun Taglari getirir lakin iqureable filterleyerek, bize lazim olan meselen 5 Tagu getirir
        IQueryable<Tag> Tags{ get; }
        
        void CreateTag(Tag tag);

    }
}