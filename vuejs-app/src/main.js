import Vue from 'vue';
import App from './App.vue';
import router from './router';
import store from './store';
import vuetify from './plugins/vuetify';
import * as VueGoogleMaps from 'vue2-google-maps';

Vue.config.productionTip = false;

Vue.use(VueGoogleMaps, {
    load: {
        key: 'YOUR_API_KEY',
        libraries: 'places' // necessary for places input
    }
});

new Vue({
    router,
    store,
    vuetify,
    render: (h) => h(App)
}).$mount('#app');
