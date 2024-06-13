using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Youtuber上片通知.Models;

namespace Youtuber上片通知
{
    public partial class YoutuberForm : Form
    {
        private Youtuber youtuber;
        
        private List<Channel> channels;
        
        public YoutuberForm(Youtuber youtuber)
        {
            InitializeComponent();
            this.youtuber = youtuber;
            this.channels = youtuber.Channels;

            comboBox1.DataSource = channels;
            comboBox1.DisplayMember = "Name";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string videoName = textBox1.Text;
            string description = textBox2.Text;

            string choosedChannelName = ((Channel)comboBox1.SelectedItem).Name;
            Channel choosedChannel = channels.FirstOrDefault(x => x.Name == choosedChannelName);
            Video video = new Video(choosedChannel, videoName, description);
            youtuber.UploadVideo(video);
            
        }
    }
}
