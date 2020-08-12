import Client from './Client';
const lugares = '/lugares';

export default {
    getOpinionesFor(payload) {
        return Client.post(`${lugares}/opiniones`, payload, {
            headers: { 'content-type': 'application/json' }
        });
    },
    addOpinion(payload) {
        return Client.post(`${lugares}/`, payload, {
            headers: { 'content-type': 'text/json' }
        });
    },
    getLugaresCercanos(payload) {
        return Client.post(`${lugares}/cerca/`, payload, {
            headers: { 'content-type': 'text/json' }
        });
    }
};
