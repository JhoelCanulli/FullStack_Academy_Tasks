using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_eventi.DAL
{
    internal interface IDAL
    {
        void create();
        void read();
        void update();
        void delete();
    }
}
