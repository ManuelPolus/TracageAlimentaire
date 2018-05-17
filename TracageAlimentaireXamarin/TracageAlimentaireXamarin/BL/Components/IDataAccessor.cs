﻿using System;
using System.Collections.Generic;

namespace TracageAlimentaireXamarin.BL.Components
{
    interface IDataAccessor <T>
    {
        bool Save(Object o);

        IEnumerable<T> GetAsList();

        T GetByIdentifier(object identifier);

        bool DeleteByIdentifier(object identifier);

        void DefineType(object o);
    }
}
