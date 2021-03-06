import Vue from 'vue';
import VueRouter from 'vue-router';
import InmobiliariasHome from '@/views/InmobiliariasHome.vue';
import InmobiliariaDetail from '@/views/InmobiliariaDetail.vue';
import Lugares from '../views/Lugares.vue';
import AddOpinion from '../views/AddOpinion.vue';
import NotFound from '@/views/NotFound.vue';

Vue.use(VueRouter);

const routes = [
    {
        path: '/',
        redirect: '/inmobiliarias'
    },
    {
        path: '/about',
        name: 'About',
        // route level code-splitting
        // this generates a separate chunk (about.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import(/* webpackChunkName: "about" */ '../views/About.vue')
    },
    {
        path: '/inmobiliarias',
        name: 'Inmobiliarias',
        component: InmobiliariasHome
    },
    {
        path: '/inmobiliarias/:id',
        name: 'InmobiliariaDetail',
        component: InmobiliariaDetail,
        props: true
    },
    {
        path: '/lugares',
        name: 'Lugares',
        component: Lugares
    },
    {
        path: '/inmobiliarias/agregar-opinion/:id',
        name: 'AddOpinion',
        component: AddOpinion,
        props: true
    },
    {
        path: '/not-found',
        name: 'NotFound',
        component: NotFound
    },
    {
        path: '*',
        redirect: '/not-found'
    }
];

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
});

export default router;
