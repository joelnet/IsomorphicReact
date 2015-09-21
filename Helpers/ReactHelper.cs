namespace IsomorphicReact.Helpers
{
    using IsomorphicReact.Services;

    public static class ReactHelper
    {
        private static ReactService reactService = new ReactService();

        public static string ExecuteComponent(string componentName, object properties)
        {
            return ReactHelper.reactService.ExecuteComponent(componentName, properties);
        }
    }
}