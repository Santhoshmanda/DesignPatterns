using System;
namespace Design_Patterns.Structural.Proxy
{
	

    /* Access Restriciton
	 *Caching
	 *Request pre processing
	 *and Response Post Processing
	 
	 */

    interface IDataService
    {
        string GetData(int id);
    }

    class DataService : IDataService
    {
        public string GetData(int id)
        {
            // Simulate retrieving data from a database
            return $"Data for ID {id}";
        }
    }

    class DataServiceCachingProxy : IDataService
    {
        private readonly IDataService _dataService;
        private readonly Dictionary<int, string> _cache = new Dictionary<int, string>();

        public DataServiceCachingProxy(IDataService dataService)
        {
            _dataService = dataService;
        }

        public string GetData(int id)
        {
            if (_cache.ContainsKey(id))
            {
                Console.WriteLine("Data retrieved from cache.");
                return _cache[id];
            }

            string data = _dataService.GetData(id);
            _cache[id] = data;
            Console.WriteLine("Data retrieved from real service.");
            return data;
        }
    }

    class ProgramTest546
    {
        static void Main(string[] args)
        {
            IDataService dataService = new DataServiceCachingProxy(new DataService());
            string data1 = dataService.GetData(1); // Data retrieved from real service.
            string data2 = dataService.GetData(1); // Data retrieved from cache.
            string data3 = dataService.GetData(2); // Data retrieved from real service.
        }
    }

}

