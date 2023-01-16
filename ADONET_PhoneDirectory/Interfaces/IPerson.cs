using ADONET_PhoneDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET_PhoneDirectory.Interfaces
{
    public interface IPerson
    {
        public bool Insert(Person person);
        public void Listed();
        public void Searcing(string search);
        public void Deleted(string inputId);

    }
}
