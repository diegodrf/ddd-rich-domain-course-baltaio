﻿using PaymentContext.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Repositories
{
    public interface ISudentRepository
    {
        void Create(Student student);
    }
}
