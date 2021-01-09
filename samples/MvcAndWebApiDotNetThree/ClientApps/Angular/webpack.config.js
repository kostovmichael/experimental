const path = require("path");
const webpack = require("webpack");
//var webpackMerge = require('webpack-merge');
const UglifyJSPlugin = require("uglifyjs-webpack-plugin");
const clientBundleOutputDir = "../../wwwroot/dev/sampleangular";
const clientBundleOutputDirPROD = "../../wwwroot/prod/sampleangular";
const publicPathDEV = "/dev/";
const publicPathPROD = "/prod/";
//const AotPlugin = require('@ngtools/webpack').AotPlugin;
const ENV = (process.env.NODE_ENV = process.env.ENV); // = "development";

module.exports = (env) => {
    console.log("NODE_ENV: ", env.NODE_ENV);
    const isDevBuild = !(env && env.NODE_ENV === "production");
    console.log("isDevBuild: ", isDevBuild);
    const environment = isDevBuild ? "development" : "production";
    console.log("environment: ", environment);

    const clientBundleConfig = {
        mode: isDevBuild ? "development" : "production",
        entry: {
            ////****Add polyfills and vendor to the build if needed.
            polyfills: "./polyfills.ts",
            vendor: "./vendor.ts",
            myapp: "./SampleAngularApp/app.ts",
        },
        devtool: isDevBuild ? "cheap-module-eval-source-map" : "source-map",
        output: {
            path: path.resolve(
                __dirname,
                isDevBuild ? clientBundleOutputDir : clientBundleOutputDirPROD
            ),
            publicPath: isDevBuild ? publicPathDEV : publicPathPROD,
            filename: "[name].js",
        },
        optimization: {
            runtimeChunk: "single",
            splitChunks: {
                chunks: "all",
                maxInitialRequests: Infinity,
                minSize: 0,
                cacheGroups: {
                    vendor: {
                        test: /[\\/]node_modules[\\/]/,
                        name(module) {
                            // get the name. E.g. node_modules/packageName/not/this/part.js
                            // or node_modules/packageName
                            const packageName = module.context.match(
                                /[\\/]node_modules[\\/](.*?)([\\/]|$)/
                            )[1];

                            // npm package names are URL-safe, but some servers don't like @ symbols
                            //return `npm.${packageName.replace('@', '')}`;
                            //return packageName;
                            return `${packageName.replace("@", "")}`;
                        },
                    },
                },
            },
        },
        module: {
            rules: [
                {
                    test: /\.ts$/,
                    exclude: /node_modules|vue\/src/,
                    loaders: [
                        "awesome-typescript-loader",
                        "angular-router-loader",
                        "angular2-template-loader",
                    ],
                    //isDevBuild ? [{ loader: "awesome-typescript-loader" }, "angular2-template-loader"] : "ts-loader"
                },
            ],
        },
        resolve: {
            extensions: [".ts", ".js"],
            modules: ["src", "node_modules"],
        },

        plugins: [
            new webpack.DefinePlugin({
                "process.env": {
                    "ENV": JSON.stringify(environment),
                },
            }),
        ].concat(
            isDevBuild
                ? [
                      new webpack.ContextReplacementPlugin(
                          // The (\\|\/) piece accounts for path separators in *nix and Windows
                          /angular(\\|\/)core(\\|\/)@angular/,
                          //helpers.root('./src'), // location of your src
                          {} // a map of your routes
                      ),
                  ]
                : [
                      //new webpack.NoEmitOnErrorsPlugin(),
                      new UglifyJSPlugin({
                          cache: true,
                          parallel: true,
                          uglifyOptions: {
                              compress: {
                                  warnings: false,
                                  unused: true,
                              },
                              keep_classnames: true,
                              keep_fnames: true,
                              ie8: false,
                          },
                      }),

                      new webpack.LoaderOptionsPlugin({
                          htmlLoader: {
                              minimize: false, // workaround for ng2
                          },
                      }),
                  ]
        ),
    };

    return [clientBundleConfig];
};
