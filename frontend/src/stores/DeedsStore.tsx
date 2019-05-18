import { observable } from "mobx";

import { loadDeeds } from "src/services/deeds-service";

export default class DeedsStore {
  @observable
  loading: boolean = false;

  @observable
  error: boolean = false;

  @observable
  deeds: any[] = [];

  loadDeeds = async () => {
    this.loading = true;
    this.error = false;

    try {
      const { data } = await loadDeeds();

      this.deeds = data;
    } catch (ex) {
      this.error = true;
    } finally {
      this.loading = false;
    }
  };
}
