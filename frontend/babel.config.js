const generateScopedName = require("./generate-css-classnames");
const context = require("./webpack.context").context;

const presetEnvOptions = {
  modules: false,
  loose: true,
  corejs: 3,
  useBuiltIns: "entry",
  targets: {
    browsers: [
      "Chrome >= 60",
      "Safari >= 10",
      "iOS >= 10",
      "Firefox >= 54",
      "Edge >= 15",
      "Opera >= 55"
    ]
  }
};

module.exports = function(api) {
  api.cache.using(() => process.env.NODE_ENV);

  const isProduction = api.env("production");

  return {
    presets: [
      ["@babel/preset-env", presetEnvOptions],
      "@babel/preset-typescript",
      "@babel/preset-react"
    ],
    env: {
      development: {
        plugins: ["react-hot-loader/babel"]
      },
      production: {
        plugins: [
          "@babel/transform-react-constant-elements",
          "@babel/transform-react-inline-elements",
          "transform-react-remove-prop-types",
          "transform-react-pure-class-to-function"
        ]
      }
    },
    plugins: [
      [
        "@babel/plugin-proposal-decorators",
        {
          legacy: true
        }
      ],
      ["@babel/plugin-proposal-class-properties", { loose: true }],
      "@babel/plugin-proposal-object-rest-spread",
      "@babel/plugin-proposal-optional-chaining",
      "@babel/plugin-proposal-nullish-coalescing-operator",
      [
        "babel-plugin-import",
        {
          libraryName: "lodash",
          libraryDirectory: "",
          camel2DashComponentName: false // default: true
        },
        "lodash"
      ],
      [
        "babel-plugin-import",
        {
          libraryName: "antd",
          style: true
        },
        "antd"
      ],
      [
        "babel-plugin-react-css-modules",
        {
          context,
          generateScopedName: generateScopedName(isProduction),
          handleMissingStyleName: "throw",
          filetypes: {
            ".less": {
              syntax: "postcss-less"
            }
          }
        }
      ]
    ]
  };
};
