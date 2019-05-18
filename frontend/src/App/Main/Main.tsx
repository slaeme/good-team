import React from "react";

import { Route, Switch } from "react-router-dom";

import MainPage from "src/pages/main";
import MapPage from "src/pages/map";
import MyPage from "src/pages/my";
import DeedPage from "src/pages/deed";
import NotFoundPage from "src/pages/not-found";

const Main: React.FC = () => (
  <Switch>
      <Route path="/" exact component={MainPage} />
      <Route path="/map" exact component={MapPage} />
      <Route path="/my" component={MyPage} />
      <Route path="/deed/:id" exact component={DeedPage} />
    <Route component={NotFoundPage} />
  </Switch>
);

export default Main;
