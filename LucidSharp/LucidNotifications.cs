using System;
using System.Threading.Tasks;
using EvtSource;
using LucidSharp.Helpers;

namespace LucidSharp
{
	public class LucidNotifications
	{
		public EventSourceReader EventSource { get; set; }

		public LucidNotifications(LucidHelper helper)
		{
			EventSource = new EventSourceReader(new Uri(helper.BuildNotificationsUri())).Start();
			EventSource.Disconnected += async (object sender, DisconnectEventArgs e) => {
				await Task.Delay(e.ReconnectDelay);
				EventSource.Start();
			};
		}

		private void EventSourceOnMessageReceived(object sender, EventSourceMessageEventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}