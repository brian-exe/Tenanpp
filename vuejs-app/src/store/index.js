import Vue from 'vue';
import Vuex from 'vuex';
import InmobiliariaService from '@/services/InmobiliariasService';

Vue.use(Vuex);

export default new Vuex.Store({
    state: {
        loadingStatus: false,
        searchInmobiliariaResult: [],
        currentInmobiliaria: {}
    },
    mutations: {
        SET_LOADING_STATUS(state) {
            state.loadingStatus = true;
        },
        SET_NOT_LOADING_STATUS(state) {
            state.loadingStatus = false;
        },
        SET_SEARCH_INMOBILIARIA_RESULT(state, result) {
            state.searchInmobiliariaResult = result;
        },
        SET_CURRENT_INMOBILIARIA(state, result) {
            state.currentInmobiliaria = result;
        }
    },
    actions: {
        searchInmobiliaria(context, val) {
            context.commit('SET_LOADING_STATUS');
            InmobiliariaService.search(val)
                .then((res) => {
                    context.commit('SET_NOT_LOADING_STATUS');
                    context.commit(
                        'SET_SEARCH_INMOBILIARIA_RESULT',
                        res.data.data
                    );
                })
                .catch((e) => {
                    context.commit('SET_NOT_LOADING_STATUS');
                    console.log(e);
                });
        },
        getInmobiliaria(context, id) {
            context.commit('SET_LOADING_STATUS');
            InmobiliariaService.getById(id)
                .then((res) => {
                    context.commit('SET_NOT_LOADING_STATUS');
                    context.commit('SET_CURRENT_INMOBILIARIA', res.data.data);
                })
                .catch((e) => {
                    context.commit('SET_NOT_LOADING_STATUS');
                    console.log(e);
                });
        }
    },
    modules: {}
});
