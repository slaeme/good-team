import * as React from "react";

import { Link, RouteComponentProps } from "react-router-dom";

const ToggleToMap: React.FC<RouteComponentProps> = props => (
  <Link to={props.location.pathname === "/map" ? "/" : "/map"}>
    {props.location.pathname === "/map" ? "Списком" : "На карте"}
  </Link>
);

export default ToggleToMap;
