import axios from "axios";
import queryString from "query-string";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import toast  from 'react-hot-toast';
const axiosClient = axios.create({
  baseURL: process.env.REACT_APP_BASE_GATEWAY,
  headers: {
    "content-type": "application/json",
    "device-type": "Browser",
  },
  paramsSerializer: (params) => queryString.stringify(params),
});

axiosClient.interceptors.request.use(async (config) => {
  //Xử lý liên quan đến token ở đây
  return config;
});

axiosClient.interceptors.response.use(
  (response) => {
    if (response.status !== 200) {
      if(response.status === 400){
        toast.error("Không thành công", {duration: 2000});
      }
      if(response.status === 401){
        toast.error("Thông tin tài khoản không hợp lệ", {duration: 2000});
      }
    } else {
      if (response && response.data) {
        // toast.success("Thành công", {duration: 2000});
        return response.data;
      }
      return response;
    }
  },
  (error) => {
    console.log(error.response);
    if(error.response.status === 401){
      toast.error("Thông tin tài khoản không hợp lệ", {duration: 2000});
    }else{
      toast.error("Lỗi", {duration: 2000});
    }
    throw error;
  }
);

export default axiosClient;
