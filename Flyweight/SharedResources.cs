using System;
using System.Collections.Generic;

namespace Flyweight
{
    public sealed class Resource
    {
        public string Key { get; }

        public Resource(string key)
        {
            Key = key;
            Console.WriteLine($"[LOAD] Resource loaded from: {key}");
        }

        public void Use(int x, int y)
        {
            Console.WriteLine($"Resource '{Key}' used at ({x}, {y})");
        }
    }

    public sealed class ResourceFactory
    {
        private readonly Dictionary<string, Resource> _cache = new();

        public Resource Get(string key)
        {
            if (!_cache.TryGetValue(key, out var resource))
            {
                resource = new Resource(key);
                _cache[key] = resource;
            }

            return resource;
        }

        public int Count => _cache.Count;
    }

    public sealed class SceneObject
    {
        private readonly int _x;
        private readonly int _y;
        private readonly Resource _resource;

        public SceneObject(int x, int y, string resourceKey, ResourceFactory factory)
        {
            _x = x;
            _y = y;
            _resource = factory.Get(resourceKey);
        }

        public void Render()
        {
            _resource.Use(_x, _y);
        }
    }
}
