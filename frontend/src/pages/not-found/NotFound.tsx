import React from "react";
import "./NotFound.less";

import { Icon } from "antd";

import { Link } from "react-router-dom";

const NotFound: React.FC = () => (
  <div styleName="root">
    <div styleName="icon">
      <Icon type="file-unknown" />
    </div>
    <div>
      <div>Страница не найдена</div>
      <div styleName="link">
        <Link to={"/"}>Начать с главной</Link>
      </div>
    </div>
  </div>
);

export default NotFound;
