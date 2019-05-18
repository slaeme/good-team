import React from "react";
import "./Layout.less";
import DeedList from "src/components/DeedList";

const Layout: React.FC = () => (
  <div styleName="wrapper">
    <div styleName="layout">
      <header styleName="header">
        <div styleName="logo" /> <span styleName="name">Добрые дела</span>
      </header>
      <main styleName="main">
        <DeedList />
      </main>
      <footer styleName="footer">by Good Team for Urbatron 2019</footer>
    </div>
  </div>
);

export default Layout;
