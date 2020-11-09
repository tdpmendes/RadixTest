import axios from 'axios'

var apiEndpoint = 'https://localhost:32770/'

const axiosInstance = axios.create({
  baseURL: apiEndpoint,
  withCredentials: false,
  headers: {
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Allow-Methods': 'GET,PUT,POST,DELETE,PATCH,OPTIONS'
  }
})
export default ({ Vue }) => {
  Vue.prototype.$axios = axiosInstance
}
export { axiosInstance }
