using Castle.DynamicProxy;
using System.Diagnostics;

namespace CastleDynamicProxyTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            ProxyGenerator generator = new ProxyGenerator();
            MyClass proxiedMyClass = generator.CreateClassProxy<MyClass>(new TimingInterceptor());

            proxiedMyClass.MyEvent += (sender, args) => {
                Debug.WriteLine("Event Handler 1 Called");
                System.Threading.Thread.Sleep(1000); // Simulate some work
            };
            proxiedMyClass.MyEvent += (sender, args) => {
                Debug.WriteLine("Event Handler 2 Called");
                System.Threading.Thread.Sleep(500); // Simulate some work
            };

            proxiedMyClass.RaiseEventPublic();

            Assert.Pass();
        }
    }
}