import Vue from 'vue'
import Vuex from 'vuex'

import authenticationStore from './modules/authenticationStore'
import clientStore from './modules/clientStore'
import administratorStore from './modules/administratorStore'
import accountStore from './modules/accountStore'
import dashboardStore from './modules/dashboardStore'


Vue.use(Vuex)

/*
 * If not building with SSR mode, you can
 * directly export the Store instantiation;
 *
 * The function below can be async too; either use
 * async/await or return a Promise which resolves
 * with the Store instance.
 */

export default function (/* { ssrContext } */) {
  const Store = new Vuex.Store({
    modules: {
      authenticationStore,
      clientStore,
      administratorStore,
      accountStore,
      dashboardStore
    },

    // enable strict mode (adds overhead!)
    // for dev mode only
    strict: process.env.DEV
  })

  return Store
}
