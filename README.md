# Isomorphic React for ASP.NET

This project uses the [Jint JavaScript Interpreter](https://github.com/sebastienros/jint) to create a single
Isomorphic codebase that runs on the client as well as the server.

# Why?

* React Controlls can be rendered on the server to improve SEO.
* React can be used to render server side templates.
* Common code base for server and client.

# Code

Server side rendering:

```HTML
<blockquote>
    <div id="timer">@Html.Raw(ReactHelper.ExecuteComponent("Timer", Model.Props))</div>
</blockquote>
```

Client side rendering:

```HTML
<script type="text/javascript">
    var props = @Html.Raw(JsonConvert.SerializeObject(Model.Props));
    React.render(
        React.createElement(Timer, props),
        document.getElementById("timer"));
</script>
```

This project is only a proof of concept.
