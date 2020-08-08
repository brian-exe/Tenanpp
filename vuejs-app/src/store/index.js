import Vue from 'vue';
import Vuex from 'vuex';
import InmobiliariaService from '@/services/InmobiliariasService';
import OpinionesService from '@/services/OpinionesService';

Vue.use(Vuex);

export default new Vuex.Store({
    state: {
        loadingStatus: false,
        searchInmobiliariaResult: [],
        currentInmobiliaria: {},
        currentInmobiliariaOpiniones: [],
        currentInmobiliariaEstadisticas: {},
        inmobiliariasRankings: {}
    },
    mutations: {
        SET_LOADING_STATUS(state) {
            state.loadingStatus = true;
        },
        SET_NOT_LOADING_STATUS(state) {
            state.loadingStatus = false;
        },
        SET_LOADING_OPINIONES(state) {
            state.loadingStatus = true;
        },
        SET_NOT_LOADING_OPINIONES(state) {
            state.loadingStatus = false;
        },
        SET_SEARCH_INMOBILIARIA_RESULT(state, result) {
            state.searchInmobiliariaResult = result;
        },
        SET_CURRENT_INMOBILIARIA(state, data) {
            state.currentInmobiliaria = data;
        },
        SET_CURRENT_INMOBILIARIA_ESTADISTICAS(state, data) {
            state.currentInmobiliariaEstadisticas = data;
        },
        SET_CURRENT_INMOBILIARIA_OPINIONES(state, data) {
            state.currentInmobiliariaOpiniones = data;
        },
        SET_INMOBILIARIAS_RANKINGS(state, data) {
            state.inmobiliariasRankings = data;
        }
    },
    getters: {
        getPathForInmobiliariasImages() {
            return InmobiliariaService.getPathForImages();
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
        },
        obtainOpinionesForInmobiliaria(context, id) {
            context.commit('SET_LOADING_OPINIONES');
            OpinionesService.getOpinionesForInmobiliaria(id)
                .then((res) => {
                    context.commit('SET_NOT_LOADING_OPINIONES');
                    context.commit(
                        'SET_CURRENT_INMOBILIARIA_OPINIONES',
                        res.data.data
                    );
                })
                .catch((e) => {
                    context.commit('SET_NOT_LOADING_OPINIONES');
                    console.log(e);
                });
        },
        obtainEstadisticasForInmobiliaria(context, id) {
            //context.commit('SET_LOADING_STATUS');
            InmobiliariaService.getEstadisticasFor(id)
                .then((res) => {
                    //context.commit('SET_NOT_LOADING_STATUS');
                    context.commit(
                        'SET_CURRENT_INMOBILIARIA_ESTADISTICAS',
                        res.data.data
                    );
                })
                .catch((e) => {
                    //context.commit('SET_NOT_LOADING_STATUS');
                    console.log(e);
                });
        },
        obtainInmobiliariasRankings(context) {
            //context.commit('SET_LOADING_STATUS');
            OpinionesService.getRankings()
                .then((res) => {
                    //context.commit('SET_NOT_LOADING_STATUS');
                    context.commit('SET_INMOBILIARIAS_RANKINGS', res.data.data);
                })
                .catch((e) => {
                    //context.commit('SET_NOT_LOADING_STATUS');
                    console.log(e);
                });
        }
    },
    modules: {}
});
