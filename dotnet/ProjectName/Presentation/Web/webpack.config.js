const path              = require('path');
const webpack           = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const CheckerPlugin     = require('awesome-typescript-loader').CheckerPlugin;
const bundleOutputDir   = './wwwroot/dist';

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);

    console.log(`webpack.config.js - isDevBuild=${isDevBuild}`);

    const extractSass = new ExtractTextPlugin({
        filename: "app.css",
        disable: isDevBuild
    });

    return [{
        stats: { modules: false, errorDetails: true },
        entry: { 'main': './Client/app/app.tsx' },
        resolve: {
            alias: {
                "@core":       path.join(__dirname, "Client", "app", "_core"),
                "@components": path.join(__dirname, "Client", "app", "components"),
                "@pages":      path.join(__dirname, "Client", "app", "pages"),
                "joi":         "joi-browser",
            },
            extensions: ['.js', '.jsx', '.ts', '.tsx'],
        },
        output: {
            path:       path.join(__dirname, bundleOutputDir),
            filename:   '[name].js',
            publicPath: 'dist/'
        },
        module: {
            rules: [
                {
                    test:    /\.tsx?$/,
                    include: /Client/,
                    use:     'awesome-typescript-loader?silent=true'
                },
                {
                    test: /\.(scss|css)$/,
                    use: extractSass.extract({
                        use: [{
                            loader: "css-loader"
                        }, {
                            loader: "sass-loader"
                        }],
                        // use style-loader in development
                        fallback: "style-loader"
                    })
                },
                {
                    test: /\.(png|jpg|jpeg|gif|svg)$/,
                    use: 'url-loader?limit=25000'
                }
            ]
        },
        plugins: [
            new CheckerPlugin(),
            extractSass,
            new webpack.DllReferencePlugin({
                context: __dirname,
                manifest: require('./wwwroot/dist/vendor-manifest.json')
            })
        ].concat(isDevBuild ? [
            // Plugins that apply in development builds only
            new webpack.SourceMapDevToolPlugin({
                filename: '[file].map', // Remove this line if you prefer inline source maps
                moduleFilenameTemplate: path.relative(bundleOutputDir, '[resourcePath]') // Point sourcemap entries to the original file locations on disk
            })
        ] : [
            // Plugins that apply in production builds only
            // new webpack.optimize.UglifyJsPlugin()
        ])
    }];
};
