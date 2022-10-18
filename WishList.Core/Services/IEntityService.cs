namespace WishList.Core.Services;

public interface IEntityService<TEntity>
{
    ServiceResponse Create(TEntity entity);
    ServiceResponse Delete(int id);
    ServiceResponse Update(TEntity entity);
    List<TEntity> GetAll();
    TEntity GetById(int id);
}