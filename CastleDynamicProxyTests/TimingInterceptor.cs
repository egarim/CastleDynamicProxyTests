using Castle.DynamicProxy;
using System;
using System.Diagnostics;

public class TimingInterceptor : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        //Stopwatch stopwatch = Stopwatch.StartNew();
        //invocation.Proceed();  // Proceed with the original method
        //stopwatch.Stop();
        //Debug.WriteLine($"Execution Time for {invocation.Method.Name}: {stopwatch.ElapsedMilliseconds} ms");


        // Check if the current method is the one we want to time
        if (invocation.Method.Name == "RaiseEvent")
        {
            Stopwatch stopwatch = Stopwatch.StartNew(); // Start timing

            invocation.Proceed(); // Execute the original method

            stopwatch.Stop(); // Stop timing
            Debug.WriteLine($"Execution Time for {invocation.Method.Name}: {stopwatch.ElapsedMilliseconds} ms");
        }
        else
        {
            invocation.Proceed(); // Just proceed without timing for other methods
        }
    }
}