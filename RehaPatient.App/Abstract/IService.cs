﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatient.App.Abstract
{
    public interface IService<T>
    {
        List<T> Patients { get; set; }

        List<T> GetAllPatients();
        int AddPatient (T patient);
        int UpdatePatient (T patient);
        void RemovePatient (T patient);

    }
}
