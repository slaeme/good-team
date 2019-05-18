module.exports = () => {
  return {
    devServer: {
      port: 3000,
      https: true,
      open: true,
      hot: true,
      historyApiFallback: true,
      proxy: {
        "/api": "http://10.34.0.48:49778"
      }
    }
  };
};
