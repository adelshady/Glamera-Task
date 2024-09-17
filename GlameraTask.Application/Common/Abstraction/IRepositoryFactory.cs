﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlameraTask.Application.Common.Abstraction
{
    public interface IRepositoryFactory
    {
        IBaseRepository<T> GetRepository<T>() where T : class;
    }
}
