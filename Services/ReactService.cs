namespace IsomorphicReact.Services
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Web;
    using Jint;

    public class ReactService
    {
        private static string reactPath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ReactPath"]);
        private static string reactComponentPath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ReactComponentPath"]);

        private Lazy<Engine> engine = new Lazy<Engine>(() =>
        {
            var react = File.ReadAllText(ReactService.reactPath);
            var components = Directory.GetFiles(ReactService.reactComponentPath, "*.js")
                .Select(File.ReadAllText);
            var engine = new Engine().Execute(react);

            foreach (var component in components)
            {
                engine.Execute(component);
            }

            ////engine.Execute("var console = { warn: function(){} }");

            engine.Execute(
                @"function renderToString(componentName, properties) {
                    var component = React.createFactory(eval(componentName));
                    return React.renderToString(component(properties));
                }");

            return engine;
        });

        public string ExecuteComponent(string componentName, object properties)
        {
            return this.engine.Value
                .Invoke("renderToString", componentName, properties)
                .ToString();
        }
    }
}