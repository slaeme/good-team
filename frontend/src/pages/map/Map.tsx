import * as React from "react";
import "./Map.less";

import { uniqueId } from "lodash";

interface Props {}
interface State {
  error: boolean;
}

class Map extends React.Component<Props, State> {
  state = {
    error: false
  };

  mapId = uniqueId("map-");

  componentDidMount() {
    const script = document.createElement("script");
    script.src =
      "https://api-maps.yandex.ru/2.1/?apikey=445dfbf6-ab8e-41aa-9ed3-5295319b4689&lang=ru_RU";

    const head = document.getElementsByTagName("head")[0];
    head.appendChild(script);

    script.onload = async () => {
      try {
        // @ts-ignore
        await ymaps.ready();
      } catch (ex) {
        this.setState({ error: true });
      }

      // @ts-ignore
      new ymaps.Map(this.mapId, {
        center: [55.76, 37.64],
        zoom: 7,
        controls: ["geolocationControl", "fullscreenControl", "zoomControl"]
      });
    };

    script.onerror = () => {
      this.setState({ error: true });
    };
  }

  render() {
    if (this.state.error) {
      return <div styleName="error">Не удалось загрузить карту</div>;
    }

    return <div id={this.mapId} styleName="map" />;
  }
}

export default Map;
