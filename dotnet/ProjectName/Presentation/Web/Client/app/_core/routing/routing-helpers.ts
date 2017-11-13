import IRoute from "@core/routing/interfaces/route";


/*
-----------------------------------------------------------------------------------------
Constants
-----------------------------------------------------------------------------------------
*/

const RoutingHelpers = {
    replaceUrlParams: (route: IRoute, routeParams?: any, querystringParams?: any) => {
        const failedPlaceholderReplacements: string[] = [];
        let newPath = route.url.replace(/\/:(\w+)\??\/?/g, (placeholder, paramName) => {
            if (routeParams && routeParams[paramName] === undefined) {
                // optional parameters
                if (placeholder.endsWith("?/") || placeholder.endsWith("?")) {
                    return "/";
                }

                failedPlaceholderReplacements.push(placeholder);
                return placeholder;
            }
            else {
                return "/" + routeParams[paramName] + "/";
            }
        });

        if (querystringParams !== undefined) {
            const querystringParamsArray: string[] = [];
            Object.keys(querystringParams).forEach((param) => {
                querystringParamsArray.push(encodeURIComponent(param) + "=" + encodeURIComponent(querystringParams[param]));
            });
            newPath = `${newPath}?${querystringParamsArray.join("&")}`;
        }

        if (failedPlaceholderReplacements.length > 0) {
            // tslint:disable-next-line
            console.log(`DEVELOPER NOTE: The following route parameters have not been replaced: `
                + failedPlaceholderReplacements.join(",") +
                `. The resulting URL is "${newPath}".  The params you have defined are: ` + JSON.stringify(routeParams));
        }

        return newPath;
    },
};


/*
-----------------------------------------------------------------------------------------
Exports
-----------------------------------------------------------------------------------------
*/

export default RoutingHelpers;
