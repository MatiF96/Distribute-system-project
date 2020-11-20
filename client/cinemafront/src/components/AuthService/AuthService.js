import axios from "axios";

const API_URL = "/api/Auth/";

export const login = async (username, password) => {
    const response = await axios
    .post(API_URL + "login", {
      username,
      password
    });
  if (response.data.username) {
    localStorage.setItem("user", JSON.stringify(response.data));
  }
  return response.data;
  }

export const logout = () => {
  localStorage.removeItem("user");
}

export const register = (username, password) => {
  return axios.post(API_URL + "register", {
    username,
    password
  });
}

export const getCurrentUser = () => {
  return JSON.parse(localStorage.getItem('user'));;
}

export const getUserRole = () => {
  const user = JSON.parse(localStorage.getItem('user'))
  return user?user.role:null;
}

export const getUserId = () => {
  const user = JSON.parse(localStorage.getItem('user'))
  return user?user.id:null;
}

// eslint-disable-next-line
export default {
  login,
  logout,
  register,
  getCurrentUser,
  getUserRole,
  getUserId
};
