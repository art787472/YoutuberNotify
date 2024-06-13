using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Youtuber上片通知.Models;

namespace Youtuber上片通知
{
    public class Channel : ISubject
    {
        public string Name { get => this._name; }
        public Youtuber Owner { get => _owner;  }

        private string _name;
        private Youtuber _owner;
        
        public Channel(string name, Youtuber owner)
        {
            this._name = name;
            this._owner = owner;
        }

        private List<IObserver> observers = new List<IObserver> ();

        public List<User> GetSubscribers()
        {
            return observers.Select(x => x as User).ToList();
        }
        
        public void RegisterObserver(IObserver pObserver)
        {
            this.observers.Add(pObserver);
        }

        public void RemoveObserver(IObserver pObserver)
        {
            this.observers.Remove(pObserver);
        }

        public void notifyObservers(object pContent)
        {
            foreach (IObserver pObserver in observers)
            {
                pObserver.Update(pContent);
            }
        }

        public void UploadVideo(Video video)
        {

            notifyObservers(video);
        }

        public void UserSubscribe(IObserver pObserver)
        {
            RegisterObserver(pObserver);

            User subscriber = (User)pObserver;

            ShowPanel.SubscribeMessage(subscriber, this);
        }

        public void UserUnsubscribe(IObserver pObserver)
        {
            RemoveObserver(pObserver);

            User subscriber = (User)pObserver;
            ShowPanel.UnsubscribeMessage(subscriber, this);
        }


        public static Channel operator + (Channel channel,IObserver observer)
        {
            channel.UserSubscribe(observer);
            return channel;
        }

        public static Channel operator -(Channel channel, IObserver observer)
        {
            channel.UserUnsubscribe(observer);
            return channel;
        }
    }
}
