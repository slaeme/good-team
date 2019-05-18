import DeedsStore from "./DeedsStore";

export interface Stores {
  deedsState: DeedsStore;
}

const stores: Stores = {
  deedsState: new DeedsStore()
};

export default stores;
