using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtuber上片通知.Models;

namespace Youtuber上片通知
{
    public class Youtuber
    {
        private string _name;
        public string Name { get => this._name; }
        public Youtuber(string name) 
        {
            this.Channels = new List<Channel>();
            this._name = name; 
        }
        
        public List<Channel> Channels  { get; set; }



        public void UploadVideo(Video video)
        {
            string channelName = video.Channel.Name;
            Channels.FirstOrDefault(x => x.Name == channelName).UploadVideo(video);
        }
    }
}
