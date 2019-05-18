import axios from "axios";

export const loadDeeds = () => axios.get<any[]>("api/deeds");
