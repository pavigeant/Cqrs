namespace Cqrs
{
    using System;

    public static class Events
    {
        public static void On<TEvent>(Action<TEvent> action)
        {
        }
    }
}