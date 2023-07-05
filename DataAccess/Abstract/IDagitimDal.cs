using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IDagitimDal : IEntityRepository<Dagitim>
    {
        //List<DagitimDetailDto> GetDagitimDetails();
        List<DagitimDetailDto> GetDagitimDetails(Expression<Func<DagitimDetailDto, bool>> filter = null);
        DagitimDetailDto GetDagitimDetail(Expression<Func<DagitimDetailDto, bool>> filter);



    }
}
