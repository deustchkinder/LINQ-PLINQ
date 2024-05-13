using App.Databases;
using App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository;

public class UserxRepo(MyDbContext db)
{
    
    public IEnumerable<Userx> GetAll()
    {
        return db.Users;
    }

    public IQueryable<Userx> GetAllQ()
    {
        return db.Users;
    }
}
