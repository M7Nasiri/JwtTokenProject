using Domain.PostAgg;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.UserAgg.Repository;
public interface IUserRepository
{
    Task<List<User>> GetAll();
    Task<User> GetById(long id);
    Task<User> GetTracking(long id);
    long Create(User dto);
    Task Delete(long id);
    void Update(long id, User dto);
    bool Exists(Expression<Func<User, bool>> expression);
    Task<int> Save();
}