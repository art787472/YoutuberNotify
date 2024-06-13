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
    public partial class UserManageForm : Form
    {
        private List<Channel> channels;
        private List<User> users;
        
        public UserManageForm(List<Channel> channels, List<User> users)
        {
            InitializeComponent();
            this.channels = channels;
            this.users = users;
            
            comboBox1.DataSource = channels;
            comboBox1.DisplayMember = "Name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if(users.Any(x => x.Name == name)) 
            {
                MessageBox.Show("使用者名稱已經使用");
                return;
            }
            User user = new User();
            user.Name = name;
            

            users.Add(user);

            string choosedChannelName = ((Channel)comboBox1.SelectedItem).Name;
            Channel choosedChannel = channels.FirstOrDefault(x => x.Name == choosedChannelName);
            choosedChannel += user;


            FlowLayoutPanel userItem = ShowPanel.GenerateUserItemUI(user);
            Button subscribeBtn = userItem.Controls.Find("subscribeBtn", true)[0] as Button;
            subscribeBtn.Click += OnUserSubscribe;

            Button unsubscribeBtn = userItem.Controls.Find("unsubscribeBtn", true)[0] as Button;
            unsubscribeBtn.Click += OnUserUnsubscribe;
            flowLayoutPanel1.Controls.Add(userItem);

            
            
        }

        private void OnUserSubscribe(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            FlowLayoutPanel item = (FlowLayoutPanel)btn.Parent;
            User user = (User)item.Tag;

            string choosedChannelName = ((Channel)comboBox1.SelectedItem).Name;
            Channel choosedChannel = channels.FirstOrDefault(x => x.Name == choosedChannelName);
            choosedChannel -= user;

            Button unsubscribeBtn = item.Controls.Find("unsubscribeBtn", true)[0] as Button;
            unsubscribeBtn.Enabled = true;
            btn.Enabled = false;
        }

        private void OnUserUnsubscribe(object sender, EventArgs e) 
        {
            Button btn = (Button)sender;
            FlowLayoutPanel item = (FlowLayoutPanel)btn.Parent;
            User user = (User)item.Tag;
            string choosedChannelName = ((Channel)comboBox1.SelectedItem).Name;
            Channel choosedChannel = channels.FirstOrDefault(x => x.Name == choosedChannelName);
            choosedChannel -= user;

            Button subscribeBtn = item.Controls.Find("subscribeBtn", true)[0] as Button;
            subscribeBtn.Enabled = true;
            btn.Enabled = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string choosedChannelName = ((Channel)comboBox1.SelectedItem).Name;
            Channel choosedChannel = channels.FirstOrDefault(x => x.Name == choosedChannelName);
            flowLayoutPanel1.Controls.Clear();
            foreach (User user in users)
            {
                FlowLayoutPanel userItem = ShowPanel.GenerateUserItemUI(user);
                Button subscribeBtn = userItem.Controls.Find("subscribeBtn", true)[0] as Button;
                subscribeBtn.Click += OnUserSubscribe;

                Button unsubscribeBtn = userItem.Controls.Find("unsubscribeBtn", true)[0] as Button;
                unsubscribeBtn.Click += OnUserUnsubscribe;

                subscribeBtn.Enabled = choosedChannel.GetSubscribers().Contains(user);
                unsubscribeBtn.Enabled = !choosedChannel.GetSubscribers().Contains(user);

                
                flowLayoutPanel1.Controls.Add(userItem);
            }
        }
    }
}
