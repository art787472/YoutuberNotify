using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtuber上片通知
{
    public interface ISubject
    {
        void RegisterObserver(IObserver pObserver);
        void RemoveObserver(IObserver pObserver);
        void notifyObservers(object pContent);
    }
}
