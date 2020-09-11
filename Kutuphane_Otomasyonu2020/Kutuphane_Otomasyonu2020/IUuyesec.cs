using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyonu2020
{
    public delegate void uyeSecildiHandle();
    public interface IUuyesec
    {
        event uyeSecildiHandle uyeSecildi;
    }
}
