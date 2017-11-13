import IRoute           from "@core/routing/interfaces/route";
import history          from "./history";
import RoutingHelpers   from "./routing-helpers";


/*
-----------------------------------------------------------------------------------------
Constants
-----------------------------------------------------------------------------------------
*/

const goTo = (route: IRoute, routeParams?: any, querystringParams?: any) => {
    history.push(replaceUrlParams(route, routeParams, querystringParams));
};

const replaceUrlParams = (route: IRoute | string, routeParams?: any, querystringParams?: any): string => {
    if (route instanceof String) {
        return route;
    }

    return RoutingHelpers.replaceUrlParams(route, routeParams, querystringParams);
};


/*
-----------------------------------------------------------------------------------------
Exports
-----------------------------------------------------------------------------------------
*/

export {
    goTo,
    replaceUrlParams,
};
