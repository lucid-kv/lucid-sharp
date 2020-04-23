using System;
using LucidSharp.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace LucidSharpTests
{
	public class KvTests
	{
		private IDistributedCache _lucidCache;

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
		}

		[Test, Order(1)]
		public void Set()
		{
			_lucidCache.SetString("lucid-sharp", "Hello World!");
			Assert.Pass();
		}

		[Test, Order(2)]
		public void Get()
		{
			var value = _lucidCache.GetString("lucid-sharp");
			Assert.AreEqual(value, "Hello World!");
		}

		[Test, Order(3)]
		public void Delete()
		{
			_lucidCache.Remove("lucid-sharp");
			Assert.Pass();
		}
	}
}