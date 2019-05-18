const generateShortNames = require("./generate-short-css-classnames");
const generateFullNames = require("./generate-full-css-classnames");

const context = require("./webpack.context").context;
const contextLength = context.split("\\").length;

module.exports = isProduction => {
    return (localName, resourcePath) => {
        const componentName = resourcePath.split(/[\\.]+/).slice(contextLength).join("_");

        return isProduction
            ? generateShortNames(componentName, localName)
            : generateFullNames(componentName, localName);
    };
};
