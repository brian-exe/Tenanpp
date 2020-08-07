import Client from './Client';
const resource = '/inmobiliarias';

export default {
    // get() {
    //     return Client.get(`${resource}`);
    // },
    getById(id) {
        return Client.get(`${resource}/${id}`);
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
