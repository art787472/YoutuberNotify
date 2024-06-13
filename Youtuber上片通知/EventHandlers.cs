using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youtuber上片通知
{
    internal static class EventHandlers
    {
        public static event EventHandler<Label> messageHandler;

        public static void Notify(Label message) 
        {
            messageHandler.Invoke(null, message);
        
        }
    }
}
