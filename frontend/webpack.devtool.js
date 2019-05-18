module.exports = (env, argv) => {
    const { mode } = require("./webpack.mode")(env, argv);
    const isProduction = mode === "production";

    return {
        devtool: isProduction ? "hidden-source-map" : "eval"
    };
};
