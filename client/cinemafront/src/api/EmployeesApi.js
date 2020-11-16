import http from "./http-common";

const getAll = () => {
  return http.get("/Admin");
};

const update = (id, data) => {
  return http.post(`/Admin/user`, data);
};

const remove = id => {
  return http.delete(`/Admin/user`);
};

// eslint-disable-next-line
export default {
  getAll,
  update,
  remove
};