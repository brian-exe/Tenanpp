import Client from './Client';
const resource = '/inmobiliarias';
import config from '@/config';

const baseDomain = config.BASE_URL;

export default {
    // get() {
    //     return Client.get(`${resource}`);
    // },
    getById(id) {
        return Client.get(`${resource}/${id}`);
    },
    getPathForImages() {
        return baseDomain + resource + '/image/';
    },
    getEstadisticasFor(id) {
        return Client.get(`${resource}/estadisticas/${id}`);
    },
    // create(payload) {
    //     return Client.post(`${resource}`, payload);
    // },
    // update(payload, id) {
    //     return Client.put(`${resource}/${id}`, payload);
    // },
    // delete(id) {
    //     return Client.delete(`${resource}/${id}`)
    // },

    search(nombre) {
        return Client.get(`${resource}/buscar?nombre=${nombre}`);
    }
    // MANY OTHER ENDPOINT RELATED STUFFS
};
