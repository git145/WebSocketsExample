import Vue from 'vue';
import Vuex, { Store } from 'vuex';

import "./admin/admin";

import { getStoreBuilder } from 'vuex-typex';

import { IAdminState } from "./admin/admin";

export interface IRootState {
    admin: IAdminState;
}

Vue.use(Vuex);

const store: Store<IRootState> = getStoreBuilder<IRootState>().vuexStore();

export default store; // <-- "store" to provide to root Vue
