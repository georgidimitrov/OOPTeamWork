﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTank.Program.Models.Contracts
{
    public interface IShell : IMovableGameObject
    {
        bool Move();
    }
}
