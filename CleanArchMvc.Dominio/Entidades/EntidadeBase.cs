﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Dominio.Entidades
{
    public abstract class EntidadeBase
    {
        public int Id { get; protected set; }
    }
}
