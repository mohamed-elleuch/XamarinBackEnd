﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppTestMvvm.Models
{
    public interface IDependencyService
    {
        T Get<T>() where T : class;
    }
}
