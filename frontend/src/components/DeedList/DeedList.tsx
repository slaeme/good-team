import React from "react";
import "./DeedList.less";

import range from "lodash/range";
import Deed from "../Deed";

const DeedList: React.FC = () => (
  <div styleName="list">
    {range(5).map(i => (
      <Deed key={i} />
    ))}
  </div>
);

export default DeedList;
