import React from "react";

import { BrowserRouter as Router, Route, Switch } from "react-router-dom";

import MainPage from "src/pages/main";
import DeedPage from "src/pages/deed";
import NotFoundPage from "src/pages/not-found";

const Main: React.FC = () => (
  <Router>
    <Switch>
      <Route path="/" exact component={MainPage} />
      <Route path="/deed/:id" exact component={DeedPage} />
      <Route component={NotFoundPage} />
    </Switch>
  </Router>
);

export default Main;
