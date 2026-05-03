// Example using axios
import axios from 'axios';

export const client = axios.create({
    baseURL: 'https://localhost:7257/',
    timeout: 5000,
});