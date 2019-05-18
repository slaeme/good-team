const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const path = require("path");
const context = require("./webpack.context");

const autoprefixer = require("autoprefixer");

module.exports = (env, argv) => {
  const { mode } = require("./webpack.mode")(env, argv);
  const isProduction = mode === "production";

  const generateScopedName = require("./generate-css-classnames")(isProduction);

  return {
    module: {
      rules: [
        {
          test: /\.html$/,
          use: "raw-loader"
        },
        {
          test: [/\.ts$/, /\.tsx$/],
          include: context.context,
          loader: "babel-loader",
          options: {
            configFile: path.resolve(__dirname, "babel.config.js")
          }
        },
        {
          test: [/\.less$/, /\.css$/],
          use: [
            isProduction
              ? {
                  loader: MiniCssExtractPlugin.loader,
                  options: { publicPath: "./" }
                }
              : "style-loader",
            {
              loader: "css-loader",
              options: {
                modules: "global"
              }
            },
            {
              loader: "less-loader",
              options: {
                javascriptEnabled: true
              }
            }
          ],
          include: [/antd/]
        },
        {
          test: [/\.less$/, /\.css$/],
          use: [
            isProduction
              ? {
                  loader: MiniCssExtractPlugin.loader,
                  options: { publicPath: "./" }
                }
              : "style-loader",
            {
              loader: "css-loader",
              options: {
                camelCase: true,
                getLocalIdent: (context, localIdentName, localName) => {
                  return generateScopedName(localName, context.resourcePath);
                },
                importLoaders: 2,
                modules: true
              }
            },
            {
              loader: "postcss-loader",
              options: {
                plugins: [
                  autoprefixer({
                    browsers: ["ie >= 11", "last 4 version"]
                  })
                ]
              }
            },
            {
              loader: "less-loader",
              options: {
                paths: [
                  path.resolve(__dirname),
                  path.resolve(__dirname, "node_modules")
                ]
              }
            }
          ],
          exclude: [/antd/],
          include: context.context
        },
        {
          test: /\.(woff|woff2|eot)$/,
          use: "file-loader"
        },
        {
          test: /\.(jpeg|png|gif|svg)$/i,
          exclude: /icons/,
          loader: "url-loader"
        },
        {
          test: /\.svg$/i,
          include: /icons/,
          exclude: /node_modules/,
          use: "svg-react-loader"
        }
      ]
    }
  };
};
