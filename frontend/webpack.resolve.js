const path = require("path");

module.exports = {
    resolve: {
        extensions: [".js", ".jsx", ".tsx", ".ts", ".json"],
        modules: ["node_modules"],
        alias: {
            src: path.resolve(__dirname, "src")
        }
    }
};
