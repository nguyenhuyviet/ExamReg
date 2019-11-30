﻿using ExamReg.Data.Infrastructure;
using ExamReg.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamReg.Data.Repositories
{
     public interface IPhongThiRepository : IRepository<PhongThi>
    {

    }

    public class PhongThiRepository : RepositoryBase<PhongThi>, IPhongThiRepository
    {
        public PhongThiRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
