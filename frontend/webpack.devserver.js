module.exports = () => {
  return {
    devServer: {
      port: 3000,
      https: true,
      open: true,
      hot: true,
      historyApiFallback: true
    }
  };
};
