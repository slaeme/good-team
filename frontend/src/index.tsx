import React from "react";
import ReactDOM from "react-dom";
import Layout from "./App";

import "core-js/stable";
import "regenerator-runtime/runtime";

import { hot } from "react-hot-loader";

if (process.env.DEV_SERVER) {
  const AppWithHot = hot(module)(Layout);

  ReactDOM.render(<AppWithHot />, document.getElementById("root"));
} else {
  ReactDOM.render(<Layout />, document.getElementById("root"));
}
