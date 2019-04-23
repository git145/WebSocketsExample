import { IRootState } from "../store";

import { getStoreBuilder, BareActionContext } from "vuex-typex";

export interface IAdminState {
    name: string;
}

const initialAdminState: IAdminState = {
    name: ''
};

const a = getStoreBuilder<IRootState>().module("admin", initialAdminState);

// getters
const nameGetter = a.read(state => state.name, "name");

// mutations
function setName(state: IAdminState, name: string): void {
    state.name = name;
}

// action
async function initialiseAdmin(
    context: BareActionContext<IAdminState, IRootState>
) {
    admin.commitSetName(initialAdminState.name);
}

// state
const stateGetter: any = a.state();

// exported "admin" module interface
const admin: any = {
    // state
    get state(): IAdminState {
        return stateGetter();
    },

    // getters (wrapped as real getters)
    get name(): string {
        return nameGetter();
    },

    // mutations
    commitSetName: a.commit(setName),

    // actions
    dispatchInitialiseAdmin: a.dispatch(initialiseAdmin)
};

export default admin;