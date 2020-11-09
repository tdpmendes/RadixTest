// import Vue from 'vue'
// import {uid, Notify} from 'quasar'
// import axios from 'axios'

const state = {
  events: {
    eventsBySensor: [
      {
        label: 'brasil.sudeste.sensor01',
        events: 800
      }
    ],
    eventsByRegion: [
      {
        label: 'brasil.sudeste',
        events: 800
      }
    ]
  }
}

const mutations = {
  apiReadEvents (state) {
    // a
  }
}

const actions = {
  apiReadEvents ({ commit }) {
    // a
  }
}

const getters = {
  events: (state) => {
    // axios.get('https://localhost:32770//report').then((response) => {
    //   state.events.eventsByRegion = response.eventsByRegion
    //   state.events.eventsBySensor = response.eventsBySensor
    //   return state.events
    // })
    return state.events
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
