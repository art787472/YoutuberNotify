using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtuber上片通知.Models
{
    public class Video
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Channel Channel { get; set; }

        public Video(Channel channel, string name, string description) 
        {
            this.Channel = channel;
            this.Name = name;
            this.Description = description;
        }
    }
}
