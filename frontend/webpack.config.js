require("dotenv").config();

const webpackMerge = require("webpack-merge");

module.exports = (env, argv) => {
    const { mode } = require("./webpack.mode")(env, argv);

    const isProduction = mode === "production";

    if (isProduction) {
        /**
         * Для babel.config.js и мб кто то еще зависит от этой переменной
         */
        process.env.NODE_ENV = "production";
    }

    return getConfigForBuild(env, argv);
};

function getConfigForBuild(env, argv) {
    const entry = require("./webpack.entry")(env);
    const context = require("./webpack.context");
    const mode = require("./webpack.mode")(env, argv);
    const devtool = require("./webpack.devtool")(env, argv);
    const module = require("./webpack.module")(env, argv);
    const plugins = require("./webpack.plugins")(env, argv);
    const optimization = require("./webpack.optimization")(env);
    const output = require("./webpack.output")(env);
    const resolve = require("./webpack.resolve");

    const isDevServer = !!env.DEV_SERVER;

    if (isDevServer) {
        resolve.resolve.alias = {
            ...resolve.resolve.alias,
            "react-dom": "@hot-loader/react-dom"
        };
    }

    const devServer = isDevServer ? require("./webpack.devserver")(env) : undefined;

    return webpackMerge(
        entry,
        context,
        mode,
        resolve,
        devtool,
        optimization,
        plugins,
        output,
        module,
        devServer
    );
}
