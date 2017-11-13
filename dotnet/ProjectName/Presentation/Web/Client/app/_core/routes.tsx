import * as React from "react";
import { Route }  from "react-router-dom";
import IRoute     from "./routing/interfaces/route";
import Routes     from "./routing/routes";


/*
-----------------------------------------------------------------------------------------
Functions
-----------------------------------------------------------------------------------------
*/

function getRoutes(route: any, routes: IRoute[]) {
    Object.keys(route).forEach((key) => {
        if (route[key].hasOwnProperty("url")) {
            routes.push(route[key]);
        } else {
            getRoutes(route[key], routes);
        }
    });
}

const routeArray: IRoute[] = [];
getRoutes(Routes, routeArray);


/*
-----------------------------------------------------------------------------------------
Exports
-----------------------------------------------------------------------------------------
*/

export const routes =
    <div className="o-application">
        {routeArray.map((route, index) => (
            <Route
                exact
                component = { route.component }
                key       = {index}
                path      = {route.url}
            />
        ))}
    </div>;
