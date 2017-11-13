import * as React                   from "react";
import * as ReactDOM                from "react-dom";
import { AppContainer }             from "react-hot-loader";
import { Router as BrowserRouter }  from "react-router-dom";
import * as RoutesModule            from "./_core/routes";
import history                      from "./_core/routing/history";

import "../assets/scss/app.scss";

let routes = RoutesModule.routes;

function renderApp() {
    // This code starts up the React app when it runs in a browser. It sets up the routing
    // configuration and injects the app into a DOM element.
    // const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href")!;

    ReactDOM.render(
        <AppContainer>
            <BrowserRouter
                children = { routes }
                history  = { history } />
        </AppContainer>,
        document.getElementById("react-app"),
    );
}

renderApp();

// Allow Hot Module Replacement
if (module.hot) {
    module.hot.accept("./_core/routes", () => {
        routes = require<typeof RoutesModule>("./_core/routes").routes;
        renderApp();
    });
}
