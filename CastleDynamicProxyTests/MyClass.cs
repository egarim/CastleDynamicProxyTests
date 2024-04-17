using Castle.DynamicProxy;
using System;
using System.Diagnostics;
public class MyClass
{
    public event EventHandler MyEvent;

    protected virtual void RaiseEvent()  // Must be virtual to be intercepted
    {
        MyEvent?.Invoke(this, EventArgs.Empty);
    }
    public void RaiseEventPublic()
    {
        RaiseEvent();
    }
}
