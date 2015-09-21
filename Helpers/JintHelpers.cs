namespace IsomorphicReact.Helpers
{
    using Jint;
    using System;

    public static class JintHelpers
    {
        public static long DateGetTime(DateTime date)
        {
            var time = new Engine()
                .Execute(@"function getTime(date){return date.getTime();}")
                .Invoke("getTime", DateTime.Now)
                .ToObject();

            return Convert.ToInt64(time);
        }

    }
}