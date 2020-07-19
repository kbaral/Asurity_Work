import Vue from 'vue';
import Vuex from 'vuex';
import { apiService } from '@/services/ApiServices';
import { State } from '@/models/State';
import { DropDownOptions } from '@/models/DropDownOptions';

Vue.use(Vuex);

interface IState {
  statesDropDownOptions: Array<State>;
  dropDownOptions: DropDownOptions;
}

//defines app state
const state :IState = {
  statesDropDownOptions: [],
  dropDownOptions: new DropDownOptions({}),
};

//defines all the applications mutations here
const mutations = {
  getStates(state: IState, statesDropDownOptions: State[]) {
    state.statesDropDownOptions = statesDropDownOptions;
  },
  getConstants(state: IState, dropDownOptions: DropDownOptions) {
    state.dropDownOptions = dropDownOptions;
  },
};

//defines all the applications actions here
const actions = {
  getStates(context: { commit: (arg0: string, arg1: Array<State>) => void; state: IState}){
    if(context.state.statesDropDownOptions.length == 0)
    {
      apiService.getAllStates().then(states => {
        context.commit('getStates', states);
      });
    }
  },
  getConstants(context: { commit: (arg0: string, arg1: DropDownOptions) => void; state: IState}){
    
    if(context.state.dropDownOptions.ContactFreqOptions == undefined || context.state.dropDownOptions.ContactFreqOptions.length == 0)
    {
      apiService.getAllDropDownOptions().then(dropDownOptions => {
       
        context.commit('getConstants', dropDownOptions);
      });
    }
  },
};
const getters = {};

export default new Vuex.Store({
  state,
  mutations,
  actions,
  getters,
});
