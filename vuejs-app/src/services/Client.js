import axios from 'axios';

const baseDomain = 'https://192.168.0.14:5800/api';
const baseURL = `${baseDomain}`; // Incase of /api/v1;

// ALL DEFUALT CONFIGURATION HERE

export default axios.create({
    baseURL,
    headers: {
        // "Authorization": "Bearer xxxxx"
    }
});
