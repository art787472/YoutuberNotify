using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Youtuber上片通知.Models;
using Label = System.Windows.Forms.Label;

namespace Youtuber上片通知
{
    internal static class ShowPanel
    {
        public static FlowLayoutPanel GenerateUsersUI(List<User> users)
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            foreach(User user in users)
            {
                Label label = new Label();
                label.Text = $"{user.Name}訂閱了頻道";
                panel.Controls.Add(label);
            }
            return panel;
        }

        public static void SubscribeMessage(User subscriber, Channel channel)
        {
            Label label = new Label();
            label.Width = 500;
            label.Text = $"{subscriber.Name}訂閱{channel.Name}";
            EventHandlers.Notify(label);
        }

        public static void UnsubscribeMessage(User subscriber, Channel channel)
        {
            Label label = new Label();
            label.Width = 500;
            label.Text = $"{subscriber.Name}取消訂閱{channel.Name}";
            EventHandlers.Notify(label);
        }

        public static void VideoPublishMessage(Video video, User user)
        {
            Label label = new Label();
            label.Width = 500;
            label.Text = $"{user.Name}收到{video.Channel.Name}發布的新影片{video.Name}";
            EventHandlers.Notify(label);
        }

        public static FlowLayoutPanel GenerateUserItemUI(User user)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Width = 500;
            flowLayoutPanel.Height = 20;
            Label label = new Label();
            label.Text = $"{user.Name}訂閱";
            flowLayoutPanel.Controls.Add(label);

            Button  subscribeBtn = new Button();
            subscribeBtn.Width = 100;
            subscribeBtn.Name = "subscribeBtn";
            subscribeBtn.Text = "訂閱";
            subscribeBtn.Enabled = false;
            Button unsubscribeBtn = new Button();
            unsubscribeBtn.Width = 100;
            unsubscribeBtn.Name = "unsubscribeBtn";
            unsubscribeBtn.Text = "取消訂閱";

            flowLayoutPanel.Controls.Add(subscribeBtn);
            flowLayoutPanel.Controls.Add(unsubscribeBtn);

            flowLayoutPanel.Tag = user;

            return flowLayoutPanel;
        }
        
    }
}
