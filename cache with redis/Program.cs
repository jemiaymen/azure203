using System;
using StackExchange.Redis;
using System.Text;
using System.Threading.Tasks;

namespace cache_with_redis
{
    class Program
    {
        public static string connectionString = "buyer.redis.cache.windows.net:6380,password=XANhuVNAXRNcTGLu4Xdhn9hy8GOBBh8iAYUlnviN8oo=,ssl=True,abortConnect=False";
        
        
        static void Main(string[] args)
        {
            IDatabase cache = lazyConn.Value.GetDatabase();

            Console.WriteLine("Read Cache : "  + cache.StringGet("session").ToString() );

            cache.StringSet("session","Hello am jemix " + DateTime.Now.ToString());

            Console.WriteLine("Read Cache Other time :"  + cache.StringGet("session").ToString());

            cache.KeyExpire("session",DateTime.Now.AddSeconds(10));


            Console.WriteLine("wait 10s and press enter");

            Console.ReadLine();

            Console.WriteLine("Read Cache last time",cache.StringGet("session"));

            lazyConn.Value.Dispose();

        }

        private static Lazy<ConnectionMultiplexer> lazyConn = new Lazy<ConnectionMultiplexer>(() => {
            return ConnectionMultiplexer.Connect(connectionString);
        });

    }
}
