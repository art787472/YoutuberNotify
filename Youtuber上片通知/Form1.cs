using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youtuber上片通知
{
    public partial class Form1 : Form
    {
        private Youtuber youtuber;
        private List<User> users = new List<User>();
        private List<Channel> channels = new List<Channel>();
        public Form1()
        {
            InitializeComponent();
            string youtuberName = "吃吃大王";
            youtuber = new Youtuber(youtuberName);
            
            string channelName = "吃播頻道";
            Channel channel1 = new Channel(channelName, youtuber);
            Channel channel2 = new Channel("旅遊頻道", youtuber);
            youtuber.Channels.Add(channel1);
            youtuber.Channels.Add(channel2);

            channels.Add(channel1);
            channels.Add(channel2);

            EventHandlers.messageHandler += MessageHandler;
        }

        private void MessageHandler(object sender, Label message)
        {
            flowLayoutPanel1.Controls.Add(message);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserManageForm userManageForm = new UserManageForm(channels, users);
            
            userManageForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YoutuberForm youtuberForm = new YoutuberForm(youtuber);
            
            youtuberForm.Show();
        }
    }
}
