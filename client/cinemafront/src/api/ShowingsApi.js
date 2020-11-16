import http from "./http-common";

const getAll = () => {
  return http.get("/Showings");
};

const create = data => {
    return http.post("/Showings", data);
  };

const get = id => {
  return http.get(`/Showings/${id}`);
};

const update = (id, data) => {
  return http.post(`/Showings/${id}`, data);
};

const remove = id => {
  return http.delete(`/Showings/${id}`);
};

// eslint-disable-next-line
export default {
  getAll,
  create,
  get,
  update,
  remove
};