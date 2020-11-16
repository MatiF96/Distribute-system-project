import http from "./http-common";

const create = data => {
    return http.post("/Reservations/complete", data);
  };

const remove = id => {
  return http.delete(`/Reservations/delete`);
};

// eslint-disable-next-line
export default {
  create,
  remove
};

