using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        public List<string> InitializeList(IEnumerable<string> items)
        {
            var bag = new ConcurrentBag<string>();
            Parallel.ForEach(items, i =>
            {
                bag.Add(i);
            });
            return bag.ToList();
        }

        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            var itemsToInitialize = Enumerable.Range(0, 100);
            var workQueue = new BlockingCollection<int>();
            var concurrentDictionary = new ConcurrentDictionary<int, string>();

            foreach (var item in itemsToInitialize)
            {
                workQueue.Add(item);
            }
            workQueue.CompleteAdding();

            var consumerTasks = Enumerable.Range(0, 3)
                .Select(_ => Task.Run(() =>
                {
                    foreach (var item in workQueue.GetConsumingEnumerable())
                    {
                        concurrentDictionary.TryAdd(item, getItem(item));
                    }
                })).ToArray();

            Task.WaitAll(consumerTasks);

            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}