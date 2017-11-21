# Docker & .NET Core Example

## Architecture Overview
The project is built leveraging the following technologies:

* Docker
* ASP.NET Core 2.0
* Microsoft SQL Server (Linux)
* React
* Webpack

The .NET web project includes two primary directories, `Client` and `Server`. The `Client` directory includes the React application as well as general assets like SCSS files and static images. The `Server` directory includes the backend code for API Controllers and any MVC View architecture utilizing Razor syntax.

The back-end project is using the [Onion Architecture](http://jeffreypalermo.com/blog/the-onion-architecture-part-1/) approach in .NET. There are `Business`, `Infrastructure` and `Presentation` projects in the solution. All business logic, models and reusable code lives within the `Business` portion of the application. All concrete data access resides in the `Infrastructure` portion of the application. Finally, all presentation projects or projects that contain views for the user reside in the `Presentation` portion of the application.

The rule of onion architecture says that the core of the onion should be created in a way where it knows nothing about the other layers. `Infrastructure` can utilize the `Business`, but `Business` should not utilize `Infrastructure`.

## Noteworthy

* Docker Sync
    * This tool is installed on Mac OSX clients to improve the performance of File IO when mounting a host Mac OSX project in a linux container.
    * Unfortunately the windows support is too complex to be useable (imho).
    * Hopefully this isn't necessary in the future as Microsoft and Docker invest in the development workflow story between the two technologies.

* Environment variables strategy
    * The SDK, Docker and .NET Core all leverage the `.env` file (one configuration to rule them all)
    * .NET Core `appsettings.json` should only contain static settings. As soon as something becomes configurable, bubble it up the `.env` and the respective `.env.{environment}.sample` file.

* Logging
    * .NET Core `Program.cs` demonstrates using SeriLog in .NET Core v2. Allowing for dependency injection of `ILogger<T>` in `Startup.cs`

* Windows Development
    * Unfortunately at this time, the windows development environment is too slow for me to advocate for its use. For windows users, simply set `STARTUP_SERVICES` to `database` so you can leverage that part of the infrastructure while running `./sdk run-web` to build the dotnet and webpack asset files locally.


## Running the Project
**Pre-requisites**

In order to run the project, the following technologies will need to be installed:

* Docker
    * [Mac](  https://download.docker.com/mac/stable/Docker.dmg)
        * Make sure to allocate at least 4 GB of RAM to docker. Otherwise MSSQL won't work.
    * [Windows](https://download.docker.com/win/stable/Docker%20for%20Windows%20Installer.exe)
        * Make sure to allocate at least 4 GB of RAM to docker. Otherwise MSSQL won't work.
        * Configure 'Settings > Shared Drives > C' to be shareable

* SDK Permissions
    * With your bash shell of choice, run `sudo chmod +x sdk` in the root of this repository
    * Follow that up with `./sdk` to verify that it worked. If all is well, you'll see current usage information about the CLI.
    
**Launching**

* Start by cloning the repository using `git clone REPO`
    * From a bash window (terminal or command prompt), change the directory to the newly created repository

* Simplified approach: 100% Docker (best for heavy front-end development)
    * From the bash window, execute the following `./sdk run`
    * After running that script, you may not want to keep installing node modules. For convenience, you can run `./sdk run --fast` which will only use cached docker layers and run the `dotnet run` portion of the previous script.

* Advanced approach: Docker for the database, Local for Web
    * Open the `.env` file and set STARTUP_SERVICES to be `STARTUP_SERVICES=database`
    * From the bash window, start up the database with docker via `./sdk run`
    * Open a second bash window, start up the web spefically with `./sdk run-web`


After the script has finished, you should see the port number which the website will be using. You can open up your favorite browser and navigate to `http://localhost:PORT` OR just run `./sdk open` :).

If everything worked properly, you should be on your way to making changes, as this is hooked up to Webpack for all front-end development changes.

Note: If you want to explore the SDK in more detail, simply run `./sdk` and read the available commands and examples


## SDK Command Reference

Command                                  | Description
-----------------------------------------|-----------------------------------------------
`./sdk`                                  | Displays help describing commands and examples
`./sdk clean`                            | Removes project related images and kills all containers based on those images
`./sdk create-migration [migration-name]` | Create new dotnet entity framework migration.<br>Does not require valid database configuration.
`./sdk create-release [version]`         | Builds a release build image with the supplied version<br>tag and deploys it to the configured docker hub repository  
`./sdk delete-migration`                 | Removes most recent entity framework migration.<br>Requires valid database configuration.
`./sdk dotnet-build`                     | Build the dotnet solution from the root of the project. 
`./sdk dotnet-restore`                   | Restore the dotnet solution from the root of the project
`./sdk info`                             | Shows build details (ie. user, versions)
`./sdk open`                             | Open the application root path in your system default web browser
`./sdk run`                              | Starts the project in debug mode. Performs re-build of docker image,<br>restores npm and nuget packages and starts up docker-compose
`./sdk run --fast`                       | Same as `run`, but skips all dependency<br>and project build steps to get to execution as fast as possible
`./sdk run --no-build`                   | Same as `run`, but skips build of docker images (leverages cache)
`./sdk run --no-restore`                 | Same as `run`, but skips npm and nuget package restores
`./sdk run-release`                      | Builds and starts a release build docker image
`./sdk run-web`                          | Locally runs only the web project (not with docker).<br>Typically used when developer wants to maximize backend development performance and is selectively using docker
`./sdk run-web --no-restore`             | Same as `run-web`, but skips npm and nuget package restores


## Future

* Port sdk from bash to Node leveraging ShellJS
* When Windows and Mac OSX prove legitimate for backend development, re-add nuget items as volumes so local editors don't have missing dependencies
    * docker-compose.debug.yml
        * `volumes:`
            * `- /app/obj`
            * `- /app/bin`
            * `- ~/.nuget:/root/.nuget`
            * `- /root/.nuget/packages/.tools`
* Add support for auto-deploying to various platforms
    * Azure
    * Amazon
    * Heroku
* Example for using HAProxy for load balancing
* Use of docker swarm


## Troubleshooting

* Changes I'm making are not being updated to the browser
    * First off, simply try to restart you current command
        * End the current process: `Ctrl + C`
        * Restart: If using `--fast`, re-run `./sdk run --fast`
    * Secondly, if that doesn't do it, try running the normal `run` via `./sdk run`
    * Finally, if all else fails, perform a full clean and run
        * `./sdk clean`
        * `./sdk run`

* Default ports are already in use in my machine OR I'd simply like to change it...
    * Provided you've run the `./sdk` at least once (in any capacity), you should have a `.env` file in your project (if not, see the ".env is missing")
    * From here, modify either `DATABASE_PORT` and/ or `WEB_PORT`

* .env file is missing!
    * This file is automatically generated in development environments when `./sdk` is run in ANY capacity
        * Under the hood it is simply doing a `cp .env.development.sample .env`
    * Simply run `./sdk`, which outputs the help, and it should be created

* Trying to run `dotnet run` manually
    * Sure, you'll have to manually load the `.env` file OR set them yourself on your system. Otherwise dotnet will likely runtime error due to configuration settings missing.


