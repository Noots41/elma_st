﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IOperationResultRepository : IEntityRepository<OperationResult>
    {
        Operation FindOperByName(string name);
        Users GetDefault();
    }
}
