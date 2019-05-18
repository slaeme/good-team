import React from "react";
import ReactDOM from "react-dom";
import App from "./App";

import "core-js/stable";
import "regenerator-runtime/runtime";

import { hot } from "react-hot-loader";

if (process.env.DEV_SERVER) {
  const AppWithHot = hot(module)(App);

  ReactDOM.render(<AppWithHot />, document.getElementById("root"));
} else {
  ReactDOM.render(<App />, document.getElementById("root"));
}
