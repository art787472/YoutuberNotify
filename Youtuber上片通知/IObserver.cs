using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtuber上片通知
{
    public interface IObserver
    {
        void Update(object content);
    }
}
