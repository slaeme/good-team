const path = require("path");

module.exports = (env, argv) => {
    const { mode } = require("./webpack.mode")(env, argv);
    const isProduction = mode === "production";

    const isDevServer = env.DEV_SERVER || false;

    const dir = "dist";

    const useNameWithHash = isProduction && !isDevServer;

    return {
        output: {
            filename: useNameWithHash ? "[name].[contenthash].js" : "[name].js",
            chunkFilename: useNameWithHash ? "[name].[contenthash].js" : "[name].js",
            path: path.resolve(__dirname, dir),
            publicPath: isDevServer ? "/" : dir + "/"
        }
    };
};
