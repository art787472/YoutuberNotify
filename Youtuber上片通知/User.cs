using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Youtuber上片通知.Models;

namespace Youtuber上片通知
{
    public class User : IObserver
    {
        public string Name { get; set; }
        
     

        public void Update(object content)
        {
            NotifyNewVideo((Video)content);
        }

        public void NotifyNewVideo(Video video)
        {
            ShowPanel.VideoPublishMessage(video, this);
        }
    }
}
