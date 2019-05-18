import React from "react";
import "./Deed.less";

import { Card } from "antd";

const Deed: React.FC = () => (
  <Card
    title="Помочь вынести старую мебель"
    extra={<a href="#">Подробнее</a>}
    type={"inner"}
    style={{ width: "100vw", maxWidth: 500 }}
  >
    <p>Card content</p>
  </Card>
);

export default Deed;
