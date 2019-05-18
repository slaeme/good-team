const UglifyJsPlugin = require("uglifyjs-webpack-plugin");
const OptimizeCSSAssetsPlugin = require("optimize-css-assets-webpack-plugin");

module.exports = env => {
  return {
    optimization: {
      minimizer: [
        new UglifyJsPlugin({
          cache: true,
          parallel: true,
          uglifyOptions: {
            ecma: 6
          },
          sourceMap: true
        }),
        new OptimizeCSSAssetsPlugin({})
      ]
    }
  };
};
