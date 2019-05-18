import React from "react";
import ReactDOM from "react-dom";
import App from "./App";

import "core-js/stable";
import "regenerator-runtime/runtime";

import { hot } from "react-hot-loader";

import { Provider } from "mobx-react";

import stores from "src/stores";

const AppWithProvider = () => (
  <Provider {...stores}>
    <App />
  </Provider>
);

if (process.env.DEV_SERVER) {
  const AppWithHot = hot(module)(AppWithProvider);

  ReactDOM.render(<AppWithHot />, document.getElementById("root"));
} else {
  ReactDOM.render(<AppWithProvider />, document.getElementById("root"));
}
