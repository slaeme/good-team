import * as React from "react";
import "./Main.less";

import { Stores } from "src/stores";
import { inject, observer } from "mobx-react";

import DeedList from "src/components/DeedList";
import { Icon, Spin } from "antd";

interface Props {
  loading: boolean;
  error: boolean;
  deeds: any[];
  loadDeeds: () => any;
}

@inject(
  ({ deedsState }: Stores): Props => ({
    loading: deedsState.loading,
    error: deedsState.error,
    deeds: deedsState.deeds,
    loadDeeds: deedsState.loadDeeds
  })
)
@observer
class Main extends React.Component<Props> {
  componentDidMount() {
    this.props.loadDeeds();
  }

  render() {
    if (this.props.loading) {
      return (
        <div styleName="container">
          <Spin size="large" />
        </div>
      );
    }

    if (this.props.error) {
      return (
        <div styleName="container">
          <span styleName="icon">
            <Icon type="stop" />
          </span>{" "}
          <span>Ошибка</span>
        </div>
      );
    }

    return <DeedList />;
  }
}

export default Main;
