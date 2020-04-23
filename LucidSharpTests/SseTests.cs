using System;
using System.Threading;
using System.Threading.Tasks;
using LucidSharp;
using LucidSharp.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace LucidSharpTests
{
	public class SseTests
	{
		private IDistributedCache _lucidCache;
		private LucidNotifications _lucidNotifications;

		[SetUp]
		public void Setup()
		{
			var serviceProvider = new ServiceCollection()
				.AddLucidCache(options =>
				{
					options.Configuration = "https://lucid-kv.herokuapp.com/";
					options.InstanceName = "LucidPublicNode";
				})
				.BuildServiceProvider();
			_lucidCache = serviceProvider.GetRequiredService<IDistributedCache>();
			_lucidNotifications = serviceProvider.GetRequiredService<LucidNotifications>();
		}

		[Test, Order(1)]
		public async Task GetNotification()
		{
			var isPassed = false;
			_lucidNotifications.EventSource.MessageReceived += (sender, args) =>
			{
				if (args.Event.Equals("lucid-sharp"))
				{
					isPassed = true;
				}
			};
			_lucidCache.SetString("lucid-sharp", "Hello World!");
			await Task.Delay(TimeSpan.FromSeconds(10));
			Assert.IsTrue(isPassed);
		}
	}
}