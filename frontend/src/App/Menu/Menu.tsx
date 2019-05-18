import * as React from "react";

import { Link, RouteComponentProps } from "react-router-dom";
import { Icon, Menu as AntdMenu } from "antd";

const Menu: React.FC<RouteComponentProps> = props => (
  <AntdMenu selectedKeys={[props.location.pathname]} mode="horizontal">
    <AntdMenu.Item key="/">
      <Link to={"/"}>
        <Icon type="unordered-list" />
        Список
      </Link>
    </AntdMenu.Item>
    <AntdMenu.Item key="/map">
      <Link to={"/map"}>
        <Icon type="compass" />
        Карта
      </Link>
    </AntdMenu.Item>
  </AntdMenu>
);

export default Menu;
