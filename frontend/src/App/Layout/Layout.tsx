import React from "react";
import "./Layout.less";

import Main from "../Main";
import Menu from "../Menu";

import { BrowserRouter as Router } from "react-router-dom";
import { Avatar } from "antd";

const Layout: React.FC = () => (
  <Router>
    <div styleName="wrapper">
      <div styleName="layout">
        <header styleName="header">
          <div styleName="logo" />{" "}
          <span styleName="name">
            <span>Добрые дела</span>{" "}
            <span styleName="account">
              <Avatar shape="square" icon="user" />
            </span>
          </span>
        </header>
        <nav>
          <Menu />
        </nav>
        <main styleName="main">
          <Main />
        </main>
        <footer styleName="footer">by Good Team for Urbatron 2019</footer>
      </div>
    </div>
  </Router>
);

export default Layout;
