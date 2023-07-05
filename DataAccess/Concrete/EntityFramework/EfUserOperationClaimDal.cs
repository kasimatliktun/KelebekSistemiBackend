using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, ButterflyContext>, IUserOperationClaimDal
    {
       
    }
}
