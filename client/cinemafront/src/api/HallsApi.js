import http from "./http-common";

const getAll = () => {
  return http.get("/Hales");
};

const create = data => {
    return http.post("/Hales", data);
  };

const get = id => {
  return http.get(`/Hales/${id}`);
};

const update = (id, data) => {
  return http.post(`/Hales/${id}`, data);
};

const remove = id => {
  return http.delete(`/Hales/${id}`);
};

// eslint-disable-next-line
export default {
  getAll,
  create,
  get,
  update,
  remove
};