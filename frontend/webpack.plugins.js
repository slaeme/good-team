const webpack = require("webpack");

const CleanWebpackPlugin = require("clean-webpack-plugin");
const ManifestPlugin = require("webpack-manifest-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const HtmlWebpackPlugin = require("html-webpack-plugin");
const FaviconsWebpackPlugin = require("favicons-webpack-plugin");

const context = require("./webpack.context").context;

const path = require("path");

module.exports = (env, argv) => {
  const { mode } = require("./webpack.mode")(env, argv);
  const isProduction = mode === "production";

  const isDevServer = env.DEV_SERVER || false;

  const plugins = [
    new MiniCssExtractPlugin({
      filename: isProduction ? "[name].[contenthash].css" : "[name].css",
      chunkFilename: isProduction ? "[id].[contenthash].css" : "[id].css"
    }),
    new webpack.ProvidePlugin({
      $: "jquery",
      jQuery: "jquery",
      "window.jQuery": "jquery"
    }),
    new ManifestPlugin(),
    new webpack.DefinePlugin({
      __STORE_VERSION__: +new Date()
    }),
    new webpack.EnvironmentPlugin({
      DEV_SERVER: isDevServer,
      NODE_ENV: mode
    })
  ];

  !isDevServer &&
    plugins.push(
      new CleanWebpackPlugin({
        verbose: false,
        cleanOnceBeforeBuildPatterns: [path.resolve(__dirname, "dist/**/*")]
      })
    );

  plugins.push(
    new HtmlWebpackPlugin({
      template: "index.template.html",
      xhtml: true
    })
  );

  plugins.push(new FaviconsWebpackPlugin(path.resolve(context, "favicon.png")));

  isDevServer && plugins.push(new webpack.HotModuleReplacementPlugin());

  return {
    plugins
  };
};
