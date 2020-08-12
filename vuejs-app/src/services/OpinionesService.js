import Client from './Client';
const opinionesInmobiliarias = '/opiniones/inmobiliarias';

export default {
    getOpinionesForInmobiliaria(id) {
        return Client.get(`${opinionesInmobiliarias}/${id}`);
    },
    getRankings() {
        return Client.get(`${opinionesInmobiliarias}/rankings/`);
    },
    addOpinion(id, payload) {
        return Client.post(`${opinionesInmobiliarias}/${id}`, payload, {
            headers: { 'content-type': 'text/json' }
        });
    }
};
