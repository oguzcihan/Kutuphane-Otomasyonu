using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyonu2020
{
    public delegate void kitapSecildiHandle();
    public interface IUkitapsec
    {
        event kitapSecildiHandle kitapSecildi;
    }
}
