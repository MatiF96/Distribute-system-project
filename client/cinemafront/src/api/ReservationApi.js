import http from "./http-common";

const create = data => {
  return http.post("/Reservations", data);
};

const complete = data => {
    return http.post("/Reservations/complete", data);
  };

const remove = data => {
  return http.delete(`/Reservations/delete`, data);
};

// eslint-disable-next-line, 
export default {
  create,
  complete,
  remove
};

