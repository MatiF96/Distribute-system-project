import http from "./http-common";

const getAll = () => {
  return http.get("/Movies");
};

const create = data => {
    return http.post("/Movies", data);
  };

const get = id => {
  return http.get(`/Movies/${id}`);
};

const update = (id, data) => {
  return http.post(`/Movies/${id}`, data);
};

const remove = id => {
  return http.delete(`/Movies/${id}`);
};

// eslint-disable-next-line
export default {
  getAll,
  create,
  get,
  update,
  remove
};