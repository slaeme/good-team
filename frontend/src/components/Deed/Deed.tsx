import React from "react";
import "./Deed.less";

import { Card } from "antd";

import { Link } from "react-router-dom";

const Deed: React.FC = () => (
  <Card
    title="Помочь вынести старую мебель"
    extra={<Link to="/deed/1">Подробнее</Link>}
    type={"inner"}
    style={{ width: "100vw", maxWidth: 500 }}
  >
    <p>Card content</p>
  </Card>
);

export default Deed;
